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

        public DbSet<Product> Products { get; set; }

    }
}