﻿namespace Foxxit.Models
{
    public class RegistrationEmailData
    {
        public RegistrationEmailData(string confirmationLink, string userName)
        {
            ConfirmationLink = confirmationLink;
            UserName = userName;
        }

        public string ConfirmationLink { get; protected set; }
        public string UserName { get; protected set; }
    }
}