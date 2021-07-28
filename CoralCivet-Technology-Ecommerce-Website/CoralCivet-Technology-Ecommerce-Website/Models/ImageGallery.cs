using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoralCivet_Technology_Ecommerce_Website.Models
{
    public class ImageGallery
    {
        public SelectList ImageList { get; set; }

        public ImageGallery()
        {
            ImageList = GetImages();
        }

        public SelectList GetImages()
        {
            var list = new List<SelectListItem>();

            DirectoryInfo d = new DirectoryInfo(HttpContext.Current.Request.MapPath("~/Content/Image")); //Assuming Test is your Folder

            FileInfo[] Files = d.GetFiles("*.jpg", SearchOption.AllDirectories); //Getting Text files
            
            foreach (FileInfo file in Files)
            {
                string title = FilterImage(file.Name);
                string imagePath = "";
                if (file.DirectoryName.Contains("Banner"))
                {
                    imagePath = "/Content/Image/Banner/";
                }
                else if (file.DirectoryName.Contains("Product"))
                {
                    imagePath = "/Content/Image/Product/";
                }
                else if (file.DirectoryName.Contains("Post"))
                {
                    imagePath = "/Content/Image/Post/";
                }
                imagePath += file.Name;
                list.Add(new SelectListItem() { Text = title, Value = imagePath });

            }
            return new SelectList(list, "Value", "Text");
        }
        string FilterImage(string FileName)
        {
            FileName = FileName.Replace('_', ' ');
            FileName = FileName.Substring(0, FileName.Length - 4);
            return FileName;
        }
    }
}