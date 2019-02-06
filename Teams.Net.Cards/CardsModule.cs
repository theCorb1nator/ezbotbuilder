using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Teams.Commands;
using Microsoft.Bot.Builder.Dialogs;
using AdaptiveCards;

namespace Teams.Net.Cards
{
    public class CardsModule : ModuleBase<ITurnContext>
    {
        [Command("hero")]
        public async Task DisplayHeroCardAsync()
        {
            var reply = Context.Activity.CreateReply();
            // Create a HeroCard with options for the user to choose to interact with the bot.
            var card = new HeroCard
            {
                Text = "You can upload an image or select one of the following choices",
                Buttons = new List<CardAction>()
                {
                    new CardAction(ActionTypes.ImBack, title: "1. Inline Attachment", value: "1"),
                    new CardAction(ActionTypes.ImBack, title: "2. Internet Attachment", value: "2"),
                    new CardAction(ActionTypes.ImBack, title: "3. Uploaded Attachment", value: "3"),
                },
            };

            // Add the card to our reply.
            reply.Attachments = new List<Attachment>() { card.ToAttachment() };
            await ReplyAsync(reply);
        }

        [Command("rel")]
        public async Task DisplayReleasesAsync()
        {
            var builder = new AdaptiveCardBuilder();          
            var reply = Context.Activity.CreateReply();
            //reply.Attachments = new List<Attachment>() { cardAttachment };
            await ReplyAsync(reply);
        }

        private static Attachment CreateAdaptiveCardAttachment(string filePath)
        {
            var adaptiveCardJson = File.ReadAllText(filePath);
            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
    }


}
