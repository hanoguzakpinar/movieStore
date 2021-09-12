using FluentValidation;
using System;

namespace WebApi.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(x => x.movieID).GreaterThan(0);
            RuleFor(x => x.Model.Name).MinimumLength(4).NotEmpty();
            RuleFor(x => x.Model.GenreID).GreaterThan(0);
            RuleFor(x => x.Model.Price).GreaterThan(0);
            RuleFor(x => x.Model.ReleaseDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.DirectorID).GreaterThan(0);
        }
    }
}