using System;
using System.ComponentModel.DataAnnotations;
using Curs_1.Models;

namespace Curs_1.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductType ProductType { get; set; }
        public double Price { get; set; }
    }
}
