using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class homeController : Controller
    {
       // [Authorize]

        // GET: home
        [HttpGet]
        public ActionResult home()
        {
            return View();
        }

        public ActionResult homePage()
        {
            return View();
        }
    }
}