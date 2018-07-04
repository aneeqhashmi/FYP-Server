using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.IO;
using System.Web.Security;
using System.Xml.Linq;

namespace WebApplication1.Controllers
{
    public class userController : Controller
    {
        //private object _myDocumentRepository;

        // GET: user

       
       //login
            [HttpGet]
            public ActionResult login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Welcome()
        {
            return View();
        }

        [HttpGet]
        public ActionResult WelcomeAdmin()
        {
            return View();
        }


        //display form info
        [HttpGet]
        public ActionResult Regiation()
        {
           


            var model = TempData["Registraion"] as User;
            ViewBag.Message = "Welcome " + model.fname;
            ViewBag.Message2 = "Your userid is:" + model.userid;

            return View();
            //return View();
       }

        //loginpost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(Userlogin login ,string ReturnUrl)
        {

            string Message = "";
            using (CITIZENPULSEEntities3 dc = new CITIZENPULSEEntities3())
            {
                var v = dc.Users.Where(a => a.email == login.email).FirstOrDefault();
                if(v!=null)
                {
                    if (string.Compare(Crypto.hash(login.password), v.password) == 0)
                    {
                        int timeout = login.RememberMe ? 525600 : 20;
                        var ticket = new FormsAuthenticationTicket(login.email, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);


                       
                            if (v.Role==1)
                            {
                                return RedirectToAction("Welcome");//welcome customer
                            }
                            else if (v.Role==2)
                            {
                                return RedirectToAction("WelcomeAdmin");
                            }

                        //    return Redirect(ReturnUrl);

                        

                       
                    }
                    else
                    {
                        Message = "invalid credidential provided";
                    }


                   
                }

                else
                {
                    Message = "invalid credidential provided";
                }

            }

            ViewBag.Message = Message;
            return View();
        }

        //logout
      // [Authorize]
        [HttpGet]
      //  [ValidateAntiForgeryToken]

        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("homePage", "home");
        }
        [HttpGet]
         public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Exclude = "IsActive")] User user)

        {
            bool Status = false;
            string Message = "";
            //model validation
            if (ModelState.IsValid)
            {

                #region
                var isExist = IsEmailExist(user.email);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "email alredy exist");
                    return View(user);
                }

                #endregion

                #region passwaord hash
                user.password = Crypto.hash(user.password);
                user.ConfirmPassword = Crypto.hash(user.ConfirmPassword);
                #endregion
                user.IsActive = true;
                try
                {
                    #region save to database
                    using (CITIZENPULSEEntities3 dc = new CITIZENPULSEEntities3())
                    {
                        dc.Users.Add(user);
                        dc.SaveChanges();


                    }

                    TempData["Registraion"] = user;
                    return RedirectToAction("Regiation");

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
            else
            {
                Message = "invalid request";
            }


            return View(user);
        }
        [NonAction]
        public bool IsEmailExist(String emailId)
        {
            using (CITIZENPULSEEntities3 dc = new CITIZENPULSEEntities3())
            {
                var v = dc.Users.Where(a => a.email == emailId).FirstOrDefault();
                return v != null;
            }

        }



    }
}