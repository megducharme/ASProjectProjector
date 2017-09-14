using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ASProjectProjector.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {   
        [Required]
        public string CountyName {get;set;}
        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DisplayName("Homes Figure")]
        public decimal HomesFigure {get;set;}
        [Required]
        [DisplayName("Toal Work Crews")]
        public decimal TotalWorkCrews {get;set;}
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DisplayName("Total Budget")]
        public decimal TotalBudget {get;set;}
    }
}