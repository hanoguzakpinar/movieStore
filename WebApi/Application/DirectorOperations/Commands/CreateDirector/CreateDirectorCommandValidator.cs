using FluentValidation;
using WebApi.Application.ActorOperations.Commands.DirectorOperations.CreateDirector;

namespace WebApi.Application.DirectorOperations.CreateDirector
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(x => x.Model.Name).MinimumLength(3).NotEmpty();
            RuleFor(x => x.Model.Surname).MinimumLength(3).NotEmpty();
        }
    }
}