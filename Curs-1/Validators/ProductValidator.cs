using System;
using Curs_1.Data;
using Curs_1.Models;
using Curs_1.ViewModels;
using FluentValidation;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Curs_1.Validators
{
    public class ProductValidator : AbstractValidator<ProductViewModel>
    {
        private readonly ApplicationDbContext _context;

        public ProductValidator(ApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.Description).MinimumLength(10);
            RuleFor(x => x.Price).InclusiveBetween(10, Double.MaxValue);

            RuleFor(x => x.ProductType).Custom((prop, validationContext) =>
            {
                var instance = validationContext.InstanceToValidate;
                int commentsForTypeCount = _context.Comments.Where(c => c.Product.ProductType == instance.ProductType).Count();
                if (commentsForTypeCount > 10)
                {
                    validationContext.AddFailure($"Cannot add a product with type {instance.ProductType} because that type has more than 10 comments: it has {commentsForTypeCount}.");
                }
            });
        }
    }
}
