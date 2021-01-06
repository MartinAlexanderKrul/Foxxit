using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foxxit.Models.Entities;
using Microsoft.AspNetCore.Authentication;

namespace Foxxit.Models.ViewModels
{
    public class RequireEmailViewModel
    {
        public RequireEmailViewModel()
        {
        }

        public User User { get; set; }
    }
}