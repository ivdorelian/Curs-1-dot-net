using System;
using System.Collections.Generic;
using System.Linq;
using Curs_1.Data;
using Curs_1.Models;

namespace Curs_1.Services
{
    public class ProductsService
    {
        public ApplicationDbContext _context;
        public ProductsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllAbovePrice(int minPrice)
        {
            return _context.Products.Where(p => p.Price >= minPrice).ToList();
        }
    }
}
