using FluentValidation;

namespace WebApi.Application.DirectorOperations.DeleteDirector
{
    public class DeleteDirectorCommandValidator : AbstractValidator<DeleteDirectorCommand>
    {
        public DeleteDirectorCommandValidator()
        {
            RuleFor(x => x.directorID).GreaterThan(0);
        }
    }
}