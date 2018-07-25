using CachedRepoSample.Data;
using CachedRepoSample.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CachedRepoSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IReadOnlyRepository<Author> _userRepository;

        public IndexModel(IReadOnlyRepository<Author> userRepository)
        {
            this._userRepository = userRepository;
        }
        public List<Author> Users { get; set; }
        public void OnGet()
        {
            Users = _userRepository.List();
        }
    }
}
