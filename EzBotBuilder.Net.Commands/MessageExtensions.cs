using System;
using System.Collections.Generic;
using System.Text;

namespace Teams.Net.Commands
{
    public static class MessageExtensions
    {

        /// <summary>
        ///     Gets whether the message starts with the provided string.
        /// </summary>
        public static bool HasStringPrefix(this string msg, string str, ref int argPos, StringComparison comparisonType = StringComparison.Ordinal)
        {
            var text = msg;
            if (!string.IsNullOrEmpty(text) && text.StartsWith(str, comparisonType))
            {
                argPos = str.Length;
                return true;
            }
            return false;
        }
    }
}
