using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<String> results = new List<string>();
            foreach (Product item in Product.GetProducts())
            {
                String name = item?.Name;
                Decimal? price = item?.Price;
                //Display Porduct's Name
                String relatedName = item?.Related?.Name;
                //String.Format()
                //results.Add(string.Format("Name: {0}, Price: {1}, Related: {2}",
                //   name, price, relatedName));
                //Syntactic Sugar
                results.Add($"Name: {name};Price: {price};Related: {relatedName}");
            }

            Dictionary<String, Product> products = new Dictionary<string, Product>()
            {
                ["XBoxSeriesX"] = new Product() { Name = "XBoxSeriesX", Category = "Consoles", Price = 499 },
                ["XBoxSeriesS"] = new Product() { Name = "XBoxSeriesS", Category = "Consoles", Price = 299 }
            };

            //Pattern Matching
            Console.WriteLine("Pattern Matching");
            object[] data = new object[] { 123M, 456M, "Something", "Everything", 789M, 200, 20 };
            decimal total = 0;
            for (int i = 0; i < data.Length; i++)
            {
                //Use in Switch Method
                switch (data[i])
                {
                    case Decimal decimalVal:
                        total += decimalVal;
                        break;
                    case Int32 int32Val when int32Val > 100:
                        total += int32Val;
                        break;
                }

                //if (data[i] is Decimal d)
                //{
                //    total += d;
                //}
            }
            Console.WriteLine(total);

            //Extension Method
            //So,Use IEnumerable could process both single product and product array
            Console.WriteLine("ExtensionMethod");
            //Single
            ShoppingCart shoppingCart = new ShoppingCart { Products = Product.GetProducts() };
            Decimal cartTotalVal = shoppingCart.TotalPrices();
            Console.WriteLine(cartTotalVal);
            //Applying Extension Methods to an Interface
            Console.WriteLine("ExtensionMethodUseInterface");
            //Array
            Product[] productArray = {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M}
            };
            decimal cartTotal = shoppingCart.TotalPrices();
            decimal arrayTotal = productArray.TotalPrices();
            Console.WriteLine(cartTotal + ' ' + arrayTotal);


            return View(results);
        }
    }
}
