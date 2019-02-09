using EzBotBuilder.Commands;
using Microsoft.Bot.Builder;
using System.Threading.Tasks;

namespace EzBotBuilder.Cards
{
    public class CardsModule : ModuleBase<ITurnContext>
    {
        private AdaptiveCardsService _adaptiveCardsService;

        //public CardsModule(AdaptiveCardsService adaptiveCardsService)
        //{
        //    _adaptiveCardsService = adaptiveCardsService;
        //}

        public CardsModule()
        {
            _adaptiveCardsService = new AdaptiveCardsService();
        }

        [Command("rel")]
        public async Task DisplayReleasesAsync()
        {
            var reply = Context.Activity.CreateReply();
            var attach = _adaptiveCardsService.GetAdaptiveCard("tag");
            reply.Attachments.Add(attach);
            await ReplyAsync(reply);
        }       
    }


}
