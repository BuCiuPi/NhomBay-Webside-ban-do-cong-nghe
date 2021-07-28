using CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CoralCivet_Technology_Ecommerce_Website.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        CoralCivetContext db = new CoralCivetContext();
        // GET: Admin/Contact
        public ActionResult Index(int? page)
        {
            ViewBag.Count = db.contacts.Count();
            return View(db.contacts.OrderByDescending(n => n.updated_at).ToPagedList(page ?? 1, 20));
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            contact contact = db.contacts.Find(id);
            db.contacts.Remove(contact);
            db.SaveChanges();
            TempData["Notification"] = String.Format("Xóa chủ đề liên hệ thành công.");
            return RedirectToAction("Index");
        }
    }
}