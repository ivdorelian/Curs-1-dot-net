using System;
using System.Collections.Generic;
using Curs_1.Models;

namespace Curs_1.ViewModels.Orders
{
    public class OrdersForUserResponse
    {
        public ApplicationUserViewModel ApplicationUser { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public DateTime OrderDateTime { get; set; }
    }
}
