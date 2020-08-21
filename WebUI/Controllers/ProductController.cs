using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
   [EnableCors]
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        private ICommentService _commentService;
        public ProductController(IProductService productService,ICategoryService categoryService,ICommentService commentService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _commentService = commentService;
        }
        public IActionResult Index(string s)
        {
            if(!string.IsNullOrEmpty(s))
            {
                return View(new ProductListViewModel
                {
                    Products = _productService.GetAllSearch(s)
                });
            }
            return View(new ProductListViewModel
            {
                Products = _productService.GetAll2(),
            }); 
        }

        public IActionResult ProductDetail(int id,int categoryId)
        {
            var product = _productService.GetById(id);
            return View(new ProductDetailViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Image = product.Image,
                Use=product.Use,
                Stock = product.Stock,
                CategoryId=product.CategoryId,
                Category=product.Category,
                Products = _productService.GetByCategoryId2(categoryId),
                Comments=_commentService.GetAll(id)
            }); ;
        }
        [HttpPost]
        public IActionResult AddComment(CommentAddViewModel commentAddViewModel)
        {
            var comment = new Comment();
            comment.UserName = User.Identity.Name;
            comment.PhoneNumber = commentAddViewModel.PhoneNumber;
            comment.Message = commentAddViewModel.Message;
            comment.ProductId = commentAddViewModel.ProductId;
            _commentService.Add(comment);
            return RedirectToAction("ProductDetail", new { id = commentAddViewModel.ProductId });
        }

    }
}
