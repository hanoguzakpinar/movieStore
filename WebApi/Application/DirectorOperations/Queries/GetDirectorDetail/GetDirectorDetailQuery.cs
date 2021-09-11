using System.Collections.Generic;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using System.Linq;
using System;

namespace WebApi.Application.DirectorOperations.GetDirectorDetail
{
    public class GetDirectorDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int directorID { get; set; }
        public GetDirectorDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetDirectorDetailModel Handle()
        {
            var _director = _context.Directors.SingleOrDefault(x => x.Id == directorID);
            if (_director is null)
                throw new InvalidOperationException("Director bulunamadı.");

            GetDirectorDetailModel _model = _mapper.Map<GetDirectorDetailModel>(_director);
            return _model;
        }
    }

    public class GetDirectorDetailModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}