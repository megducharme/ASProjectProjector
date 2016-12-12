using System.Collections.Generic;
using ASProjectProjector.Models;

namespace ASProjectProjector.ViewModels
{
    public class CreateCountyProjectViewModel
    {
        public ApplicationUser User {get;set;}
        public List<ProjectType> ProjectTypes {get;set;}
        public ProjectType ProjectType {get;set;}
        public List<Material> Material {get;set;}
        public List<AdditionalCost> AdditionalCost {get;set;}
        public List<ProjectTypeMaterial> ProjectTypeMaterial {get;set;}
    }
}