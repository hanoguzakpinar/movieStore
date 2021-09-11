using AutoMapper;
using WebApi.DBOperations;
using System.Linq;
using System;
using WebApi.Entities;

namespace WebApi.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateMovieModel Model { get; set; }
        public CreateMovieCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var _movie = _context.Movies.SingleOrDefault(x => x.Name == Model.Name);
            if (_movie is not null)
                throw new InvalidOperationException("Movie mevcut.");

            _movie = _mapper.Map<Movie>(Model);

            _context.Movies.Add(_movie);
            _context.SaveChanges();
        }
    }

    public class CreateMovieModel
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreID { get; set; }
        public int DirectorID { get; set; }
        public float Price { get; set; }
    }
}