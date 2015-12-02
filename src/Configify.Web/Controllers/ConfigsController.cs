using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Configify.Web.Controllers
{
    public class ConfigsController : Controller
    {
        // GET: Config
        public ActionResult Index()
        {
            return View();
        }
    }
}