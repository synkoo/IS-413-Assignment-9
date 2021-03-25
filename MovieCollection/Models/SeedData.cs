using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

//Populate Database if empty
namespace MovieCollection.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            MovieDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<MovieDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Movies.Any())
            {
                context.Movies.AddRange(
                    new Movie
                    {
                        Category = "Action/Adventure",
                        Title = "Avengers, The",
                        Year = 2012,
                        Director = "Joss Whedon",
                        Rating = "PG-13"
                    },

                    new Movie
                    {
                        Category = "Action/Adventure",
                        Title = "Batman",
                        Year = 1989,
                        Director = "Tim Burton",
                        Rating = "PG-13"
                    },

                    new Movie
                    {
                        Category = "Action/Adventure",
                        Title = "Batman & Robin",
                        Year = 1997,
                        Director = "Joel Schumacher",
                        Rating = "PG-13"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
