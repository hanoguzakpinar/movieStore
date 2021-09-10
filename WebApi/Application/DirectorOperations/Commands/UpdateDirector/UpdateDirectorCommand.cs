using WebApi.DBOperations;
using System.Linq;
using System;

namespace WebApi.Application.DirectorOperations.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        private readonly IMovieStoreDbContext _context;
        public UpdateDirectorModel Model { get; set; }
        public int directorID { get; set; }
        public UpdateDirectorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var _director = _context.Directors.SingleOrDefault(x => x.Id == directorID);
            if (_director is null)
                throw new InvalidOperationException("Director bulunamadı.");

            if (_context.Directors.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Surname.ToLower() == Model.Surname.ToLower() && x.Id != directorID))
                throw new InvalidOperationException("Director mevcut.");

            _director.Name = _director.Name != default ? _director.Name = Model.Name : _director.Name;
            _director.Surname = _director.Surname != default ? _director.Surname = Model.Surname : _director.Surname;

            _context.SaveChanges();
        }
    }
    public class UpdateDirectorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}