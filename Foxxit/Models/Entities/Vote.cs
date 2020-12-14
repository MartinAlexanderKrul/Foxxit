namespace Foxxit.Models.Entities
{
    public class Vote : IIdentityEntity
    {
        public long Id { get; set; }
        public bool IsNegative { get; set; }
        public User Owner { get; set; }
        public long FoxxitUserId { get; set; }
        public PostBase Postbase { get; set; }
        public long PostBaseId { get; set; }
    }
}