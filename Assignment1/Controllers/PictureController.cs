using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class PictureController : Controller
    {
        Assignment1DataContext db = new Assignment1DataContext();
        // GET: Picture
        public ActionResult Index()
        {
            profile_information personid = TempData["personid"] as profile_information;
            TempData.Keep("personid");
            var pictures = from p in db.profile_pictures
                           where p.personid == personid.Id
                           select p;
            ViewBag.Picture = pictures;
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
                profile_information profile = TempData["personid"] as profile_information;
                var fileName = g.ToString() + Path.GetExtension(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                profile_picture newPicture = new profile_picture();
                newPicture.relative_path = "/Images/"+fileName;
                Debug.WriteLine("Path"+ newPicture.relative_path);
                newPicture.personid = profile.Id;
                newPicture.description = collection["Description"];
                db.profile_pictures.InsertOnSubmit(newPicture);
                db.SubmitChanges();
                file.SaveAs(path);
            }

            return RedirectToAction("Index");
        }
        // GET: Picture/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Picture/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Picture/Create
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

        // GET: Picture/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Picture/Edit/5
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

        // GET: Picture/Delete/5
        public ActionResult Delete(int id)
        {
            profile_picture thePicture = db.profile_pictures.FirstOrDefault(p=>p.Id==id);
            var pictures = from p in db.profile_pictures
                           where p.Id==id
                           select p;
            ViewBag.PictureToDelete = pictures;
            return View(thePicture);
        }

        // POST: Picture/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                profile_picture thePicture = db.profile_pictures.FirstOrDefault(p => p.Id == id);
                var filepath = Server.MapPath("~"+thePicture.relative_path);
                System.IO.File.Delete(filepath);
                db.profile_pictures.DeleteOnSubmit(thePicture);
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
