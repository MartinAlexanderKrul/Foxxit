namespace Foxxit.Models.Entities
{
    public class Vote
    {
        public long Id { get; set; }
        public bool IsNegative { get; set; }

        //each vote has one Giver
        public FoxxitUser GivenBy { get; set; }

        //each vote has one Owner
        public FoxxitUser Owner { get; set; }
        public long FoxxitUserId { get; set; }
        
        //each vote belongs to a certain Post
        public Post Post { get; set; }
        public long PostId { get; set; }
        
        //each vote belongs to a certain Comment
        public Comment Comment { get; set; }
        public long CommentId { get; set; }
        
    }
}