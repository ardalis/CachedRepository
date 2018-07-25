using CachedRepoSample.Data.Models;
using System.Collections.Generic;

namespace CachedRepoSample.Data
{
    public interface IReadOnlyRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        List<T> List();

    }
}