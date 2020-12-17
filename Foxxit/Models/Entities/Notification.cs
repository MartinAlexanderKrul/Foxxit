using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Models.Entities
{
    public class Notification : IIdentityEntity
    {
        public Notification(User receiver, User sender)
        {
            Receiver = receiver;
            Sender = sender;
        }

        public Notification()
        {
        }

        public long Id { get; set; }
        public User Receiver { get; set; }
        public long ReceiverId { get; set; }
        public User Sender { get; set; }
        public long SenderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool HasBeenRead { get; set; }
        public Post PostBase { get; set; }
        public long PostBaseId { get; set; }

        public string Content
        {
            get { return $"{Sender.UserName} commented on your post {PostBase.Title}."; }
        }
    }
}