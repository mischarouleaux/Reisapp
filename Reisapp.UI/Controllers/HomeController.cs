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
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";

            RouteService.FindRoute(1, 7, false, true, true);

            return View();
        }

        [HttpPost]
        public ActionResult GetRoute(int cityidFrom, int cityidTo, bool bus, bool train, bool airplane)
        {
            return View();
        }

        [HttpPost]
        public ActionResult RouteTowards(int cityid)
        {
            return View();
        }

        [HttpPost]
        public ActionResult RouteFrom(int cityid)
        {
            return View();
        }
     }
}
