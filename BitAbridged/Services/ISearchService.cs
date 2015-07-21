
using BitAbridged.Models;
using System.Collections.Generic;

namespace BitAbridged.Services
{
    public interface ISearchService
    {
        IList<Searchable> GetSearchables();
    }
}
