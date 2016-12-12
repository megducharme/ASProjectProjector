using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ASProjectProjector.Models;
using ASProjectProjector.Data;

namespace ASProjectProjector.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
              // Look for any materials. 
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
                      Name = "4x8 1/2 Drywall",
                      CostSqFt = 12.00,
                      CountSqFt = 1
                  },
                  new Material {
                      Name = " 1 1/2 Drywall Screws",
                      CostSqFt = 2.00,
                      CountSqFt = 15
                  },
                  new Material {
                      Name = "Joint Compound",
                      CostSqFt = 0.50,
                      CountSqFt = 0
                  },
                  new Material {
                      Name = "Drywall Tape",
                      CostSqFt = 1.15,
                      CountSqFt = 0
                  },
                  new Material {
                      Name = "120 grit Sandpaper",
                      CostSqFt = 1.50,
                      CountSqFt = 0
                  }
              };
              foreach (Material i in materials)
              {
                  context.Material.Add(i);
              }
              context.SaveChanges();

              //SEEDED PROJECTS
              var projecttypes = new ProjectType[]
              {
                  new ProjectType {
                      Name = "Drywall"
                  },
                  new ProjectType {
                      Name = "Drainage Ditch"
                  },
                  new ProjectType {
                      Name = "Roofing"
                  },
                  new ProjectType{
                      Name = "Floor Covering"
                  }
              };
                foreach (ProjectType i in projecttypes)
                {
                    context.ProjectType.Add(i);
                }
                context.SaveChanges();
            }
        }
    }
}