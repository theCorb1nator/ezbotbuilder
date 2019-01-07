using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teams.Commands;

namespace Teams.CommandBot.Modules
{
    public class Module : ModuleBase<ITurnContext>
    {
        [Command("ping")]
        [Alias("pong", "hello")]
        public Task PingAsync()
            => ReplyAsync("pong!");


        [Command("next")]
        [Alias("next", "next steps")]
        public Task NextStepsAsync()
            => ReplyAsync("Great work corbin, now to implement cool features like interactive cards and such");
    }
}
