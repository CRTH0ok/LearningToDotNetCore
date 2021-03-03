using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class ShoppingCartDefaultImplement : IProductSelection
    {
        private List<Product> products = new List<Product>();

        public ShoppingCartDefaultImplement(params Product[] prod)
        {
            products.AddRange(prod);
        }

        public IEnumerable<Product> Products { get => products; }
    }
}
