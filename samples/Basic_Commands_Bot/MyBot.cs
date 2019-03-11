using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Teams.Net.Commands;
using Microsoft.Bot.Builder.Teams;
using System.Reflection;
using EzBotBuilder.Commands;
using System;
using Teams;

namespace msteams.commandbot
{
    public class MyBot : IBot
    {
        private readonly CommandService _commands;
        private readonly IServiceProvider _services;

        public MyBot(CommandService commandService)
        {
            _commands = commandService;
        }

        public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (turnContext.Activity.Type == ActivityTypes.Message)
            {
                var argPos = 0;
                if (!(turnContext.Activity.MentionsRecipient() || turnContext.Activity.Text.HasStringPrefix("!", ref argPos))) return;
                await _commands.ExecuteAsync(turnContext, argPos, _services);
                // Echo back to the user whatever they typed.             
            }
        }
    }
}