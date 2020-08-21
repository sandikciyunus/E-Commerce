using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private ICategoryService _categoryService;
        private IProductService _productService;
        private IOrderService _orderService;
        public AdminController(ICategoryService categoryService,IProductService productService,IOrderService orderService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
        }
        public IActionResult CategoryList()
        {
            return View(new CategoryListViewModel
            {
                Categories=_categoryService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            if(ModelState.IsValid)
            {
                _categoryService.Add(category);
                return RedirectToAction("CategoryList");
            }
            return View();
        }

        [HttpGet]
        public IActionResult CategoryUpdate(int id)
        {
            var category = _categoryService.GetById(id);
            return View(new CategoryUpdateViewModel
            {
                Id = category.Id,
                Name = category.Name
            });
        }

        [HttpPost]
        public IActionResult CategoryUpdate(Category category)
        {
            if(ModelState.IsValid)
            {
                _categoryService.Update(category);
                return RedirectToAction("CategoryList");
            }
            return View();
        }

        public IActionResult CategoryDelete(int id)
        {
            var category = _categoryService.GetById(id);
            var product = _productService.GetByCategory(category.Id);
            if (product == null)
            {
                _categoryService.Delete(category.Id);
                return Json(new
                {
                    isDeleted = true,
                    message = "Kategori başarıyla silindi"
                });
            }
            return Json(new
            {
                isDeleted = false,
                message = "Kategoriye ait bir ürün bulunmaktadır,silinemez"
            });
        }

        public IActionResult ProductList()
        {
            return View(new ProductListViewModel
            {
                Products = _productService.GetAll2()
            });
        }

        [HttpGet]
        public IActionResult ProductAdd()
        {
            return View(new ProductAddViewModel
            {
                Categories = _categoryService.GetAll()
            });
        }

        [HttpPost]
        public async Task<IActionResult> ProductAdd(Product product,IFormFile file)
        {
            if (file != null)
            {
                product.Image = file.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            if(ModelState.IsValid)
            {
                _productService.Add(product);
                return RedirectToAction("ProductList");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ProductUpdate(int id)
        {
            var product = _productService.GetById(id);
            return View(new ProductUpdateViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Use = product.Use,
                Image = product.Image,
                Price = product.Price,
                Stock = product.Stock,
                Category = product.Category,
                CategoryId = product.CategoryId,
                Categories = _categoryService.GetAll()
            });
        }

        [HttpPost]
        public async Task<IActionResult> ProductUpdate(Product product, IFormFile file)
        {
            if (file != null)
            {
                product.Image = file.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            if (ModelState.IsValid)
            {
                _productService.Update(product);
                return RedirectToAction("ProductList");
            }
            return View();
        }
     
       
        public IActionResult ProductDelete(int id)
        {
            var product = _productService.GetById(id);
            _productService.Delete(product.Id);
            return RedirectToAction("ProductList");
        }

       

    }
}
