// using WebApi.DBOperations;
// using System.Linq;
// using System;

// namespace WebApi.Application.ActorOperations.Commands.UpdateActor
// {
//     public class UpdateActorCommand
//     {
//         private readonly IMovieStoreDbContext _context;
//         public UpdateActorModel Model { get; set; }
//         public int actorID { get; set; }
//         public UpdateActorCommand(IMovieStoreDbContext context)
//         {
//             _context = context;
//         }
//         public void Handle()
//         {
//             var _actor = _context.Actors.SingleOrDefault(x => x.Id == actorID);
//             if (_actor is null)
//                 throw new InvalidOperationException("Actor bulunamadı.");

//             if (_context.Actors.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Surname.ToLower() == Model.Surname.ToLower() && x.Id != actorID))
//                 throw new InvalidOperationException("Actor mevcut.");

//             _actor.Name = _actor.Name != default ? _actor.Name = Model.Name : _actor.Name;
//             _actor.Surname = _actor.Surname != default ? _actor.Surname = Model.Surname : _actor.Surname;

//             _context.SaveChanges();
//         }
//     }
//     public class UpdateActorModel
//     {
//         public string Name { get; set; }
//         public string Surname { get; set; }
//     }
// }