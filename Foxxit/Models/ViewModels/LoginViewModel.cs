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
        [Required]
        public string UserName { get; set; }

        [Required, StringLength(255, ErrorMessage = "Must be between 6 and 255 characters", MinimumLength = 6), DataType(DataType.Password)]
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