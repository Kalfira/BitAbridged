using BitAbridged.Models;
using BitAbridged.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace BitAbridged.Controllers.api
{
    public class SearchController : ApiController
    {
        private ISearchService _service;
        public SearchController()
        {
            _service = new SearchService();
        }
        public SearchController(ISearchService service)
        {
            _service = service;
        }

        [HttpGet]
        public IList<Language> Index()
        {
            return _service.GetSearchables();
        }
    }
}
