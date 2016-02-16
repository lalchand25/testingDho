using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Security;

using System.Web.Mail;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using DhotGroupNew.Models;

namespace DhotGroupNew.Controllers
{
    public class loginController : Controller
    {
        Int32 ConfirmedUserid = 0;
        plugingaganzEntities db = new plugingaganzEntities();


        public ActionResult LogOn()
        {
            Session.Abandon();
            //Session.Add("projectmetatags", clsCommon.getMetaTag(232));
            SubRightData();
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model)
        {
            SubRightData();
            if (ModelState.IsValid)
            {
                String returnUrl = "";

                if (checkUser(model.UserName, model.Password))
                {
                    GenerateLogInformation();

                    if (Request.Form["returnurl"] != null)
                    {
                        returnUrl = Request.Form["returnurl"];
                        if (!String.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            //  return RedirectToAction("adminIndex", "misreports");
                            return RedirectToAction("profile", "profile");
                        }
                    }
                    else
                    {
                        //return RedirectToAction("adminIndex", "misreports");
                        return RedirectToAction("profile", "profile");
                    }

                }
            }
            else
            {
                // emailSystem.errorLog("Log On", Request.ServerVariables["REMOTE_ADDR"].ToString(), "Confirmation " + model.UserName, 0);

                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }


            // If we got this far, something failed, redisplay form
            return View(model);
        }

       // public ActionResult Image()
       // {
          //  var builder = new XCaptcha.ImageBuilder();
            //var result = builder.Create();
            //Session.Add("captcha", result.Solution);

          //  return new FileContentResult(result.Image, result.ContentType);

    //    }
        //private void CounsellingEnquiry(Int32 enqid)
        //{
        //    String pass = emailSystem.CreateRandomPassword(8);
        //    var model3 = (from m in db.tb_Counsellings
        //                  where m.ID == enqid
        //                  select m);

        //    if (model3.Count() > 0)
        //    {

        //        var model = (from m in db.tb_Counsellings
        //                     where m.ID == enqid
        //                     select m).Single();



        //        var model1 = (from m in db.pms_UserMasters
        //                      where m.EmailID == model.EmailID
        //                      select m);

        //        if (model1.Count() == 0)
        //        {
        //            tb_UserMaster pms = new tb_UserMaster();
        //            pms.CompanyID = 0;
        //            pms.FirstName = model.FirstName;
        //            pms.LastName = model.LastName;
        //            pms.MiddleName = "";
        //            pms.ProfileName = model.FirstName;
        //            pms.UserMainCateID = 3;
        //          //  pms.ReferUserID = 3;
        //            pms.ConfirmPassword = pass;
        //            pms.UserPassword = pass;
        //            pms.ContactNo = "";
        //            pms.EmailID = model.EmailID;
        //            pms.Picture = "BlankMan.png";
        //         //   pms.ProjectCategoryid = 4;

        //            pms.CreateDate = DateTime.Now;
        //            pms.IpAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
        //            pms.ModifiedDate = DateTime.Now;
        //            pms.CompanyID = 0;
        //            pms.Groupid = 0;
        //            pms.UserCateID = 0;
        //            pms.LastLogin = DateTime.Now;
        //            pms.ConfirmDate = DateTime.Now;
        //            //pms.ValidFrom = DateTime.Now;
        //            //pms.ValidUpTo = DateTime.Now.AddDays(365);

        //            //pms.ReferUserID = Convert.ToInt32(model.CreatedBy);
        //            //pms.ConfirmID = true;
        //            //pms.DeletedBy = "";
        //            //pms.DeleteStatus = "N";
        //            //pms.DeletionDate = DateTime.Now;
        //            pms.LastLogin = DateTime.Now;

        //            //pms.AvtarPicture = "default_avtar1.jpg";

        //            //pms.CityID = model.DistrictId;
        //            //pms.StateID = model.StateId;
        //            //pms.CountryID = model.countryid;
                    
        //            //pms.UserAddress = model.Address;
        //            //pms.ContactNo = model.Cell;




        //            pms.Terms = true;
        //            db.tb_UserMasters.InsertOnSubmit(pms);
        //            db.SubmitChanges();

