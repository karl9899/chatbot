using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BotProcivicaV3.Dialogs
{
    [Serializable]
    public class DenunciationForm
    {
        [Prompt(new string[] { "" })]
        public string Name { get; set; }

        [Prompt("")]
        public string Contact { get; set; }

        [Prompt("")]
        public string Denunciation { get; set; }

        [Prompt("")]
        public string Functionary { get; set; }

        [Prompt("")]
        public string Dependency { get; set; }

        public static IForm<DenunciationForm> BuildForm()
        {
            //Se obtienen las cadenas de preguntas
            string name = ChatResponse.Denunciation;
            string contact = ChatResponse.Step2Contact;
            string denunciation = ChatResponse.Step4Denunciation;
            string functionary = ChatResponse.Step5Denunciation;
            string dependency = ChatResponse.Step6Denunciation;

            return new FormBuilder<DenunciationForm>()
                .Field(nameof(Name),prompt: name)
                .Field(nameof(Contact), validate: ValidateContactInformation, prompt: contact)
                .Field(nameof(Denunciation),prompt: denunciation)
                .Field(nameof(Functionary),prompt: functionary)
                .Field(nameof(Dependency),active: DenunciationEnabled, prompt: dependency)
                .AddRemainingFields()
                .Build();
        }

        private static bool DenunciationEnabled(DenunciationForm state) =>
         !string.IsNullOrWhiteSpace(state.Contact) && !string.IsNullOrWhiteSpace(state.Name);

        private static Task<ValidateResult> ValidateContactInformation(DenunciationForm state, object response)
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