using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teams.Commands
{
    public class CommandContext : TurnContext, ITurnContext
    {
        public CommandContext(BotAdapter adapter, Activity activity) : base(adapter, activity)
        {

        }
        public IUser User { get; }

        public IMessageActivity MessageActivity { get; }
    }
}
