using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Models
{
    public class RegistrationEmailData
    {
        public string ConfirmationLink { get; protected set; }
        public string UserName { get; protected set; }
        public RegistrationEmailData(string confirmationLink, string userName)
        {
            ConfirmationLink = confirmationLink;
            UserName = userName;
        }
    }
}
