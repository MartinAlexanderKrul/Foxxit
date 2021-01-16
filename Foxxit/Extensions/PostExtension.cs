using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;

namespace Foxxit.Extensions
{
    public static class PostExtension
    {
        public static int NumOfComments(this Post post)
        {
            int amount = post.Comments.Count;

            foreach (var subComment in post.Comments)
            {
                amount += subComment.Comments.Count;
            }

            return amount;
        }
    }
}