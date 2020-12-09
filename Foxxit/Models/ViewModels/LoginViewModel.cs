using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required, StringLength(50, ErrorMessage = "Must be between 3 and 50 characters", MinimumLength = 3)]
        public string UserName { get; set; }

        [Required, StringLength(50, ErrorMessage = "Must be between 6 and 50 characters", MinimumLength = 6), DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string DisplayName { get; set; }
        public string AvatarUrl { get; set; }
        public string Message { get; set; }
        public string ReturnUrl { get; set; }
        public ICollection<AuthenticationScheme> ExternalLogins { get; set; }

        public LoginViewModel()
        {
        }

        public LoginViewModel(string returnUrl, ICollection<AuthenticationScheme> externalLogins)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = externalLogins;
        }
    }
}