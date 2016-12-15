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

            //retrieve the staff's projects
            model.CountyProject = await context.CountyProject
                .Where(m => m.User.Id == currentUserId && m.Active == true)
                .ToListAsync();

            //add up total project cost
            decimal allProjectCostSum = 0;
            foreach (var project in model.CountyProject)
            {
                allProjectCostSum += project.TotalProjectCost;
            }
            model.TotalProjectCost = allProjectCostSum;

            //display active and inactive projects
            model.CountyProjectActive = await context.CountyProject
                .Where(l => l.Active == true && l.User.Id == currentUserId)
                .OrderBy(l => l.CodeName).ToListAsync();

            model.CountyProjectInactive = await context.CountyProject
                .Where(l => l.Active == false && l.User.Id == currentUserId)
                .OrderBy(l => l.CodeName).ToListAsync();            

            //total budget
            var rcDonations = await context.RestrictedCounty
                .Where(l => l.User.Id == currentUserId).ToListAsync();

            decimal totalDonations = 0;
            foreach(var donation in rcDonations)
            {
                totalDonations += donation.Amount;
            }

            model.TotalBudget = (User.TotalWorkCrews * User.HomesFigure) + totalDonations;

            //reamining budget
            model.RemainingBudget = model.TotalBudget - model.TotalProjectCost;

            //projected budget



            return View(model);
        }
            
    }
}