using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Models.ViewModels
{
    public class UsernameChangeViewModel
    {
        public UsernameChangeViewModel()
        {
        }

        [Required]
        [StringLength(50, ErrorMessage = "Username must be between 3 and 50 characters!", MinimumLength = 3)]
        [RegularExpression("([0-9a-zA-Z._+@-])+", ErrorMessage = "Username cannot contain any special character!")]
        public string NewUserName { get; set; }

        public string Message { get; set; }
    }
}