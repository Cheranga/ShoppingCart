using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Infrastructure;

namespace ShoppingCart.Business.Models
{
    public class SalesOrder : IObjectWithState
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PONumber { get; set; }

        public ObjectState ObjectState { get; set; }
    }
}
