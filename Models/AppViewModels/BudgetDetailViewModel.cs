using System.Collections.Generic;
using ASProjectProjector.Models;

namespace ASProjectProjector.ViewModels
{
    public class BudgetDetailViewModel
    {
        public ApplicationUser User {get;set;}
        public List<CountyProject> CountyProject {get;set;}
        public List<ProjectType> ProjectType {get;set;}
        public List<Material> Material {get;set;}
        public List<AdditionalCost> AdditionalCost {get;set;}
        public List<RestrictedCounty> RestrictedCounty {get;set;}
        public List<ProjectTypeMaterial> ProjectTypeMaterial {get;set;}
    }
}