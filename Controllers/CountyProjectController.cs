using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASProjectProjector.Data;
using Microsoft.EntityFrameworkCore;
using ASProjectProjector.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASProjectProjector.ViewModels;
using System.Collections.Generic;
using ASProjectProjector.Models.AccountViewModels;
using ASProjectProjector.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ASProjectProjector.Controllers
{
    public class CountyProjectController : Controller
    {
        private ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CountyProjectController(UserManager<ApplicationUser> userManager, ApplicationDbContext ctx)
        {
            _userManager = userManager;
            context = ctx;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var User = await GetCurrentUserAsync();
            var currentUserId = User.Id;

            var model = new AllProjectsViewModel();
            model.CountyProjectActive = await context.CountyProject
                            .Where(l => l.Active == true && l.User.Id == currentUserId)
                            .OrderBy(l => l.CodeName).ToListAsync();

            model.CountyProjectInactive = await context.CountyProject
                            .Where(l => l.Active == false && l.User.Id == currentUserId)
                            .OrderBy(l => l.CodeName).ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var ProjectTypesIdDropDown = context.ProjectType
                                       .OrderBy(l => l.Name)
                                       .AsEnumerable()
                                       .Select(li => new SelectListItem { 
                                           Text = li.Name,
                                           Value = li.ProjectTypeId.ToString()
                                        }).ToList();
            
            ProjectTypesIdDropDown.Insert(0, new SelectListItem{
                Text = "Project Type",
                Value = 0.ToString()
            });

            var model = new CreateCountyProjectViewModel();
            model.ProjectTypeId = ProjectTypesIdDropDown;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(CountyProject countyProject)
        {
            
            ModelState.Remove("countyProject.User");

            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                countyProject.User = user;

                context.Add(countyProject);

                await context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "CountyProfile");
        }

        
        [HttpGet]
        [RouteAttribute("/Detail/{id}")]
        public async Task<IActionResult> Detail([FromRoute]int? id)
        {
            // If no id was in the route, return 404
            if (id == null)
            {
                return NotFound();
            }

            ProjectDetailViewModel model = new ProjectDetailViewModel();

            model.CountyProject = await context.CountyProject
                    .SingleOrDefaultAsync(m => m.CountyProjectId == id);  

            var specificProject = model.CountyProject;  

            if (model.CountyProject == null)
            {
                return NotFound();
            }

                //get specificProject
                model.ProjectType = await context.ProjectType
                        .SingleOrDefaultAsync(m => m.ProjectTypeId == model.CountyProject.ProjectTypeId);
                
                //get all materials for specificProject's prejct type
                model.MaterialList =
                (from mat in context.Material
                join projectmaterial in context.ProjectTypeMaterial on mat.MaterialId equals projectmaterial.MaterialId
                join projtype in context.ProjectType on projectmaterial.ProjectTypeId equals projtype.ProjectTypeId
                join ctyproj in context.CountyProject on projtype.ProjectTypeId equals ctyproj.ProjectTypeId
                where ctyproj.CountyProjectId == id
                select mat).ToList();

                //determine the total material cost based on the sqft the user input and the cost/sqft for each material
                decimal totalMaterialCost = 0;
                foreach(var material in model.MaterialList)
                {
                    totalMaterialCost += (material.CostSqFt * specificProject.ProjectSqFt);
                }

                //query the additional costs for that particular proejct
                var totalAdditionalCosts = 
                (from addcosts in context.AdditionalCost 
                join ctyprj in context.CountyProject on addcosts.CountyProjectId equals ctyprj.CountyProjectId
                select addcosts).ToList();

                model.AdditionalCosts = totalAdditionalCosts;

                //add up all the addional costs
                decimal sumAddCosts = 0;
                foreach(var cost in totalAdditionalCosts)
                {
                    sumAddCosts += cost.Amount;
                }

                //calculate the total project cost based on materials and additional costs
                model.TotalProjectCost = totalMaterialCost + sumAddCosts;

            return View(model);
        }

        [RouteAttribute("CountyProject/Activate/{id}")]
        [HttpPost("{id}")]
        public async Task<IActionResult> Activate([FromRoute]int? id)
        {
            var project = await context.CountyProject
                .Where(l => l.CountyProjectId == id).SingleOrDefaultAsync();
                project.Active = !project.Active;

                context.Update(project);

                await context.SaveChangesAsync();

                return RedirectToAction("Index", "CountyProfile");
        }

        [RouteAttribute("CountyProject/Delete/{id}")]
        [HttpPost("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int? id)
        {
            var project = await context.CountyProject
                .Where(l => l.CountyProjectId == id).SingleOrDefaultAsync();

                context.Remove(project);

                await context.SaveChangesAsync();

                return RedirectToAction("Index", "CountyProfile");
        }
    }
}