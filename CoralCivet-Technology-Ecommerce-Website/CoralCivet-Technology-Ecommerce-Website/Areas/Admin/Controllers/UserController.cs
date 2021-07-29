using CoralCivet_Technology_Ecommerce_Website.Models;
using CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoralCivet_Technology_Ecommerce_Website.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        // GET: Admin/User
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationUser User)
        {
            User.Update_at = DateTime.Now;

            var userContext = db.Users.First(p=>p.Id == User.Id);
            userContext.Update_at = User.Update_at;
            userContext.Name = User.Name;
            userContext.Update_by = User.Update_by;
            userContext.Email = User.Email;
            userContext.PhoneNumber = User.PhoneNumber;
            userContext.Status = User.Status;


            db.Entry(userContext).State = EntityState.Modified;
            db.SaveChanges();
            TempData["Notification"] = String.Format("Cập nhật User [{0}] thành công.", User.Name);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(String id)
        {
            ApplicationUser UserID = db.Users.Find(id);
            db.Users.Remove(UserID);
            db.SaveChanges();
            TempData["Notification"] = String.Format("Xóa User [{0}] thành công.", UserID.Name);
            return RedirectToAction("Index");
        }
        
    }
}