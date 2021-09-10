using FluentValidation;

namespace WebApi.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(x => x.Model.Name).MinimumLength(3).NotEmpty();
            RuleFor(x => x.Model.Surname).MinimumLength(3).NotEmpty();
        }
    }
}