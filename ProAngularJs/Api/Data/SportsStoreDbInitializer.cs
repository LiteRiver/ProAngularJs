using ProAngularJs.Api.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProAngularJs.Api.Data {
    public class SportsStoreDbInitializer : MigrateDatabaseToLatestVersion<SportsStoreDbContext, SportsStoreDbMigrateConfiguration> {
        public override void InitializeDatabase(SportsStoreDbContext context) {
            base.InitializeDatabase(context);

            //context.Products.AddRange(new[] {
            //    new Product{ Name = "Kayak", Description = "A boat for one person", Category = "Watersports", Price = 275 },
            //    new Product{ Name = "Lifejacket", Description = "Protective and fashionable", Category = "Watersports", Price = 48.95m },
            //    new Product{ Name = "Soccer Ball", Description = "FIFA-approved size and weight", Category = "Soccer", Price = 19.5m },
            //    new Product{ Name = "Corner Flags", Description = "Give your playing field a professional touch", Category = "Soccer", Price = 34.95m },
            //});

            //context.SaveChanges();
        }
    }
}