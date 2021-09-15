using FluentValidation;

namespace WebApi.Application.OrderOperations.DeleteOrder
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(x => x.orderID).GreaterThan(0);
        }
    }
}