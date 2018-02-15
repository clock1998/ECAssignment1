using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class ProductImageController : Controller
    {
        ProductCatalogDataContext db = new ProductCatalogDataContext();
        // GET: ProductImage
        public ActionResult Index()
        {
            Product product = TempData["productid"] as Product;
            TempData.Keep("productid");
            var images = from p in db.Product_images
                           where p.product_id == product.Id
                           select p;
            Debug.WriteLine("Image:" + images); 
            ViewBag.image = images;
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, FormCollection collection)
        {
            string[] allowedTypes = { "image/jpeg", "image/png", "image/gif" };
            string type = file.ContentType;

            if (file != null && file.ContentLength > 0 && allowedTypes.Contains(type))
            {
                Guid g = Guid.NewGuid();
                Product product = TempData["productid"] as Product;
                TempData.Keep("productid");
                var fileName = g.ToString() + Path.GetExtension(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                Product_image newImage = new Product_image();
                newImage.path = "/Images/" + fileName;
                Debug.WriteLine("Path" + newImage.path);
                newImage.product_id = product.Id;
                newImage.description = collection["Description"];
                db.Product_images.InsertOnSubmit(newImage);
                db.SubmitChanges();
                file.SaveAs(path);
            }

            return RedirectToAction("Index");
        }

        // GET: ProductImage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductImage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductImage/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductImage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductImage/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: ProductImage/Delete/5
        public ActionResult Delete(int id)
        {

            Product_image image = db.Product_images.FirstOrDefault(p => p.Id == id);
            var pictures = from p in db.Product_images
                           where p.Id == id
                           select p;
            ViewBag.PictureToDelete = pictures;
            return View(image);
        }

        // POST: ProductImage/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Product_image image= db.Product_images.FirstOrDefault(p => p.Id == id);
                var filepath = Server.MapPath("~" + image.path);
                System.IO.File.Delete(filepath);
                db.Product_images.DeleteOnSubmit(image);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
