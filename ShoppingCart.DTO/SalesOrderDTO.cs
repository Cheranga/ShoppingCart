﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DTO
{
    public class SalesOrderDTO
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PONumber { get; set; }

        public string StatusMessage { get; set; }
    }
}
