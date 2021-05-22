using System;
using System.Collections.Generic;

namespace Curs_1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public DateTime OrderDateTime { get; set; }
    }
}
