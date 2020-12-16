using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Models.Entities
{
    public class Notification : IIdentityEntity
    {
        public Notification(User receiver, string content)
        {
            Receiver = receiver;
            Content = content;
            ReceivedAt = DateTime.Now;
        }

        public Notification()
        {
        }

        public long Id { get; set; }
        public string Content { get; set; }
        public User Receiver { get; set; }
        public long ReceiverId { get; set; }
        public DateTime ReceivedAt { get; set; }
        public bool HasBeenRead { get; set; }
        public PostBase Issue { get; set; }
    }
}