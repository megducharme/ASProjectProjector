using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
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
        public double HomesFigure {get;set;}
        [Required]
        public int TotalWorkCrews {get;set;}
        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double TotalBudget {get;set;}
        public ICollection<Project> Projects { get; set; }
        public ICollection<AdditionalCost> AdditionalCost { get; set; }
        public ICollection<RestrictedCounty> RestrictedCounty { get; set; }

    }
}
