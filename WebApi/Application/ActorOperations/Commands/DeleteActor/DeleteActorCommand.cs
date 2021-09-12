using WebApi.DBOperations;
using System.Linq;
using System;

namespace WebApi.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int actorID { get; set; }
        public DeleteActorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var _actor = _context.Actors.SingleOrDefault(x => x.Id == actorID);
            if (_actor is null)
                throw new InvalidOperationException("Actor bulunamadı.");
            
            var _movie = _context.Movies.FirstOrDefault(x => x.Actors.Any(u=> u.Id == actorID));
            if (_movie is not null)
                throw new InvalidOperationException("Actor silinemez. Mevcut Filmi Var.");

            _context.Actors.Remove(_actor);
            _context.SaveChanges();
        }
    }
}