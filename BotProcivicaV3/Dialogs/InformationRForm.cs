using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BotProcivicaV3.Dialogs
{
    [Serializable]
    public class InformationRForm
    {
        [Prompt(new string[] { "" })]
        public string Name { get; set; }
        [Prompt("")]
        public string Contact { get; set; }
        [Prompt("")]
        public string Information { get; set; }

        public static IForm<InformationRForm> BuildForm()
        {
            string name = ChatResponse.Step1Name;
            string contact = ChatResponse.Step2Contact;
            string informationrequest = ChatResponse.Step4Request;

            return new FormBuilder<InformationRForm>()
                .Field(nameof(Name), prompt: name)
                .Field(nameof(Contact), validate: ValidateContactInformation, prompt: contact)
                .Field(nameof(Information), active: RequestEnabled, prompt: informationrequest)
                .AddRemainingFields()
                .Build();
        }
        private static bool RequestEnabled(InformationRForm state) =>
          !string.IsNullOrWhiteSpace(state.Contact) && !string.IsNullOrWhiteSpace(state.Name);


        private static Task<ValidateResult> ValidateContactInformation(InformationRForm state, object response)
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