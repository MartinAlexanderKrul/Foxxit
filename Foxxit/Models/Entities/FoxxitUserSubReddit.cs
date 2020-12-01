namespace Foxxit.Models.Entities
{
    public class FoxxitUserSubReddit
    {
        public long UserId { get; set; }
        public FoxxitUser User { get; set; }
        public long SubRedditId { get; set; }
        public SubReddit SubReddit { get; set; }
    }
}