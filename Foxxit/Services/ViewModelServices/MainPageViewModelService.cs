using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;

namespace Foxxit.Services.ViewModelServices
{
    public class MainPageViewModelService : IMainPageViewModelService
    {
        public string GetTimeStamp(Post post)
        {
            var totalMinutes = (DateTime.Now - post.CreatedAt).TotalMinutes;
            string result = string.Empty;

            switch (totalMinutes)
            {
                case var expression when totalMinutes < 1:
                    result = "less than a minute";
                    break;

                case var expression when totalMinutes < 60 && totalMinutes >= 1:
                    var minutes = Math.Round(totalMinutes, MidpointRounding.AwayFromZero);
                    result = minutes > 1 ? $"{minutes} minutes" : $"{minutes} minute";
                    break;

                case var expression when totalMinutes < 1440 && totalMinutes >= 60:
                    var hours = Math.Round(totalMinutes / 60, MidpointRounding.AwayFromZero);
                    result = hours > 1 ? $"{hours} hours" : $"{hours} hour";
                    break;

                case var expression when totalMinutes >= 1440:
                    var days = Math.Round(totalMinutes / 60 / 24, MidpointRounding.AwayFromZero);
                    result = days > 1 ? $"{days} days" : $"{days} day";
                    break;
            }

            return result;
        }
    }
}