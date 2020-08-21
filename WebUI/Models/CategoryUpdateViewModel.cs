using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class CategoryUpdateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Kategori adı boş geçilemez")]
        public string Name { get; set; }
    }
}
