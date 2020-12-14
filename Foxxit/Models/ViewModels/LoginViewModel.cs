using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

namespace Foxxit.Models.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
        }

        public LoginViewModel(string returnUrl, ICollection<AuthenticationScheme> externalLogins)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = externalLogins;
        }

        [Required]
        [StringLength(50, ErrorMessage = "Username must be between 3 and 50 characters!", MinimumLength = 3)]
        [RegularExpression("([0-9a-zA-Z._+@-])+", ErrorMessage = "Username cannot contain any special character!")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Password must be between 6 and 50 characters!", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string DisplayName { get; set; }
        public string AvatarUrl { get; set; }
        public string Message { get; set; }
        public string ReturnUrl { get; set; }
        public ICollection<AuthenticationScheme> ExternalLogins { get; set; }
    }
}