using FluentValidation;

namespace WebApi.Application.ActorOperations.Queries.GetActorMovies
{
    public class GetActorMoviesQueryValidator : AbstractValidator<GetActorMoviesQuery>
    {
        public GetActorMoviesQueryValidator()
        {
            RuleFor(x => x.actorID).GreaterThan(0);
        }
    }
}