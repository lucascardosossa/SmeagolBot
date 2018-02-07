using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace SmeagolBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            var message = activity.CreateReply();


            if (activity.Text.Equals("como voce se parece?", StringComparison.InvariantCultureIgnoreCase))
            {
                var heroCard = new HeroCard();
                heroCard.Title = "Smeagol";
                heroCard.Subtitle = "Bots";
                heroCard.Images = new List<CardImage>
                {
                    new CardImage("https://cdni.rt.com/files/2015.11/article/56507f12c46188d3148b45b2.jpg", "Smeagol")
                };

                message.Attachments.Add(heroCard.ToAttachment());
            }else if (activity.Text.Equals("qual filme voce fez?", StringComparison.InvariantCultureIgnoreCase))
            {
                var videoCard = new VideoCard();
                videoCard.Title = "Senhor dos Anéis";
                videoCard.Autoloop = false;
                videoCard.Autostart = true;
                videoCard.Media = new List<MediaUrl>
                {
                    new MediaUrl("http://videos.criticalcommons.org/transcoded/http/www.criticalcommons.org/Members/ebreilly/clips/the-lord-of-the-rings-gollum-and-smeagol/video_file/webm-low/gollum-and-smeagol-mp4.webm")
                };

                message.Attachments.Add(videoCard.ToAttachment());
            }
            else
            {
                await context.PostAsync("**Ola, tudo bem? Em que posso ajudar.**");
            }

            await context.PostAsync(message);

            context.Wait(MessageReceivedAsync);
        }
    }
}