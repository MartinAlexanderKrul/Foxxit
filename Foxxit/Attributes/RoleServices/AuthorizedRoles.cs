using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Foxxit.Attributes.RoleServices
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AuthorizedRoles : AuthorizeAttribute
    {
        public AuthorizedRoles(params UserRole[] roles)
        {
            var allowedRoles = roles.Select(r => UserRole.GetName(typeof(UserRole), r));
            Roles = string.Join(",", allowedRoles);
        }
    }
}
