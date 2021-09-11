using WebApi.DBOperations;
using System.Linq;
using System;

namespace WebApi.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int movieID { get; set; }
        public DeleteMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var _movie = _context.Movies.SingleOrDefault(x => x.Id == movieID);
            if (_movie is null)
                throw new InvalidOperationException("Movie bulunamadı.");

            _context.Movies.Remove(_movie);
            _context.SaveChanges();
        }
    }
}