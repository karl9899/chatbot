using BotProcivicaV3.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace BotProcivicaV3
{
    public class ChatResponse
    {
        
        //private static string headerValue;
        //Aquí asigno todas las respuestas a: Default, por si no entiende lo que quizó decir el usuario

        public static string Default
        {
            get { return DoTranslation(Settings.GetDefault(), idiom); }
        }

        public static string SwearWord
        {
            get { return DoTranslation(Settings.GetSwearWord(), idiom); }
        }

        public static string Unsense
        {
            get { return DoTranslation(Settings.GetUnsense(), idiom); }
        }

        public static string Identity
        {
            get { return DoTranslation(Settings.GetIdentity(), idiom); }
        }

        //Aquí asigno todas las respuestas a: WelcomeMessage
        public static readonly string WelcomeMessage = Settings.GetWelcomeMessage();

        //Aquí asigno todas las respuestas a: Intenciones
        public static string idiom
        {
            get { return Settings.GetLanguageTranslation()/*TranslationHandler.isoName.ToString()*/; }
        }

        public static string SuggestionGreet
        {
            get { return DoTranslation(Settings.GetSuggestionGreet(), idiom); }
        }

        public static string ComplaintGreet
        {
            get { return DoTranslation(Settings.GetComplaintGreet(), idiom); }
        }

        public static string DenunciationGreet
        {
            get { return DoTranslation(Settings.GetDenunciationGreet(), idiom); }
        }

        public static string InformationRGreet
        {
            get { return DoTranslation(Settings.GetInformationRGreet(), idiom); }
        }

        //Usando informacion estática
        public static string Greeting
        {
            get { return DoTranslation(Settings.GetGreeting(), idiom); }
        }
        public static string Suggestion
        {
            get { return DoTranslation(Step1Name, idiom); }
        }

        public static string Complaint
        {
            get { return DoTranslation(Step1Name, idiom); }
        }

        public static string Denunciation
        {
            get { return DoTranslation(Step1Name, idiom); }
        }

        public static string InformationR
        {
            get { return DoTranslation(Step1Name, idiom); }
        }

        //Aquí asigno todas las respuestas a: Flujo de obtención de datos
        public static readonly string Step1Name = Settings.GetStep1();

        public static string Step2Contact
        {
            get { return DoTranslation(Settings.GetStep2(), idiom); }
        }
        public static string Step3Suggestion
        {
            get { return DoTranslation(Settings.GetStep3Suggestion(), idiom); }
        }

        public static string Step3Request
        {
            get { return DoTranslation(Settings.GetStep3Request(), idiom); }
        }
        public static string Step3Complaint
        {
            get { return DoTranslation(Settings.GetStep3Complaint(), idiom); }
        }

        public static string Step3Denunciation
        {
            get { return DoTranslation(Settings.GetStep3Denunciation(), idiom); }

        }

        public static string Step4Suggestion
        {
            get { return DoTranslation(Settings.GetStep4Suggestion(), idiom); }
        }

        public static string Step4Request
        {
            get { return DoTranslation(Settings.GetStep4Request(), idiom); }
        }

        public static string Step4Complaint
        {
            get { return DoTranslation(Settings.GetStep4Complaint(), idiom); }
        }

        public static string Step4Denunciation
        {
            get { return DoTranslation(Settings.GetStep4Denunciation(), idiom); }
        }

        public static string Step5Else
        {
            get { return DoTranslation(Settings.GetStep5Else(), idiom); }
        }

        public static string Step5Denunciation
        {
            get { return DoTranslation(Settings.GetStep5Denunciation(), idiom); }
        }

        public static string Step6Denunciation
        {
            get { return DoTranslation(Settings.GetStep6Denunciation(), idiom); }
        }

        //Aquí asigno todas las respuestas a: Posibles Errores

        public static string EmailInvalid
        {
            get { return DoTranslation(Settings.GetInvalidEmail(), idiom); }
        }

        public static string Error
        {
            get { return DoTranslation(Settings.GetError(), idiom); }
        }


        public static string ErrorStatus
        {
            get { return DoTranslation(Settings.GetErrorStatus(), idiom); }
        }

        public static string formCanceled
        {
            get { return DoTranslation(Settings.GetFormCanceled(), idiom); }
        }

        //Aquí asigno todas las respuestas a: Status
        public static string id
        {
            get { return DoTranslation(Settings.Getid(), idiom); }
        }
        public static string idstring
        {
            get { return DoTranslation(Settings.GetidString1(), idiom); }
        }

        public static string idstring2
        {
            get { return DoTranslation(Settings.GetidString2(), idiom); }
        }
        public static string Status
        {
            get { return DoTranslation(Settings.GetStatus(), idiom); }
        }
        //Aquí asigno la respuesta a: Cancelar la acción

        public static string CancelStatus
        {
            get { return DoTranslation(Settings.GetCancelStatus(), idiom); }
        }

        //Aquí asigno todas las respuestas a: Help/Mensajes de ayuda
        public static string HelpMessage
        {
            get { return DoTranslation(Settings.GetHelp(), idiom); }
        }

        //Aquí asigno todas las respuestas a: SuggestionFormComplete
        public static string Thanks
        {
            get { return DoTranslation(Settings.GetThanks(), idiom); }
        }
        public static string Checkid
        {
            get { return DoTranslation(Settings.GetCheckID(), idiom); }
        }
        public static string onemoment
        {
            get { return DoTranslation(Settings.GetOneMoment(), idiom); }
        }
        public static string Goodbye
        {
            get { return DoTranslation(Settings.GetGoodbye(), idiom); }
                 //string text = DoTranslation(Settings.GetGoodbye(), idiom);
                ////String result = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(text);
                //String result2 = new CultureInfo("en-US", false).TextInfo.ToTitleCase(text);
                //return result2; }
            }
        public static string Cancel
        {
            get { return DoTranslation(Settings.Cancel(), idiom); }
        }
        public static string IfCancel
        {
            get { return DoTranslation(Settings.IfCancel(),idiom); }
        }

        //Identificamos el lenguaje de la Actividad
        public static string getLanguageActivity
        {
            get { return Translator.TranslatorHandler.isoName; }
        }
        //

        private static string DoTranslation(string input, string lang)
        {
            try
            {
                var translation = new Translator.Translator();
                var textTranslated = translation.TranslateString(input, lang/*es*/, getLanguageActivity.ToString()/*El lenguaje de la Actividad*/);
                return textTranslated;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        
    }
}