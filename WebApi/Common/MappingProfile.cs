using AutoMapper;
using WebApi.Application.ActorOperations.Commands.CreateActor;
using WebApi.Application.ActorOperations.Queries.GetActorDetail;
using WebApi.Application.ActorOperations.Queries.GetActors;
using WebApi.Application.DirectorOperations.CreateDirector;
using WebApi.Application.DirectorOperations.GetDirectorDetail;
using WebApi.Application.DirectorOperations.Queries.GetDirectors;
using WebApi.Application.DirectorOperations.UpdateDirector;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.MovieOperations.Queries.GetMovieDetail;
using WebApi.Application.MovieOperations.Queries.GetMovies;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Actor, GetActorsModel>();
            CreateMap<Actor, GetActorDetailModel>();
            CreateMap<CreateActorModel, Actor>();
            CreateMap<CreateDirectorModel, Director>();
            CreateMap<Director, GetDirectorsModel>();
            CreateMap<Director, GetDirectorDetailModel>();
            CreateMap<Movie, GetMoviesModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(x => x.Director, y => y.MapFrom(z => z.Director.Name + " " + z.Director.Surname));
            CreateMap<Movie, GetMovieDetailModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(x => x.Director, y => y.MapFrom(z => z.Director.Name + " " + z.Director.Surname));
        }
    }
}