using System;
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
                if (context.Genres.Any())
                {
                    return;
                }
                context.Genres.AddRange(
                    new Genre { Name = "Mystery" },
                    new Genre { Name = "Western" },
                    new Genre { Name = "Romance" },
                    new Genre { Name = "Fantasy" },
                    new Genre { Name = "Science Fiction" },
                    new Genre { Name = "Dystopian" },
                    new Genre { Name = "Magical Realism" }
                );

                context.SaveChanges();
            }
        }
    }
}