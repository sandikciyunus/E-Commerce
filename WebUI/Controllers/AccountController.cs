using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    [EnableCors]
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private IOrderService _orderService;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,IOrderService orderService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _orderService = orderService;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppUserAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var AddRoleResult = await _userManager.AddToRoleAsync(user, "Member");
                    if (AddRoleResult.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AppUserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    var identityResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                    if (identityResult.Succeeded)
                    {
                        var roles =await  _userManager.GetRolesAsync(user);
                        if(roles.Contains("Admin"))
                        {
                            return RedirectToAction("CategoryList", "Admin");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Default");
                        }
                    }
                }
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
            }
            return View();
        }

        public IActionResult Index()
        {
            var userName = User.Identity.Name;
            var orders = _orderService.GetAllByUserName(userName);
            return View(new UserOrderListViewModel
            {
                UserOrderModels = orders
            });
        }

        public IActionResult Details(int id)
        {
            return View(new OrderDetailsViewModel
            {
                OrderDetails = _orderService.GetByOrderId(id)
            });
        }
        public async Task<IActionResult> LogOut()
        {
           await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Default");
        }

    }
}
