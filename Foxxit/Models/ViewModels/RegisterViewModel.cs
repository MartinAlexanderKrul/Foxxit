﻿using System.ComponentModel.DataAnnotations;

namespace Foxxit.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Username must be between 3 and 50 characters!", MinimumLength = 3)]
        [RegularExpression("([0-9a-zA-Z._+@-])+", ErrorMessage = "Username cannot contain any special character!")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Password must be between 6 and 50 characters!", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Password be between 6 and 50 characters!", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password does not match the confirmation password!")]
        public string ConfirmPassword { get; set; }

        public string DisplayName { get; set; }
        public string AvatarUrl { get; set; }
        public string Message { get; set; }

        public RegisterViewModel()
        {
        }
    }
}