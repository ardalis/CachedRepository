using System;
using System.Collections.Generic;
using CachedRepoSample.Data.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CachedRepoSample.Data.Repositories
{
    public class CachedAuthorRepositoryDecorator : IReadOnlyRepository<Author>
    {
        private readonly AuthorRepository _repository;
        private readonly IMemoryCache cache;
        private const string MyModelCacheKey = "Authors";
        private MemoryCacheEntryOptions cacheOptions;

        // alternatively use IDistributedCache if you use redis and multiple services
        public CachedAuthorRepositoryDecorator(AuthorRepository repository, IMemoryCache cache)
        {
            this._repository = repository;
            this.cache = cache;

            // 5 second cache
            cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(relative: TimeSpan.FromSeconds(5));
        }

        public Author GetById(int id)
        {
            string key = MyModelCacheKey + "-" + id;
            var result = cache.Get<Author>(key);
            if (result == null)
            {
                result = _repository.GetById(id);

                cache.Set(key, result, cacheOptions);
            }
            return result;
        }

        public List<Author> List()
        {
            var result = cache.Get<List<Author>>(MyModelCacheKey);
            if (result == null)
            {
                result = _repository.List();

                cache.Set(MyModelCacheKey, result, cacheOptions);
            }
            return result;
        }
    }
}