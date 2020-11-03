using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGolfScoreApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Round()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Course()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}