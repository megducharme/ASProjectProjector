using System;
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
    public class CountyProfileController : Controller
    {
        private ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CountyProfileController(UserManager<ApplicationUser> userManager, ApplicationDbContext ctx)
        {
            _userManager = userManager;
            context = ctx;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var User = await GetCurrentUserAsync();
            var currentUserId = User.Id;

            CountyProfileViewModel model = new CountyProfileViewModel();

            model.CountyProject = await context.CountyProject
                .Where(m => m.User.Id == currentUserId)
                .ToListAsync();

            decimal sum = 0;
            foreach (var project in model.CountyProject)
            {
                sum += project.TotalProjectCost;
            }
            model.TotalProjectCost = sum;            

            return View(model);

        }

        // public async Task<IActionResult> EditWorkCrews()
        // {

        // }
            
    }
}