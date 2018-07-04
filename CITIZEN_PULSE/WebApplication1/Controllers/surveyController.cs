using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

//using System.Web.Security;


using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class surveyController : Controller
    {

        private CITIZENPULSEEntities3 db = new CITIZENPULSEEntities3();




       

        [HttpGet]
        public ActionResult displaySur()
        {


            var model = TempData["survey"] as Survey;
            ViewBag.Message = "your survey id is :" + model.SurveyId;
            ViewBag.Message2 = "Your survey name is:" + model.Name;

            return View();
        }


        [HttpGet]
        
        // GET: survey
        public ActionResult survey()
        {
            ViewBag.categoryId = new SelectList(db.Categories, "categoryId", "categoryId");
            ViewBag.customerId = new SelectList(db.Customers, "customerId", "customerId");

            return View();
  }


        [HttpPost]
        [ValidateAntiForgeryToken]
public ActionResult survey(Survey sur)
        {

           
                try
                {

              //  sur.status = "completed";
                //sur.Duration_days_ = 7;
                #region save to database
                using (CITIZENPULSEEntities3 dc = new CITIZENPULSEEntities3())
                {


                    if (ModelState.IsValid)
                    {

                        sur.status = "completed";
                        sur.Duration_days_ = 7;


                        dc.Surveys.Add(sur);

                        dc.SaveChanges();

                        TempData["survey"] = sur;
                        return RedirectToAction("displaySur");
                    }

                }



                

                    ViewBag.categoryId = new SelectList(db.Categories, "categoryId", "categoryId", sur.categoryId);
                    ViewBag.customerId = new SelectList(db.Customers, "customerId", "customerId", sur.customerId);
                         return View(sur);

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

                #endregion
          
        }

           

    }
}