using CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet;
using PagedList;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace CoralCivet_Technology_Ecommerce_Website.Areas.Admin.Controllers
{
    public class TopicController : Controller
    {
        CoralCivetContext db = new CoralCivetContext();
        // GET: Admin/Topic
        public ActionResult Index(int? page)
        {
            ViewBag.Count = db.topics.Count();
            return View(db.topics.OrderByDescending(n=>n.updated_at).ToPagedList(page ?? 1, 20));
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(topic topic)
        {
            topic.updated_at = DateTime.Now;
            topic.created_at = DateTime.Now;
            db.topics.Add(topic);
            db.SaveChanges();
            TempData["Notification"] = String.Format("Thêm mới chủ đề [{0}] thành công.", topic.name);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(topic topic)
        {
            topic.updated_at = DateTime.Now;
            db.Entry(topic).State = EntityState.Modified;
            db.SaveChanges();
            TempData["Notification"] = String.Format("Cập nhật chủ đề [{0}] thành công.", topic.name);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            topic topicID = db.topics.Find(id);
            if (topicID.posts.Any())
            {
                TempData["NotificationError"] = String.Format("Không thể xóa chủ đề [{0}].", topicID.name);
                return RedirectToAction("Index");
            }
            db.topics.Remove(topicID);
            db.SaveChanges();
            TempData["Notification"] = String.Format("Xóa chủ đề [{0}] thành công.", topicID.name);
            return RedirectToAction("Index");
        }
    }
}