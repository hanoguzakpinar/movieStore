using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperations.Queries.GetDirectors
{
    public class GetDirectorsQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetDirectorsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetDirectorsModel> Handle()
        {
            var _directors = _context.Directors.OrderBy(x => x.Id).ToList<Director>();
            List<GetDirectorsModel> _list = _mapper.Map<List<GetDirectorsModel>>(_directors);
            return _list;
        }
    }

    public class GetDirectorsModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}