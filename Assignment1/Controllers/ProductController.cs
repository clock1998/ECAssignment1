using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class ProductController : Controller
    {
        ProductCatalogDataContext db = new ProductCatalogDataContext();
        // GET: Product
        public ActionResult Index()
        {
            var items = from i in db.Products
                        select i;
            return View(items);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Product product = new Product();
                product.item = collection["item"];
                product.price =Decimal.Parse(collection["price"]);
                product.quantities = Int32.Parse(collection["quantities"]);
                product.seller = collection["seller"];
                product.shipping = collection["shipping"];
                product.specs = collection["specs"];
                product.description = collection["description"];
                product.handling = Decimal.Parse(collection["handling"]);
                // TODO: Add insert logic here
                db.Products.InsertOnSubmit(product);
                db.SubmitChanges();
                Debug.WriteLine("Productid:"+ product.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var items = (from i in db.Products
                         where i.Id == id
                        select i).FirstOrDefault();
            TempData["productid"] = items;
            return View(items);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var items = (from i in db.Products
                             where i.Id == id
                             select i).FirstOrDefault();
                items.item = collection["item"];
                items.price = Decimal.Parse(collection["price"]);
                items.quantities = Int32.Parse(collection["quantities"]);
                items.seller = collection["seller"];
                items.shipping = collection["shipping"];
                items.specs = collection["specs"];
                items.description = collection["description"];
                items.handling = Decimal.Parse(collection["handling"]);
                TempData["productid"] = items;
                db.SubmitChanges();
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var items = (from i in db.Products
                         where i.Id == id
                         select i).FirstOrDefault();
            return View(items);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var items = (from i in db.Products
                             where i.Id == id
                             select i).FirstOrDefault();
                db.Products.DeleteOnSubmit(items);
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