        //            var model21 = (from m in db.tb_UserMasters
        //                           where m.UserID == pms.UserID
        //                           select m).Single();
        //          //  model21.promocode = 1234 + pms.UserID;
        //            db.SubmitChanges();
        //            var tmodel = (from m in db.tb_emailsDescriptions
        //                          where m.Autoid == 2
        //                          select m).Single();

        //            string desc = tmodel.Description;

        //            desc = desc.Replace("UserID", pms.EmailID);
        //            desc = desc.Replace("PassWord", pms.UserPassword);
        //            desc = desc.Replace("Pcode", model21.promocode.ToString());

        //            desc = desc.Replace("DearClient", "Dear " + pms.ProfileName + " [" + pms.EmailID + "]");
        //            clsCommon.SendEmailCurrentFormat(pms.EmailID, 2, 99999, Convert.ToInt32(pms.UserID), 0, 0, 0, desc, tmodel.EmailSubject, Request.ServerVariables["REMOTE_ADDR"].ToString());
        //            Session.Add("pmsuserid", pms.UserID);
        //            Session.Add("pmspromocode", pms.promocode);
        //            Session.Add("pmsusername", pms.AvtarName);
        //            Session.Add("emailid", pms.EmailID);
        //            Session.Add("cateid", pms.UserMainCateID);
        //            Session.Add("moduleid", 0);
        //            Session.Add("groupid", pms.Groupid);
        //            Session.Add("Imagepath", pms.AvtarPicture);
        //            Session.Add("projectcategory", pms.ProjectCategoryid);

        //            Session.Add("ProjectCategoryid", pms.ProjectCategoryid);
        //            model.ReferID = pms.UserID;

        //            db.SubmitChanges();

        //            var model111 = (from m in db.tb_DocumentMasters
        //                            where m.EqnuiryId == enqid
        //                            select m);
        //            if (model111.Count() > 0)
        //            {
        //                var model112 = (from m in db.tb_DocumentMasters
        //                                where m.EqnuiryId == enqid
        //                                select m).Single();

        //                model112.UserID = pms.UserID;
        //                db.SubmitChanges();
        //            }

        //            var tmodeldesc = (from m in db.tb_emailsDescriptions
        //                              where m.Autoid == 45
        //                              select m).Single();

        //            string emailbody = tmodeldesc.Description;
        //            string emailSubject = tmodeldesc.EmailSubject;
        //            emailbody = emailbody.Replace("UserName", pms.ProfileName + "<br> [" + pms.EmailID + "]");
        //            emailSubject = emailSubject.Replace("Client", pms.ProfileName);
        //            //clsCommon.SendEmailCurrentFormat(pms.EmailID, 0, 99999, Convert.ToInt32(pms.UserID), 0, 0, 0, emailbody, emailSubject, Request.ServerVariables["REMOTE_ADDR"].ToString());
   

        //            // return RedirectToAction("profile", "profile", new { usertype = pms.UserMainCateID });

        //        }

        //    }

        //}
        //private void FranchiseeEnquiry(Int32 enqid)
        //{
        //    String pass = emailSystem.CreateRandomPassword(8);
        //    var model3 = (from m in db.tb_CounsellingFranchisees
        //                  where m.ID == enqid
        //                  select m);

        //    if (model3.Count() > 0)
        //    {

        //        var model = (from m in db.tb_CounsellingFranchisees
        //                     where m.ID == enqid

        //                     select m).Single();
        //        var model1 = (from m in db.pms_UserMasters
        //                      where m.EmailID == model.EmailID
        //                      select m);

        //        if (model1.Count() == 0)
        //        {
        //            tb_UserMaster pms = new tb_UserMaster();
        //            pms.CompanyID = 0;
        //            pms.FirstName = model.FirstName;
        //            pms.LastName = model.LastName;
        //            pms.MiddleName = "";
        //            pms.ProfileName = model.FirstName;
        //            //pms.UserMainCateID = 17;
        //            pms.UserMainCateID = 3;
        //            pms.ConfirmPassword = pass;
        //            pms.UserPassword = pass;
        //            pms.ContactNo = "";
        //            pms.EmailID = model.EmailID;
        //            pms.Picture = "BlankMan.png";
        //            //pms.ReferUserID = 3;
        //            pms.CreateDate = DateTime.Now;
        //            pms.IpAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
        //            pms.ModifiedDate = DateTime.Now;
        //            pms.CompanyID = 0;
        //            pms.Groupid = 0;
        //            pms.UserCateID = 0;
        //            pms.LastLogin = DateTime.Now;
        //            pms.ConfirmDate = DateTime.Now;
        //            //pms.ValidFrom = DateTime.Now;
        //            //pms.ValidUpTo = DateTime.Now.AddDays(365);

