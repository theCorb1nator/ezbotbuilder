using Microsoft.Bot.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;
using Teams.Commands;

namespace msteams.commandbot
{
    public class CommandHandlingService
    {

        private readonly CommandService _commands;
        private readonly IServiceProvider _services;
        public CommandHandlingService(IServiceProvider services)
        {
            _commands = services.GetRequiredService<CommandService>();
            _services = services;
        }

        public async Task InitializeAsync()
        {
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }
    }
}