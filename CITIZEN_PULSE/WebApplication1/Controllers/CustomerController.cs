using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class CustomerController : Controller
    {

        private CITIZENPULSEEntities3 db = new CITIZENPULSEEntities3();




        [HttpGet]
        public ActionResult displayCus()
        {


            var model = TempData["CUSTOM"] as Customer;
            ViewBag.Message = "CUSTOMER IS CREATED FOR USERID :" + model.userid;
            ViewBag.Message2 = "WITH OCCUPATION:" + model.occupation;
            ViewBag.Message3 = ".YOUR CUSTOMER ID IS:" + model.customerId;

            return View();
        }

        [HttpGet]

       
        public ActionResult CUSTOM()
        {
            List<User> users = db.Users.ToList();
            ViewBag.userid = new SelectList(users, "userid", "userid");

            return View();
        }
        // GET: Customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CUSTOM(Customer cust)
        {
            try
            {
                #region save to database
                using (CITIZENPULSEEntities3 dc = new CITIZENPULSEEntities3())
                {
                    if (ModelState.IsValid)
                    {
                        dc.Customers.Add(cust);
                        dc.SaveChanges();
                        //                        return RedirectToAction("Index");
                        TempData["CUSTOM"] = cust;
                        return RedirectToAction("displayCus");

                    }




                }



                ViewBag.userid = new SelectList(db.Users, "userid", "userid", cust.userid);
                return View(cust);

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
