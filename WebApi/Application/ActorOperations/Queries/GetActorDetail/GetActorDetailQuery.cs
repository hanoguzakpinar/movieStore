using System.Collections.Generic;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using System.Linq;
using System;

namespace WebApi.Application.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int actorID { get; set; }
        public GetActorDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetActorDetailModel Handle()
        {
            var _actor = _context.Actors.SingleOrDefault(x => x.Id == actorID);
            if (_actor is null)
                throw new InvalidOperationException("Actor bulunamadı.");

            GetActorDetailModel _model = _mapper.Map<GetActorDetailModel>(_actor);
            return _model;
        }
    }

    public class GetActorDetailModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        
        //public ICollection<Movie> Movies { get; set; }
    }
}