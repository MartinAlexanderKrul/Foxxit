namespace Foxxit.Models.Entities
{
    public class FoxxitUserSubReddit
    {
        public long FoxxitUserId { get; set; }
        public FoxxitUser FoxxitUser { get; set; }
        public long SubRedditId { get; set; }
        public SubReddit SubReddit { get; set; }
    }
}