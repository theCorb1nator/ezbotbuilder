using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using System;
using Teams.Commands;

namespace Teams.CommandBot.Modules
{
    public class CardsModule : ModuleBase<ITurnContext>
    {
        private CardsAccessors _accessors;

        private DialogSet _dialogs;

        public CardsModule(CardsAccessors accessors)
        {
            this._accessors = accessors ?? throw new ArgumentNullException(nameof(accessors));
            this._dialogs = new DialogSet(accessors.ConversationDialogState);
            this._dialogs.Add(new WaterfallDialog("cardSelector", new WaterfallStep[] { ChoiceCardStepAsync, ShowCardStepAsync }));
            this._dialogs.Add(new ChoicePrompt("cardPrompt"));
        }
}
