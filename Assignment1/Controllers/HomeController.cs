using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class HomeController : Controller
    {
        Assignment1DataContext db = new Assignment1DataContext();
        public int myid = 0;
        // GET: Profile
        public ActionResult Index()
        {
            var profiles = from p in db.profile_informations
                           select p;
            return View(profiles);
        }

        // GET: Profile/Details/5
        public ActionResult Details(int id)
        {
            profile_information profile = db.profile_informations.FirstOrDefault(p => p.Id == id);
            var personidForAddress = from a in db.address_informations
                                     where a.personid == id
                                     select a;
            var personidForPicture = from p in db.profile_pictures
                                     where p.personid == id
                                     select p;
            var personidForContact = from c in db.contact_informations
                                     where c.personid == id
                                     select c;
            Debug.WriteLine("Debug:" + personidForAddress + "");
            ViewBag.address = personidForAddress;
            ViewBag.picture = personidForPicture;
            ViewBag.contact = personidForContact;
            return View(profile);
        }

        // GET: Profile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                profile_information newProfile = new profile_information();
                newProfile.first_name = collection["first_name"];
                newProfile.last_name = collection["last_name"];
                newProfile.middle_name = collection["middle_name"];
                
                db.profile_informations.InsertOnSubmit(newProfile);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            profile_information profile = db.profile_informations.FirstOrDefault(p=>p.Id==id);
            TempData["personid"] = profile;
            return View(profile);
        }

        // POST: Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var theProfile = (from p in db.profile_informations
                                 where p.Id == id
                                 select p).FirstOrDefault();
                theProfile.last_name = collection["last_name"];
                theProfile.first_name = collection["first_name"];
                theProfile.middle_name = collection["middle_name"];
                TempData["personid"] = theProfile;
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Edit failed.");
            }
        }

        // GET: Profile/Delete/5
        public ActionResult Delete(int id)
        {
            var profileToDelete = (from p in db.profile_informations
                                   where p.Id == id
                                   select p).FirstOrDefault();
            return View(profileToDelete);
        }

        // POST: Profile/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var profileToDelete = (from t1 in db.profile_informations
                                      where t1.Id == id
                                      select t1).FirstOrDefault();
                var addressToDelete = from t1 in db.profile_informations
                                      join t2 in db.address_informations on t1.Id equals t2.personid
                                      where t1.Id == id
                                      select t2;
                var contactToDelete = from t1 in db.profile_informations
                                      join t2 in db.contact_informations on t1.Id equals t2.personid
                                      select t2;
                var pictureToDelete = from t1 in db.profile_pictures
                                      join t2 in db.profile_pictures on t1.Id equals t2.personid
                                      select t2;
                db.profile_pictures.DeleteAllOnSubmit(pictureToDelete);
                db.contact_informations.DeleteAllOnSubmit(contactToDelete);
                db.address_informations.DeleteAllOnSubmit(addressToDelete);
                db.profile_informations.DeleteOnSubmit(profileToDelete);

                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Search()
        {
            var searchProfile = from s in db.profile_informations
                                select s;
            return View();
        }
        [HttpPost]
        public ActionResult Search(FormCollection collection)
        {
            var searchProfile = from s in db.profile_informations
                                where s.last_name.Contains(collection["Searchinput"]) ||
                                      s.first_name.Contains(collection["Searchinput"])
                                select s;
            return View(searchProfile);
        }
    }
}