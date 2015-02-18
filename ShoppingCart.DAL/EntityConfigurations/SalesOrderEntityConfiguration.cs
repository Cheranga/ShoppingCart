using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Business.Models;

namespace ShoppingCart.DAL.EntityConfigurations
{
    public class SalesOrderEntityConfiguration : EntityTypeConfiguration<SalesOrder>
    {
        public SalesOrderEntityConfiguration()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.CustomerName).IsRequired().HasMaxLength(100);
            this.Property(x => x.PONumber).IsRequired().HasMaxLength(10);
        }
    }
}
