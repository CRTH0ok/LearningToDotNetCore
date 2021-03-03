using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        //public static decimal TotalPrices(this ShoppingCart cartParam)
        //{
        //    decimal total = 0;
        //    foreach (Product prod in cartParam.Products)
        //    {
        //        total += prod?.Price ?? 0;
        //    }
        //    return total;
        //}
        public static Decimal TotalPrices(this IEnumerable<Product> products)
        {
            decimal total = 0;
            foreach (Product prod in products)
            {
                total += prod?.Price ?? 0;
            }
            return total;
        }

        public static IEnumerable<Product> FilterByPrice(
            this IEnumerable<Product> products,
            decimal minimumPrice)
        {
            foreach (Product product in products)
            {
                if ((product?.Price ?? 0) > minimumPrice)
                {
                    yield return product;
                }
            }
        }

        public static IEnumerable<Product> FilterByName(
            this IEnumerable<Product> products,
            char firstLetter)
        {
            foreach (Product product in products)
            {
                if (product?.Name[0] == firstLetter)
                {
                    yield return product;
                }
            }
        }

        public static IEnumerable<Product> Filter(this IEnumerable<Product> products, Func<Product,bool> selector)
        {
            foreach (Product product in products)
            {
                if (selector(product))
                {
                    yield return product;
                }
            }
        }
    }
}
