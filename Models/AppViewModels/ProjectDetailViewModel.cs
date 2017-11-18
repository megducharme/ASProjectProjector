using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ASProjectProjector.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASProjectProjector.ViewModels
{
    public class ProjectDetailViewModel
    {
        public CountyProject CountyProject {get;set;}
        public ApplicationUser User {get;set;}
        public ProjectType ProjectType {get;set;}
        public List<Material> MaterialList {get;set;}
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TotalProjectCost {get;set;}
    }
}