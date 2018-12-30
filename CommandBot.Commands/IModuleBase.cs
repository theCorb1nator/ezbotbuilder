using Microsoft.Bot.Builder;
using Teams.Commands.Builders;

namespace Teams.Commands
{
    internal interface IModuleBase
    {
        void SetContext(ITurnContext context);

        void BeforeExecute(CommandInfo command);

        void AfterExecute(CommandInfo command);

        void OnModuleBuilding(CommandService commandService, ModuleBuilder builder);
    }
}