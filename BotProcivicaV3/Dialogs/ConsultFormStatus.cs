using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotProcivicaV3.Dialogs
{
    [Serializable]
    public class ConsultFormStatus
    {
         [Prompt(new string[] { "" })]
        public string Checkid { get; set; }
        public static IForm<ConsultFormStatus> BuildForm()
        {
            string id = ChatResponse.id;
            string onemoment = ChatResponse.onemoment;
            return new FormBuilder<ConsultFormStatus>()
                .Field(nameof(Checkid), prompt: id)
                .Message(onemoment)
                .AddRemainingFields()
                .Build();
        }
    }
}