using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class WebApiTestController : ApiController
    {
        // GET api/HelloWorld

        private CITIZENPULSEEntities3 db = new CITIZENPULSEEntities3();

        [HttpGet]
        public IHttpActionResult Getuser(string email,string pass)
        {

            var result = from u in db.Users.Where(s => s.email== email )
.Where(w=>w.password==pass)
                         select new
                         {
                             u.userid,
                             u.fname,
                             u.Lname,
                             u.email,
                             u.password,
                             u.Role
                         };
            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetCustomer()
        {

            var result = from u in db.Customers
                         select new
                         {
                             u.occupation,
                             u.customerId,
                             u.userid

                         };
            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult Getcategory()
        {

            var result = from u in db.Categories
                         select new
                         {
                             u.categoryId,
                             u.Cat_Name,
                             u.Cat_createdon,
                             u.customerId
                         };
            return Ok(result);
        }

        [HttpGet]
      //  public IHttpActionResult GetSurvey(int id)

        public IHttpActionResult GetSurvey(int id )
        {

           var result = from u in db.Surveys.Where(s=> s.categoryId == id)
                                     //var result = from u in db.Surveys

                                                  select new
                         {
                             u.Name,
                             u.SurveyId,
                             u.categoryId,
                             u.customerId

                         };
            return Ok(result);
        }
        [HttpGet]
        public IHttpActionResult GetQuestion(int id)
        {

            var result = from u in db.Questions.Where(u=>u.SurveyId == id)
                         select new
                         {
                             u.SurveyId,
                             u.Questionid,
                             u.customerId,
                             u.Q_text

                         };
            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult Getoptions(int f)
        {

            var result = from u in db.options.Where(o=>o.Questionid==f)
                         select new
                         {
                             u.op_text,
                             u.Questionid,
                             u.optionId


                         };
            return Ok(result);
        }
        [HttpGet]
        public IHttpActionResult Getnuser()
        {

            var result = from u in db.Users
                         select new
                         {
                             u.fname,
                             u.Lname,
                             u.email,
                             u.password,
                             u.IsActive,
                             u.Role,
                             u.gender


                         };
            return Ok(result);
        }
        //[HttpPost]
        //public IHttpActionResult PostUser(User user)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest("Not a valid model");

        //    using (CITIZENPULSEEntities3 dc = new CITIZENPULSEEntities3())
        //    {

        //        dc.Users.Add(user);
        //        dc.SaveChanges();
        //    }

        //    return CreatedAtRoute("GetTodo", new { id = user.userid }, user);


        //}
        //[HttpGet]
        //public IHttpActionResult GetById(long id)
        //{
        //    var item = db.Users.Find(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(item);
        //}
        [HttpPost]
        public IHttpActionResult Postuser([FromBody]User user)
        {

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Not a valid model");

                using (CITIZENPULSEEntities3 dc = new CITIZENPULSEEntities3())
                {
                   
                    dc.Users.Add(user);
                    dc.SaveChanges();
                }



            }


            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }



            return CreatedAtRoute("DefaultApi", new { id = user.userid }, user);

        }
        [HttpPost]
        public IHttpActionResult PostAnswer([FromBody]Sur_answer ans)
        {

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Not a valid model");

                using (CITIZENPULSEEntities3 dc = new CITIZENPULSEEntities3())
                {

                    dc.Sur_answer.Add(ans);
                    dc.SaveChanges();
                }



            }

            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            return CreatedAtRoute("DefaultApi", new { id = ans.Answerid }, ans);

        }

        [HttpPost]
        public IHttpActionResult PostAResponse([FromBody]sur_response res)
        {

            try { 
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
           
                using (CITIZENPULSEEntities3 dc = new CITIZENPULSEEntities3())
                {
                   // var mn = res.SurveyId;
                    //var ny = res.Respondon;
                    dc.sur_response.Add(res);
                    dc.SaveChanges();
                }

              

            }

            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            return CreatedAtRoute("DefaultApi", new { id = res.responseId }, res);

        }

        //[HttpPut]

        //public IHttpActionResult GetByresId(long id)
        //{
        //    var item = db.sur_response.Find(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(item);
        //}
        //[HttpPost]
        //public IHttpActionResult PostSurAns(Sur_answer ans)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest("Not a valid model");

        //    using (CITIZENPULSEEntities3 dc = new CITIZENPULSEEntities3())
        //    {

        //        dc.Sur_answer.Add(ans);
        //        dc.SaveChanges();
        //    }

        //    return CreatedAtRoute("GetTodo", new { id = ans.Answerid }, ans);


        //}
        //[HttpGet]
        //public IHttpActionResult GetByAnsId(long id)
        //{
        //    var item = db.Sur_answer.Find(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(item);
        //}


    }



    //      [HttpGet]
    //      public IHttpActionResult Geti()
    //      {
    //          var result = from u in db.Users
    //                       select new
    //                       {
    //                           u.userid,
    //                           u.fname,

    //                           cust = from c in db.Customers
    //                                  where c.userid == u.userid
    //                                  select new
    //                                  {
    //                                      c.customerId,
    //                                      c.createdOn,


    //                                       cat = from cat in db.Categories
    //                                             where cat.customerId == c.customerId
    //                                             select new
    //                                             {
    //                                                 cat.Cat_Name,

    //sur = from s in db.Surveys
    //      where cat.categoryId == s.categoryId
    //      select new
    //      {
    //          s.Name,
    //          s.Sur_createdon,

    //          Ques = from q in db.Questions
    //                where s.SurveyId == q.SurveyId
    //                select new
    //                {
    //                    q.Q_text,
    //                    q.order,
    //                    opt = from o in db.options
    //                          where o.Questionid == q.Questionid
    //                          select new
    //                          {
    //                              o.op_text

    //                          }
    //                          }
    //                          }
    //                          }
    //                    }



    //      };
    //                                   return Ok(result);

    //      }


    //  [HttpGet]
    //public string Get()
    //{
    //    return "Hello World";
    //}


    //[HttpGet]

    // GET api/HelloWorld/id
    //public string Get(string id)
    //    {
    //        return "Hello " + id;
    //    }





}
