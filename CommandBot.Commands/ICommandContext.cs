using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Teams;
namespace Teams.Commands
{
    /// <summary>
    ///     Represents a context of a command. This may include the client, channel, user, and message.
    /// </summary>
    public interface ICommandContext : ITurnContext
    {
        IUser User { get; }

        IMessageActivity Activity { get; }
    }
}