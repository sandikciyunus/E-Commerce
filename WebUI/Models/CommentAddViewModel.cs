using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class CommentAddViewModel
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; } 
        public string Message { get; set; }
        public int ProductId { get; set; }
       
    }
}
