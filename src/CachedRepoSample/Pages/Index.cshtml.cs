using CachedRepoSample.Data;
using CachedRepoSample.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Diagnostics;

namespace CachedRepoSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IReadOnlyRepository<Author> _authorRepository;

        public IndexModel(IReadOnlyRepository<Author> authorRepository)
        {
            this._authorRepository = authorRepository;
        }
        public List<Author> Authors { get; set; }
        public long ElapsedTimeMilliseconds { get; set; }

        public void OnGet()
        {
            var timer = Stopwatch.StartNew();
            Authors = _authorRepository.List();
            timer.Stop();
            ElapsedTimeMilliseconds = timer.ElapsedMilliseconds;
        }
    }
}
