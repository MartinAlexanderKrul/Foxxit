using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Extensions
{
    public static class Extensions
    {
        public static bool ContainsCaseInsensitive(this string text, string value,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return text.Contains(value, stringComparison);
        }
    }
}