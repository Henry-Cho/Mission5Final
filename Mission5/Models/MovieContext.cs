using System;
using Microsoft.EntityFrameworkCore;

namespace Mission5.Models
{
    public class MovieContext : DbContext
    {
        // constructor
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }

        public DbSet<ApplicationResponse> Responses { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Action/Adventure"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Comedy"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Drama"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Family"
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "Horror/Suspense"
                },
                new Category
                {
                    CategoryId = 6,
                    CategoryName = "Television"
                },
                new Category
                {
                    CategoryId = 7,
                    CategoryName = "VHS"
                }
            );

            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    MovieId = 1,
                    Categoryid = 1,
                    Title = "Harry Potter and the Chamber of Secrets",
                    Year = "2002",
                    Director = "Chris Columbus",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "Logan Kim",
                    Note = "For FHE"
                },
                new ApplicationResponse
                {
                    MovieId = 2,
                    Categoryid = 2,
                    Title = "Iron Man",
                    Year = "2008",
                    Director = "Jon Favreau",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "Wayne Park",
                    Note = "For his dating"
                },
                new ApplicationResponse
                {
                    MovieId = 3,
                    Categoryid = 3,
                    Title = "About Time",
                    Year = "2013",
                    Director = "Richard Curtis",
                    Rating = "R",
                    Edited = true,
                    LentTo = "Yes",
                    Note = "For fun"
                }
            );
        }
    }
}
