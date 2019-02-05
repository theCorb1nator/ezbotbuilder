using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Teams.Commands.Builders;

namespace Teams.Commands
{
    public abstract class ModuleBase : ModuleBase<ITurnContext> { }

    /// <summary>
    ///     Provides a base class for a command module to inherit from.
    /// </summary>
    /// <typeparam name="T">A class that implements <see cref="ITurnContext"/>.</typeparam>
    public abstract class ModuleBase<T> : IModuleBase
        where T : class, ITurnContext
    {
        /// <summary>
        ///     The underlying context of the command.
        /// </summary>
        public T Context { get; private set; }

        /// <summary>
        ///     Sends a message to the source channel.
        /// </summary>
        /// <param name="message">
        /// Contents of the message
        /// </param>
        protected virtual async Task<ResourceResponse> ReplyAsync(string message)
        {
            return await Context.SendActivityAsync(message).ConfigureAwait(false);
        }

        /// <summary>
        ///     Sends a message to the source channel.
        /// </summary>
        /// <param name="message">
        /// Contents of the message; optional only if <paramref name="embed" /> is specified.
        /// </param>
        /// <param name="ativity">An activity to be displayed alongside the <paramref name="message"/>.</param>
        protected virtual async Task<ResourceResponse> ReplyAsync(IActivity activity, string message = null)
        {
            return await Context.SendActivityAsync(activity).ConfigureAwait(false);
        }


        /// <summary>
        ///     The method to execute before executing the command.
        /// </summary>
        /// <param name="command">The <see cref="CommandInfo"/> of the command to be executed.</param>
        protected virtual void BeforeExecute(CommandInfo command)
        {
        }
        /// <summary>
        ///     The method to execute after executing the command.
        /// </summary>
        /// <param name="command">The <see cref="CommandInfo"/> of the command to be executed.</param>
        protected virtual void AfterExecute(CommandInfo command)
        {
        }

        /// <summary>
        ///     The method to execute when building the module.
        /// </summary>
        /// <param name="commandService">The <see cref="CommandService"/> used to create the module.</param>
        /// <param name="builder">The builder used to build the module.</param>
        protected virtual void OnModuleBuilding(CommandService commandService, ModuleBuilder builder)
        {
        }

        //IModuleBase
        void IModuleBase.SetContext(ITurnContext context)
        {
            var newValue = context as T;
            Context = newValue ?? throw new InvalidOperationException($"Invalid context type. Expected {typeof(T).Name}, got {context.GetType().Name}.");
        }
        void IModuleBase.BeforeExecute(CommandInfo command) => BeforeExecute(command);
        void IModuleBase.AfterExecute(CommandInfo command) => AfterExecute(command);
        void IModuleBase.OnModuleBuilding(CommandService commandService, ModuleBuilder builder) => OnModuleBuilding(commandService, builder);
    }
}
