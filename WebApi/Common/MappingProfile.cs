using AutoMapper;
using WebApi.Application.ActorOperations.Commands.CreateActor;
using WebApi.Application.ActorOperations.Queries.GetActorDetail;
using WebApi.Application.ActorOperations.Queries.GetActors;
using WebApi.Application.DirectorOperations.CreateDirector;
using WebApi.Application.DirectorOperations.UpdateDirector;
using WebApi.Application.GenreOperations.Queries.GetGenres;
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
            CreateMap<UpdateDirectorModel, Director>();
        }
    }
}