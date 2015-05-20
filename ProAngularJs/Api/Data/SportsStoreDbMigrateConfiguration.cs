using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ProAngularJs.Api.Data {
    public class SportsStoreDbMigrateConfiguration : DbMigrationsConfiguration<SportsStoreDbContext> {
        public SportsStoreDbMigrateConfiguration() {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ProAngularJs.Api.Data.SportsStoreDbContext";
        }
    }
}