using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Teams.Commands;

namespace Teams.Net.Cards
{
    public class CardsModule : ModuleBase<ITurnContext>
    {
        [Command("test")]
        [Alias("test", "hello")]
        public Task PingAsync()
           => ReplyAsync("testpong!");
    }
}
