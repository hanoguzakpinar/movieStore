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

            var _order = _context.Orders.FirstOrDefault(x => x.MovieID == movieID);
            if (_order is not null)
                throw new InvalidOperationException("Movie silinemez. Siparişi Var.");

            _context.Movies.Remove(_movie);
            _context.SaveChanges();
        }

        /* Alternatif - isActive

        public void Handle()
        {
            var _status = _context.Movies.SingleOrDefault(x => x.Id == movieID);
            if (_status is null)
                throw new InvalidOperationException("Movie bulunamadı.");

             _status.isActive = false;

            _context.Movies.Update(_status);

            _context.SaveChanges();
        }

        */
    }
}