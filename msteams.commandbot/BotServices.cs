using System;
using System.Collections.Generic;

namespace msteams.commandbot
{
    /// <summary>
    /// Represents references to external services.
    /// </summary>
    public class BotServices
    {
        public BotServices(Dictionary<string, CommandHandlingService> commandHandlingService)
        {
            CommandServices = commandHandlingService ?? throw new ArgumentNullException(nameof(commandHandlingService));
        }
      
        public Dictionary<string, CommandHandlingService> CommandServices { get; } = new Dictionary<string, CommandHandlingService>();
    }
}
