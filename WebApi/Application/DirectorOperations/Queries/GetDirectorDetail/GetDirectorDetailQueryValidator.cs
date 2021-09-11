using FluentValidation;
using WebApi.Application.DirectorOperations.GetDirectorDetail;

namespace WebApi.Application.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQueryValidator : AbstractValidator<GetDirectorDetailQuery>
    {
        public GetDirectorDetailQueryValidator()
        {
            RuleFor(x => x.directorID).GreaterThan(0);
        }
    }
}