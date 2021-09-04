using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.Queries.GetGenres
{
    public class GetGenresQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenresQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<GenresViewModel> Handle()
        {
            var genres = _context.Genres.Where(x => x.isActive).OrderBy(x => x.Id);
            List<GenresViewModel> genreList = _mapper.Map<List<GenresViewModel>>(genres);
            return genreList;
        }
    }

    public class GenresViewModel
    {
        public string Name { get; set; }
    }
}