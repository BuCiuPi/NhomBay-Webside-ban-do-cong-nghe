using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet;
using PagedList;

namespace CoralCivet_Technology_Ecommerce_Website.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private CoralCivetContext db = new CoralCivetContext();
        // GET: Admin/Category
        public ActionResult Index(int? page)
        {
            ViewBag.Count = db.Types.Count();
            return View(db.Types.OrderByDescending(n=>n.updated_at).ToPagedList(page ?? 1, 20));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.CoralCivet.Type type)
        {
            type.updated_at = DateTime.Now;
            type.created_at = DateTime.Now;
            //type.created_by = User.Identity.Name;
            db.Types.Add(type);
            db.SaveChanges();
            TempData["Notification"] = String.Format("Thêm mới danh mục [{0}] thành công.", type.name);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.CoralCivet.Type type)
        {
            if (type.parentId == type.Id)
            {
                TempData["NotificationError"] = String.Format("Danh mục không thể phụ thuộc chính mình.", type.name);
                return RedirectToAction("Index");
            }
            else if(type.parentId != null && db.Types.FirstOrDefault(x => x.Id == type.parentId).parentId == type.Id)
            {
                TempData["NotificationError"] = String.Format("Danh mục không thể phụ thuộc danh mục con của chính mình.", type.name);
                return RedirectToAction("Index");
            }
                type.updated_at = DateTime.Now;
            //type.updated_by = User.Identity.Name;
            db.Entry(type).State = EntityState.Modified;
            db.SaveChanges();
            TempData["Notification"] = String.Format("Cập nhật danh mục [{0}] thành công.", type.name);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Models.CoralCivet.Type typeID = db.Types.Find(id);
            if (typeID.Products.Any())
            {
                TempData["NotificationError"] = String.Format("Không thể xóa danh mục [{0}].", typeID.name);
                return RedirectToAction("Index");
            }
            db.Types.Remove(typeID);
            db.SaveChanges();
            TempData["Notification"] = String.Format("Xóa danh mục [{0}] thành công.", typeID.name);
            return RedirectToAction("Index");
        }
    }
}