        //            //pms.ConfirmID = true;
        //            //pms.ProjectCategoryid = 4;
        //            //pms.DeletedBy = "";
        //            //pms.DeleteStatus = "N";
        //            //pms.DeletionDate = DateTime.Now;
        //            pms.LastLogin = DateTime.Now;
        //            pms.Terms = true;

        //            //pms.CityID = model.DistrictId;
        //            //pms.StateID = model.StateID;
        //            //pms.CountryID = model.countryid;

        //            //pms.CountryChain = model.countryid;
        //            //pms.DistrictChain = model.DistrictId;
        //            //pms.StateChain = model.StateID;

        //            //pms.UserAddress = model.Address;
        //            //pms.ContactNo = model.Cell;
        //            //pms.FranCategory = model.FranCategory;
        //            //pms.AvtarPicture = "default_avtar1.jpg";

        //            //db.pms_UserMasters.InsertOnSubmit(pms);
        //            db.SubmitChanges();

        //            var model21 = (from m in db.pms_UserMasters
        //                           where m.UserID == pms.UserID
        //                           select m).Single();
        //            model21.promocode = 1234 + pms.UserID;
        //            db.SubmitChanges();

        //            var tmodel = (from m in db.tb_emailsDescriptions
        //                          where m.Autoid == 2
        //                          select m).Single();

        //            string desc = tmodel.Description;

        //            desc = desc.Replace("UserID", pms.EmailID);
        //            desc = desc.Replace("PassWord", pms.UserPassword);
        //            desc = desc.Replace("Pcode", model21.promocode.ToString());

        //            desc = desc.Replace("DearClient", "Dear " + pms.ProfileName + " [" + pms.EmailID + "]");

        //            //clsCommon.SendEmailCurrentFormat(pms.EmailID, 2, 99999, Convert.ToInt32(pms.UserID), 0, 0, 0, desc, tmodel.EmailSubject, Request.ServerVariables["REMOTE_ADDR"].ToString());
        //            Session.Add("pmsuserid", pms.UserID);
        //            //Session.Add("pmspromocode", pms.promocode);
        //            //Session.Add("pmsusername", pms.AvtarName);
        //            Session.Add("emailid", pms.EmailID);
        //            Session.Add("cateid", pms.UserMainCateID);
        //            Session.Add("moduleid", 0);
        //            Session.Add("groupid", pms.Groupid);
        //            //Session.Add("Imagepath", pms.AvtarPicture);
        //            //Session.Add("projectcategory", pms.ProjectCategoryid);
        //            //Session.Add("ProjectCategoryid", pms.ProjectCategoryid);

        //            //Transfering Enquiry for Actual User
        //            model.ReferID = pms.UserID;
        //            db.SubmitChanges();
        //            ////Transfering Chain and Promotor Code

        //            ////District 
        //            //if (model.FranCategory == 4)
        //            //{
        //            //    string strQuery = @"update pms_usermaster set businesscode=referuserid,referuserid=" + pms.UserID + " ,istrans = 1 where istrans = 0 and districtid=" + pms.DistrictChain;
        //            //    db.ExecuteCommand(strQuery);
        //            //}
        //            ////State Master
        //            //if (model.FranCategory == 5)
        //            //{
        //            //    string strQuery = @"update pms_usermaster set businesscode=referuserid,referuserid=" + pms.UserID + ",istrans = 1  where istrans = 0  and  stateid=" + pms.DistrictChain;
        //            //    db.ExecuteCommand(strQuery);
        //            //}
                    

        //            //Instrucdtion email

        //            var tmodeldesc = (from m in db.tb_emailsDescriptions
        //                              where m.Autoid == 49
        //                              select m).Single();

