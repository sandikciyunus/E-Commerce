using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.Enums;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using WebUI.Services;

namespace WebUI.Controllers
{
    [EnableCors]
    public class CartController : Controller
    {
        private ICartSessionService _cartSessionService;
        private ICartService _cartService;
        private IProductService _productService;
        private IOrderService _orderService;
        private IOrderLineService _orderLineService;
        public CartController(ICartSessionService cartSessionService,ICartService cartService,IProductService productService,IOrderService orderService,IOrderLineService orderLineService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _productService = productService;
            _orderLineService = orderLineService;
            _orderService = orderService;
          
        }
        public IActionResult Index()
        {
            return View(new CartSummaryViewModel
            {
                Cart=_cartSessionService.GetCart()
            });
        }
        
        public IActionResult AddToCart(int id)
        {
            var productToBeAdded = _productService.GetById2(id);
            var cart = _cartSessionService.GetCart();
            _cartService.AddToCart(cart, productToBeAdded);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", String.Format("{0} sepete başarıyla eklendi",productToBeAdded.Name));
            return RedirectToAction("Index","Product");
        }

        public IActionResult Remove(int id)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, id);
            _cartSessionService.SetCart(cart);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(ShippingDetaill shippingDetail)
        {
            var cart = _cartSessionService.GetCart();
            if(cart.CartLines.Count==0)
            {
                ModelState.AddModelError("UrunYok", "Sepetinizde ürün bulunmamaktadır");
            }
            if(ModelState.IsValid)
            {
                SaveOrder(cart, shippingDetail);
                cart.CartLines.Clear();
                _cartSessionService.SetCart(cart);
                return View("CheckOutComplete");
            }

            return View();
        }

        public void SaveOrder(Cart cart,ShippingDetaill shippingDetaill)
        {
            var order = new Order
            {
                OrderNumber = "A" + (new Random().Next(1111, 9999).ToString()),
                Total = cart.Total,
                OrderDate = DateTime.Now,
                UserName = User.Identity.Name,
                OrderState = OrderState.Bekleniyor,
                Addres = shippingDetaill.Address,
                City = shippingDetaill.City,
                District = shippingDetaill.District,
                Parish = shippingDetaill.Parish,
                PostCode = shippingDetaill.PostCode,
                OrderLines = new List<OrderLine>()
            };
            foreach (var item in cart.CartLines)
            {
                var orderLine = new OrderLine
                {
                    Quantity = item.Quantity,
                    Price = item.Quantity * item.Product.Price,
                    ProductId = item.Product.Id
                };
                order.OrderLines.Add(orderLine);
            }
            _orderService.Add(order);
        }
    }
}
