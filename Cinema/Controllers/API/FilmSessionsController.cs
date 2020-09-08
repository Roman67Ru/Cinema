using Data;
using System.Linq;
using System.Web.Http;

namespace Cinema.Controllers
{
    public class FilmSessionsController : ApiController
    {
        protected readonly DataContext db = new DataContext();

        // GET api/FilmSessions
        public IHttpActionResult Get()
        {
            return Json(db.FilmSessions.OrderBy(x=>x.DateTime).ToList());
        }
    }
}