using System.Collections.Generic;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int movieID { get; set; }
        public GetMovieDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetMovieDetailModel Handle()
        {
            var _movie = _context.Movies.Include(x => x.Genre).Include(y => y.Director).SingleOrDefault(x => x.Id == movieID);
            if (_movie is null)
                throw new InvalidOperationException("Movie bulunamadı.");

            GetMovieDetailModel _model = _mapper.Map<GetMovieDetailModel>(_movie);
            return _model;
        }
    }

    public class GetMovieDetailModel
    {
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public float Price { get; set; }
    }
}