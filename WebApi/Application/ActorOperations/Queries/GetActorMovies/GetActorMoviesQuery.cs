using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperations.Queries.GetActorMovies
{
    public class GetActorMoviesQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int actorID { get; set; }
        public GetActorMoviesQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetActorMoviesModel> Handle()
        {
            var _movies = _context.Movies.Include(x => x.Actors).Include(x => x.Genre).Include(y => y.Director).Where(x => x.Actors.Contains(new Actor() { Id = actorID })).ToList<Movie>();

            List<GetActorMoviesModel> mv = _mapper.Map<List<GetActorMoviesModel>>(_movies);
            return mv;
        }
    }
    public class GetActorMoviesModel
    {
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public float Price { get; set; }
        public ICollection<Actor> Actors { get; set; }
    }
}