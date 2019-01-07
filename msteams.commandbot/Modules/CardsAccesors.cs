using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.CommandBot.Modules
{
    /// <summary>
    /// This is a helper class to support the state accessors for the bot.
    /// </summary>
    public class CardsAccessors
    {
        /// <summary>
        /// The name of the dialog state.
        /// </summary>
        /// <remarks>Accessors require a unique name.</remarks>
        /// <value>The accessor name for the dialog state accessor.</value>
        public static readonly string DialogStateName = $"{nameof(CardsAccessors)}.DialogState";

        /// <summary>
        /// Initializes a new instance of the <see cref="CardsBotAccessors"/> class.
        /// Contains the <see cref="ConversationState"/> and associated <see cref="IStatePropertyAccessor{T}"/>.
        /// </summary>
        /// <param name="conversationState">The state object that stores the dialog state.</param>
        /// <param name="userState">The state object that stores the user state.</param>
        public CardsBotAccessors(ConversationState conversationState)
        {
            ConversationState = conversationState ?? throw new ArgumentNullException(nameof(conversationState));
        }

        /// <summary>
        /// Gets or sets the <see cref="IStatePropertyAccessor{T}"/> for ConversationDialogState.
        /// </summary>
        /// <value>
        /// The accessor stores the dialog state for the conversation.
        /// </value>
        public IStatePropertyAccessor<DialogState> ConversationDialogState { get; set; }

        /// <summary>
        /// Gets the <see cref="ConversationState"/> object for the conversation.
        /// </summary>
        /// <value>The <see cref="ConversationState"/> object.</value>
        public ConversationState ConversationState { get; }
    }
}
