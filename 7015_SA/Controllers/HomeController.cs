using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _7015_SA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return new FilePathResult("~/Views/Home/index.html", "text/html");
        }

        public ActionResult About()
        {
            return new FilePathResult("~/Views/Home/about.html", "text/html");
        }

        public ActionResult Contact()
        {
            return new FilePathResult("~/Views/Home/contact.html", "text/html");
        }

        public ActionResult Services()
        {
            return new FilePathResult("~/Views/Home/services.html", "text/html");
        }

        public ActionResult Portfolio()
        {
            var Email = Session["Email"];
            if (Email == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return new FilePathResult("~/Views/Home/portfolio.html", "text/html");
            }
            

        }
    }
}