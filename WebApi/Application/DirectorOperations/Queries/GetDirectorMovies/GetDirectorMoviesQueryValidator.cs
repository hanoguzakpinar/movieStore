using FluentValidation;

namespace WebApi.Application.DirectorOperations.Queries.GetDirectorMovies
{
    public class GetDirectorMoviesQueryValidator : AbstractValidator<GetDirectorMoviesQuery>
    {
        public GetDirectorMoviesQueryValidator()
        {
            RuleFor(x => x.directorID).GreaterThan(0);
        }
    }
}