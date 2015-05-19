using ProAngularJs.Api.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProAngularJs.Api.Data {
    public class SportsStoreDbContext : DbContext {

        public SportsStoreDbContext()
            : base("SportsStore") {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            modelBuilder.Entity<OrderProduct>().HasRequired(t => t.Order).WithMany(t => t.OrderProducts);

            modelBuilder.Entity<OrderProduct>().HasRequired(t => t.Product).WithMany();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }

        public DbSet<User> Users { get; set; }

    }
}