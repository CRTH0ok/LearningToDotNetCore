using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class Product
    {
        public Product(Boolean inStock = true)
        {
            InStock = inStock;
        }
        public String Name { get; set; }
        public String Category { get; set; } = "PC";
        public decimal? Price { get; set; }
        public Product Related { get; set; }
        public Boolean InStock { get; }
        public static Product[] GetProducts()
        {
            Product XBoxSeriesX = new Product
            {
                Name = "XBoxSeriseX",
                Category = "Consoles",
                Price = 499,
            };
            Product XBoxSeriesS = new Product(false)
            {
                Name = "XBoxSeriseS",
                Category = "Consoles",
                Price = 299,
            };
            XBoxSeriesX.Related = XBoxSeriesX;
            return new Product[] { XBoxSeriesX, XBoxSeriesS, null };
        }
    }
}
