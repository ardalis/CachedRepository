using CachedRepoSample.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CachedRepoSample.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceType> ResourceTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    Name = "Steve Smith"
                });

            builder.Entity<ResourceType>().HasData(
                new ResourceType { Id = 1, Name = "Book" },
                new ResourceType { Id = 2, Name = "Podcast Episode" },
                new ResourceType { Id = 3, Name = "Blog Post" },
                new ResourceType { Id = 4, Name = "Interview" },
                new ResourceType { Id = 5, Name = "Video" });

            builder.Entity<Resource>().HasData(
                new Resource
                {
                    Id = 1,
                    AuthorId = 1,
                    ResourceTypeId = 1,
                    Name = "ASP.NET By Example",
                    Description = "Published in 2002",
                    Url = "https://www.amazon.com/ASP-NET-Example-Steven-Smith/dp/0789725622"
                });

        }
    }
}
