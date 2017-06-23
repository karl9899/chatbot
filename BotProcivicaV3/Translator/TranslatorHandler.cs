using BotProcivicaV3.Utilities;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotProcivicaV3.Translator
{
    public class TranslatorHandler
    {
        public static string conversationText;
        public static string isoName;
        public static string conversation;
        public static string DetectAndTranslate(Activity activity)
        {
            //detect language
            //update state for current user to detected language
            var inputLanguageCode = DoLanguageDetection(activity.Text);
            //Extraer la cadena de texto para analizar en el método IdentifyLanguage
            conversationText = activity.Text;

            //StateHelper.SetUserLanguageCode(activity, inputLanguageCode);

            if (inputLanguageCode.ToLower() != Settings.GetLanguageTranslation())
            {
                return DoTranslation(activity.Text, inputLanguageCode, Settings.GetLanguageTranslation());
            }
            return activity.Text;
        }
        public static string DoTranslation(string inputText, string inputLocale, string outputLocale)
        {
            var translator = new Translator();
            var translation = translator.Translate(inputText, inputLocale, outputLocale);
            return translation;
        }
        public static string DoLanguageDetection(string input)
        {
            var translator = new Translator();
            return translator.Detect(input);
        }
    }
}