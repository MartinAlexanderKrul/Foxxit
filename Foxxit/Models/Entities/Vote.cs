namespace Foxxit.Models.Entities
{
    public class Vote
    {
        public long Id { get; set; }
        public bool IsNegative { get; set; }

        //each vote has one Owner
        public FoxxitUser Owner { get; set; }
        public long FoxxitUserId { get; set; }
        
        //each vote belongs to a certain PostBase
        public PostBase Postbase { get; set; }
        public long PostBaseId { get; set; }

    }
}