using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using System.Text.RegularExpressions;
using System.Net.Mail;
using DhotGroupNew.Models;

namespace DhotGroupNew.Controllers
{
    public class EnquiryController : Controller
    {
        plugingaganzEntities db = new plugingaganzEntities();
        public ActionResult success()
        {
            return View();
        }

        public ActionResult notsuccess()
        {
            return View();
        }

        public ActionResult Enquiry(int id)
        {
            var tb = (from m in db.tb_PageDescription where m.Pageid == id select m).Single();

            ViewData["pageTitle"] = tb.Title;
            Session.Add("PageTitle", tb.Title); // for email
            ViewData["PageDesc"] = tb.Description;

            return View();

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Enquiry(tb_EnquiryDhot model, int id, String captchatext)
        {
            try
            {

                const string emailregex = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                if (!string.IsNullOrEmpty(model.EmailId) && !Regex.IsMatch(model.EmailId, emailregex))
                    ViewData.ModelState.AddModelError("email", " Please enter a the valid e-mail ID!");
                if (string.IsNullOrEmpty(model.EmailId))
                    ViewData.ModelState.AddModelError("EmailID", " Please enter a the valid e-mail ID!");
                if (string.IsNullOrEmpty(model.FirstName))
                    ViewData.ModelState.AddModelError("FirstName", " Please enter a the First Name!");
                if (string.IsNullOrEmpty(model.ContactNo))
                    ViewData.ModelState.AddModelError("ContactNo", " Please enter a the Contact No!");
                if (string.IsNullOrEmpty(model.Comments))
                    ViewData.ModelState.AddModelError("Comments", " Please enter a the Comments!");
                if (!ViewData.ModelState.IsValid)
                {
                    return View();
                }

                string filename = "";
                string filePath = "";
                foreach (string inputTagName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[inputTagName];
                    if (file.ContentLength < 60000000)
                    {
                        String FileExtension = Path.GetExtension(file.FileName).ToLower();
                        if (FileExtension == ".png" || FileExtension == ".jpeg" || FileExtension == ".jpg" || FileExtension == ".txt" || FileExtension == ".doc"
                   || FileExtension == ".gif" || FileExtension == ".xls" || FileExtension == ".xlsx" || FileExtension == ".zip" || FileExtension == ".docx" || FileExtension == ".pdf")
                        {
                            string randName = emailSystem.CreateRandomPassword(5);
                            filename = randName + "_" + file.FileName;
                            filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename);
                            file.SaveAs(filePath);
                        }
                    }
                }
                model.filepath = filename;
                model.SystemDate = DateTime.Now;
                db.tb_EnquiryDhot.AddObject(model);
                db.SaveChanges();

                string emailid = model.EmailId;

                //Sending email to concern Person
                //BY Lal

                string emailBody = "";

                var tb = (from m in db.tb_PageDescription where m.Pageid == id select m).Single();
                string emailSubject = tb.Title;

                emailSubject = "Contact Us   " + tb.Title;
                emailBody += " Name :" + model.FirstName + " <br/>  <br/>";
                emailBody += "Email Id   :" + model.EmailId + " <br/>  <br/>";
                emailBody += "Contact No :" + model.ContactNo + " <br/>  <br/>";
                emailBody += "Comments   :" + model.Comments + " <br/>  <br/>";
                string ForDispaly = emailBody;
                //  string emailtodhot = "info@dhotgroup.com";
                emailid = model.EmailId;
                // ====================================================================================================
                Attachment data = new Attachment(filePath);


                string bottom = "";
                emailBody += bottom;
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                System.Net.NetworkCredential cred = new System.Net.NetworkCredential("info@dhotgroup.com", "group4321");
                mail.To.Add("info@dhotgroup.com");
                //mail.To.Add("lal@gaganz.com");

                mail.Subject = emailSubject;
                mail.From = new System.Net.Mail.MailAddress("info@dhotgroup.com");
                mail.Priority = MailPriority.High;
                mail.IsBodyHtml = true;
                mail.Body = emailBody;
                mail.Attachments.Add(data);
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("relay-hosting.secureserver.net");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = cred;
                smtp.EnableSsl = false;
                smtp.Port = 25;
                smtp.Send(mail);


                // ========================================================================
                //emailSystem.sendEmailold(emailtodhot, emailSubject, emailBody );

                string emailbodytoClient = "";
                emailbodytoClient = " Thanks for your following information, We will  get back to you soon <br/> <br/>";
                emailbodytoClient += emailBody;
                emailbodytoClient += " <br/> <br/> Thanks <br/> <br/> Dhot Group of Services Inc. Team ";
                emailSystem.sendEmailold(emailid, emailSubject, emailbodytoClient);

                ViewData["message"] = "Email has sent to concern person";

                return RedirectToAction("success");

            }
            catch (Exception ce)
            {
                String message = ce.Message;
                ViewData["messageERR"] = message;
            }
            return View();
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EnquiryBottom(String captchatext, FormCollection form)
        {
            try
            {
                string name = "", email = "", contact = "", prps = "";
                if (Request.Form["name"] != null && Request.Form["name"] != "")
                {
                    name = (Request.Form["name"]).ToString();
                }
                if (Request.Form["email"] != null && Request.Form["email"] != "")
                {
                    email = (Request.Form["email"]).ToString();
                }
                if (Request.Form["contact"] != null && Request.Form["contact"] != "")
                {
                    contact = (Request.Form["contact"]).ToString();
                }
                if (Request.Form["prps"] != null && Request.Form["prps"] != "")
                {
                    prps = (Request.Form["prps"]).ToString();
                }
                string emailid = email;
                string emailBody = "";

                string emailSubject = "Contact Us   ";
                emailBody += "Name :" + name + " <br/>  <br/>";
                emailBody += "Email Id   :" + email + " <br/>  <br/>";
                emailBody += "Contact No :" + contact + " <br/>  <br/>";
                emailBody += "Comments   :" + prps + " <br/>  <br/>";
                string ForDispaly = emailBody;


                string filename = "";
                string filePath = "";
                foreach (string inputTagName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[inputTagName];
                    if (file.ContentLength < 60000000)
                    {
                        String FileExtension = Path.GetExtension(file.FileName).ToLower();
                        if (FileExtension == ".png" || FileExtension == ".jpeg" || FileExtension == ".jpg" || FileExtension == ".txt" || FileExtension == ".doc"
                   || FileExtension == ".gif" || FileExtension == ".xls" || FileExtension == ".xlsx" || FileExtension == ".zip" || FileExtension == ".docx" || FileExtension == ".pdf")
                        {
                            string randName = emailSystem.CreateRandomPassword(5);
                            filename = randName + "_" + file.FileName;
                            filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename);
                            file.SaveAs(filePath);
                        }
                    }
                }
                tb_EnquiryDhot model = new tb_EnquiryDhot();

                model.EmailId = email;
                model.FirstName = name;
                model.ContactNo = contact;
                model.Comments = prps;
                model.filepath = filename;
                model.SystemDate = DateTime.Now;
                db.tb_EnquiryDhot.AddObject(model);
                db.SaveChanges();

                if (emailid != "")
                {


                    // ====================================================================================================
                    if (filePath != "")
                    {
                        Attachment data = new Attachment(filePath);


                        string bottom = "";
                        emailBody += bottom;
                        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                        System.Net.NetworkCredential cred = new System.Net.NetworkCredential("info@dhotgroup.com", "group4321");
                        mail.To.Add("info@dhotgroup.com");
                        //  mail.To.Add("lal@gaganz.com");

                        mail.Subject = emailSubject;
                        mail.From = new System.Net.Mail.MailAddress("info@dhotgroup.com");
                        mail.Priority = MailPriority.High;
                        mail.IsBodyHtml = true;
                        mail.Body = emailBody;
                        mail.Attachments.Add(data);
                        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("relay-hosting.secureserver.net");
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = cred;
                        smtp.EnableSsl = false;
                        smtp.Port = 25;
                        smtp.Send(mail);
                    }
                    else
                    {
                      


                        string bottom = "";
                        emailBody += bottom;
                        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                        System.Net.NetworkCredential cred = new System.Net.NetworkCredential("info@dhotgroup.com", "group4321");
                        mail.To.Add("info@dhotgroup.com");
                        //  mail.To.Add("lal@gaganz.com");

                        mail.Subject = emailSubject;
                        mail.From = new System.Net.Mail.MailAddress("info@dhotgroup.com");
                        mail.Priority = MailPriority.High;
                        mail.IsBodyHtml = true;
                        mail.Body = emailBody;
                 
                        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("relay-hosting.secureserver.net");
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = cred;
                        smtp.EnableSsl = false;
                        smtp.Port = 25;
                        smtp.Send(mail);
                    
                    }
                }
                // ========================================================================
                //emailSystem.sendEmailold(emailtodhot, emailSubject, emailBody );





                if (emailid != "")
                {

                    // string emailtodhot = "info@dhotgroup.com";
                    //  emailSystem.sendEmailold(emailtodhot, emailSubject, emailBody);
                    string emailbodytoClient = "";
                    emailbodytoClient = " Thanks for your following information, We will  get back to you soon <br/> <br/>";
                    emailbodytoClient += emailBody;
                    emailbodytoClient += " <br/>  Thanks <br/> <br/> Dhot Group of Services Inc. Team ";
                    emailSystem.sendEmailold(emailid, emailSubject, emailbodytoClient);
                    ViewData["message"] = "Email has sent to concern person";
                    return RedirectToAction("success");
                }
            }
            catch (Exception ce)
            {
                String message = ce.Message;
                ViewData["messageERR"] = message;
                Session.Add("messageERR", message);
            }
            return RedirectToAction("notsuccess");

        }




