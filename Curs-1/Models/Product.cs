using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Curs_1.Models
{
    public enum ProductType {
        Consumable,
        Heavy,
        Other
    };

    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MinLength(10)]
        public string Description { get; set; }

        [Range(10, Double.MaxValue)]
        public double Price { get; set; }

        public ProductType ProductType { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
