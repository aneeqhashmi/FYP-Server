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

        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        
        // GET: survey
        public ActionResult survey()
        {
            ViewBag.categoryid = new SelectList(db.Category, "categoryid", "categoryid");
            ViewBag.customerid = new SelectList(db.Customer, "customerid","customerid");

            return View();
  }


        [HttpPost]
        [ValidateAntiForgeryToken]
public ActionResult survey([Bind(Include = "categoryid,customerid,surveyid")]Survey sur)
        {


            try
            {
                #region save to database
                using (CITIZENPULSEEntities3 dc = new CITIZENPULSEEntities3())
                {
                    if (ModelState.IsValid)
                    {
                        dc.Surveys.Add(sur);
                        dc.SaveChanges();
                    }

                }



                ViewBag.categoryid = new SelectList(db.Category, "categoryid", "categoryid", sur.categoryId);
                ViewBag.customerid = new SelectList(db.Customer, "customerid", "customerid", sur.customerId);
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