using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using networkProj.Models;

namespace networkProj.Dal
{
    public class OrdersDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Orders>().ToTable("Orders");
        }
        public DbSet<Orders> Order { get; set; }
    }
}