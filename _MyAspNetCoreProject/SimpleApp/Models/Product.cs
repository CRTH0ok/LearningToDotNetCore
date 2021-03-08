using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Models
{
    public class Product
    {
        public String Name { get; set; }
        public Decimal? Price { get; set; }
        //public static Product[] GetProducts()
        //{
        //    Product XBoxSeriesX = new Product
        //    {
        //        Name = "XBoxSeriesX",
        //        Price = 499M,
        //    };
        //    Product XBoxSeriesS = new Product
        //    {
        //        Name = "XBoxSeriesS",
        //        Price = 299M
        //    };
        //    return new Product[] { XBoxSeriesX, XBoxSeriesS };
        //}
    }

    public class ProductDataSource : IDataSource
    {
        public IEnumerable<Product> Products => new Product[]
        {
            new Product{Name = "XBoxSeriesX",Price = 499M,},
            new Product{Name = "XBoxSeriesS",Price = 299M,}
        };
    }
}
