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
    public class BudgetController : Controller
    {
        private ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> _userManager;
        public BudgetController(UserManager<ApplicationUser> userManager, ApplicationDbContext ctx)
        {
            _userManager = userManager;
            context = ctx;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public async Task<IActionResult> Index()
        {
            var model = new BudgetDetailViewModel();
            model.ProjectType = await context.ProjectType
                            .OrderBy(l => l.Name).ToListAsync();

            model.Material = await context.Material
                            .OrderBy(l => l.Name).ToListAsync();

            return View(model);
        }

        // public async Task<IActionResult> ProductTypes()
        // {
        //     var model = new ProductTypeDetailViewModel(context);
        //     model.ProductTypes = await context.ProductType.ToListAsync();
        //     model.Products = await context.Product.ToListAsync();
            
        //     var productTypes = context.ProductType.ToList();

        //     productTypes.ForEach(pt => pt.Quantity = context.ProductSubType.Count(p => p.ProductTypeId == pt.ProductTypeId) );

        //     model.ProductTypes = productTypes;

        //     return View(model);
        // }

        // public async Task<IActionResult> ProductTypeDetail([FromRoute]int id)
        // {
        //     var model = new ProductTypeDetailViewModel(context);
        //     model.ProductSubTypes = await context.ProductSubType.ToListAsync();
            
        //     var queriedProds = 
        //     from prd in context.Product
        //     join prst in context.ProductSubType on prd.ProductId equals prst.ProductSubTypeId
        //     where prd.ProductTypeId == id
        //     select prd;
            
        //     model.Products = await queriedProds.ToListAsync();
        //     var allProductsOfProductType = context.Product 
        //                     .Where(s => s.ProductTypeId == id) 
        //                     .OrderBy(s => s.Name);

        //     model.Products = await allProductsOfProductType.ToListAsync();

        //     return View(model);
        // }

        // public async Task<IActionResult> Detail([FromRoute]int? id)
        // {
        //     // If no id was in the route, return 404
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var product = await context.Product
        //             .Include(s => s.User)
        //             .SingleOrDefaultAsync(m => m.ProductId == id);

        //     // If product not found, return 404
        //     if (product == null)
        //     {
        //         return NotFound();
        //     }

        //     ProductDetailViewModel model = new ProductDetailViewModel(context);
        //     model.Product = product;

        //     return View(model);
        // }

        // [HttpGet]
        // [Authorize]
        // public IActionResult Create()
        // {

        //     var ProductTypesId = context.ProductType
        //                                .OrderBy(l => l.Name)
        //                                .AsEnumerable()
        //                                .Select(li => new SelectListItem { 
        //                                    Text = li.Name,
        //                                    Value = li.ProductTypeId.ToString()
        //                                 }).ToList();

        //     ProductTypesId.Insert(0, new SelectListItem{
        //         Text = "Select a product type!",
        //         Value = 0.ToString()
        //     });

        //     SellProductViewModel model = new SellProductViewModel(context);

        //     // var productsOnOrder =
        //     //     from ord in context.Order
        //     //     join uid in context.User on ord.UserId equals uid.UserId
        //     //     join op in context.OrderProduct on ord.OrderId equals op.OrderId
        //     //     join prod in context.Product on op.ProductId equals prod.ProductId
        //     //     where ord.UserId == ActiveUser.Instance.User.UserId 
        //     //     && ord.PaymentTypeId == null
        //     //     select prod;

        //     // model.count = productsOnOrder.Count();
        //     model.ProductTypeId = ProductTypesId;
                                        
        //     return View(model);
        // }

        // [HttpGet]
        // public DbSet<ProductSubType> GetSubTypesForDropdown()
        // {
        //     var subTypes  = context.ProductSubType;
        //     return subTypes; 
        // }

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create(Product product)
        // {
        //     var User = await GetCurrentUserAsync();
        //     product.User = User;

        //      if (!ModelState.IsValid)
        //     {
        //         return RedirectToAction("Create", "Products");
        //     }

        //     context.Add(product);

        //     try
        //     {
        //         context.SaveChanges();
        //         return RedirectToAction("Index", "Products");
        //     }
            
        //     catch (DbUpdateException)
        //     {
        //         return RedirectToAction("Create", "Products");
        //     }
        // }

        // public IActionResult Error()
        // {
        //     return View();
        // }
    }
}