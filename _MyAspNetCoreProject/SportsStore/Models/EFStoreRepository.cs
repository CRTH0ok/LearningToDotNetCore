using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private StoreDbContext _StoreDbContext;
        public EFStoreRepository(StoreDbContext storeDbContext)
        {
            _StoreDbContext = storeDbContext;
        }

        public IQueryable<Product> Products => _StoreDbContext.Products;
    }
}
