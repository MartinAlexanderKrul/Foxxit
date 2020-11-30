namespace Foxxit.Models.Entities
{
    public class Vote
    {
        public long Id { get; set; }
        
        //each vote has one Giver
        public FoxxitUser GivenBy { get; set; }
        
        //each vote has one Owner
        public FoxxitUser Owner { get; set; }
        
        //each vote belongs to a certain Post
        public Post Post { get; set; }
        
    }
}