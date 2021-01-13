namespace Foxxit.Models.Entities
{
    public class UserSubReddit : IIdentityEntity
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public long SubRedditId { get; set; }
        public SubReddit SubReddit { get; set; }
    }
}