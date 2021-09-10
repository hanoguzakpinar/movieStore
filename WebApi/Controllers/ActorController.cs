using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ActorOperations.Commands.DeleteActor;
using WebApi.Application.ActorOperations.Queries.GetActorDetail;
using WebApi.Application.ActorOperations.Queries.GetActors;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class ActorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public ActorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetActors()
        {
            GetActorsQuery query = new GetActorsQuery(_context, _mapper);
            var _actors = query.Handle();
            return Ok(_actors);
        }
        [HttpGet("{id}")]
        public IActionResult GetActorDetail(int id)
        {
            GetActorDetailQuery query = new GetActorDetailQuery(_context, _mapper);
            query.actorID = id;

            GetActorDetailQueryValidator validator = new GetActorDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var _actor = query.Handle();
            return Ok(_actor);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
            DeleteActorCommand query = new DeleteActorCommand(_context);
            query.actorID = id;

            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
            validator.ValidateAndThrow(query);

            query.Handle();
            return Ok();
        }
    }
}