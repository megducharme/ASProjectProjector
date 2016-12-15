using System.Collections.Generic;
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
        public decimal TotalProjectCost {get;set;}
        public decimal TotalBudget {get;set;}
        public decimal RemainingBudget {get;set;}
        public decimal TotalWorkCrews {get;set;}

    }
}