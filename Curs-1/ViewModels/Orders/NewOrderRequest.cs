using System;
using System.Collections.Generic;

namespace Curs_1.ViewModels.Orders
{
    public class NewOrderRequest
    {
        public List<int> OrderedProductIds { get; set; }
        public DateTime? OrderDateTime { get; set; }
    }
}
