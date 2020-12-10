using Foxxit.Enums;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Attributes.RoleServices
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AuthorizedRoles : AuthorizeAttribute
    {
        public AuthorizedRoles(params Role[] allowedRoles)
        {
            var allowedRolesAsStrings = allowedRoles.Select(x => Role.GetName(typeof(Role), x));
            Roles = string.Join(",", allowedRolesAsStrings);
        }
    }
}
