using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Models.ViewModels
{
    public class ExternalLoginModel
    {
        [Required, StringLength(50, ErrorMessage = "Must be between 5 and 50 characters", MinimumLength = 5)]
        public string Email { get; set; }

        public ExternalLoginModel()
        {
        }
    }
}