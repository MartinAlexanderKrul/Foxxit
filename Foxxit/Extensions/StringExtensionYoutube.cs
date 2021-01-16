using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Foxxit.Extensions
{
    public static class YoutubeExtension
    {
        public static string GetYoutubeId(this string url)
        {
            var uri = new Uri(url);
            var query = HttpUtility.ParseQueryString(uri.Query);

            if (query.AllKeys.Contains("v"))
            {
                return query["v"];
            }

            return uri.Segments.Last();
        }
    }
}