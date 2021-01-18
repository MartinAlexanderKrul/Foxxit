using System;
using Foxxit.Services.EntityServices;

namespace Foxxit.Models.Entities
{
    public class Vote : IIdentityEntity
    {
        public long Id { get; set; }
        public int Value { get; set; }
        public User Owner { get; set; }
        public long OwnerId { get; set; }
        public PostBase Postbase { get; set; }
        public long PostBaseId { get; set; }
        public DateTime CreatedOn { get; } = DateTime.UtcNow;
    }
}