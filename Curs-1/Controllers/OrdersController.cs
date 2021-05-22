using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Curs_1.Data;
using Curs_1.Models;
using Curs_1.ViewModels.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Curs_1.Controllers
{
    [Authorize(AuthenticationSchemes = "Identity.Application,Bearer")]
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<OrdersController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;


        public OrdersController(ApplicationDbContext context, ILogger<OrdersController> logger, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> PlaceOrder(NewOrderRequest newOrderRequest)
        {
            var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            List<Product> orderedProducts = new List<Product>();
            newOrderRequest.OrderedProductIds.ForEach(pid =>
            {
                var productWithId = _context.Products.Find(pid);
                if (productWithId != null)
                {
                    orderedProducts.Add(productWithId);
                }
            });

            if (orderedProducts.Count == 0)
            {
                return BadRequest();
            }

            var order = new Order
            {
                ApplicationUser = user,
                OrderDateTime = newOrderRequest.OrderDateTime.GetValueOrDefault(),
                Products = orderedProducts
            };
            
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var result = _context.Orders.Where(o => o.ApplicationUser.Id == user.Id).Include(o => o.Products).FirstOrDefault();
            var resultViewModel = _mapper.Map<OrdersForUserResponse>(result);

            return Ok(resultViewModel);
        }

    }
}
