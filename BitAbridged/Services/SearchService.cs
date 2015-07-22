
using BitAbridged.Models;
using System.Collections.Generic;
using System.Linq;

namespace BitAbridged.Services
{
    public class SearchService : ISearchService
    {
        private ApplicationDbContext _context;

        public SearchService()
        {
            _context = new ApplicationDbContext();
        }

        public SearchService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Language> GetSearchables()
        {
            return _context.Languages.ToList();
        }
    }
}