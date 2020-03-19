using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.Entities
{
    public class Products
    {
        public string Style { get; set; }
        public string Colour { get; set; }

        [Display(Name = "SKU ")]
        [Required(ErrorMessage = "SKU value required")]
        public int Sku { get; set; }
        
        [Required(ErrorMessage = "Name required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Recommended price required")]
        [Range(1, 3000, ErrorMessage = "Value must be in range £1 to £3000")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
