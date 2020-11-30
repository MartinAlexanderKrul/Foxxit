using System.Collections.Generic;

namespace Foxxit.Models.Entities
{
    public class SubReddit
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
       
        //each SubReddit has many posts
        public List<Post> Posts { get; set; }
        
        //each SubReddit has many members
        public ICollection<FoxxitUser> Members { get; set; }
        
        //each SubReddit has one Creator/Owner
        public FoxxitUser Owner { get; set; }

    }
}