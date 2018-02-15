using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class ContactController : Controller
    {
        Assignment1DataContext db = new Assignment1DataContext();
        // GET: Contact
        public ActionResult Index()
        {
            profile_information personid = TempData["personid"] as profile_information;
            TempData.Keep("personid");
            var contacts = from c in db.contact_informations
                           where c.personid == personid.Id
                           select c;
            return View(contacts);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                profile_information personid = TempData["personid"] as profile_information;
                TempData.Keep("personid");
                contact_information newContact = new contact_information();
                newContact.personid = personid.Id;
                newContact.contact_data = collection["contact_data"];
                newContact.contact_type = collection["contact_type"];
                db.contact_informations.InsertOnSubmit(newContact);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            contact_information theContact = db.contact_informations.FirstOrDefault(c=>c.Id==id);
            return View(theContact);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var theContact = (from c in db.contact_informations
                                 where c.Id == id
                                 select c).FirstOrDefault();
                theContact.contact_data = collection["contact_data"];
                theContact.contact_type = collection["contact_type"];
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            contact_information theContact = db.contact_informations.FirstOrDefault(c => c.Id == id);
            return View(theContact);
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                contact_information theContact = db.contact_informations.FirstOrDefault(c => c.Id == id);
                db.contact_informations.DeleteOnSubmit(theContact);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Delete fialed");
            }
        }
    }
}
