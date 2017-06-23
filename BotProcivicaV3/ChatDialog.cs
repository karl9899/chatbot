using System;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis.Models;
using RestSharp;
using BotProcivicaV3.Translator;
using static BotProcivicaV3.Translator.IdentifyLanguage;
using System.Linq;
using BotProcivicaV3.Dialogs;
using System.IO;
using Microsoft.Bot.Builder.FormFlow;

namespace BotProcivicaV3
{
    [Serializable]
    [LuisModel("62768a68-711f-4071-90e7-90c965a7f1ef", "1470d989404a4e11bc49fd0694ad5b88")]

    public class ChatDialog : LuisDialog<object>
    {

        public ChatDialog(params ILuisService[] services) : base(services)
        {
        }

        //AQUI VAN TODAS LAS ENTIDADES DADAS DE ALTA EN LUIS
        [LuisIntent("None")]
        [LuisIntent("")]
        public async Task None(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            IdentifyLanguage();
            Activity replyToConversation = (Activity)context.MakeMessage();
            replyToConversation.Recipient = replyToConversation.Recipient;
            replyToConversation.Type = "Message";
            try
            {
                var response = ChatResponse.Default;

                ConnectionDB.Chatbot_PGBEntities1 DBot = new ConnectionDB.Chatbot_PGBEntities1();
                ConnectionDB.UserLogin NewUserLogBot = new ConnectionDB.UserLogin();
                NewUserLogBot.Channel = replyToConversation.ChannelId;
                NewUserLogBot.UserID = replyToConversation.From.Id;
                NewUserLogBot.UserName = replyToConversation.From.Name;
                NewUserLogBot.Created = DateTime.UtcNow;
                NewUserLogBot.Message = response;
                DBot.UserLogins.Add(NewUserLogBot);
                DBot.SaveChanges();

                await context.PostAsync(response);

                context.Wait(MessageReceived);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        [LuisIntent("Saludo")]
        public async Task Greet(IDialogContext context, LuisResult result)
        {
            IdentifyLanguage();

            Activity replyToConversation = (Activity)context.MakeMessage();
            replyToConversation.Recipient = replyToConversation.Recipient;
            replyToConversation.Type = "Message";

            try
            {
                

                IdentifyLanguage();
                var response = ChatResponse.Greeting;

                ConnectionDB.Chatbot_PGBEntities1 DBot = new ConnectionDB.Chatbot_PGBEntities1();
                ConnectionDB.UserLogin NewUserLogBot = new ConnectionDB.UserLogin();
                NewUserLogBot.Channel = replyToConversation.ChannelId;
                NewUserLogBot.UserID = replyToConversation.From.Id;
                NewUserLogBot.UserName = replyToConversation.From.Name;
                NewUserLogBot.Created = DateTime.UtcNow;
                NewUserLogBot.Message = response;
                DBot.UserLogins.Add(NewUserLogBot);
                DBot.SaveChanges();
                DBot.Dispose();

                await context.PostAsync(response);

                context.Wait(MessageReceived);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        [LuisIntent("Despedida")]
        public async Task Goodbye(IDialogContext context, LuisResult result)
        {
            IdentifyLanguage();
            Activity replyToConversation = (Activity)context.MakeMessage();
            replyToConversation.Recipient = replyToConversation.Recipient;
            replyToConversation.Type = "Message";
            try
            {
                var response = ChatResponse.Goodbye;

                ConnectionDB.Chatbot_PGBEntities1 DBot = new ConnectionDB.Chatbot_PGBEntities1();
                ConnectionDB.UserLogin NewUserLogBot = new ConnectionDB.UserLogin();
                NewUserLogBot.Channel = replyToConversation.ChannelId;
                NewUserLogBot.UserID = replyToConversation.From.Id;
                NewUserLogBot.UserName = replyToConversation.From.Name;
                NewUserLogBot.Created = DateTime.UtcNow;
                NewUserLogBot.Message = response;
                DBot.UserLogins.Add(NewUserLogBot);
                DBot.SaveChanges();

                await context.PostAsync(response);
                //await context.PostAsync("El lenguaje es: " + TranslatorHandler.isoName);

                context.Wait(MessageReceived);
                
            }
            catch (Exception exc)
            {
               // await context.PostAsync("El error es: " + exc);
                throw exc;
            }
        }
        [LuisIntent("Groserías")]
        public async Task SwearWord(IDialogContext context, LuisResult result)
        {
            IdentifyLanguage();

            Activity replyToConversation = (Activity)context.MakeMessage();
            replyToConversation.Recipient = replyToConversation.Recipient;
            replyToConversation.Type = "Message";
            try
            {

                var response = ChatResponse.SwearWord;

                ConnectionDB.Chatbot_PGBEntities1 DBot = new ConnectionDB.Chatbot_PGBEntities1();
                ConnectionDB.UserLogin NewUserLogBot = new ConnectionDB.UserLogin();
                NewUserLogBot.Channel = replyToConversation.ChannelId;
                NewUserLogBot.UserID = replyToConversation.From.Id;
                NewUserLogBot.UserName = replyToConversation.From.Name;
                NewUserLogBot.Created = DateTime.UtcNow;
                NewUserLogBot.Message = response;
                DBot.UserLogins.Add(NewUserLogBot);
                DBot.SaveChanges();

                await context.PostAsync(response);
                context.Wait(MessageReceived);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        [LuisIntent("Identidad")]
        public async Task Identity(IDialogContext context, LuisResult result)
        {
            IdentifyLanguage();
            Activity replyToConversation = (Activity)context.MakeMessage();
            replyToConversation.Recipient = replyToConversation.Recipient;
            replyToConversation.Type = "Message";
            try
            {
                
                var response = ChatResponse.Identity;

                ConnectionDB.Chatbot_PGBEntities1 DBot = new ConnectionDB.Chatbot_PGBEntities1();
                ConnectionDB.UserLogin NewUserLogBot = new ConnectionDB.UserLogin();
                NewUserLogBot.Channel = replyToConversation.ChannelId;
                NewUserLogBot.UserID = replyToConversation.From.Id;
                NewUserLogBot.UserName = replyToConversation.From.Name;
                NewUserLogBot.Created = DateTime.UtcNow;
                NewUserLogBot.Message = response;
                DBot.UserLogins.Add(NewUserLogBot);
                DBot.SaveChanges();

                await context.PostAsync(response);
                context.Wait(MessageReceived);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        [LuisIntent("SinSentido")]
        public async Task Unsense(IDialogContext context, LuisResult result)
        {
            IdentifyLanguage();
            Activity replyToConversation = (Activity)context.MakeMessage();
            replyToConversation.Recipient = replyToConversation.Recipient;
            replyToConversation.Type = "Message";
            try
            {
             
                var response = ChatResponse.Unsense;

                ConnectionDB.Chatbot_PGBEntities1 DBot = new ConnectionDB.Chatbot_PGBEntities1();
                ConnectionDB.UserLogin NewUserLogBot = new ConnectionDB.UserLogin();
                NewUserLogBot.Channel = replyToConversation.ChannelId;
                NewUserLogBot.UserID = replyToConversation.From.Id;
                NewUserLogBot.UserName = replyToConversation.From.Name;
                NewUserLogBot.Created = DateTime.UtcNow;
                NewUserLogBot.Message = response;
                DBot.UserLogins.Add(NewUserLogBot);
                DBot.SaveChanges();

                await context.PostAsync(response);
                context.Wait(MessageReceived);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        [LuisIntent("Denuncia")]
        public async Task Denunciation(IDialogContext context, LuisResult result)
        {
            IdentifyLanguage();
            Activity replyToConversation = (Activity)context.MakeMessage();
            replyToConversation.Recipient = replyToConversation.Recipient;
            replyToConversation.Type = "Message";
            try
            {          
                var denunciation = ChatResponse.DenunciationGreet;

                ConnectionDB.Chatbot_PGBEntities1 DBot = new ConnectionDB.Chatbot_PGBEntities1();
                ConnectionDB.UserLogin NewUserLogBot = new ConnectionDB.UserLogin();
                NewUserLogBot.Channel = replyToConversation.ChannelId;
                NewUserLogBot.UserID = replyToConversation.From.Id;
                NewUserLogBot.UserName = replyToConversation.From.Name;
                NewUserLogBot.Created = DateTime.UtcNow;
                NewUserLogBot.Message = denunciation;
                DBot.UserLogins.Add(NewUserLogBot);
                DBot.SaveChanges();

                await context.PostAsync(denunciation);
                var denunciationForm = new FormDialog<DenunciationForm>(new DenunciationForm(), DenunciationForm.BuildForm, FormOptions.PromptInStart);
                context.Call(denunciationForm, DenunciationFormComplete);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        [LuisIntent("Sugerencia")]
        public async Task Suggestion(IDialogContext context, LuisResult result)
        {
            IdentifyLanguage();

            Activity replyToConversation = (Activity)context.MakeMessage();
            replyToConversation.Recipient = replyToConversation.Recipient;
            replyToConversation.Type = "Message";

            try
            {
                var suggestion = ChatResponse.SuggestionGreet;
                var ifcancel = ChatResponse.IfCancel;

                await context.PostAsync(suggestion+"\n\n"+ifcancel);
                ConnectionDB.Chatbot_PGBEntities1 DBot = new ConnectionDB.Chatbot_PGBEntities1();
                ConnectionDB.UserLogin NewUserLogBot = new ConnectionDB.UserLogin();
                NewUserLogBot.Channel = replyToConversation.ChannelId;
                NewUserLogBot.UserID = replyToConversation.From.Id;
                NewUserLogBot.UserName = replyToConversation.From.Name;
                NewUserLogBot.Created = DateTime.UtcNow;
                NewUserLogBot.Message = suggestion +" "+ ifcancel;
                DBot.UserLogins.Add(NewUserLogBot);
                DBot.SaveChanges();
                DBot.Dispose();

                var suggestionForm = new FormDialog<SuggestionForm>(new SuggestionForm(), SuggestionForm.BuildForm, FormOptions.PromptInStart);
                context.Call(suggestionForm, SuggestionFormComplete);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        [LuisIntent("Queja")]
        public async Task Complaint(IDialogContext context, LuisResult result)
        {
            Activity replyToConversation = (Activity)context.MakeMessage();
            replyToConversation.Recipient = replyToConversation.Recipient;
            replyToConversation.Type = "Message";
            try
            {
                IdentifyLanguage();
                var complaint = ChatResponse.ComplaintGreet;

                ConnectionDB.Chatbot_PGBEntities1 DBot = new ConnectionDB.Chatbot_PGBEntities1();
                ConnectionDB.UserLogin NewUserLogBot = new ConnectionDB.UserLogin();
                NewUserLogBot.Channel = replyToConversation.ChannelId;
                NewUserLogBot.UserID = replyToConversation.From.Id;
                NewUserLogBot.UserName = replyToConversation.From.Name;
                NewUserLogBot.Created = DateTime.UtcNow;
                NewUserLogBot.Message = complaint;
                DBot.UserLogins.Add(NewUserLogBot);
                DBot.SaveChanges();

                await context.PostAsync(complaint);
                var complaintForm = new FormDialog<ComplaintForm>(new ComplaintForm(), ComplaintForm.BuildForm, FormOptions.PromptInStart);
                context.Call(complaintForm, ComplaintFormComplete);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        [LuisIntent("SolicitudInformación")]
        public async Task InformationR(IDialogContext context, LuisResult result)
        {
            
            Activity replyToConversation = (Activity)context.MakeMessage();
            replyToConversation.Recipient = replyToConversation.Recipient;
            replyToConversation.Type = "Message";

            try
            {
                IdentifyLanguage();
                var request = ChatResponse.InformationRGreet;

                ConnectionDB.Chatbot_PGBEntities1 DBot = new ConnectionDB.Chatbot_PGBEntities1();
                ConnectionDB.UserLogin NewUserLogBot = new ConnectionDB.UserLogin();
                NewUserLogBot.Channel = replyToConversation.ChannelId;
                NewUserLogBot.UserID = replyToConversation.From.Id;
                NewUserLogBot.UserName = replyToConversation.From.Name;
                NewUserLogBot.Created = DateTime.UtcNow;
                NewUserLogBot.Message = request;
                DBot.UserLogins.Add(NewUserLogBot);
                DBot.SaveChanges();

                await context.PostAsync(request);
                var informationrForm = new FormDialog<InformationRForm>(new InformationRForm(), InformationRForm.BuildForm, FormOptions.PromptInStart);
                context.Call(informationrForm, InformationRFormComplete);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        [LuisIntent("Estatus")]
        public async Task ConsultStatus(IDialogContext context, LuisResult result)
        {
            IdentifyLanguage();
            Activity replyToConversation = (Activity)context.MakeMessage();
            replyToConversation.Recipient = replyToConversation.Recipient;
            replyToConversation.Type = "Message";
            try
            {
                ConnectionDB.Chatbot_PGBEntities1 DBot = new ConnectionDB.Chatbot_PGBEntities1();
                ConnectionDB.UserLogin NewUserLogBot = new ConnectionDB.UserLogin();
                NewUserLogBot.Channel = replyToConversation.ChannelId;
                NewUserLogBot.UserID = replyToConversation.From.Id;
                NewUserLogBot.UserName = replyToConversation.From.Name;
                NewUserLogBot.Created = DateTime.UtcNow;
                NewUserLogBot.Message = replyToConversation.Text;
                DBot.UserLogins.Add(NewUserLogBot);
                DBot.SaveChanges();
                
                var denunciationD = new FormDialog<FormStatus>(new FormStatus(), FormStatus.BuildForm, FormOptions.PromptInStart);
                context.Call(denunciationD, FormStatusComplete);
            }
            catch (Exception)
            {
                var error = ChatResponse.Error;
                await context.PostAsync(error);
                context.Wait(MessageReceived);
            }
        }

        #region IdentifyLanguage
        private void IdentifyLanguage()
        {

            var client = new RestClient("https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/languages");
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("ocp-apim-subscription-key", "");
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

        //Aqui se ejecutan los formularios para extraer la informacion que se necesite acorde a la denuncia
        #region FormDenunciation
        public async Task DenunciationFormComplete(IDialogContext context, IAwaitable<DenunciationForm> result)
        {
            try
            {
                var denunciation = await result;

                int idtipocaso = 2; //Tipo de caso: denuncia
                int idstatus = 1; //Estado: No revisado
                string folio;
                int idciudadano = 1;
                var fecha = DateTime.UtcNow;

                //Creación de folio
                folio = denunciation.Name.Substring(0, 2).ToUpper() + idciudadano + "_" + idtipocaso;

                //****Log to DataBase****
                ConnectionDB.Chatbot_PGBEntities DB = new ConnectionDB.Chatbot_PGBEntities();
                ConnectionDB.Casos NewCaso = new ConnectionDB.Casos();
                NewCaso.idtipocaso = idtipocaso;
                NewCaso.idstatus = idstatus;
                NewCaso.folio = folio;
                NewCaso.idciudadano = idciudadano;
                NewCaso.nombre = denunciation.Name;
                NewCaso.email = denunciation.Contact;
                NewCaso.descripcion = denunciation.Denunciation;
                NewCaso.nombre_funcionario = denunciation.Functionary;
                NewCaso.nombre_dependencia = denunciation.Dependency;
                NewCaso.fecha_registro = DateTime.UtcNow;
                DB.Casos.Add(NewCaso);
                DB.SaveChanges();

                await context.PostAsync(ChatResponse.Thanks);
                await context.PostAsync(ChatResponse.Checkid + "Folio: " + folio);
                await context.PostAsync(ChatResponse.Status);
                await context.PostAsync(ChatResponse.Step5Else);
            }
            catch (FormCanceledException)
            {
                await context.PostAsync(ChatResponse.formCanceled);
            }
            catch (Exception)
            {

                await context.PostAsync(ChatResponse.Error);
            }

            finally
            {
                context.Wait(MessageReceived);
            }
        }
        //private async Task DenunciationFormStatusComplete(IDialogContext context, IAwaitable<DenunciationFormStatus> result)
        //{
        //}
        #endregion

        #region FormSuggestion
        public async Task SuggestionFormComplete(IDialogContext context, IAwaitable<SuggestionForm> result)
        {
            IdentifyLanguage();
            Activity replyToConversation = (Activity)context.MakeMessage();
            replyToConversation.Recipient = replyToConversation.Recipient;
            replyToConversation.Type = "Message";

            try
           {
                var suggestion = await result;
                
                int idtipocaso = 1; //Tipo de caso: sugerencia
                int idstatus = 1; //Estado: No revisado
                string folio;
                int idciudadano = 1;
                var fecha = DateTime.UtcNow;

                //Creación de folio
                folio = suggestion.Name.Substring(0, 2).ToUpper() + idciudadano + "_" + idtipocaso;

                //****Log to DataBase****
                ConnectionDB.Chatbot_PGBEntities DB = new ConnectionDB.Chatbot_PGBEntities();
                ConnectionDB.Casos NewCaso = new ConnectionDB.Casos();
                NewCaso.idtipocaso = idtipocaso;
                NewCaso.idstatus = idstatus;
                NewCaso.folio = folio;
                NewCaso.idciudadano = idciudadano;
                NewCaso.nombre = suggestion.Name;
                NewCaso.email = suggestion.Contact;
                NewCaso.descripcion = suggestion.Suggestion;
                NewCaso.fecha_registro = DateTime.UtcNow;
                DB.Casos.Add(NewCaso);
                DB.SaveChanges();
                DB.Dispose();

                ConnectionDB.Chatbot_PGBEntities1 DBot = new ConnectionDB.Chatbot_PGBEntities1();
                ConnectionDB.UserLogin NewUserLogBot = new ConnectionDB.UserLogin();
                NewUserLogBot.Channel = replyToConversation.ChannelId;
                NewUserLogBot.UserID = replyToConversation.From.Id;
                NewUserLogBot.UserName = replyToConversation.From.Name;
                NewUserLogBot.Created = DateTime.UtcNow;
                NewUserLogBot.Message = ChatResponse.Thanks+" "+ ChatResponse.Checkid + " Folio: " + folio + " " + ChatResponse.Status +" "+ ChatResponse.Step5Else;
                DBot.UserLogins.Add(NewUserLogBot);
                DBot.SaveChanges();
                DBot.Dispose();


                await context.PostAsync(ChatResponse.Thanks);
                await context.PostAsync(ChatResponse.Checkid + "Folio: " + folio);
                await context.PostAsync(ChatResponse.Status);
                await context.PostAsync(ChatResponse.Step5Else);
            }
            catch (FormCanceledException)
            {
                await context.PostAsync(ChatResponse.formCanceled);
            }
            catch (Exception)
            {

                await context.PostAsync(ChatResponse.Error);
            }

            finally
            {
                context.Wait(MessageReceived);
            }
        }
       
        #endregion

        #region FormComplaint
        public async Task ComplaintFormComplete(IDialogContext context, IAwaitable<ComplaintForm> result)
        {
            Activity replyToConversation = (Activity)context.MakeMessage();
            replyToConversation.Recipient = replyToConversation.Recipient;
            replyToConversation.Type = "Message";

            IdentifyLanguage();

            try
            {
                var complaint = await result;

            int idtipocaso = 3; //Tipo de caso: queja
            int idstatus = 1; //Estado: No revisado
            string folio;
            int idciudadano = 1;
            var fecha = DateTime.UtcNow;

            //Creación de folio
            folio = complaint.Name.Substring(0, 2).ToUpper() + idciudadano + "_" + idtipocaso;

            //****Log to DataBase****
            ConnectionDB.Chatbot_PGBEntities DB = new ConnectionDB.Chatbot_PGBEntities();
            ConnectionDB.Casos NewCaso = new ConnectionDB.Casos();
            NewCaso.idtipocaso = idtipocaso;
            NewCaso.idstatus = idstatus;
            NewCaso.folio = folio;
            NewCaso.idciudadano = idciudadano;
            NewCaso.nombre = complaint.Name;
            NewCaso.email = complaint.Contact;
            NewCaso.descripcion = complaint.Complaint;
            NewCaso.fecha_registro = DateTime.UtcNow;
            DB.Casos.Add(NewCaso);
            DB.SaveChanges();

                ConnectionDB.Chatbot_PGBEntities1 DBot = new ConnectionDB.Chatbot_PGBEntities1();
                ConnectionDB.UserLogin NewUserLogBot = new ConnectionDB.UserLogin();
                NewUserLogBot.Channel = replyToConversation.ChannelId;
                NewUserLogBot.UserID = replyToConversation.From.Id;
                NewUserLogBot.UserName = replyToConversation.From.Name;
                NewUserLogBot.Created = DateTime.UtcNow;
                NewUserLogBot.Message = ChatResponse.Thanks + " " + ChatResponse.Checkid + " Folio: " + folio + " " + ChatResponse.Status + " " + ChatResponse.Step5Else;
                DBot.UserLogins.Add(NewUserLogBot);
                DBot.SaveChanges();
                DBot.Dispose();

                await context.PostAsync(ChatResponse.Thanks);
            await context.PostAsync(ChatResponse.Checkid + "Folio: " + folio);
            await context.PostAsync(ChatResponse.Status);
            await context.PostAsync(ChatResponse.Step5Else);
            }
            catch (FormCanceledException)
            {
                await context.PostAsync(ChatResponse.formCanceled);
            }
            catch (Exception)
            {

                await context.PostAsync(ChatResponse.Error);
            }

            finally
            {
                context.Wait(MessageReceived);
            }
        }
        //private async Task ComplaintFormStatusComplete(IDialogContext context, IAwaitable<ComplaintFormStatus> result)
        //{
        //}
        #endregion

        #region FormInformationR
        public async Task InformationRFormComplete(IDialogContext context, IAwaitable<InformationRForm> result)
        {
            Activity replyToConversation = (Activity)context.MakeMessage();
            replyToConversation.Recipient = replyToConversation.Recipient;
            replyToConversation.Type = "Message";

            IdentifyLanguage();

            try
            {
                var informationr = await result;

            int idtipocaso = 4; //Tipo de caso: solicitud de informacion
            int idstatus = 1; //Estado: No revisado
            string folio;
            int idciudadano = 1;
            var fecha = DateTime.UtcNow;

            //Creación de folio
            folio = informationr.Name.Substring(0, 2).ToUpper() + idciudadano + "_" + idtipocaso;

            //****Log to DataBase****
            ConnectionDB.Chatbot_PGBEntities DB = new ConnectionDB.Chatbot_PGBEntities();
            ConnectionDB.Casos NewCaso = new ConnectionDB.Casos();
            NewCaso.idtipocaso = idtipocaso;
            NewCaso.idstatus = idstatus;
            NewCaso.folio = folio;
            NewCaso.idciudadano = idciudadano;
            NewCaso.nombre = informationr.Name;
            NewCaso.email = informationr.Contact;
            NewCaso.descripcion = informationr.Information;
            NewCaso.fecha_registro = DateTime.UtcNow;
            DB.Casos.Add(NewCaso);
            DB.SaveChanges();

                ConnectionDB.Chatbot_PGBEntities1 DBot = new ConnectionDB.Chatbot_PGBEntities1();
                ConnectionDB.UserLogin NewUserLogBot = new ConnectionDB.UserLogin();
                NewUserLogBot.Channel = replyToConversation.ChannelId;
                NewUserLogBot.UserID = replyToConversation.From.Id;
                NewUserLogBot.UserName = replyToConversation.From.Name;
                NewUserLogBot.Created = DateTime.UtcNow;
                NewUserLogBot.Message = ChatResponse.Thanks + " " + ChatResponse.Checkid + " Folio: " + folio + " " + ChatResponse.Status + " " + ChatResponse.Step5Else;
                DBot.UserLogins.Add(NewUserLogBot);
                DBot.SaveChanges();
                DBot.Dispose();

                await context.PostAsync(ChatResponse.Thanks);
            await context.PostAsync(ChatResponse.Checkid + ": " + folio);
            await context.PostAsync(ChatResponse.Status);
            await context.PostAsync(ChatResponse.Step5Else);
            }
            catch (FormCanceledException)
            {
                await context.PostAsync(ChatResponse.formCanceled);
            }
            catch (Exception)
            {

                await context.PostAsync(ChatResponse.Error);
            }

            finally
            {
                context.Wait(MessageReceived);
            }
        }
        //private async Task InformationRFormStatusComplete(IDialogContext context, IAwaitable<InformationRFormStatus> result)
        //{

        #endregion

        #region Status
        private async Task FormStatusComplete(IDialogContext context, IAwaitable<FormStatus> result)
        {
            var consultstatus = await result;
            string idsuggestion = ChatResponse.idstring;
            var folio = consultstatus.Checkid;

            try
            {
                ConnectionDB.Chatbot_PGBEntities DB = new ConnectionDB.Chatbot_PGBEntities();
                //Obteniendo el caso
                var status = (from UserLog in DB.Casos
                              where UserLog.folio == folio
                              select UserLog);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("Usted escribió:\n\n");

                foreach (var caso in status)
                {
                    //var tcaso = caso.idtipocaso;
                    //var tipocaso = (from UserLogStatus in DBCaso.TipoCasos
                    //                where UserLogStatus.tipocaso = tcaso
                    //                where UserLogStatus);
                    //Añadiendo el caso a la respuesta
                    sb.Append(String.Format("Caso: {0} \n\n Estatus: {1} \n\n Folio: {2} \n\n Nombre: {3} \n\n Descripción del caso: {4} \n\n Nombre del funcionario: {5} \n\n Dependencia: {6} \n\n Fecha de registro: {7}\n\n"
                            , caso.idcaso
                            , caso.idstatus
                            , caso.folio
                            , caso.nombre
                            , caso.descripcion
                            , caso.nombre_funcionario
                            , caso.nombre_dependencia
                            , caso.fecha_registro));
                    string response = sb.ToString();
                    await context.PostAsync(response);
                    string elsem = ChatResponse.Step5Else;
                    await context.PostAsync(elsem);
                }

                //PRUEBAS CON VISTAS
                //Conexion para la Vista
                //ConnectionDB.Chatbot_PGBEntities1 Vistas = new ConnectionDB.Chatbot_PGBEntities1();
                //Creando una respuesta
                //var vista = (from UserLogV in Vistas.desc_tipo_caso_denuncia
                //             where UserLogV.folio == folio
                //             select UserLogV);
                //foreach (var view in vista)
                //{
                //    //Añadiendo el caso a la respuesta
                //    sb.Append(String.Format("Caso: {0} \n\n Estatus: {1} \n\n Folio: {2} \n\n Nombre: {3} \n\n Descripción del caso: {4} \n\n Nombre del funcionario: {5} \n\n Dependencia: {6} \n\n Fecha de registro: {7}\n\n"
                //            , view.tipocaso
                //            , view.status
                //            , view.folio
                //            , view.nombre
                //            , view.descripcion
                //            , view.nombre_funcionario
                //            , view.nombre_dependencia
                //            , view.fecha_registro));
                //    string response = sb.ToString();
                //    await context.PostAsync(response);
                //}
                
            }
            catch (FormCanceledException)
            {
                await context.PostAsync(ChatResponse.formCanceled);
            }
            catch (Exception exc)
            {

                await context.PostAsync(ChatResponse.Error + " + " + exc);
            }

            finally
            {
                context.Wait(MessageReceived);
            }
        }
        #endregion
    }
}