using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Reisapp.Business.Services;

namespace Reisapp.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetRoute(int cityidFrom, int cityidTo, bool bus, bool train, bool airplane)
        {
            return View();
        }

        [HttpPost]
        public ActionResult RouteTowards(string cityname)
        {
            return View();
        }

        [HttpPost]
        public ActionResult RouteFrom(string cityname)
        {
            return View();
        }
     }
}
