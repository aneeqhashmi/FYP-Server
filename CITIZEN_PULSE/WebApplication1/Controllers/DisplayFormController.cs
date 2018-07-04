using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DisplayFormController : Controller
    {

        private CITIZENPULSEEntities3 db = new CITIZENPULSEEntities3();

        [HttpGet]

        public ActionResult ListSurvey(int customerid)
        {
            if (customerid <= 0)
            {
                return HttpNotFound();
            }
            var su = from s in db.Surveys
                     where s.customerId == customerid
                     select s;


            if (su == null)
            {
                return HttpNotFound();
            }
            ViewBag.show = su.Count();
            return View(su.ToList());
        }

        [HttpGet]

        public ActionResult CustomerId()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerId(Customer cs)
        {
            TempData["Customer"] = cs;
            return RedirectToAction("ListSurvey", new { customerid= cs.customerId });

           
        }
        [HttpGet]

        public ActionResult listSurId()
        {
            var sur = db.Surveys.ToList();
            return View(sur);
        }

        // GET: DisplayForm
        [HttpGet]
        public ActionResult SurveyId()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SurveyId(Survey sr)
        {

            TempData["Survey"] = sr;
            return RedirectToAction("Generate_form2", "Queestion", new {surveyId= sr.SurveyId });
           // return View();
        }
       

    }
}