using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TipsyTasty.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Age Statement")]
        public string AgeStatment { get; set; }
        [Required]
        [Display(Name = "ABV (%)")]
        public double AlcoholContent { get; set; }

        // FK Fields
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        // Navigation Properties (Indicates the above two declarations are FK Fields)
        public Category Category { get; set; }

        // Navigation Properties
        public List<Collection> Collections { get; set; }

    }
}
