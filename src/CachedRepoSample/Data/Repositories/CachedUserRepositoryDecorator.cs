using System;
using System.Collections.Generic;
using CachedRepoSample.Data.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CachedRepoSample.Data.Repositories
{
    public class CachedAuthorRepositoryDecorator : IReadOnlyRepository<Author>
    {
        private readonly AuthorRepository _repository;
        private readonly IMemoryCache _cache;
        private const string MyModelCacheKey = "Users";
        private MemoryCacheEntryOptions cacheOptions;

        // alternatively use IDistributedCache if you use redis and multiple services
        public CachedAuthorRepositoryDecorator(AuthorRepository repository,
            IMemoryCache cache)
        {
            _repository = repository;
            _cache = cache;

            // 1 minute caching
            cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(relative: TimeSpan.FromMinutes(1));
        }

        public Author GetById(int id)
        {
            string key = MyModelCacheKey + "-" + id;

            return _cache.GetOrCreate(key, entry =>
            {
                entry.SetOptions(cacheOptions);
                return _repository.GetById(id);
            });
        }

        public List<Author> List()
        {
            return _cache.GetOrCreate(MyModelCacheKey, entry =>
            {
                entry.SetOptions(cacheOptions);
                return _repository.List();
            });
        }
    }
}