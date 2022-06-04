using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication_proiect.DAL.Configurations;
using WebApplication_proiect.DAL.Entities;

namespace WebApplication_proiect.DAL
{
    public class AppDbContext : IdentityDbContext<User,
        Role,
        int,
        IdentityUserClaim<int>,
        UserRole,
        IdentityUserLogin<int>,
        IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<Photographer> Photographers{ get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Exhibition> Exhibitions{ get; set; }
        public DbSet<PhotographerExhibition> PhotographerExhibitions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(options => options.AddConsole()));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //in context trb apelate configurarile
            modelBuilder.ApplyConfiguration(new PhotographerConfiguration());
            modelBuilder.ApplyConfiguration(new GalleryConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new ExhibitionConfiguration());
            modelBuilder.ApplyConfiguration(new PhotographerExhibitionConfiguration());
        }
    }
}
