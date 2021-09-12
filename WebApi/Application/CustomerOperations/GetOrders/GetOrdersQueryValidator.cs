using FluentValidation;

namespace WebApi.Application.CustomerOperations.GetOrders
{
    public class GetOrdersQueryValidator : AbstractValidator<GetOrdersQuery>
    {
        public GetOrdersQueryValidator()
        {
            RuleFor(x => x.customerID).GreaterThan(0);
        }
    }
}