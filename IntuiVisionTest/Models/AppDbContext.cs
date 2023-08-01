using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntuiVisionTest.Models.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace IntuiVisionTest.Models
{
    public class AppDbContext : DbContext
    {

        public DbSet<City> Cities { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
             : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasNoKey();
        }

    }
}

