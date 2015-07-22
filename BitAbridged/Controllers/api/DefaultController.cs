using System.Web.Http;

namespace BitAbridged.Controllers.api
{
    public class DefaultController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Index()
        {
            return Redirect("~");
        }
    }
}
