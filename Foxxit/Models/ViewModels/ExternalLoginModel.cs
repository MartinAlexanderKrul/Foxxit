using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Foxxit.Models.ViewModels
{
    public class ExternalLoginModel
    {
        public ExternalLoginModel()
        {
        }

        [Required]
        [StringLength(50, ErrorMessage = "Must be between 5 and 50 characters", MinimumLength = 5)]
        public string Email { get; set; }
    }
}