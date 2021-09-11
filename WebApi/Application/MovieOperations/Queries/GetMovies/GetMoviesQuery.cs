using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieOperations.Queries.GetMovies
{
    public class GetMoviesQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetMoviesQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetMoviesModel> Handle()
        {
            var _movieList = _context.Movies.Include(x => x.Genre).Include(y => y.Director).OrderBy(z => z.Id).ToList<Movie>();
            List<GetMoviesModel> mv = _mapper.Map<List<GetMoviesModel>>(_movieList);
            return mv;
        }
    }
    public class GetMoviesModel
    {
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public float Price { get; set; }
    }
}