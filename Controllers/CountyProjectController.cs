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

        public async Task<IActionResult> Index()
        {
            var model = new AllProjectsViewModel();
            model.CountyProjectActive = await context.CountyProject
                            .Where(l => l.Active == true)
                            .OrderBy(l => l.CodeName).ToListAsync();

            model.CountyProjectInactive = await context.CountyProject
                            .Where(l => l.Active == false)
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

        public async Task<IActionResult> Detail([FromRoute]int? id)
        {
            // If no id was in the route, return 404
            if (id == null)
            {
                return NotFound();
            }

            var project = await context.CountyProject
                    .Include(s => s.User)
                    .SingleOrDefaultAsync(m => m.CountyProjectId == id);

            // If product not found, return 404
            if (project == null)
            {
                return NotFound();
            }

            var projectTypeName = await context.ProjectType
                    .SingleOrDefaultAsync(m => m.ProjectTypeId == project.ProjectTypeId);

            ProjectDetailViewModel model = new ProjectDetailViewModel();
            model.CountyProject = project;
            model.ProjectType = projectTypeName;

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
                return RedirectToAction("Index");
        }
    }
}