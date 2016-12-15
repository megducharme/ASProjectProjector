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
    public class RestrictedCountyController : Controller
    {
        private ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> _userManager;
        public RestrictedCountyController(UserManager<ApplicationUser> userManager, ApplicationDbContext ctx)
        {
            _userManager = userManager;
            context = ctx;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [HttpGet]
        public async Task<IActionResult> AddDonation()
        {
            RestrictedCountyViewModel model = new RestrictedCountyViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddDonation(RestrictedCounty donation)
        {
            ModelState.Remove("donation.User");

            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                donation.User = user;

                context.Add(donation);

                await context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "CountyProfile");
        }
    }
}