        //            string emailbody = tmodel.Description;
        //            string emailSubject = tmodel.EmailSubject;
        //            emailbody = emailbody.Replace("UserName", pms.ProfileName + "<br> [" + pms.EmailID + "]");
        //            emailSubject = emailSubject.Replace("Franchisee", pms.ProfileName);
        //            //clsCommon.SendEmailCurrentFormat(pms.EmailID, 0, 99999, Convert.ToInt32(pms.UserID), 0, 0, 0, emailbody, emailSubject, Request.ServerVariables["REMOTE_ADDR"].ToString());
         

        //        }

        //    }

        //}
        public ActionResult confirm(Int32 id)
        {
            try
            {
                String results = "";

                if (id == 0)
                {
                    if (Request.QueryString["enqid"] != null)
                    {
                        Int32 cid = 0;
                        Int32 enqtype = 0;

                        

                        if (Request.QueryString["enqid"] != null)
                        {
                            cid = Convert.ToInt32(Request.QueryString["enqid"].ToString());
                        }
                        if (Request.QueryString["enqtype"] != null)
                        {
                            enqtype = Convert.ToInt32(Request.QueryString["enqtype"].ToString());
                        }

                        if (enqtype == 99)
                        {
                           // FranchiseeEnquiry(cid);
                        }
                        else
                        {
                            //CounsellingEnquiry(cid);
                            return RedirectToAction("details", "ProcessEqnuiry", new { id = cid });
                        }

                        var pms = (from m in db.tb_UserMaster
                                   where m.UserID == Convert.ToInt32(Session["pmsuserid"])
                                   select m).Single();

                        return RedirectToAction("profile", "profile", new { usertype = pms.UserMainCateID });
                    }
                    else
                    {

                        results = "Invalid Link !!!!!";
                    }
                }
                else
                {
                    var tb = (from c in db.tb_UserMaster where c.UserID == id && c.ConfirmID == false select c).Single();

                    if (tb != null)
                    {
                        tb_UserMaster pms = (from m in db.tb_UserMaster where m.UserID == id select m).Single();
                        pms.ConfirmID = true;
                        pms.ConfirmDate = DateTime.Now;
                        //pms.ValidFrom = DateTime.Now;
                        //pms.ValidUpTo = DateTime.Now.AddDays(365);
                        //pms.AvtarPicture = "default_avtar1.jpg";

                        db.SaveChanges();
                        results = "User ID has been confirmed";


                        var tmodel = (from m in db.tb_emailsDescription
                                      where m.Autoid == 2
                                      select m).Single();

                        string desc = tmodel.Description;
                        desc = desc.Replace("UserID", pms.EmailID);
                        desc = desc.Replace("PassWord", pms.UserPassword);
                      //  desc = desc.Replace("Pcode", pms.promocode.ToString());
                        desc = desc.Replace("DearClient", "Dear " + pms.ProfileName + " [" + pms.EmailID + "]");

                        //emailSystem.sendComments(pms.EmailID, tmodel.EmailSubject, desc, "");
                        //clsCommon.SendEmailCurrentFormat(pms.EmailID,0, 99999, Convert.ToInt32(pms.UserID), 0, 0, 0, desc, tmodel.EmailSubject, Request.ServerVariables["REMOTE_ADDR"].ToString());
                        
                        if (pms.UserMainCateID == 1)
                        {
                            var tmodeldesc = (from m in db.tb_emailsDescription
                                              where m.Autoid == 47
                                              select m).Single();

                            string emailbody = tmodeldesc.Description;
                            string emailSubject = tmodeldesc.EmailSubject;
                            emailbody = emailbody.Replace("UserName", pms.ProfileName + "<br> [" + pms.EmailID + "]");
                            emailSubject = emailSubject.Replace("PA", pms.ProfileName);
                            //clsCommon.SendEmailCurrentFormat(pms.EmailID, 0, 99999, Convert.ToInt32(pms.UserID), 0, 0, 0, emailbody, emailSubject, Request.ServerVariables["REMOTE_ADDR"].ToString());
                        } 
                        
                      
    
                        //var model111 = (from m in db.tb_pageDescriptions
                        //                where
                        //                    m.Pageid == 19
                        //                select m).Single();

                     //   Session.Add("marqmessage", model111.Description);
                        Session.Add("pmsuserid", pms.UserID);
                        //Session.Add("pmspromocode", pms.promocode);
                        //Session.Add("pmsusername", pms.AvtarName);
                        Session.Add("cateid", pms.UserMainCateID);
                        Session.Add("moduleid", 0);


                        Session.Add("groupid", pms.Groupid);
                        //Session.Add("Imagepath", pms.AvtarPicture);
                        Session.Add("emailid", pms.EmailID);
                        //Session.Add("ProjectCategoryid", pms.ProjectCategoryid);
                       
                         return RedirectToAction("profile", "profile", new { usertype = 1 });

                    }
                    else
                    {
                         var model111 = (from m in db.tb_emailsDescription
                                where
                                    m.Autoid == 33
                                select m).Single();
                                      
                        results = model111.Description;
                    }
                }

                ViewData["results"] = results;
            }
            catch (Exception ce)
            {
               // emailSystem.errorLog(ce.Message, Request.ServerVariables["REMOTE_ADDR"].ToString(), "Confirmation", id);
                var model111 = (from m in db.tb_emailsDescription
                                where
                                    m.Autoid == 33
                                select m).Single();

                
                ViewData["results"] = model111.Description;
            }
            return View();
        }

