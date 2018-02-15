using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class CountryController : Controller
    {
        Assignment1DataContext db = new Assignment1DataContext(); 
        // GET: Country
        public ActionResult Index()
        {
            var countries = from c in db.countries
                            select c;
            return View(countries);
        }

        // GET: Country/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                country newCountry = new country();
                newCountry.country_code = collection["country_code"];//country code can only be 3 letters.
                newCountry.country_name = collection["country_name"];
                db.countries.InsertOnSubmit(newCountry);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Country insert failed");
            }
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int id)
        {
            country theCountry = db.countries.FirstOrDefault(c=>c.Id==id);
            return View(theCountry);
        }

        // POST: Country/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var theCountry = (from c in db.countries
                                 where c.Id == id
                                 select c).FirstOrDefault();
                theCountry.country_code = collection["country_code"];
                theCountry.country_name = collection["country_name"];
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Country edit failed");
            }
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int id)
        {
            country theCountry = db.countries.FirstOrDefault(c => c.Id == id);
            return View(theCountry);
        }

        // POST: Country/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                country theCountry = db.countries.FirstOrDefault(c => c.Id == id);
                db.countries.DeleteOnSubmit(theCountry);
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
