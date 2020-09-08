using Data;
using System.Linq;
using System.Web.Http;

namespace Cinema.Controllers
{
    public class OrdersController : ApiController
    {
        protected readonly DataContext db = new DataContext();

        // GET api/Orders/1
        [HttpGet]
        public IHttpActionResult GetOrder(int Id)
        {
            return Json(db.Orders.Where(x => x.FilmSession_Id == Id).ToList());
        }

        // POST api/Orders
        [HttpPost]
        public void CreateOrder([FromBody] Order model)
        {
            db.Orders.Add(model);
            db.SaveChanges();
        }

        // DELETE api/Orders/5
        [HttpDelete]
        public void DeleteOrder(int id)
        {
            Order order = db.Orders.Find(id);

            if (order != null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }
    }
}