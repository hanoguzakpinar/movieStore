using System.Collections.Generic;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using System.Linq;

namespace WebApi.Application.ActorOperations.Queries.GetActors{
    public class GetActorsQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetActorsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetActorsModel> Handle()
        {
            var _actors = _context.Actors.OrderBy(x => x.Id).ToList<Actor>();
            List<GetActorsModel> _list = _mapper.Map<List<GetActorsModel>>(_actors);
            return _list;
        }
    }

    public class GetActorsModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        //public ICollection<Movie> Movies { get; set; }
    }
}