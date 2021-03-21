using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository _StoreRepository;
        public Int32 _PageSize = 4;
        public HomeController(IStoreRepository storeRepository)
        {
            _StoreRepository = storeRepository;
        }

        public IActionResult Index(Int32 productPage = 1)
            => View(new ProductsListViewModel
            {
                Products = _StoreRepository.Products.OrderBy(e => e.ProductID).Skip((productPage - 1) * _PageSize).Take(_PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = _PageSize,
                    TotalItems = _StoreRepository.Products.Count(),
                }
            });

        public IActionResult Index1(int productPage = 1)
            => View(_StoreRepository.Products
                .OrderBy(e => e.ProductID).Skip((productPage - 1) * _PageSize).Take(_PageSize));
    }
}
