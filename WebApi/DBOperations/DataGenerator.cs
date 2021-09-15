using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class dataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                List<Genre> genres = new List<Genre>(){
                    new Genre { Name = "Mystery" },
                    new Genre { Name = "Romance" },
                    new Genre { Name = "Fantasy" },
                    new Genre { Name = "Science Fiction" },
                    new Genre { Name = "Dystopian" },
                    new Genre { Name = "Turkish" },
                    new Genre { Name = "Action" }
                };

                List<Actor> actors = new List<Actor>(){
                    new Actor {Name="Ezel", Surname="Bayraktar"},
                    new Actor {Name="Han", Surname="Solo"},
                    new Actor {Name="Bruce",Surname="Wayne"},
                    new Actor {Name="Alfred",Surname="Pennyworth"},
                    new Actor {Name="Ramiz",Surname="Karaeski"}
                };

                List<Director> directors = new List<Director>(){
                    new Director{Name="Christopher",Surname=" Nolan"},
                    new Director{Name="Quentin",Surname="Tarantino"},
                    new Director{Name="Martin",Surname="Scorsese"},
                    new Director{Name="Uluç",Surname="Bayraktar"}
                };

                List<Movie> movies = new List<Movie>(){
                    new Movie{Name="Dark Knight Rises",ReleaseDate=DateTime.Now.AddYears(-9),GenreID=7,DirectorID=1,Price=30,
                    Actors = new List<Actor>(){actors[2],actors[3]
                        }
                    },
                    new Movie{Name="Ezel",ReleaseDate=DateTime.Now.AddYears(-12),GenreID=6,DirectorID=4,Price=10,
                    Actors = new List<Actor>(){
                        actors[0],actors[4]
                        }
                    }
                };

                List<Customer> customers = new List<Customer>(){
                    new Customer{Name="Oğuzhan",Surname="Akpınar",Email="oguzhanakpinar@yahoo.com",Password="535353",
                    Genres = new List<Genre>(){genres[5],genres[6]}
                    },
                    new Customer{Name="Oğuz",Surname="Han",Email="oguzhan@yahoo.com",Password="343434",
                    Genres = new List<Genre>(){genres[4],genres[3]}
                    }
                };

                List<Order> orders = new List<Order>(){
                    new Order{CustomerID=1,MovieID=1,OrderDate=DateTime.Now.AddMonths(-1),Price=movies[0].Price},
                    new Order{CustomerID=2,MovieID=2,OrderDate=DateTime.Now.AddMonths(-2),Price=movies[1].Price},
                    new Order{CustomerID=1,MovieID=2,OrderDate=DateTime.Now.AddMonths(-3),Price=movies[1].Price}
                };

                if (context.Genres.Any())
                {
                    return;
                }
                context.Genres.AddRange(genres);

                if (context.Actors.Any())
                {
                    return;
                }
                context.Actors.AddRange(actors);

                if (context.Directors.Any())
                {
                    return;
                }
                context.Directors.AddRange(directors);

                if (context.Movies.Any())
                {
                    return;
                }
                context.Movies.AddRange(movies);

                if (context.Customers.Any())
                {
                    return;
                }
                context.Customers.AddRange(customers);

                if (context.Orders.Any())
                {
                    return;
                }
                context.Orders.AddRange(orders);

                context.SaveChanges();
            }
        }
    }
}