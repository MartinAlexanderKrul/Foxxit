namespace Foxxit.Models.Entities
{
    public class Comment:PostBase
    {
        //For comments hierarchy
        public long OriginalCommentId { get; set; }
        
        public Post Post { get; set; }
        public long PostId { get; set; }
    }
}