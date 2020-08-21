using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    
    [EnableCors]
    public class DefaultController : Controller
    {
        private IProductService _productService;
        public DefaultController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View(new ProductListViewModel
            {
                Products=_productService.GetAllLastFive()
            });
        }

        public IActionResult ProductList(int id)
        {
            return View(new ProductListViewModel
            {
                Products = _productService.GetByCategoryId2(id)
            });
        }
    }
}
