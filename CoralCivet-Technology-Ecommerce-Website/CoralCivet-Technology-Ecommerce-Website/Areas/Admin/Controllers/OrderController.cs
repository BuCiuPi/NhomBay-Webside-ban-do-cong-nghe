using CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CoralCivet_Technology_Ecommerce_Website.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        CoralCivetContext db = new CoralCivetContext();
        // GET: Admin/Order
        public ActionResult Index(int? page)
        {
            ViewBag.Count = db.orders.Count();
            return View(db.orders.OrderByDescending(n => n.update_at).ToPagedList(page ?? 1, 20));
        }
        public ActionResult ChangeStatus(int ID)
        {
            order order = db.orders.Find(ID);
            db.orders.Find(ID).status = order.status == 0 ? 1 : 0;
            db.orders.Find(ID).update_at = DateTime.Now;
            //db.orders.Find(ID).update_by = User.Identity.Name;
            db.SaveChanges();
            TempData["Notification"] = String.Format("Cập nhật tình trạng đơn hàng [{0}] thành công.", order.deliveryname);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            order order = db.orders.Find(id);
            foreach(var item in order.ordersdetails.ToList())
            {
                db.ordersdetails.Remove(item);
            }
            db.orders.Remove(order);
            db.SaveChanges();
            TempData["Notification"] = String.Format("Xóa đơn hàng [{0}] thành công.", order.deliveryname);
            return RedirectToAction("Index");
        }
    }
}