using AutoMapper;
using WebApi.Application.ActorOperations.Queries.GetActorDetail;
using WebApi.Application.ActorOperations.Queries.GetActors;
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
        }
    }
}