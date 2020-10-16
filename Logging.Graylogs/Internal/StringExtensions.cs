using System;

namespace Deposit.PG.Logging.Graylogs.Internal
{
    internal static class StringExtensions
    {
        internal static bool EqualsOrdinalIgnoreCase(this string text, string text2)
        {
            return string.Equals(text, text2, StringComparison.OrdinalIgnoreCase);
        }
    }
}
