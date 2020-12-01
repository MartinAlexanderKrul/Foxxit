namespace Foxxit.Models.Entities
{
    public class UserSubReddit
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public long SubRedditId { get; set; }
        public SubReddit SubReddit { get; set; }
    }
}