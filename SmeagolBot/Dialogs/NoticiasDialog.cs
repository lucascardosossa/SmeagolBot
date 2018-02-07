using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace SmeagolBot.Dialogs
{
    [Serializable]
    [LuisModel("8f8c95dc-93ff-4ea4-9abb-205b9307cbfa", "980fd1fe484e4466a66b0b50e516f69a")]
    public class NoticiasDialog : LuisDialog<object>
    {
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Não consegui entender a frase {result.Query}");
        }

        [LuisIntent("Agradecimento")]
        public async Task Agradecimento(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Tamo aqui sempre!");
        }

        [LuisIntent("Saudacao")]
        public async Task Saudacao(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Tudo tranquilo jhow!");
        }

        [LuisIntent("Noticias")]
        public async Task Noticias(IDialogContext context, LuisResult result)
        {
            var framework = result.Entities?.Select(e => e.Entity);
            await context.PostAsync($"Noticias sobre {string.Join(",", framework.ToArray())} vá no medium.");
        }
    }
}