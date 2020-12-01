using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Models.DTOs
{
    public class ConfirmMailDto
    {
        public string MailTo { get; set; }
        public string Username { get; set; }
        public string ConfirmationLink { get; set; }
        public IDictionary<string, string> CustomMessageHeaders { get; set; }
    }
}