        //public class branch
        //{
        //    string id { get; set; }
        //    string name { get; set; }
        //}


        public class branch
        {
            public string id { get; set; }
            public string name { get; set; }

        }

        public void setview()
        {
            var text = new[] { new branch { id = "Residential", name = "Residential" }, new branch { id = "Commercial", name = "Commercial" } };

            var list1 = new SelectList(text, "id", "name");

            ViewData["typeData"] = list1;
        }



        public ActionResult EnquiryRealEstate(int id)
        {
            setview();
            var tb = (from m in db.tb_PageDescription where m.Pageid == id select m).Single();

            ViewData["pageTitle"] = tb.Title;
            ViewData["PageDesc"] = tb.Description;

            return View();

        }





        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EnquiryRealEstate(tb_EnquiryDhot model, int id, String captchatext)
        {
            try
            {
                setview();

                const string emailregex = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                if (!string.IsNullOrEmpty(model.EmailId) && !Regex.IsMatch(model.EmailId, emailregex))
                    ViewData.ModelState.AddModelError("email", " Please enter a the valid e-mail ID!");
                if (string.IsNullOrEmpty(model.EmailId))
                    ViewData.ModelState.AddModelError("EmailID", " Please enter a the valid e-mail ID!");
                if (string.IsNullOrEmpty(model.FirstName))
                    ViewData.ModelState.AddModelError("FirstName", " Please enter a the First Name!");
                if (string.IsNullOrEmpty(model.ContactNo))
                    ViewData.ModelState.AddModelError("ContactNo", " Please enter a the Contact No!");
                if (string.IsNullOrEmpty(model.Comments))
                    ViewData.ModelState.AddModelError("Comments", " Please enter a the Comments!");
                if (!ViewData.ModelState.IsValid)
                {
                    return View();
                }


                string filename = "";

                foreach (string inputTagName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[inputTagName];
                    if (file.ContentLength < 60000000)
                    {
                        String FileExtension = Path.GetExtension(file.FileName).ToLower();
                        if (FileExtension == ".png" || FileExtension == ".jpeg" || FileExtension == ".jpg" || FileExtension == ".txt" || FileExtension == ".doc"
                   || FileExtension == ".gif" || FileExtension == ".xls" || FileExtension == ".xlsx" || FileExtension == ".zip" || FileExtension == ".docx" || FileExtension == ".pdf")
                        {
                            string randName = emailSystem.CreateRandomPassword(5);
                            filename = randName + "_" + file.FileName;
                            string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename);
                            file.SaveAs(filePath);
                        }
                    }
                }
                model.filepath = filename;


                model.SystemDate = DateTime.Now;
                db.tb_EnquiryDhot.AddObject(model);
                db.SaveChanges();

                string emailid = model.EmailId;

                //Sending email to concern Person
                //BY Lal

                string emailBody = "";

                var tb = (from m in db.tb_PageDescription where m.Pageid == id select m).Single();
                string emailSubject = tb.Title + "-" + model.EnquiryType;


                emailSubject = "Contact Us   " + tb.Title;
                emailBody += " Name :" + model.FirstName + " <br/>  <br/>";
                emailBody += "Email Id   :" + model.EmailId + " <br/>  <br/>";
                emailBody += "Contact No :" + model.ContactNo + " <br/>  <br/>";
                emailBody += "Comments   :" + model.Comments + " <br/>  <br/>";
                string ForDispaly = emailBody;
                string emailtodhot = "info@dhotgroup.com";
                emailid = model.EmailId;
                emailSystem.sendEmailold(emailtodhot, emailSubject, emailBody);
                string emailbodytoClient = "";
                emailbodytoClient = " Thanks for your following information, We will  get back to you soon <br/> <br/>";
                emailbodytoClient += emailBody;
                emailbodytoClient += " <br/> <br/> Thanks <br/> <br/> Dhot Group of Services Inc. Team ";
                emailSystem.sendEmailold(emailid, emailSubject, emailbodytoClient);

                ViewData["message"] = "Email has sent to concern person";

                return RedirectToAction("success");

            }
            catch (Exception ce)
            {
                String message = ce.Message;
                ViewData["messageERR"] = message;
            }
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
        public ActionResult contactus(tb_EnquiryDhot model, String captchatext)
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
                db.tb_EnquiryDhot.AddObject(model);
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
            var tbCon = (from m in db.tb_ContactUs where m.ID > 24 orderby m.ID descending select m).ToList();
            return View(tbCon);
        }

        public ActionResult EnquiryList()
        {
            var tbEnq = (from m in db.tb_EnquiryDhot orderby m.ID descending select m).ToList();
            return View(tbEnq);
        }

        //
        // GET: /ContactUs/Details/5

        public ActionResult Details()
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
            var tbdel = (from m in db.tb_EnquiryDhot where m.ID == id select m).Single();
            return View(tbdel);
        }

        //
        // POST: /ContactUs/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var tbdel = (from m in db.tb_EnquiryDhot where m.ID == id select m).Single();
                db.tb_EnquiryDhot.DeleteObject(tbdel);
                db.SaveChanges();
                return RedirectToAction("EnquiryList");
            }
            catch
            {
                return View();
            }
        }
    }
}
