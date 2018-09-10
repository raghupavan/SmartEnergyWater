using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartEnergyWater.Models
{
    public class ProductsModel
    {
        public List<Products> productsList { get; set; }
        public int Discount { get; set; }
        public decimal totalBill { get; set; }
        public decimal totalSavings { get; set; }
        public List<PurchaseOrder> po { get; set; }
    }
}