using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Foxxit.Models.DTO
{
    public class NetworkCredentials : ICredentialsByHost
    {
        public NetworkCredentials()
        {
        }

        public NetworkCredential GetCredential(string host, int port, string authenticationType)
        {
            return new NetworkCredential();
        }
    }
}
