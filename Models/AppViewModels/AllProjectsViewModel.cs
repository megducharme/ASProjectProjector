using System.Collections.Generic;
using ASProjectProjector.Models;

namespace ASProjectProjector.ViewModels
{
    public class AllProjectsViewModel
    {
        public List<CountyProject> CountyProjectActive {get;set;}
        public List<CountyProject> CountyProjectInactive {get;set;}  

    }
}