using System;
using System.ComponentModel.DataAnnotations;

namespace Curs_1.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MinLength(10)]
        public string Description { get; set; }

        [Range(10, Double.MaxValue)]
        public double Price { get; set; }
    }
}
