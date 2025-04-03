using LibraryManagement.Domain.Models;
using LibraryManagement.Infrastucture.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Infrastucture.Data
{
    public class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var context = serviceProvider.GetRequiredService<AppDbContext>();

            // Ensure the database is created and migrated
            await context.Database.MigrateAsync();

            // ✅ Seed Users
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser
                {
                    UserName = "sakshi@demo.com",
                    NormalizedUserName = "SAKSHI@DEMO.COM",
                    Email = "sakshi@demo.com",
                    NormalizedEmail = "SAKSHI@DEMO.COM",
                    EmailConfirmed = true,
                    FirstName = "John",
                    LastName = "Doe"
                };
                await userManager.CreateAsync(user, "Pass@123");
            }

            // ✅ Seed Authors
            if (!context.authors.Any())
            {
                context.authors.AddRange(
                    new Author { AuthorName = "J.K. Rowling" },
                    new Author { AuthorName = "George R.R. Martin" }
                );
            }

            // ✅ Seed Categories
            if (!context.categories.Any())
            {
                context.categories.AddRange(
                    new Category { Name = "Fantasy" },
                    new Category { Name = "Science Fiction" }
                );
            }

            // ✅ Seed Books
            if (!context.books.Any())
            {
                var author1 = context.authors.First(a => a.AuthorName == "J.K. Rowling");
                var author2 = context.authors.First(a => a.AuthorName == "George R.R. Martin");

                context.books.AddRange(
                    new Book
                    {
                        Title = "Harry Potter and the Sorcerer's Stone",
                        Description = "A young wizard's journey begins.",
                        PublishedDate = new DateTime(1997, 6, 26),
                        Price = 29.99m,
                        AuthorId = author1.Id
                    },
                    new Book
                    {
                        Title = "A Game of Thrones",
                        Description = "The first book in A Song of Ice and Fire.",
                        PublishedDate = new DateTime(1996, 8, 6),
                        Price = 34.99m,
                        AuthorId = author2.Id
                    }
                );
            }



            // ✅ Save Changes
            await context.SaveChangesAsync();
        }
    }
}
