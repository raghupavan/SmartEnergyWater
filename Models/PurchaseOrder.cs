using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartEnergyWater.Models
{
    public class PurchaseOrder
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        //public decimal weight { get; set; }
        public decimal Discount { get; set; }
        public decimal Price { get; set; }

        public int Total { get; set; }
    }
}
