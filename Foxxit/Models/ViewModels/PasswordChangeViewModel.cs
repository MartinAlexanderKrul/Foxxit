using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Models.ViewModels
{
    public class PasswordChangeViewModel
    {

        [Required, StringLength(255, ErrorMessage = "Must be between 6 and 255 characters", MinimumLength = 6), DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required, StringLength(255, ErrorMessage = "Must be between 6 and 255 characters", MinimumLength = 6), DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required, DataType(DataType.Password), Compare("NewPassword", ErrorMessage = "The password does not match the confirmation password!")]
        public string ConfirmPassword { get; set; }

        public string Message { get; set; }

        public PasswordChangeViewModel()
        {
        }
    }
}