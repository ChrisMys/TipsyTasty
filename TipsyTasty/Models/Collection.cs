using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TipsyTasty.Models
{
    public class Collection
    {

        public int Id { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }
        [Required]
        [Range(0, 5)]
        public int Rating { get; set; }
        [Required]
        public string Notes { get; set; }

        // FK Fields
        [Required]
        [Display(Name = "Brand")]
        public int BrandId { get; set; }

        // Navigation Properties (Indicates the above two declarations are FK Fields)
        public Brand Brand { get; set; }
    }
}
