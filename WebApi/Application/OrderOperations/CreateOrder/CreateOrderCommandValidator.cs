using System;
using FluentValidation;

namespace WebApi.Application.OrderOperations.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.Model.Price).GreaterThan(0);
            RuleFor(x => x.Model.MovieID).GreaterThan(0);
            RuleFor(x => x.Model.CustomerID).GreaterThan(0);
            RuleFor(x => x.Model.OrderDate).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}