using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;

namespace Foxxit.Services.ViewModelServices
{
    public class MainPageViewModelService
    {
        public string GetTimeStamp(Post post)
        {
            var totalMinutes = (DateTime.Now - post.CreatedAt).TotalMinutes;
            string result = string.Empty;

            switch (totalMinutes)
            {
                case var expression when totalMinutes < 1:
                    result = $"{totalMinutes} less than a minute ago";
                    break;

                case var expression when totalMinutes < 60 && totalMinutes >= 1:
                    var minutes = Math.Round(totalMinutes, MidpointRounding.AwayFromZero);
                    result = minutes > 1 ? $"{minutes} minutes ago" : $"{minutes} minute ago";
                    break;

                case var expression when totalMinutes < 1440 && totalMinutes >= 60:
                    var hours = Math.Round(totalMinutes / 60, MidpointRounding.AwayFromZero);
                    result = hours > 1 ? $"{hours} hours ago" : $"{hours} hour ago";
                    break;

                case var expression when totalMinutes >= 1440:
                    var days = Math.Round(totalMinutes / 60 / 60, MidpointRounding.AwayFromZero);
                    result = days > 0 ? $"{days + 1} days ago" : $"{days + 1} day ago";
                    break;
            }

            return result;
        }
    }
}