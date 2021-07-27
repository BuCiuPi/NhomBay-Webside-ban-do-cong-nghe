using CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet;
using PagedList;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoralCivet_Technology_Ecommerce_Website.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PostController : Controller
    {
        private CoralCivetContext db = new CoralCivetContext();
        // GET: Admin/Post
        public ActionResult Index(int? page)
        {
            ViewBag.Count = db.posts.Count();
            return View(db.posts.OrderByDescending(n => n.updated_at).ToPagedList(page ?? 1, 20));
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(post post, HttpPostedFileBase imgUpload)
        {
            if (imgUpload == null)
            {
                ViewBag.NotificationError = "Chọn hình ảnh";
                return RedirectToAction("Index");
            }
            else
            {
                var fileimg = Path.GetFileName(imgUpload.FileName);
                //Lưu file
                var pa = Path.Combine(Server.MapPath("~/Content/Image/Post"), fileimg);
                imgUpload.SaveAs(pa);
            }
            post.img = imgUpload.FileName;
            post.updated_at = DateTime.Now;
            post.created_at = DateTime.Now;
            db.posts.Add(post);
            db.SaveChanges();
            TempData["Notification"] = String.Format("Thêm mới bài viết [{0}] thành công.", post.title);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(post post, HttpPostedFileBase imgUpload)
        {
            if (imgUpload != null)
            {
                var fileimg = Path.GetFileName(imgUpload.FileName);
                //Lưu file
                var pa = Path.Combine(Server.MapPath("~/Content/Image/Post"), fileimg);
                imgUpload.SaveAs(pa);
                post.img = imgUpload.FileName;
            }
            post.updated_at = DateTime.Now;
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();
            TempData["Notification"] = String.Format("Cập nhật bài viết [{0}] thành công.", post.title);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            return View();
        }
    }
}