using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BotProcivicaV3.ConnectionDB;
using Microsoft.Bot.Connector;

namespace BotProcivicaV3.Dialogs
{
    [Serializable]
    public class SuggestionForm
    {
        [Prompt(new string[] { "" })]
        public string Name { get; set; }

        [Prompt("")]
        public string Contact { get; set; }

        [Prompt("")]
        public string Suggestion { get; set; }
        
        public static IForm<SuggestionForm> BuildForm()
        {

            //Se obtienen las cadenas de preguntas
            string name = ChatResponse.Suggestion;
            string contact = ChatResponse.Step2Contact;
            string suggestion = ChatResponse.Step4Suggestion;

            //IMessageActivity replyToConversation = (IMessageActivity) BuildForm();  
            
            //ConnectionDB.Chatbot_PGBEntities1 DBot = new ConnectionDB.Chatbot_PGBEntities1();
            //ConnectionDB.UserLogin NewUserLogBot = new ConnectionDB.UserLogin();
            //NewUserLogBot.Channel = replyToConversation.ChannelId;
            //NewUserLogBot.UserID = replyToConversation.From.Id;
            //NewUserLogBot.UserName = replyToConversation.From.Name;
            //NewUserLogBot.Created = DateTime.UtcNow;
            //NewUserLogBot.Message = replyToConversation.Text;
            //DBot.UserLogins.Add(NewUserLogBot);
            //DBot.SaveChanges();
            //DBot.Dispose();

            return new FormBuilder<SuggestionForm>()
                .Field(nameof(Name), prompt: name)
                .Field(nameof(Contact), validate: ValidateContactInformation, prompt: contact)
                .Field(nameof(Suggestion), active: SuggestionEnabled, prompt: suggestion)
                .AddRemainingFields()
                .Build();

           

        }


        private static bool SuggestionEnabled(SuggestionForm state) =>
          !string.IsNullOrWhiteSpace(state.Contact) && !string.IsNullOrWhiteSpace(state.Name);


        private static Task<ValidateResult> ValidateContactInformation(SuggestionForm state, object response)
        {
            var result = new ValidateResult();
            string contactInfo = string.Empty;
            if (GetTwitterHandle((string)response, out contactInfo) || GetEmailAddress((string)response, out contactInfo))
            {
                result.IsValid = true;
                result.Value = contactInfo;
            }
            else
            {
                result.IsValid = false;
                result.Feedback = "Has ingresado un email no válido, vuelve a intentarlo por favor.";
            }
            return Task.FromResult(result);
        }


        private static bool GetEmailAddress(string response, out string contactInfo)
        {
            contactInfo = string.Empty;
            var match = Regex.Match(response, @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            if (match.Success)
            { //[azAZ]|[0-9]
                contactInfo = match.Value;
                return true;
            }
            return false;
        }

        private static bool GetTwitterHandle(string response, out string contactInfo)
        {
            contactInfo = string.Empty;
            if (!response.StartsWith("@"))
                return false;
            contactInfo = response;
            return true;
        }
    }
}