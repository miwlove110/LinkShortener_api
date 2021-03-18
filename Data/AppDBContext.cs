using Microsoft.EntityFrameworkCore;
using LinkShortener.Models;
using System;
using System.Collections.Generic;
using LinkShortener.Models.ShortLink;

namespace LinkShortener.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Role>()
            //     .HasData(new List<Role>()
            //    {
            //         new Role(){ Id = Guid.NewGuid(), Name = "user"},
            //         new Role(){ Id = Guid.NewGuid(), Name = "Manager"},
            //         new Role(){ Id = Guid.NewGuid(), Name = "Admin"},
            //         new Role(){ Id = Guid.NewGuid(), Name = "Developer"}
            //    });
        }


        public DbSet<ShortLink> ShortLinks { get; set; }

    }
}