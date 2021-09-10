using AutoMapper;
using WebApi.DBOperations;
using System.Linq;
using System;
using WebApi.Entities;

namespace WebApi.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateActorModel Model { get; set; }
        public CreateActorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var _actor = _context.Actors.SingleOrDefault(x => x.Name == Model.Name && x.Surname == Model.Surname);
            if (_actor is not null)
                throw new InvalidOperationException("Actor mevcut.");

            _actor = _mapper.Map<Actor>(Model);

            _context.Actors.Add(_actor);
            _context.SaveChanges();
        }
    }
    public class CreateActorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}