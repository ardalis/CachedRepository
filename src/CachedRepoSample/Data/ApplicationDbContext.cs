using CachedRepoSample.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CachedRepoSample.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public const int MAX_AUTHORS = 1000;
        public const int MAX_RESOURCES_PER_AUTHOR = 10;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }

        private List<Author> GetAuthors()
        {
            var list = new List<Author>();
            list.Add(new Author { Id = 1, Name = "Steve Smith" });
            for (int i = 0; i < MAX_AUTHORS; i++)
            {
                list.Add(new Author { Id = 2 + i, Name = $"Another Author + {i}" });
            }
            return list;
        }

        private List<dynamic> GetResources(List<Author> authors)
        {
            var list = new List<dynamic>()
            {
                new { Id = 1, TypeId = 1, AuthorId = 1, Name = "ASP.NET By Example", Url = "https://www.amazon.com/ASP-NET-Example-Steven-Smith/dp/0789725622", Description = "ASP developers need to understand how ASP.NET can help them solve business problems better than any prior product. ASP.NET by Example is designed to provide a 'crash course' on ASP.NET and quickly help the reader start using this new technology." },
                    new { Id = 2, TypeId = 2, AuthorId = 1, Name = "What's New in ASP.NET Core 2.1", Url = "https://msdn.microsoft.com/en-us/magazine/mt829706.aspx", Description = "Microsoft recently released ASP.NET Core 2.1 along with .NET Core 2.1 and Entity Framework (EF) Core 2.1. Combined, these releases offer some great improvements in performance, as well as additional features for .NET Core developers. Microsoft is also offering Long-Term Support (LTS) with this release, meaning it will remain supported for three years. This article provides an overview of the improvements in ASP.NET Core 2.1." },
                    new {Id = 3, TypeId = 3, AuthorId = 1, Name = "SOLID Principles of Object-Oriented Design", Url = "https://www.pluralsight.com/courses/principles-oo-design", Description = "The SOLID principles are fundamental to designing effective, maintainable, object-oriented systems. Whether you've only just begun writing software or have been doing so for years, these principles, when used appropriately, can improve the encapsulation and coupling of your application, making it more malleable and testable in the face of changing requirements." }
            };
            int id = 4;
            foreach (var author in authors)
            {
                for (int i = 0; i < MAX_RESOURCES_PER_AUTHOR; i++)
                {
                    list.Add(new {Id = id++, TypeId = i % 4 + 1, AuthorId = author.Id, Name = "Random Resource", Url = "https://ardalis.com", Description = "Description would go here."});
                }

            }
            return list;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ResourceType>()
                .HasData(
                new ResourceType { Id = 1, Name = "Book" },
                new ResourceType { Id = 2, Name = "Magazine Article" },
                new ResourceType { Id = 3, Name = "Online Course" },
                new ResourceType { Id = 4, Name = "Podcast Episode" }
                );

            var authors = GetAuthors();

            // Note: https://github.com/aspnet/EntityFrameworkCore/issues/12003
            // Need to pass an array not IEnumerable to HasData - should be fixed in EF Core 2.2
            builder.Entity<Author>()
                .HasData(authors.ToArray());

            var resources = GetResources(authors);
            builder.Entity<Resource>()
                .HasData(resources.ToArray());
        }
    }
}
