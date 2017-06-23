using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BotProcivicaV3.Utilities
{
    public static class Settings
    {
        public static string GetTranslatorClientId()
        {
            return ConfigurationManager.AppSettings["TranslatorClientId"];
        }
        public static string GetTranslatorClientSecret()
        {
            return ConfigurationManager.AppSettings["TranslatorClientSecret"];
        }
        public static string GetTokenUri()
        {
            return ConfigurationManager.AppSettings["TokenUri"];
        }
        public static string GetTranslatorUri()
        {
            return ConfigurationManager.AppSettings["TranslatorUri"];
        }
        public static string GetDataSource()
        {
            return ConfigurationManager.AppSettings["DataSource"];
        }
        public static string GetLanguageTranslation()
        {
            return ConfigurationManager.AppSettings["LanguageTranslation"];
        }
        #region messages
        public static string GetDefault()
        {
            return ConfigurationManager.AppSettings["Default"];
        }
        public static string GetSwearWord()
        {
            return ConfigurationManager.AppSettings["SwearWord"];
        }
        public static string GetUnsense()
        {
            return ConfigurationManager.AppSettings["Unsense"];
        }
        public static string GetIdentity()
        {
            return ConfigurationManager.AppSettings["Identity"];
        }
        public static string GetWelcomeMessage()
        {
            return ConfigurationManager.AppSettings["WelcomeMessage"];
        }
        public static string GetSuggestionGreet()
        {
            return ConfigurationManager.AppSettings["SuggestionGreet"];
        }
        public static string GetComplaintGreet()
        {
            return ConfigurationManager.AppSettings["ComplaintGreet"];
        }
        public static string GetDenunciationGreet()
        {
            return ConfigurationManager.AppSettings["DenunciationGreet"];
        }
        public static string GetInformationRGreet()
        {
            return ConfigurationManager.AppSettings["InformationRGreet"];
        }
        public static string GetGreeting()
        {
            return ConfigurationManager.AppSettings["Greeting"];
        }
        public static string GetStep1()
        {
            return ConfigurationManager.AppSettings["Step1"];
        }
        public static string GetStep2()
        {
            return ConfigurationManager.AppSettings["Step2"];
        }
        public static string GetStep3Suggestion()
        {
            return ConfigurationManager.AppSettings["Step3Suggestion"];
        }
        public static string GetStep3Request()
        {
            return ConfigurationManager.AppSettings["Step3Request"];
        }
        public static string GetStep3Complaint()
        {
            return ConfigurationManager.AppSettings["Step3Complaint"];
        }
        public static string GetStep3Denunciation()
        {
            return ConfigurationManager.AppSettings["Step3Denunciation"];
        }
        public static string GetStep4Suggestion()
        {
            return ConfigurationManager.AppSettings["Step4Suggestion"];
        }
        public static string GetStep4Request()
        {
            return ConfigurationManager.AppSettings["Step4Request"];
        }
        public static string GetStep4Complaint()
        {
            return ConfigurationManager.AppSettings["Step4Complaint"];
        }
        public static string GetStep4Denunciation()
        {
            return ConfigurationManager.AppSettings["Step4Denunciation"];
        }
        public static string GetStep5Else()
        {
            return ConfigurationManager.AppSettings["Step5Else"];
        }
        public static string GetStep5Denunciation()
        {
            return ConfigurationManager.AppSettings["Step5Denunciation"];
        }
        public static string GetStep6Denunciation()
        {
            return ConfigurationManager.AppSettings["Step6Denunciation"];
        }
        public static string GetInvalidEmail()
        {
            return ConfigurationManager.AppSettings["InvalideEmail"];
        }
        public static string GetError()
        {
            return ConfigurationManager.AppSettings["Error"];
        }
        public static string GetErrorStatus()
        {
            return ConfigurationManager.AppSettings["ErrorStatus"];
        }
        public static string GetFormCanceled()
        {
            return ConfigurationManager.AppSettings["FormCanceled"];
        }
        public static string Getid()
        {
            return ConfigurationManager.AppSettings["id"];
        }
        public static string GetidString1()
        {
            return ConfigurationManager.AppSettings["idString1"];
        }
        public static string GetidString2()
        {
            return ConfigurationManager.AppSettings["idString2"];
        }
        public static string GetStatus()
        {
            return ConfigurationManager.AppSettings["Status"];
        }
        public static string GetCancelStatus()
        {
            return ConfigurationManager.AppSettings["CancelStatus"];
        }
        public static string GetHelp()
        {
            return ConfigurationManager.AppSettings["Help"];
        }
        public static string GetThanks()
        {
            return ConfigurationManager.AppSettings["Thanks"];
        }
        public static string GetCheckID()
        {
            return ConfigurationManager.AppSettings["CheckID"];
        }
        public static string GetOneMoment()
        {
            return ConfigurationManager.AppSettings["OneMoment"];
        }
        public static string GetGoodbye()
        {
            return ConfigurationManager.AppSettings["Goodbye"];
        }
        public static string Cancel()
        {
            return ConfigurationManager.AppSettings["Cancel"];
        }
        public static string IfCancel()
        {
            return ConfigurationManager.AppSettings["IfCancel"];
        }
        #endregion
    }
}