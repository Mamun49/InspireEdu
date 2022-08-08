using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InspireEdu.Models;

namespace InspireEdu.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            InspireModel db = new InspireModel();           
            var search = (from n in db.Blogtbls select n).FirstOrDefault();
            return View(search);
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}