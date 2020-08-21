using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class AppUserAddViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Parolalar eşlemiyor")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
    }
}
