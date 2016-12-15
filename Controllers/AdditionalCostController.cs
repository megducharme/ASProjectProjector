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
        public async Task<IActionResult> AddAdditionalCost()
        {
            AdditionalCostViewModel model = new AdditionalCostViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddDonation(AdditionalCost additionalCost)
        {
            ModelState.Remove("additionalCost.User");

            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                additionalCost.User = user;

                context.Add(additionalCost);

                await context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "AdditionalCost");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var User = await GetCurrentUserAsync();
            var currentUserId = User.Id;

            var model = new AllDonationsViewModel();
            model.RestrictedCounty = await context.RestrictedCounty
                            .Where(l => l.User.Id == currentUserId)
                            .OrderBy(l => l.ContactPerson).ToListAsync();

            return View(model);
        }

        [RouteAttribute("RestrictedCounty/Delete/{id}")]
        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteCost([FromRoute]int id)
        {
            var donation = await context.RestrictedCounty
                .Where(l => l.RestrictedCountyId == id).SingleOrDefaultAsync();

                context.Remove(donation);

                await context.SaveChangesAsync();

                return RedirectToAction("Index", "RestrictedCounty");
        }
    }
}