using AutoMapper;
using WebApi.Application.ActorOperations.Commands.CreateActor;
using WebApi.Application.ActorOperations.Queries.GetActorDetail;
using WebApi.Application.ActorOperations.Queries.GetActorMovies;
using WebApi.Application.ActorOperations.Queries.GetActors;
using WebApi.Application.CustomerOperations.CreateCustomer;
using WebApi.Application.CustomerOperations.GetOrders;
using WebApi.Application.DirectorOperations.CreateDirector;
using WebApi.Application.DirectorOperations.GetDirectorDetail;
using WebApi.Application.DirectorOperations.Queries.GetDirectors;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.MovieOperations.Commands.CreateMovie;
using WebApi.Application.MovieOperations.Queries.GetMovieDetail;
using WebApi.Application.MovieOperations.Queries.GetMovies;
using WebApi.Application.OrderOperations.CreateOrder;
using WebApi.Application.OrderOperations.GetOrders;
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
            CreateMap<CreateMovieModel, Movie>();
            CreateMap<CreateCustomerModel, Customer>();
            CreateMap<CreateOrderModel, Order>();
            CreateMap<Order, GetOrdersView>().ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie.Name)).ForMember(x => x.Customer, y => y.MapFrom(z => z.Customer.Name + " " + z.Customer.Surname));
            CreateMap<Order, GetOrdersModel>().ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie.Name)).ForMember(x => x.Customer, y => y.MapFrom(z => z.Customer.Name + " " + z.Customer.Surname));
            CreateMap<Movie, GetActorMoviesModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(x => x.Director, y => y.MapFrom(z => z.Director.Name + " " + z.Director.Surname));
        }
    }
}