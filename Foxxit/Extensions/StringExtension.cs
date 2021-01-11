using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Extensions
{
    public static class Extensions
    {
        public static bool ContainsCaseInsensitive(
            this string text,
            string value,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return text.Contains(value, stringComparison);
        }

        public static string ShortenDisplayName(this string displayName)
        {
            displayName = displayName.Contains('@')
                               ? displayName.Split('@')[0]
                               : displayName;

            displayName = displayName.Length > 16
                    ? displayName.Substring(0, 13) + "..."
                    : displayName;

            return displayName;
        }
    }
}