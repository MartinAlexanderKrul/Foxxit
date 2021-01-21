using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Models.DTO
{
    public class EditPostBaseDTO
    {
        public EditPostBaseDTO()
        {
        }

        public string Password { get; set; }
        public long Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public string Text { get; set; }
    }
}