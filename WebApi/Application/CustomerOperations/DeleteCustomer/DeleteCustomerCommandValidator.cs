using FluentValidation;

namespace WebApi.Application.CustomerOperations.DeleteCustomer
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(x => x.customerID).GreaterThan(0);
        }
    }
}