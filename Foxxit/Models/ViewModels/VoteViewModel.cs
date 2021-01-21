using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;

namespace Foxxit.Models.ViewModels
{
    public class VoteViewModel
    {
        public PostBase PostBase { get; set; }
        public int Value { get; set; } = 0;
        public int Count { get; set; }
    }
}
