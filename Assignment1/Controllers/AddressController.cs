using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class AddressController : Controller
    {
        Assignment1DataContext db = new Assignment1DataContext();
        // GET: Address
        public ActionResult Index()
        {
            profile_information personid = TempData["personid"] as profile_information;
            TempData.Keep("personid");
            var theAddresses = from a in db.address_informations
                               where a.personid == personid.Id
                               select a;
            return View(theAddresses);
        }

        // GET: Address/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Address/Create
        public ActionResult Create()
        {
            ViewBag.List = GetCountryList();
            return View();
        }

        // POST: Address/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                address_information newAddress = new address_information();
                profile_information personid = TempData["personid"] as profile_information;
                TempData.Keep("personid");
                ViewBag.List = GetCountryList();
                string countryName = GetCountryList().Where(i => i.Value == collection["List"]).FirstOrDefault().Text;
                newAddress.personid = personid.Id;
                newAddress.province = collection["province"];
                newAddress.state = countryName;
                newAddress.street_address = collection["street_address"];
                newAddress.zip_code = collection["zip_code"];
                newAddress.description = collection["description"];
                newAddress.city = collection["city"];
                newAddress.countryid = Int32.Parse(collection["List"]);

                db.address_informations.InsertOnSubmit(newAddress);
                db.SubmitChanges();
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return Content("Address Creation failed");
            }
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int id)
        {
            address_information addr = db.address_informations.FirstOrDefault(a => a.Id == id);
            ViewBag.List = GetCountryList();
            return View(addr);
        }

        // POST: Address/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                address_information newAddress = db.address_informations.FirstOrDefault(a => a.Id == id);
                profile_information personid = TempData["personid"] as profile_information;
                TempData.Keep("personid");
                ViewBag.List = GetCountryList();
                string countryName = GetCountryList().Where(i => i.Value == collection["List"]).FirstOrDefault().Text;
                newAddress.personid = personid.Id;
                newAddress.province = collection["province"];
                newAddress.state = countryName;
                newAddress.street_address = collection["street_address"];
                newAddress.zip_code = collection["zip_code"];
                newAddress.description = collection["description"];
                newAddress.city = collection["city"];
                newAddress.countryid = Int32.Parse(collection["List"]);

                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Edit failed.");
            }
        }

        // GET: Address/Delete/5
        public ActionResult Delete(int id)
        {
            address_information addressTobeDeleted = db.address_informations.FirstOrDefault(a => a.Id == id);
            return View(addressTobeDeleted);
        }

        // POST: Address/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                address_information addressTobeDeleted = db.address_informations.FirstOrDefault(a => a.Id == id);
                db.address_informations.DeleteOnSubmit(addressTobeDeleted);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [NonAction]
        public List<SelectListItem> GetCountryList()
        {
            var countries = from c in db.countries
                            select c;
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var c in countries)
            {
                items.Add(new SelectListItem { Text = c.country_name, Value = c.Id+"" });
            }
            string a = items.Where(i => i.Value == "2").First().Text;
            return items;
        }
    }
}
