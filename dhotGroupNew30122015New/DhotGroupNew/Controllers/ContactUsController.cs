using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DhotGroupNew.Models;
using System.Text.RegularExpressions;
namespace dhotGroupNew.Controllers
{
    public class ContactUsController : Controller
    {
        plugingaganzEntities db = new plugingaganzEntities ();

        public ActionResult success()
        {
            return View();

        }

        public ActionResult contactus()
        {
            //ViewData["PageTitle"] = "studyWorkImmigrate.com : Contact us";
            //var model = (from m in db.tb_pageDescriptions
            //             where
            //                 m.Pageid == 6
            //             select m).Single();

            //ViewData["pagedescription"] = model.Description;
            //ViewData["PageTitle"] = model.Title;
            return View();


        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult contactus(tb_ContactUs model, String captchatext)
        {

            try
            {
                //String sessionCap = Session["captcha"].ToString();

                const string emailregex = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                if (!string.IsNullOrEmpty(model.EmailId) && !Regex.IsMatch(model.EmailId, emailregex))
                    ViewData.ModelState.AddModelError("email", " Please enter a the valid e-mail ID!");
                if (string.IsNullOrEmpty(model.EmailId))
                    ViewData.ModelState.AddModelError("EmailID", " Please enter a the valid e-mail ID!");
                if (string.IsNullOrEmpty(model.FirstName))
                    ViewData.ModelState.AddModelError("FirstName", " Please enter a the First Name!");
                if (string.IsNullOrEmpty(model.LastName))
                    ViewData.ModelState.AddModelError("LastName", " Please enter a the Last Name!");

                //if (string.IsNullOrEmpty(model.Location))
                //    ViewData.ModelState.AddModelError("Location", " Please enter a the Location!");

                if (string.IsNullOrEmpty(model.ContactNo))
                    ViewData.ModelState.AddModelError("ContactNo", " Please enter a the Contact No!");

                if (string.IsNullOrEmpty(model.Comments))
                    ViewData.ModelState.AddModelError("Comments", " Please enter a the Comments!");

                //if (string.IsNullOrEmpty(captchatext))
                //    ViewData.ModelState.AddModelError("captchatext", " Please enter the image in Red Color text !");

                //if (!String.Equals(captchatext, sessionCap, StringComparison.CurrentCultureIgnoreCase))
                //    ViewData.ModelState.AddModelError("captchatext", " Please enter the image in Red Color text !");

                if (!ViewData.ModelState.IsValid)
                {
                    return View();
                }
                model.SystemDate = DateTime.Now;
                db.tb_ContactUs.AddObject(model);
                db.SaveChanges();

                string emailid = model.EmailId;

                //Sending email to concern Person
                //BY Lal
                string emailSubject = "";
                string emailBody = "";
                //string emailHeader = clsCommon.getEmailHeader(emailid);
                //string emailFooter = clsCommon.getEmailBottom(emailid);
                //var item = (from m in db.tb_emailsDescriptions
                //            where m.setmoduleid == 29
                //            select m).Single();

                //emailSubject = item.EmailSubject;
                emailSubject = "Contact Us   "; //+model.subject ;
                //emailBody = item.Description;
                emailBody += "First Name :" + model.FirstName + " <br/>  <br/>";
                emailBody += "Last Name  :" + model.LastName + " <br/>  <br/>";
                emailBody += "Email Id   :" + model.EmailId + " <br/>  <br/>";
                emailBody += "Contact No :" + model.ContactNo + " <br/>  <br/>";
                emailBody += "Comments   :" + model.Comments + " <br/>  <br/>";

                string ForDispaly = emailBody;

                //emailBody = emailHeader + emailBody + emailFooter;

                //ViewData["emailstatus"] = item.Description;
                //ForDispaly = ForDispaly.Replace("Client", model.FirstName + " " + model.LastName);

                //  emailBody = emailBody.Replace("Client", model.FirstName + " " + model.LastName);
                emailid = model.EmailId;
                emailSystem.sendEmailold(emailid, emailSubject, emailBody);
                //End of EMail 

                ViewData["message"] = "Email has sent to concern person";

                //  ViewData["message"] = ForDispaly;


                return RedirectToAction("success");

            }
            catch (Exception ce)
            {
                String message = ce.Message;
                ViewData["messageERR"] = message;
            }
            return View();
        }

        //
        // GET: /ContactUs/


        public ActionResult contactusForUser()
        {
            //ViewData["PageTitle"] = "studyWorkImmigrate.com : Contact us";
            //var model = (from m in db.tb_pageDescriptions
            //             where
            //                 m.Pageid == 6
            //             select m).Single();

            //ViewData["pagedescription"] = model.Description;
            //ViewData["PageTitle"] = model.Title;
            return View();
            
        }

   

        public ActionResult Index()
        {
            var tbCon = (from m in db.tb_ContactUs where m.ID> 24 orderby m.ID descending select m).ToList();
            return View(tbCon);
        }
        //
        // GET: /ContactUs/Details/5

        public ActionResult Details( )
        {
            return View();
        }

        //
        // GET: /ContactUs/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ContactUs/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ContactUs/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /ContactUs/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ContactUs/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ContactUs/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
