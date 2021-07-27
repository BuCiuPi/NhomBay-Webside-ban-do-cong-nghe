using System;
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
    public class ProductController : Controller
    {
        private CoralCivetContext db = new CoralCivetContext();
        // GET: Admin/Product
        public ActionResult Index(int? page)
        {
            ViewBag.Count = db.Products.Count();
            return View(db.Products.OrderByDescending(n=>n.created_at).ToPagedList(page ?? 1, 20));
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase imgUpload, int[] typeID)
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
                var pa = Path.Combine(Server.MapPath("~/Content/Image/Product"), fileimg);
                imgUpload.SaveAs(pa);
            }
            product.created_at = DateTime.Now;
            db.Products.Add(product);
            int lastID = db.ProductImgs.OrderByDescending(x => x.Id).ToArray()[0].Id;
            db.ProductImgs.Add(new ProductImg()
            {
                Id = ++lastID,
                name = imgUpload.FileName,
                productId = product.ID,
                type = 1,
            });
            foreach(var item in typeID)
            {
                db.TypeDetails.Add(new TypeDetail()
                {
                    ProductId = product.ID,
                    TypeId = item
                });
            }
            db.SaveChanges();
            TempData["Notification"] = String.Format("Thêm mới sản phẩm [{0}] thành công.", product.name);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, HttpPostedFileBase imgUpload, int[] typeID)
        {
            if (imgUpload != null)
            {
                var fileimg = Path.GetFileName(imgUpload.FileName);
                //Lưu file
                var pa = Path.Combine(Server.MapPath("~/Content/Image/Product"), fileimg);
                imgUpload.SaveAs(pa);
                var productimg = db.ProductImgs.FirstOrDefault(x => x.productId == product.ID);
                productimg.name = imgUpload.FileName;
            }
            // xoa type id ko co
            var productDetail = db.TypeDetails.Where(x => x.ProductId == product.ID);
            foreach (var item in productDetail.Where(x => !typeID.Contains(x.TypeId)))
            {
                db.TypeDetails.Remove(item);
            }
            // them type moi
            foreach (var item in typeID.Where(x => !productDetail.Select(t => t.TypeId).Contains(x)))
            {
                db.TypeDetails.Add(new TypeDetail()
                {
                    ProductId = product.ID,
                    TypeId = item
                });
            }
            product.created_at = DateTime.Now;
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            TempData["Notification"] = String.Format("Cập nhật sản phẩm [{0}] thành công.", product.name);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Product productID = db.Products.Find(id);
            if (productID.ordersdetails.Any())
            {
                TempData["NotificationError"] = String.Format("Xóa sản phẩm [{0}] thất bại.", productID.name);
                return RedirectToAction("Index");
            }
            foreach(var item in productID.ProductImgs.ToList())
            {
                db.ProductImgs.Remove(item);
            }
            foreach (var item in productID.TypeDetails.ToList())
            {
                db.TypeDetails.Remove(item);
            }
            db.Products.Remove(productID);
            db.SaveChanges();
            TempData["Notification"] = String.Format("Xóa sản phẩm [{0}] thành công.", productID.name);
            return RedirectToAction("Index");
        }
    }
}