using AutoMapper;
using WebApi.DBOperations;
using System.Linq;
using System;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperations.CreateDirector
{
    public class CreateDirectorCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateDirectorModel Model { get; set; }
        public CreateDirectorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var _director = _context.Directors.SingleOrDefault(x => x.Name == Model.Name && x.Surname == Model.Surname);
            if (_director is not null)
                throw new InvalidOperationException("Director mevcut.");

            _director = _mapper.Map<Director>(Model);

            _context.Directors.Add(_director);
            _context.SaveChanges();
        }
    }
    public class CreateDirectorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}