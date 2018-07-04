using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {

        private CITIZENPULSEEntities3 db = new CITIZENPULSEEntities3();



        //[HttpGet]
        //public ActionResult ListAllCat(Category c)
        //{

        //    var a = db.Categories.ToList();

        //    return View(a);

        //}

        //[HttpPost]
        //public ActionResult ListAllCat()
        //{

        //    return View();

        //}




        [HttpGet]
        public ActionResult displayCat()
        {


            var model = TempData["category"] as Category;
            ViewBag.Message = "Your Survey category is :" + model.Cat_Name;
            ViewBag.Message2 = "and Category Id is:" + model.categoryId;

            return View();
        }



        [HttpGet]


        public ActionResult category()
        {
         //   List<User> users = db.Users.ToList();
            ViewBag.customerId = new SelectList(db.Customers, "customerId", "customerId");

            return View();
        }
        // GET: Customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult category(Category cat)
        {
            try
            {
                #region save to database
                using (CITIZENPULSEEntities3 dc = new CITIZENPULSEEntities3())
                {
                    if (ModelState.IsValid)
                    {
                        
                        dc.Categories.Add(cat);
                        dc.SaveChanges();
                        //                        return RedirectToAction("Index");

                        TempData["category"] = cat;
                        return RedirectToAction("displayCat");
                    }


                   

                }




                ViewBag.customerId = new SelectList(db.Customers, "customerId", "customerId");

                return View(cat);
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