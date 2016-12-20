using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ASProjectProjector.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASProjectProjector.ViewModels
{
    public class CountyProfileViewModel
    {
        public List<CountyProject> CountyProject {get;set;}
        public List<CountyProject> CountyProjectActive {get;set;}
        public List<CountyProject> CountyProjectInactive {get;set;}
        public ApplicationUser User {get;set;}
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TotalProjectCost {get;set;}
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TotalBudget {get;set;}
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal RemainingBudget {get;set;}
        public decimal TotalWorkCrews {get;set;}
        public List<ProjectType> ProjectType {get;set;}
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TotalDonations {get;set;}

    }
}