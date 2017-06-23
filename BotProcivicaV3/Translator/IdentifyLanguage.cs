using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotProcivicaV3.Translator
{
    public class IdentifyLanguage
    {


        public class Response
        {
            public document[] documents { get; set; }
            //public error[] errors { get; set; }

        }

        public class document
        {
            public string id { get; set; }
            public DetectedLanguage[] detectedLanguages { get; set; }
        }

        public class DetectedLanguage
        {
            public string name { get; set; }
            public string iso6391Name { get; set; }
            public decimal score { get; set; }
        }
        public class error
        {

        }
    }
}