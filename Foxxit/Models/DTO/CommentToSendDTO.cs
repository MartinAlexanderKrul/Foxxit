using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Models.DTO
{
    public class CommentToSendDTO
    {
        public CommentToSendDTO(long id, long postedBy, string text)
        {
            CommentId = id;
            PostedById = postedBy;
            Text = text;
        }

        public long CommentId { get; set; }
        public long PostedById { get; set; }
        public string Text { get; set; }
    }
}
