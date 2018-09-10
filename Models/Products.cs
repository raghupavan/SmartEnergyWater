using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartEnergyWater.Models
{
    public class Products
    {
        public int productid { get; set; }
        public string productName { get; set; }
        public bool IsProductByWeight { get; set; }
        public string quantity { get; set; }
        public decimal cost { get; set; }
        public int Discount { get; set; }
        public decimal Savings { get; set; }
        public decimal Total { get; set; }
        
    }
}