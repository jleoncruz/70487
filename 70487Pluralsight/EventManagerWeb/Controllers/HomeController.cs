using Microsoft.WindowsAzure.ServiceRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagerWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = RoleEnvironment.GetConfigurationSettingValue("Greeting");
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
