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
    public class AdditionalCostController : Controller
    {
        private ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> _userManager;
        public AdditionalCostController(UserManager<ApplicationUser> userManager, ApplicationDbContext ctx)
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

            var model = new AllAdditionalCostsViewModel();
            model.AdditionalCost = await context.AdditionalCost
                            .Where(l => l.User.Id == currentUserId).ToListAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            AdditionalCostViewModel model = new AdditionalCostViewModel();
            model.CountyProjectId = id;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCost(AdditionalCostViewModel additionalCostViewModel)
        {
            ModelState.Remove("additionalCost.User");

            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                AdditionalCost additionalCost = new AdditionalCost()
                {
                    User = user,
                    Description = additionalCostViewModel.AdditionalCost.Description,
                    CountyProjectId = additionalCostViewModel.CountyProjectId,
                    Amount = additionalCostViewModel.AdditionalCost.Amount
                };

                context.Add(additionalCost);
                await context.SaveChangesAsync();
            }
            return RedirectToAction("Detail", "CountyProject", new {id = additionalCostViewModel.CountyProjectId });
        }

        [RouteAttribute("AdditionalCost/Delete/{id}")]
        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteCost([FromRoute]int id)
        {
            var cost = await context.AdditionalCost
                .Where(l => l.AdditionalCostId == id).SingleOrDefaultAsync();

                context.Remove(cost);

                await context.SaveChangesAsync();

                return RedirectToAction("Index", "AdditionalCost");
        }
    }
}