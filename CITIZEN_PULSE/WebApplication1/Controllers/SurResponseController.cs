using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SurResponseController : Controller
    {


        private CITIZENPULSEEntities3 db = new CITIZENPULSEEntities3();


        [HttpGet]

        public ActionResult Answers(int responseid)
        {


            if (responseid <= 0)
            {
                return HttpNotFound();
            }

            var sur = from s in db.Sur_answer
                      where s.responseId == responseid
                      select s;
                      

            if (sur == null)
            {
                return HttpNotFound();
            }
            ViewBag.show = sur.Count();
            return View(sur.ToList());
        }


        [HttpGet]

        public ActionResult response(int surveyId)
        {


            if (surveyId <= 0)
            {
                return HttpNotFound();
            }

            var sur = from s in db.sur_response
                      where s.SurveyId == surveyId
                      select s;

            if (sur == null)
            {
                return HttpNotFound();
            }
            ViewBag.show = sur.Count();
            return View(sur.ToList());
}
        [HttpGet]
        // GET: SurResponse
        public ActionResult Sresponse()
        {
            ViewBag.SurveyId = new SelectList(db.Surveys, "SurveyId", "SurveyId");

            return View();
    }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sresponse(sur_response respo)
        {
            try
            {
                #region save to database
                using (CITIZENPULSEEntities3 dc = new CITIZENPULSEEntities3())
                {
                    if (ModelState.IsValid)
                    {
                        dc.sur_response.Add(respo);
                        dc.SaveChanges();
                        //                        return RedirectToAction("Index");

                    }

                }




                ViewBag.SurveyId = new SelectList(db.Surveys, "SurveyId", "SurveyId");

                return View(respo);
            }

            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

        }

        #endregion



    }
}