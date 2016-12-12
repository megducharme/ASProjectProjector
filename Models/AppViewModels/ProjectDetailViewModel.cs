using System.Collections.Generic;
using ASProjectProjector.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASProjectProjector.ViewModels
{
    public class ProjectDetailViewModel
    {
        public CountyProject CountyProject {get;set;}
        public ApplicationUser User {get;set;}
        public ProjectType ProjectType {get;set;}
    }
}