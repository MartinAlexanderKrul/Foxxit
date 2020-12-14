using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;

namespace Foxxit.Models.ViewModels
{
    public class SubRedditViewModel
    {
        public SubReddit SubReddit { get; set; }
        public User User { get; set; }
    }
}
