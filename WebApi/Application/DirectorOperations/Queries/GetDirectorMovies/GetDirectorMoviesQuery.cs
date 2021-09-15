using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperations.Queries.GetDirectorMovies
{
    public class GetDirectorMoviesQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int directorID { get; set; }
        public GetDirectorMoviesQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetDirectorMoviesModel> Handle()
        {
            var _movies = _context.Movies.Include(x => x.Actors).Include(x => x.Genre).Include(y => y.Director).Where(xx => xx.DirectorID == directorID).ToList<Movie>();

            List<GetDirectorMoviesModel> mv = _mapper.Map<List<GetDirectorMoviesModel>>(_movies);
            return mv;
        }
    }
    public class GetDirectorMoviesModel
    {
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public float Price { get; set; }
        public ICollection<Actor> Actors { get; set; }
    }
}