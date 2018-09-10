using SmartEnergyWater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartEnergyWater.Controllers
{
    public class HomeController : Controller
    {
        ProductsModel productsmodel = new ProductsModel();
        List<Products> products;

        //initialising the Products For the Cart
        public HomeController()
        {
           
            products = new List<Products>
            {
             new Products() {productid=1, productName = "Apples", IsProductByWeight=true, cost=10.5m} ,
              new Products() {productid=2, productName = "Detergent", IsProductByWeight=false, cost = 12m } ,
                new Products() {productid=4, productName = "Bananas", IsProductByWeight=true, cost = 3.5m },
             new Products() {productid=3, productName = "Milk", IsProductByWeight=false, cost = 10m },
            
             new Products() { productid=5,productName = "PaperTowels", IsProductByWeight=false, cost = 12.5m },

            new Products() {productid=6, productName = "DietCoke", IsProductByWeight=false, cost = 2.75m } ,
            new Products() {productid=7, productName = "Tomatos", IsProductByWeight=true, cost = 20m }
            };
            productsmodel.productsList = products;
        }
        public ActionResult Index()
        {
            return View(productsmodel);
        }

        //calculates the Total things 
       [HttpPost]
       public ActionResult Calculate(string[] quantities)
        {
            decimal TotalBill = 0;
            decimal Totalsavings = 0;
            int freeItems = 0;
            for( int i=0;i< productsmodel.productsList.Count; i++)
            {
                productsmodel.productsList[i].quantity = quantities[i];
                productsmodel.productsList[i].Total =  CalculateBill(productsmodel.productsList[i]);
                productsmodel.productsList[i].Discount = CalculateDiscount(productsmodel.productsList[i]);
                productsmodel.productsList[i].Savings = CalculateSavings(productsmodel.productsList[i]);
                TotalBill += productsmodel.productsList[i].Total;
                Totalsavings += productsmodel.productsList[i].Savings;
            }
            productsmodel.totalSavings = Totalsavings;
            if (TotalBill > 100)
            {
                TotalBill = TotalBill * 0.9m;
                productsmodel.totalSavings =Totalsavings + TotalBill * 0.1m;
            }
            productsmodel.totalBill = TotalBill;
            return View("About", productsmodel);
        }

        //Calculates theamount After Discount
        public decimal CalculateBill(Products i)
        {
            decimal amount = 0;
            

            switch (i.productid)
            {
                
                case 2:
                    {
                        if (i.quantity == "")
                            i.quantity = "0";

                        int temp = Convert.ToInt32(i.quantity) % 2;
                        int tempquantity = Convert.ToInt32(i.quantity) / 2 + temp;
                        amount += i.cost *tempquantity;
                        break;
                    }
                    case 1:
                    case 3:
                    case 4:
                case 7:
                    {
                        if (i.quantity == "")
                            i.quantity = "0";
                        amount += i.cost * Convert.ToDecimal(i.quantity);
                        break;
                    }
                case 6:
                case 5:
                    {
                        if (i.quantity == "")
                            i.quantity = "0";

                        var quantity = Convert.ToDecimal(i.quantity);
                        int temp = (int)quantity % 3;
                        int tempquantity = Convert.ToInt32(quantity) / 3 * 2 + temp;
                        amount += i.cost * tempquantity;
                        break;
                    }
                
                default: break;
            }
            return amount;
        }

        //Calculates the Discounted Items
        public int CalculateDiscount(Products i)
        {
            int freeItems = 0;


            switch (i.productid)
            {
                case 1:
                    {
                       
                        break;
                    }
                case 2:
                    {
                        if (i.quantity == "")
                            i.quantity = "0";

                        int temp = Convert.ToInt32(i.quantity) % 2;
                        int tempquantity = Convert.ToInt32(i.quantity) / 2  + temp;
                        freeItems = Convert.ToInt32(i.quantity) - tempquantity;
                        break;
                    }
                case 3:
                case 4:
                case 7:
                    {
                       

                        break;
                    }
                case 6:
                case 5:
                    {
                        if (i.quantity == "")
                            i.quantity = "0";

                        var quantity = Convert.ToDecimal(i.quantity);
                        int temp = (int)quantity % 3;

                        //int temp = Convert.ToInt32(i.quantity) % 3;
                        int tempquantity = Convert.ToInt32(quantity) / 3 * 2 + temp;
                        freeItems = Convert.ToInt32(quantity) - tempquantity;
                        break;
                    }

                default: break;
            }
            return freeItems;
        }
        //Calculate the Amount saved oneach item
        public decimal CalculateSavings(Products i)
        {
            decimal savedamount = 0;
            switch (i.productid)
            {
                case 1:
                    {
                        //amount += i.cost * i.quantity;
                        break;
                    }
                case 2:
                    {
                        if (i.quantity == "")
                            i.quantity = "0";

                        int temp = Convert.ToInt32(i.quantity) % 2;
                        int tempquantity = Convert.ToInt32(i.quantity) / 2 + temp;
                       tempquantity= Convert.ToInt32(i.quantity) - tempquantity;
                        savedamount += i.cost * tempquantity;
                        break;
                    }
                case 3:
                case 4:
                case 7:
                    {
                        //amount += i.cost * i.quantity;
                        break;
                    }
                case 6:
                case 5:
                    {
                        if (i.quantity == "")
                            i.quantity = "0";

                        var quantity = Convert.ToDecimal(i.quantity);
                        int temp = (int)quantity % 3;
                       // int temp = Convert.ToInt32(i.quantity) % 3;
                        int tempquantity = Convert.ToInt32(quantity) / 3 * 2 + temp;
                        tempquantity = Convert.ToInt32(quantity) - tempquantity;
                        savedamount += i.cost * tempquantity;
                        break;
                    }

                default: break;
            }
            return savedamount;
        }

    }
}