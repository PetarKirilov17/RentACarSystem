using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentACarSystemWeb.Models;
using System;
using System.Collections.Generic;
using System.Text;
using RentACarSystemWeb.ViewModels.Cars;
using RentACarSystemWeb.ViewModels.Queries;


namespace RentACarSystemWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Query> Queries { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>()
            .HasIndex(u => u.EGN)
            .IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<RentACarSystemWeb.ViewModels.Cars.IndexViewModel> GetCarsViewModel { get; set; }

        public DbSet<RentACarSystemWeb.ViewModels.Cars.DetailsViewModel> DetailsViewModel { get; set; }

        public DbSet<RentACarSystemWeb.ViewModels.Cars.CreateViewModel> CreateViewModel { get; set; }

        public DbSet<RentACarSystemWeb.ViewModels.Cars.EditViewModel> EditViewModel { get; set; }

        public DbSet<RentACarSystemWeb.ViewModels.Cars.DeleteViewModel> DeleteViewModel { get; set; }

        public DbSet<RentACarSystemWeb.ViewModels.Queries.QueryIndexViewModel> QueryIndexViewModel { get; set; }
    }
}
