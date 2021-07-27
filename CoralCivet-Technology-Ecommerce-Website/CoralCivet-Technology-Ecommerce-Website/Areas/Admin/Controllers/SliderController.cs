using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet;
using PagedList;

namespace CoralCivet_Technology_Ecommerce_Website.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SliderController : Controller
    {
        private CoralCivetContext db = new CoralCivetContext();
        // GET: Admin/Slider
        public ActionResult Index(int? page)
        {
            ViewBag.Count = db.sliders.Count();
            return View(db.sliders.OrderByDescending(n=>n.updated_at).ToPagedList(page ?? 1, 20));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(slider slider, HttpPostedFileBase imgUpload)
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
                var pa = Path.Combine(Server.MapPath("~/Content/Image/Banner"), fileimg);
                imgUpload.SaveAs(pa);
            }
            slider.orders = 0;
            slider.img = imgUpload.FileName;
            slider.updated_at = DateTime.Now;
            slider.created_at = DateTime.Now;
            db.sliders.Add(slider);
            db.SaveChanges();
            TempData["Notification"] = String.Format("Thêm mới slider [{0}] thành công.", slider.name);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(slider slider, HttpPostedFileBase imgUpload)
        {
            if (imgUpload != null)
            {
                var fileimg = Path.GetFileName(imgUpload.FileName);
                //Lưu file
                var pa = Path.Combine(Server.MapPath("~/Content/Image/Banner"), fileimg);
                imgUpload.SaveAs(pa);
                slider.img = imgUpload.FileName;
            }
            slider.updated_at = DateTime.Now;
            db.Entry(slider).State = EntityState.Modified;
            db.SaveChanges();
            TempData["Notification"] = String.Format("Cập nhật slider [{0}] thành công.", slider.name);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            slider sliderID = db.sliders.Find(id);
            db.sliders.Remove(sliderID);
            db.SaveChanges();
            TempData["Notification"] = String.Format("Xóa slider [{0}] thành công.", sliderID.name);
            return RedirectToAction("Index");
        }
    }
}