        public ActionResult forgotpassword()
        {
            //var model = (from m in db.tb_pageDescriptions
            //             where
            //                 m.Pageid == 35
            //             select m).Single();

            //ViewData["pagedescription"] = model.Description;
            //ViewData["PageTitle"] = model.Title;

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult forgotpassword(String UserName, String captchatext)
        {
            //Please correct the following errors. Fields with errors are highlighted.<br />&nbsp;You have entered an Invalid Email Address. Please try again. 
            //var model = (from m in db.tb_pageDescriptions
            //             where
            //                 m.Pageid == 35
            //             select m).Single();

            //ViewData["pagedescription"] = model.Description;
            //ViewData["PageTitle"] = model.Title;

            try
            {
                //String sessionCap = Session["captcha"].ToString();
                var pdEmail = from c in db.tb_UserMasterDhot where c.EmailID == UserName select c;
                if (pdEmail.Count() == 0)
                    ViewData.ModelState.AddModelError("EmailID", " Please enter a the valid e-mail ID!");
                const string emailregex = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                if (string.IsNullOrEmpty(UserName) ||  !Regex.IsMatch(UserName, emailregex))
                    ViewData.ModelState.AddModelError("email", " Please enter a the valid e-mail ID!");
                if (string.IsNullOrEmpty(UserName))
                    ViewData.ModelState.AddModelError("EmailID", " Please enter a the valid e-mail ID!");
                //if (string.IsNullOrEmpty(captchatext))
                //    ViewData.ModelState.AddModelError("captchatext", " Please enter the image in Red Color text !");
                //if (!String.Equals(captchatext, sessionCap, StringComparison.CurrentCultureIgnoreCase))
                //    ViewData.ModelState.AddModelError("captchatext", " Please enter the image in Red Color text !");
                if (!ViewData.ModelState.IsValid)
                {
                    return View();
                }

                var pd = db.tb_UserMasterDhot.Single(a => a.EmailID == UserName);
                String password = "";
                if (pd != null)
                {
                    password = pd.UserPassword;

                    var modelg = (from m in db.tb_emailsDescription
                                  where m.Autoid == 1
                                  select m).Single();

                    string emailbody1 = modelg.Description;
                    emailbody1 = emailbody1.Replace("profilename", pd.ProfileName);
                    emailbody1 = emailbody1.Replace("sUserID", pd.EmailID);
                    emailbody1 = emailbody1.Replace("sPassWord", pd.UserPassword);
                 //   emailbody1 = emailbody1.Replace("Pcode", pd.promocode.ToString());


                    emailSystem.sendEmailold(pd.EmailID, modelg.EmailSubject, emailbody1);
                 

                 //   clsCommon.SendEmailCurrentFormat(pd.EmailID, 3, 99999, Convert.ToInt32(pd.UserID), 0, 0, 0, emailbody1, modelg.EmailSubject, Request.ServerVariables["REMOTE_ADDR"].ToString());

                              
                    ViewData["error"] = "Sent";
                    ViewData["message"] = "Thank you<br /><br />Dear Member,<br />We have sent you an email on " + UserName + " with your password.<br /><br />";
                    
                    
                    return RedirectToAction("emailsent");
                }

                else
                {
                    ViewData["message"] = "invalid Emailid";
                }
            }
            catch (Exception ce)
            {
                String message = ce.Message;
                ViewData["message"] = message;
            }
            return View();
        }


        private void SubRightData()
        {


          

            //var model111 = (from m in db.tb_pageDescriptions
            //                where
            //                    m.Pageid == 19
            //                select m).Single();

            //Session.Add("marqmessage", model111.Description);
            //Session.Add("modulename", "Login Area");

            //var model = (from m in db.tb_pageDescriptions
            //             where
            //                 m.Pageid == 33
            //             select m).Single();

            //ViewData["pagedescription"] = model.Description;
            //ViewData["PageTitle"] = model.Title;
        
        }

      
        private void GenerateLogInformation()
        {
            if (Session.SessionID != null)
            {
                tb_UserHistory model = new tb_UserHistory();

                model.IpAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                model.UserID = Convert.ToInt32(Session["pmsuserid"]);

                model.LoginTime = DateTime.Now;
                model.LogoutStatus = true;
                model.SessionName = Session.SessionID;
                model.Timeout = DateTime.Now;
                model.TimeStamp = DateTime.Now;
                model.SystemDate = DateTime.Now;
                db.tb_UserHistory.AddObject(model);
                db.SaveChanges();
            }
        }
        private Boolean checkUser(string emailid, string password)
        {
            
                Boolean loginstatus = false;
                //var tb = from m in db.tb_UserMasters
                //         where m.EmailID == emailid 
                //         select m;

                var tb = from m in db.tb_UserMasterDhot 
                         where m.EmailID == emailid
                         select m;

                //var tb = from m in db.tb_UserMasters
                //         where m.EmailID == emailid && m.ConfirmID == true
                //         select m;
                if (tb != null && tb.Count() > 0)
                {
                    tb_UserMasterDhot tb1 = db.tb_UserMasterDhot.Single(p => p.EmailID == emailid);

                    //var gcat = (from m in db.tb_UserMasters
                    //            where m.MainCateid == tb1.UserMainCateID
                    //            select m).Single();

               //     Session.Add("catname", gcat.MainCateName);


                    string password1 = tb1.UserPassword.ToString();

                    if (String.Equals(password1, password, StringComparison.Ordinal))
                    {
                        var item = (from m in db.tb_UserMaster                              
                                    select m);


                        if (item.Count() > 0)
                        {
                            //foreach (var tt in item)
                            //{
                            //    if (tt.Logopath != "")
                            //    {
                            //        string url = "<a href='/Home'><img src='../../uploads/" + tt.Logopath + "' alt='Logo' width='263' height='58' /></a>";
                            //        Session.Add("companylogo", url);
                            //        Session.Add("companyid", tt.CompanyID);

                            //        string contacts = "Mobile No:  " + tt.Cell + "  Phone No:  " + tt.PhoneNo + "  Website:  " + tt.Website + "  Emailid:  " + tt.EmailId + "  Fax:  " + tt.Fax;
                            //        string address = "<span style='color: #FF0000;font-size: large;'><strong>" + tt.Name + "</strong></span> <br />  " + tt.Address + "  " + tt.City + "  " + tt.State + "  " + tt.Country + "  " + tt.ZipCode;

                            //        Session.Add("contacts", contacts);
                            //        Session.Add("address", address);
                            //        Session.Add("DispalyName", tt.Slogan);
                                   

                            //        var model1 = (from m in db.tb_pageDescriptions
                            //                      where
                            //                          m.Pageid == 19
                            //                      select m).Single();

                            //        Session.Add("marqmessage", model1.Description);
                            //    }
                            //}
                        }
                        else
                        {
                            //var item1 = (from m in db.tb_Companies
                            //             where m.CreatedBy == tb1.ReferUserID.ToString()
                            //             select m);
                            //if (item.Count() > 0)
                            //{
                            //    foreach (var tt in item)
                            //    {
                            //        if (tt.Logopath != "")
                            //        {
                            //            string url = "<a href='/Home'><img src='../../uploads/" + tt.Logopath + "' alt='Logo' width='263' height='58' /></a>";
                            //            Session.Add("companylogo", url);
                            //            string contacts = "Mobile No:" + tt.Cell + " Phone No:" + tt.PhoneNo + " Website:" + tt.Website + " Emailid:" + tt.EmailId + " Fax:" + tt.Fax;
                            //            string address = tt.DispalyName + "," + tt.Address + "," + tt.City + "," + tt.State + "," + tt.Country + "," + tt.ZipCode;

                            //            Session.Add("contacts", contacts);
                            //            Session.Add("address", address);

                            //            var model1 = (from m in db.tb_pageDescriptions
                            //                          where
                            //                              m.Pageid == 19
                            //                          select m).Single();

                            //            Session.Add("marqmessage", model1.Description);
                            //        }
                            //    }
                            //}
                        }


                        Session.Add("pmsuserid", tb1.UserID);
                        //Session.Add("pmspromocode", tb1.promocode);
                        Session.Add("pmsusername", tb1.FirstName);
                        Session.Add("cateid", tb1.UserMainCateID);
                        Session.Add("moduleid", 0);
                       // Session.Add("groupid", tb1.Groupid);
                        //if (tb1.Picture != "")
                        //{
                        //    Session.Add("Imagepath", tb1.Picture);
                        //}
                        //else
                        //{
                        //    Session.Add("Imagepath", "BlankMan.png");

                        //}

                        Session.Add("emailid", tb1.EmailID);
                        //Session.Add("ProjectCategoryid", tb1.ProjectCategoryid);



                      //  tb1.LastLogin = DateTime.Now;
                        db.SaveChanges();
                        loginstatus = true;
                    }

                }

              //  emailSystem.errorLog("Model error", Request.ServerVariables["REMOTE_ADDR"].ToString(), "Log on" + emailid, 0);
                return loginstatus;
            
        }

        //[HttpPost]
        //public ActionResult LogOn(LogOnModel model)
        //{
        //    SubRightData();
        //    if (ModelState.IsValid)
        //    {
        //        String returnUrl = "";

        //        if (checkUser(model.UserName, model.Password))
        //        {
        //            GenerateLogInformation();
  
        //            if (Request.Form["returnurl"] != null)
        //            {
        //                returnUrl = Request.Form["returnurl"];
        //                if (!String.IsNullOrEmpty(returnUrl))
        //                {
        //                    return Redirect(returnUrl);
        //                }
        //                else
        //                {
        //                  //  return RedirectToAction("adminIndex", "misreports");
        //                   return RedirectToAction("profile", "profile");
        //                }
        //            }
        //            else
        //            {
        //                //return RedirectToAction("adminIndex", "misreports");
        //                return RedirectToAction("profile", "profile");
        //            }

        //        }
        //    }
        //    else
        //    {
        //       // emailSystem.errorLog("Log On", Request.ServerVariables["REMOTE_ADDR"].ToString(), "Confirmation " + model.UserName, 0);

        //        ModelState.AddModelError("", "The user name or password provided is incorrect.");
        //    }


        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        // **************************************
        // URL: /Account/LogOff
        // **************************************
        public ActionResult emailsent()
        {

            return View();
        }
        public ActionResult LogOff()
        {
            //if (Session.SessionID != null)
            //{
            //    var model = (from m in db.tb_UserHistories
            //                 where m.SessionName == Session.SessionID
            //                 select m);
            //    if (model.Count() > 0)
            //    {

            //        var model1 = (from m in db.tb_UserHistories
            //                      where m.SessionName == Session.SessionID
            //                      select m).Single();

            //        model1.Timeout = DateTime.Now;
            //        model1.LogoutStatus = false;
            //        db.SubmitChanges();

            //    }
            //}
            Session.Abandon();
            return RedirectToAction("index", "Home");
        }
        public ActionResult LogOff1()
        {

            return View();

        }
    }

}
