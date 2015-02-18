using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Business.Models;
using ShoppingCart.DAL.EntityConfigurations;

namespace ShoppingCart.DAL
{
    public class ShoppingCartDbContext : DbContext
    {
        public DbSet<SalesOrder> SalesOrders { get; set; }

        public ShoppingCartDbContext():base("shoppingcartdbconnection")
        {
            Debug.WriteLine("ShoppingCartDbContext created...");
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //
            // Remove pluralizing of table name configuration
            //
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //
            // Add entity configuration classes
            //
            modelBuilder.Configurations.Add(new SalesOrderEntityConfiguration());


            base.OnModelCreating(modelBuilder);
        }
    }
}
