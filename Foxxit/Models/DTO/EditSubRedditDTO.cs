using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Models.DTO
{
    public class EditSubRedditDTO
    {
        public EditSubRedditDTO()
        {
        }

        public string Password { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
    }
}