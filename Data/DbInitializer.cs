using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ASProjectProjector.Models;
using ASProjectProjector.Data;

namespace BangazonDelta.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
              // Look for any products.
              if (context.Material.Any())
              {
                  return;   // DB has been seeded
              }

              //SEEDED MATERIALS
              var materials = new Material[]
              {
                  new Material {
                      Name = "Roof Decking Screws",
                      CostSqFt = 3.50,
                      CountSqFt = 15
                  },
                  new Material {
                      Name = "Roof Decking Screws",
                      CostSqFt = 3.50,
                      CountSqFt = 15
                  }
              };
              foreach (Material i in materials)
              {
                  context.Material.Add(i);
              }
              context.SaveChanges();

              //SEEDED PROJECTS
              var projects = new Project[]
              {
                  new Project {
                      Name = "Drywall",
                      EstimatedLengthInDays = 5,
                      FamilyName = "Blankenship",
                      Active = false,
                      User = 
                  }
                  new Project {
                      Name 
                  }

                  }
              }

            
               
              //   SUBCATEGORIES. MD - Seeding the database.
              var productSubType = new ProductSubType[]
              {
                  new ProductSubType { 
                      Name = "Pencils",
                      ProductTypeId = 3
                  },
                  new ProductSubType { 
                      Name = "Pens",
                      ProductTypeId = 3
                  },
                  new ProductSubType { 
                      Name = "Office Equipment",
                      ProductTypeId = 3
                  },
                  new ProductSubType { 
                      Name = "Music",
                      ProductTypeId = 1
                  },
                  new ProductSubType { 
                      Name = "Appliances",
                      ProductTypeId = 1
                  },
                  new ProductSubType { 
                      Name = "Phones",
                      ProductTypeId = 1
                  },
                  new ProductSubType { 
                      Name = "Treats",
                      ProductTypeId = 2
                  },
                  new ProductSubType { 
                      Name = "Bedding",
                      ProductTypeId = 2
                  },
                  new ProductSubType { 
                      Name = "Toys",
                      ProductTypeId = 2
                  }
              };
              foreach (ProductSubType i in productSubType)
              {
                  context.ProductSubType.Add(i);
              }
              context.SaveChanges();
          }
       }
    }
}