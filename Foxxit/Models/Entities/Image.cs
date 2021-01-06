using System;
using Foxxit.Services.Interfaces;

namespace Foxxit.Models.Entities
{
    public class Image : IIdentityEntity, ISoftDeletable
    {
        public Image()
        {
            Name = Guid.NewGuid().ToString();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Format { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] Stream { get; set; }
    }
}