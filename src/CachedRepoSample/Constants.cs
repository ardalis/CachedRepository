using CachedRepoSample.Data;
using CachedRepoSample.Data.Models;
using CachedRepoSample.Data.Repositories;
using CachedRepoSample.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CachedRepoSample
{
    public class Constants
    {
        public const int DEFAULT_CACHE_SECONDS = 5;
    }
}
