using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Depots.WebUI.Controllers
{
    public class DepotsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}