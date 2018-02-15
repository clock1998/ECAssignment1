using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class HomeController : Controller
    {
        private Assignment1DataContext dc = new Assignment1DataContext();

        public ActionResult Index()
        {
             var countries = from c in dc.countries
                        select c;
             return View();
        }
    }
}