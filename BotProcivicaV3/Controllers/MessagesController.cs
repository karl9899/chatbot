using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac;
//using BotProcivicaV3.Translator;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Connector;
using BotProcivicaV3.Translator;
using RestSharp;
using static BotProcivicaV3.Translator.IdentifyLanguage;
using AutoMapper;
//using BotProcivicaV3.Utilities;

namespace BotProcivicaV3
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {

        public string converstationText = "";
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {

            IdentifyLanguage();
            #region Set CurrentBaseURL and ChannelAccount
            // Get the base URL that this service is running at
            // This is used to show images
            string CurrentBaseURL =
                    this.Url.Request.RequestUri.AbsoluteUri.Replace(@"api/messages", "");

            // Create an instance of BotData to store data
            BotData objBotData = new BotData();

            // Instantiate a StateClient to save BotData            
            StateClient stateClient = activity.GetStateClient();

            // Use stateClient to get current userData
            BotData userData = await stateClient.BotState.GetUserDataAsync(
                activity.ChannelId, activity.From.Id);

            // Update userData by setting CurrentBaseURL and Recipient
            userData.SetProperty<string>("CurrentBaseURL", CurrentBaseURL);

            // Save changes to userData
            await stateClient.BotState.SetUserDataAsync(
                activity.ChannelId, activity.From.Id, userData);


            #endregion
            
            if (activity.Type == ActivityTypes.Message)
            {
                IMessageActivity mensaje = activity.AsMessageActivity();

                Activity msj = (Activity)mensaje;
                msj.Recipient = msj.Recipient;
                msj.Type = "Message";


                ConnectionDB.Chatbot_PGBEntities1 DBTop = new ConnectionDB.Chatbot_PGBEntities1();
                ConnectionDB.UserLogin NewUserLogTop = new ConnectionDB.UserLogin();
                NewUserLogTop.Channel = msj.ChannelId;
                NewUserLogTop.UserID = msj.From.Id;
                NewUserLogTop.UserName = msj.From.Name;
                NewUserLogTop.Created = DateTime.UtcNow;
                NewUserLogTop.Message = msj.Text;
                DBTop.UserLogins.Add(NewUserLogTop);
                DBTop.SaveChanges();
                //DBTop.Dispose();

                if (activity.Text.Contains("CANCELAR")|| activity.Text.Contains("CANCEL"))
                {
                    IdentifyLanguage();
                    ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                    string response1 = ChatResponse.Cancel;
                    string response2 = ChatResponse.Step5Else;
                    Activity reply = activity.CreateReply(response1);
                    Activity reply2 = activity.CreateReply(response2);
                    await connector.Conversations.ReplyToActivityAsync(reply);
                    await connector.Conversations.ReplyToActivityAsync(reply2);
                    //Reinicia la conversación
                    activity.GetStateClient().BotState.DeleteStateForUser(activity.ChannelId, activity.From.Id);

                   
                }
                //else
                //{
                //    if (activity.Text.Contains("Adiós") || activity.Text.Contains("Adios"))
                //    {
                //        ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                //        string response1 = ChatResponse.Goodbye;
                //        //string response2 = ChatResponse.Step5Else;
                //        Activity reply = activity.CreateReply(response1);
                //        //Activity reply2 = activity.CreateReply(response2);
                //        await connector.Conversations.ReplyToActivityAsync(reply);
                //        //await connector.Conversations.ReplyToActivityAsync(reply2);
                //        //Reinicia la conversación
                //        activity.GetStateClient().BotState.DeleteStateForUser(activity.ChannelId, activity.From.Id);
                //    }
                //}
                else
                {
                    activity.Text = TranslatorHandler.DetectAndTranslate(activity);
                    await Conversation.SendAsync(activity, MakeRoot);
                }
            }
            else
            {
                await HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        internal static IDialog<object> MakeRoot()
        {
            try
            {

                return Chain.From(() => new ChatDialog());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private async Task<Activity> HandleSystemMessage(Activity message)
        {


            

            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                IConversationUpdateActivity conversationupdate = message;
                using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, message))
                {
                    var client = scope.Resolve<IConnectorClient>();
                    if (conversationupdate.MembersAdded.Any())
                    {
                        
                        var reply = message.CreateReply();
                        

                        foreach (var newMember in conversationupdate.MembersAdded)
                        {
                            if (newMember.Id != message.Recipient.Id)
                            {
                                reply.Text = "¡Hola!";

                                ConnectionDB.Chatbot_PGBEntities1 DBTop = new ConnectionDB.Chatbot_PGBEntities1();
                                ConnectionDB.UserLogin NewUserLogTop = new ConnectionDB.UserLogin();
                                NewUserLogTop.Channel = message.ChannelId;
                                NewUserLogTop.UserID = message.From.Id;
                                NewUserLogTop.UserName = message.From.Name;
                                NewUserLogTop.Created = DateTime.UtcNow;
                                NewUserLogTop.Message = "Inicia nueva conversación --> "+reply.Text;
                                DBTop.UserLogins.Add(NewUserLogTop);
                                DBTop.SaveChanges();
                                DBTop.Dispose();

                                await client.Conversations.ReplyToActivityAsync(reply);
                            }
                        }
                    }
                }





            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }

        #region IdentifyLanguage
        private void IdentifyLanguage()
        {

            var client = new RestClient("https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/languages");
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "0d04c0e2-d501-6191-3dc8-dde26b1c9bf2");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("ocp-apim-subscription-key", "555766c30cd84c9f8ea32ba077eaede3");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\r\n  \"documents\": [\r\n    {\r\n      \"id\": \"1\",\r\n      \"text\": \"" + TranslatorHandler.conversationText + "\"\r\n    }\r\n  ]\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Response r = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(content);

            if (r.documents.Count() > 0 && r.documents[0].detectedLanguages.Count() > 0)
            {
                TranslatorHandler.isoName = r.documents[0].detectedLanguages[0].iso6391Name;

            }

        }
        #endregion
    }

}