using FluentValidation;
using ShopWarehouse.API.Data.Models;

namespace ShopWarehouse.API.Core.Validator
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name).NotEmpty();
            RuleFor(product => product.Description).NotEmpty();
            RuleFor(product => product.Quantity).NotEmpty();
            RuleFor(product => product.Ean13).NotEmpty();
        }
    }
}
