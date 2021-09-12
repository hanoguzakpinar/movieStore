using FluentValidation;

namespace WebApi.Application.CustomerOperations.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Model.Name).MinimumLength(3).NotEmpty();
            RuleFor(x => x.Model.Surname).MinimumLength(2).NotEmpty();
            RuleFor(x => x.Model.Email).MinimumLength(5).NotEmpty();
            RuleFor(x => x.Model.Password).MinimumLength(5).NotEmpty();
        }
    }
}