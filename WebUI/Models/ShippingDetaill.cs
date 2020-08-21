using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class ShippingDetaill
    {
       
        public string UserName { get; set; }
        [Required(ErrorMessage ="Adres alanı boş geçilemez")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Şehir alanı boş geçilemez")]
        public string City { get; set; }
        [Required(ErrorMessage = "İlçe alanı boş geçilemez")]
        public string District { get; set; }
        [Required(ErrorMessage = "Mahalle alanı boş geçilemez")]
        public string Parish { get; set; }
        [Required(ErrorMessage = "Posta kodu alanı boş geçilemez")]
        public string PostCode { get; set; }
    }
}
