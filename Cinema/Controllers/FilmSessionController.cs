using Data;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Cinema.Controllers
{
    public class FilmSessionController : Controller
    {
        protected readonly DataContext db = new DataContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            IQueryable<FilmSession> filmSessions = db.FilmSessions;
            DataSourceResult result = filmSessions.ToDataSourceResult(request, entity => new FilmSession
            {
                Id = entity.Id,
                Name = entity.Name,
                DateTime = entity.DateTime
            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create([DataSourceRequest] DataSourceRequest request, FilmSession model)
        {
            db.FilmSessions.Add(model);
            db.SaveChanges();

            return Json(new[] { model }.ToDataSourceResult(request));
        }

        public ActionResult Update([DataSourceRequest] DataSourceRequest request, FilmSession model)
        {
            db.FilmSessions.Attach(model);
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, FilmSession model)
        {
            IQueryable<Order> orders1 = db.Orders.Where(x => x.FilmSession_Id == model.Id);

            if (orders1 != null)
            {
                foreach (Order order in orders1)
                {
                    Order entityX = db.Orders.Find(order.Id);
                    db.Orders.Attach(entityX);
                    db.Orders.Remove(entityX);
                }
            };
            db.SaveChanges();
            FilmSession entity = db.FilmSessions.FirstOrDefault(x => x.Id == model.Id);

            db.FilmSessions.Attach(entity);
            db.FilmSessions.Remove(entity);
            db.SaveChanges();

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}
