using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using networkProj.Models;
using System.Data.Entity;

namespace networkProj.Dal
{
    public class ProductsDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().ToTable("Products");
        }

        public DbSet<Product> Products { get; set; }
    }
}