using FluentValidation;

namespace WebApi.Application.CustomerOperations.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(x => x.customerID).GreaterThan(0);
            RuleFor(x => x.Model.Name).MinimumLength(3).NotEmpty();
            RuleFor(x => x.Model.Surname).MinimumLength(2).NotEmpty();
            RuleFor(x => x.Model.Email).MinimumLength(5).NotEmpty();
            RuleFor(x => x.Model.Password).MinimumLength(5).NotEmpty();
        }
    }
}