using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ASProjectProjector.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ASProjectProjector.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){ }
        public ApplicationDbContext(){}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<ApplicationUser> User { get; set; }
        public DbSet<AdditionalCost> AdditionalCost { get; set; }
        public DbSet<ProjectType> ProjectType { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<ProjectTypeMaterial> ProjectTypeMaterial { get; set; }
        public DbSet<RestrictedCounty> RestrictedCounty { get; set; }
        public DbSet<CountyProject> CountyProject {get;set;}
    }
}