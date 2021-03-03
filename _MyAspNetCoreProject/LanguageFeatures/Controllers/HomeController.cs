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
            ShoppingCart shoppingCart = new ShoppingCart
            {
                Products = Product.GetProducts()
            };
            Decimal cartTotalVal = shoppingCart.TotalPrices();
            Console.WriteLine(cartTotalVal);
            //Applying Extension Methods to an Interface
            Console.WriteLine("ExtensionMethodUseInterface");
            //Array
            Product[] productArray = {
                new Product
                {
                    Name = "Kayak",
                    Price = 275M
                },
                new Product
                {
                    Name = "Lifejacket",
                    Price = 48.95M
                },
                new Product
                {
                    Name = "Soccer Ball",
                    Price = 19.5M
                },
                new Product
                {
                    Name= "Corner Flag",
                    Price = 22.5M
                }
            };
            decimal cartTotal = shoppingCart.TotalPrices();
            decimal arrayTotal = productArray.TotalPrices();
            Console.WriteLine(cartTotal + ' ' + arrayTotal);

            //Use FilterExtension
            Decimal filterByPriceArrayTotal = productArray.FilterByPrice(20).TotalPrices();
            Decimal filterByNameArrayTotal = productArray.FilterByName('L').TotalPrices();
            Console.WriteLine($"FilterByPriceArrayTotal = {filterByPriceArrayTotal:C2}");
            Console.WriteLine($"FilterByNameArrayTotal = {filterByNameArrayTotal:C2}");

            //Use Function FilterExtension
            bool filterByPrice(Product product)
            {
                return product?.Price > 20;
            }
            Func<Product, bool> filterByName = delegate (Product product)
             {
                 return product?.Name[0] == 'L';
             };
            Decimal funcFilterByPriceArrayTotal = productArray.Filter(filterByPrice).TotalPrices();
            Decimal funcFilterByNameArrayTotal = productArray.Filter(filterByName).TotalPrices();
            Console.WriteLine($"FuncFilterByPriceArrayTotal = {funcFilterByPriceArrayTotal:C2}");
            Console.WriteLine($"FuncFilterByNameArrayTotal = {funcFilterByNameArrayTotal:C2}");

            //Use LambdaExpress
            Decimal lambdaFilterByPriceArrayTotal = productArray.Filter(e => e?.Price > 20).TotalPrices();
            Decimal lambdaFilterByNameArratTotal = productArray.Filter(e => e?.Name[0] == 'L').TotalPrices();

            //AnonymousType
            var anonynousProducts = new[] {
                new { Name = "Kayak", Price = 275M },
                new { Name = "Lifejacket", Price = 48.95M },
                new { Name = "Soccer ball", Price = 19.50M },
                new { Name = "Corner flag", Price = 34.95M }
            };
            Console.WriteLine($"AnonymousProducts'Name = '{anonynousProducts.Select(e => e.Name)}'");


            //UseDefaultImplementInterface
            IProductSelection productSelection = new ShoppingCartDefaultImplement
            (
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "Lifejacket", Price = 48.95M },
                new Product { Name = "Soccer ball", Price = 19.50M },
                new Product { Name = "Corner flag", Price = 34.95M }
            );
            Console.WriteLine($"Use Default ImplementInterface Require Names:{productSelection}");


            return View(results);
        }

        public async Task<ViewResult> Asynchronous()
        {
            //Asynchronous methods
            long? traditionalLength = await MyAsyncMethods.TraditionalGetPageLength();
            long? simplyLength = await MyAsyncMethods.SimplifyGetPageLength();
            Console.WriteLine($"traditionalLength:{traditionalLength}, simplyLength:{simplyLength}");

            //Asynchronous Enumerable
            List<String> output = new List<string>();
            await foreach (long? length in MyAsyncMethods.GetPageLength(output, "apress.com", "microsoft.com", "amazon.com"))
            {
                output.Add($"Page length : {length}");
            }
            foreach (string item in output)
            {
                Console.WriteLine(item);
            }
            return View(new string[] { $"traditionalLength:{traditionalLength}, simplyLength:{simplyLength}" });
        }
    }
}
