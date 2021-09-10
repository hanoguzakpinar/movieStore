using FluentValidation;

namespace WebApi.Application.DirectorOperations.UpdateDirector
{
    public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand>
    {
        public UpdateDirectorCommandValidator()
        {
            RuleFor(x => x.Model.Name).MinimumLength(3).NotEmpty();
            RuleFor(x => x.Model.Surname).MinimumLength(3).NotEmpty();
            RuleFor(x => x.directorID).GreaterThan(0);
        }
    }
}