using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Foxxit.Models.DTO
{
    public class NetworkCredentials : ICredentialsByHost
    {
        public NetworkCredential GetCredential(string host, int port, string authenticationType)
        {
            throw new NotImplementedException();
        }

        public NetworkCredentials()
        {
        }
    }
}