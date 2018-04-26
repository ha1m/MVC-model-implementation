using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using networkProj.Models;

namespace networkProj.Dal
{
    public class UserDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users");
        }

        public DbSet<User> Users  { get; set; }

    }
}