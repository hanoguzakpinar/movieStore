using WebApi.DBOperations;
using System.Linq;
using System;

namespace WebApi.Application.DirectorOperations.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int directorID { get; set; }
        public DeleteDirectorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var _director = _context.Directors.SingleOrDefault(x => x.Id == directorID);
            if (_director is null)
                throw new InvalidOperationException("Director bulunamadı.");

            var _movie = _context.Movies.FirstOrDefault(x => x.DirectorID == directorID);
            if (_movie is not null)
                throw new InvalidOperationException("Director silinemez. Mevcut Filmi Var.");

            _context.Directors.Remove(_director);
            _context.SaveChanges();
        }
    }
}