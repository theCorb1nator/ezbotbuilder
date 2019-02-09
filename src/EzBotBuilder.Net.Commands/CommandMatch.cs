using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EzBotBuilder.Commands
{
    public struct CommandMatch
    {
        /// <summary> The command that matches the search result. </summary>
        public CommandInfo Command { get; }
        /// <summary> The alias of the command. </summary>
        public string Alias { get; }

        public CommandMatch(CommandInfo command, string alias)
        {
            Command = command;
            Alias = alias;
        }

        public Task<PreconditionResult> CheckPreconditionsAsync(ITurnContext context, IServiceProvider services = null)
            => Command.CheckPreconditionsAsync(context, services);
        public Task<ParseResult> ParseAsync(ITurnContext context, SearchResult searchResult, PreconditionResult preconditionResult = null, IServiceProvider services = null)
            => Command.ParseAsync(context, Alias.Length, searchResult, preconditionResult, services);
        public Task<IResult> ExecuteAsync(ITurnContext context, IEnumerable<object> argList, IEnumerable<object> paramList, IServiceProvider services)
            => Command.ExecuteAsync(context, argList, paramList, services);
        public Task<IResult> ExecuteAsync(ITurnContext context, ParseResult parseResult, IServiceProvider services)
            => Command.ExecuteAsync(context, parseResult, services);
    }
}
