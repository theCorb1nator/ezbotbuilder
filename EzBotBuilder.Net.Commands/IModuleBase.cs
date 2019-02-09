using Microsoft.Bot.Builder;
using EzBotBuilder.Commands.Builders;

namespace EzBotBuilder.Commands
{
    internal interface IModuleBase
    {
        void SetContext(ITurnContext context);

        void BeforeExecute(CommandInfo command);

        void AfterExecute(CommandInfo command);

        void OnModuleBuilding(CommandService commandService, ModuleBuilder builder);
    }
}