using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class QueestionController : Controller
    {




        private CITIZENPULSEEntities3 db = new CITIZENPULSEEntities3();

       
        [HttpGet]
        public ActionResult GetExam()
        {
            int catid = Convert.ToInt32(TempData["categoryid"]);
            ViewBag.cat = catid;
            
            return View();
        }

      
        [HttpGet]
        public ActionResult ListAllCat(Category c)
        {

            var a = db.Categories.ToList();

            return View(a);

        }

        [HttpPost]
        public ActionResult ListAllCat()
        {

            var a = db.Categories.ToList();

            return View(a);

        }

        [HttpGet]
        public ActionResult TestForm(int categoryid )
        {
if(categoryid==1)
            {
                TempData["categoryid"] = categoryid;
                return RedirectToAction("GetExam");
            }


            return View();
        }
        [HttpGet]
        public ActionResult categorized_sur(int categoryid)
        {

            
            if (categoryid <= 0)
            {
                return HttpNotFound();
            }

            var v = from s in db.Surveys
                    where s.categoryId == categoryid
                    select s;

            if (v == null)
            {
                return HttpNotFound();
            }

            return View(v.ToList());
        }
        [HttpPost]
        public ActionResult categorized_sur()
        {

            var Data = TempData["Survey"] as Survey;

            return RedirectToAction("categorized_sur");

        }




        [HttpGet]
        public ActionResult Generate_form2(int surveyId)
        {
            
            if(surveyId <= 0)
            {
                return HttpNotFound();
            }

            Survey sur = db.Surveys.FirstOrDefault(s=> s.SurveyId == surveyId);

            if(sur == null)
            {
                return HttpNotFound();
            }

            ViewBag.ID = sur.SurveyId;
            ViewBag.name = sur.Name;
            
            return View(sur);
        }

        [HttpPost]
        public ActionResult Generate_form2()
        {


            var Data = TempData["Survey"] as Survey;
            TempData.Keep("Survey");

            var Data2 = TempData["Option"] as option;

            return RedirectToAction("Generate_form2");
            //return View();

        }

        //FINAL SUBMIT





        [HttpGet]
        public ActionResult SUR_SUBMIT()
        {
            return View();
        }
        [HttpGet]
        // get options
        public ActionResult Optionn()
        {

            ViewBag.Questionid = new SelectList(db.Questions, "Questionid", "QuestionId");

            ViewBag.customerId = new SelectList(db.Customers, "customerId", "customerId");

            return View();
        }


        // GET: Queestion
        [HttpGet]
        public ActionResult Questions()
        {
            //List<User> users = db.Users.ToList();
            ViewBag.SurveyId = new SelectList(db.Surveys, "SurveyId", "surveyId");

            ViewBag.customerId = new SelectList(db.Customers, "customerId", "customerId");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //post for option

        public ActionResult Optionn(option opt)
        {

           

            try
            {
                #region save to database
                using (CITIZENPULSEEntities3 dc = new CITIZENPULSEEntities3())
                {
                    if(ModelState.IsValid)
                    { 
                        opt.op_isdeleted = false;
                    dc.options.Add(opt);
                    dc.SaveChanges();
                    return RedirectToAction("Optionn");




                    // TempData["Optionn"] = opt;

                    //  return RedirectToAction("Generate_form");

                }

            }

                ViewBag.Questionid = new SelectList(db.Questions, "QuestionId", "QuestionId");

                ViewBag.customerId = new SelectList(db.Customers, "customerId", "customerId");


                return View(opt);

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

        //post for question

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Questions(Question ques)

        {

           
            try
            {
                #region save to database
                using (CITIZENPULSEEntities3 dc = new CITIZENPULSEEntities3())
                {
                    if (ModelState.IsValid)
                    {
                        ques.Isdeleted = false;
                        ques.typeId = 1;
                        dc.Questions.Add(ques);
                        dc.SaveChanges();



                        TempData["Questions"] = ques;
                        return RedirectToAction("Optionn");
                    }
                }


                ViewBag.SurveyId = new SelectList(db.Surveys, "SurveyId", "surveyId");

                ViewBag.customerId = new SelectList(db.Customers, "customerId", "customerId");

                return View(ques);

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
