using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using View3model.Models;

namespace View3model.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<Vegetable> Vegetables { get; set; }
        public DbSet<Legume> Legumes { get; set; }
        public DbSet<Grain> Grains { get; set; }
    }
}
