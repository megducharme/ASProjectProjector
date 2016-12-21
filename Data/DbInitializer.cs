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
                      CostSqFt = 3.50M,
                      CountSqFt = 15
                  },
                  new Material {
                      Name = "4x8 1/2 Drywall",
                      CostSqFt = 12.00M,
                      CountSqFt = 1
                  },
                  new Material {
                      Name = " 1 1/2 Drywall Screws",
                      CostSqFt = 2.00M,
                      CountSqFt = 15
                  },
                  new Material {
                      Name = "Joint Compound",
                      CostSqFt = 0.50M,
                      CountSqFt = 0
                  },
                  new Material {
                      Name = "Drywall Tape",
                      CostSqFt = 1.15M,
                      CountSqFt = 0
                  },
                  new Material {
                      Name = "120 grit Sandpaper",
                      CostSqFt = 1.50M,
                      CountSqFt = 0
                  },
                  new Material {
                      Name = "Tar Paper",
                      CostSqFt = 3.50M,
                      CountSqFt = 0
                  },
                  new Material {
                      Name = "Roofing Nails",
                      CostSqFt = 3.50M,
                      CountSqFt = 15
                  },
                  new Material {
                      Name = "1/2 OSB",
                      CostSqFt = 2.75M,
                      CountSqFt = 0
                  },
                  new Material {
                      Name = "H Clips",
                      CostSqFt = 0.50M,
                      CountSqFt = 7
                  },
                  new Material {
                      Name = "Ferring Strips",
                      CostSqFt = 2.50M,
                      CountSqFt = 0
                  },
                  new Material {
                      Name = "Liquid Nail",
                      CostSqFt = 3.75M,
                      CountSqFt = 0
                  },
                  new Material {
                      Name = "Ridge Cap",
                      CostSqFt = 2.50M,
                      CountSqFt = 0
                  },
                  new Material {
                      Name = "Rake Trim",
                      CostSqFt = 3.20M,
                      CountSqFt = 0
                  },
                  new Material {
                      Name = "Neoprene Screws",
                      CostSqFt = 4.50M,
                      CountSqFt = 8
                  },
                  new Material {
                      Name = "Ridge Mesh",
                      CostSqFt = 2.50M,
                      CountSqFt = 0
                  },
                  new Material {
                      Name = "Beutle Tape",
                      CostSqFt = 2.56M,
                      CountSqFt = 0
                  },
                  new Material {
                      Name = "2x6x8 treated",
                      CostSqFt = 4.56M,
                      CountSqFt = 0
                  },
                  new Material {
                      Name = "4x4x8 treated",
                      CostSqFt = 5.67M,
                      CountSqFt = 0
                  },
                  new Material {
                      Name = "Joist Hangers",
                      CostSqFt = 2.56M,
                      CountSqFt = 0
                  },
                  new Material {
                      Name = "Decking Screws",
                      CostSqFt = 2.56M,
                      CountSqFt = 6
                  },
                  new Material {
                      Name = "2x6x10",
                      CostSqFt = 3.56M,
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
                      Name = "5x5 Porch"
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

            var materialsForProjects = new ProjectTypeMaterial[]
            {
                new ProjectTypeMaterial {
                    ProjectTypeId = 1,
                    MaterialId = 1
                },
                new ProjectTypeMaterial {
                    ProjectTypeId = 1,
                    MaterialId = 2
                },
                new ProjectTypeMaterial {
                    ProjectTypeId = 1,
                    MaterialId = 3
                },
                new ProjectTypeMaterial {
                    ProjectTypeId = 1,
                    MaterialId = 4
                },
                new ProjectTypeMaterial {
                    ProjectTypeId = 3,
                    MaterialId = 7
                },
                new ProjectTypeMaterial {
                    ProjectTypeId = 3,
                    MaterialId = 11
                },
                new ProjectTypeMaterial {
                    ProjectTypeId = 3,
                    MaterialId = 13
                },
                new ProjectTypeMaterial {
                    ProjectTypeId = 3,
                    MaterialId = 14
                },
                new ProjectTypeMaterial {
                    ProjectTypeId = 3,
                    MaterialId = 15
                },
                new ProjectTypeMaterial {
                    ProjectTypeId = 3,
                    MaterialId = 16
                },
                new ProjectTypeMaterial {
                    ProjectTypeId = 3,
                    MaterialId = 19
                },
                new ProjectTypeMaterial {
                    ProjectTypeId = 3,
                    MaterialId = 22
                }
            };
            foreach (ProjectTypeMaterial i in materialsForProjects)
            {
                context.ProjectTypeMaterial.Add(i);
            }
            context.SaveChanges();
            }
        }
    }
}