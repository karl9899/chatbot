using BotProcivicaV3.Models;
using BotProcivicaV3.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web;

namespace BotProcivicaV3.Translator
{
    public class Translator
    {
        internal Translator()
        {
            try
            {
                GlobalVars.bearer = Task.Run(GetBearerTokenForTranslator).Result;
            }
            catch (HttpRequestException exc)
            {
                if (GlobalVars.tkn.RequestStatusCode == HttpStatusCode.Unauthorized)
                {
                    throw exc;
                }
                if (GlobalVars.tkn.RequestStatusCode == HttpStatusCode.Forbidden)
                {
                    throw exc;
                }
                throw exc;
            }
        }
        public string Translate(string inputText, string inputLocale, string outputLocale)
        {
            try
            {


                string uri = "https://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + HttpUtility.UrlEncode(inputText) + "&from=" + inputLocale + "&to=" + outputLocale;
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                httpWebRequest.Headers.Add("Authorization", GlobalVars.bearer);
                using (WebResponse response = httpWebRequest.GetResponse())
                using (Stream stream = response.GetResponseStream())
                {
                    DataContractSerializer dcs = new DataContractSerializer(Type.GetType("System.String"));
                    string translation = (string)dcs.ReadObject(stream);
                    return translation;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public string TranslateString(string v, string lan, string langActivity)
        {
            string text = v;
            string laninput = lan;//Idioma por defecto --> "es"
            string lanActivity = langActivity;//Idioma detectado --> Cualquiera
           

            if (laninput == lanActivity)
            {
                //No hay traducción y devuelve la cadena v
                return text;
            }

            else //(inputLanguageCode != inputLanguageActivity)
            {
                //Si el idioma por defecto y el idioma detectado son diferentes se hará la traducción y regresará el texto traducido
                string txtToTranslate = v;
                string lang = langActivity.ToLower();

                try
                {
                   
                    string uri = "https://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + HttpUtility.UrlEncode(text) + "&from=" + laninput + "&to=" + lanActivity;
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                    httpWebRequest.Headers.Add("Authorization", GlobalVars.bearer);
                    using (WebResponse response = httpWebRequest.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    {
                        DataContractSerializer dcs = new DataContractSerializer(Type.GetType("System.String"));
                        string translation = (string)dcs.ReadObject(stream);
                        return translation;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

        }
        internal string Detect(string input)
        {
            try
            {
                string uri = "https://api.microsofttranslator.com/v2/Http.svc/Detect?text=" + input;
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                httpWebRequest.Headers.Add("Authorization", GlobalVars.bearer);
                using (WebResponse response = httpWebRequest.GetResponse())
                using (Stream stream = response.GetResponseStream())
                {
                    System.Runtime.Serialization.DataContractSerializer dcs = new System.Runtime.Serialization.DataContractSerializer(Type.GetType("System.String"));
                    string languageDetected = (string)dcs.ReadObject(stream);
                    return languageDetected;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //internal async Task<AdmAccessToken> GetBearerTokenForTranslator()
        internal async Task<string> GetBearerTokenForTranslator()
        {
            try
            {
                /*
                var azureDataMarket = new AzureDataMarket();
                var token = await azureDataMarket.GetAccessToken();
                GlobalVars.Bearer = token;
                return token;
                */
                var azureAuthTkn = new AzureAuthToken(Settings.GetTranslatorClientSecret().Trim());
                GlobalVars.tkn = azureAuthTkn;
                var token = await azureAuthTkn.GetAccessTokenAsync();
                GlobalVars.bearer = token;
                return token;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}