using ShoppingCart.Business.Models;

namespace ShoppingCart.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShoppingCart.DAL.ShoppingCartDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ShoppingCart.DAL.ShoppingCartDbContext context)
        {
            context.SalesOrders.AddOrUpdate(x=>x.CustomerName,new []
                                                              {
                                                                  new SalesOrder{CustomerName = "Cheranga Hatangala", PONumber = "PO_1"},
                                                                  new SalesOrder{CustomerName = "Bodhi Dayananda", PONumber = "PO_2"},
                                                                  new SalesOrder{CustomerName = "Kenolee Hatangala", PONumber = "PO_3"},
                                                              });
        }
    }
}

