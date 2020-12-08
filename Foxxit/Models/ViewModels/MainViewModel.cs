using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;

namespace Foxxit.Models.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
        }

        public List<Post> Posts { get; set; }
    }
}