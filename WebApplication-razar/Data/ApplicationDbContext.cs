﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using WebApplication_razar.Models;

namespace WebApplication_razar.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DIsplayOrder = 1 },
                new Category { Id = 2, Name = "Action", DIsplayOrder = 2 },
                new Category { Id = 3, Name = "Action", DIsplayOrder = 3 }
                );
        }
    }

}
