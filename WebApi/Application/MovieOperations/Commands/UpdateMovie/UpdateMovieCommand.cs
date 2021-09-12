using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        public UpdateMovieModel Model { get; set; }
        public int movieID { get; set; }
        private readonly IMovieStoreDbContext _context;
        public UpdateMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var _status = _context.Movies.SingleOrDefault(x => x.Id == movieID);
            if (_status is null)
                throw new InvalidOperationException("Movie bulunamadı.");

            _status.GenreID = _status.GenreID != default ? Model.GenreID : _status.GenreID;
            _status.Price = _status.Price != default ? Model.Price : _status.Price;
            _status.ReleaseDate = _status.ReleaseDate != default ? Model.ReleaseDate : _status.ReleaseDate;
            _status.Name = _status.Name != default ? Model.Name : _status.Name;
            _status.DirectorID = _status.DirectorID != default ? Model.DirectorID : _status.DirectorID;
           
            _context.Movies.Update(_status);

            _context.SaveChanges();
        }
    }

    public class UpdateMovieModel
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreID { get; set; }
        public int DirectorID { get; set; }
        public float Price { get; set; }
    }
}