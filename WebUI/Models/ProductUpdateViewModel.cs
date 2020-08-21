using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class ProductUpdateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ürün adı boş geçilemez")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ürün açıklaması boş geçilemez")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Ürün kullanım açıklaması boş geçilemez")]
        public string Use { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Ürün fiyatı boş geçilemez")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Ürün stok sayısı boş geçilemez")]
        public int Stock { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; }
    }
}
