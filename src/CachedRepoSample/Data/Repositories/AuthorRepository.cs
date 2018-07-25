using System.Collections.Generic;
using System.Linq;
using CachedRepoSample.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CachedRepoSample.Data.Repositories
{
    public class AuthorRepository : EfRepository<Author>
    {
        public AuthorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Author> List()
        {
            return _dbContext.Authors.Include(u => u.Resources).ToList();
        }
    }
}