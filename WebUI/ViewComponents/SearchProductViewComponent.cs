using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.ViewComponents
{
    [ViewComponent]
    public class SearchProductViewComponent:ViewComponent
    {
        private IProductService _productService;
        public SearchProductViewComponent(IProductService productService)
        {
            _productService = productService;
        }
        public IViewComponentResult Invoke(string s)
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAllSearch(s),
            };

            return View(model);
        }
    }
}
