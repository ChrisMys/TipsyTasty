using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TipsyTasty.Models;

namespace TipsyTasty.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // Declaring all the models so they can be accessed by the DB
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
