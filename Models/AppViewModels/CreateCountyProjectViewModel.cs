using System.Collections.Generic;
using ASProjectProjector.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASProjectProjector.ViewModels
{
    public class CreateCountyProjectViewModel
    {
        public ApplicationUser User {get;set;}
        public List<SelectListItem> ProjectTypeId {get;set;}
        public CountyProject CountyProject {get;set;}
        public double ProjectSqFt {get;set;}
    }
}