using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KHCharacterEdit.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Customize your favorite characters from this beloved series!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Entre em contato com o desenvolvedor:";

            return View();
        }
    }
}