using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TipsyTasty.Models
{
    public class Category
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        // Navigation Properties
        public List<Brand> Brands { get; set; }

    }
}
