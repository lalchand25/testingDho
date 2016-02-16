using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DhotGroupNew.Models;
using System.Net.Mail;
namespace DhotGroupNew.Models
{
    public static class emailSystem
    {
        //public static void SetCookie(string name, string value)
        //{
           
        //    HttpCookie myCookie = new HttpCookie(name);
        //    myCookie.Value = value;
        //    myCookie.Expires.Date.AddDays(7);

        //    HttpContext.Current.Response.Cookies.Add(myCookie);

        //}

        //public static HttpCookie GetCookie(string name)
        //{
        //    return HttpContext.Current.Request.Cookies[name];
        //}

        public static string sendEmailold(String emailTo, string strSubject, string strbody)
        {
            string msg = "";
            try
            {

                string bottom = "";
                strbody += bottom;
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                System.Net.NetworkCredential cred = new System.Net.NetworkCredential("info@dhotgroup.com", "group4321");
                mail.To.Add(emailTo);
                mail.Subject = strSubject;
                mail.From = new System.Net.Mail.MailAddress("info@dhotgroup.com");
                mail.Priority = MailPriority.High;
                mail.IsBodyHtml = true;
                mail.Body = strbody;
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("relay-hosting.secureserver.net");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = cred;
                smtp.EnableSsl = false;
                smtp.Port = 25;
                smtp.Send(mail);
                msg = "Success";
            }
            catch (Exception ce)
            {
                msg = ce.Message;
            }

            return msg;
        }


        public static string CreateRandomPassword(int PasswordLength)
        {
            string _allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            Random randNum = new Random();
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;

            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }

            return new string(chars);
        }


        ////      const string SERVER = "relay-hosting.secureserver.net";
        ////MailMessage oMail = new System.Web.Mail.MailMessage();
        ////oMail.From = "emailaddress@domainname";
        ////oMail.To = "emailaddress@domainname";
        ////oMail.Subject = "Test email subject";
        ////oMail.BodyFormat = MailFormat.Html; // enumeration
        ////oMail.Priority = MailPriority.High; // enumeration
        ////oMail.Body = "Sent at: " + DateTime.Now;
        ////SmtpMail.SmtpServer = SERVER;
        ////SmtpMail.Send(oMail);
        ////oMail = null; // free up resources
        //public static string emailHeader()
        //{

        //    String strheader = "<table cellspacing='0' cellpadding='0' width='100%' border='0' align='center' style='border-bottom:#9a9a9a 1px solid;border-left:#9a9a9a 1px solid;width:600px;border-top:#9a9a9a 1px solid;border-right:#9a9a9a 1px solid'>";
        //    strheader += "<tr><td style='padding-left:20px'><a target='_blank' href='http://www.gaganz.ca/'><img border='0' src='http://www.gaganz.ca/images/logo.jpg' alt=''></a></td>";
        //    strheader += "<td valign='top' align='right' style='padding-right:20px;padding-top:5px'><a target='_blank' href='http://www.gaganz.ca/login/LogOn' style='font:bold 11px arial;color:#D80303;text-decoration:none'>Login</a></td></tr>";

        //    return strheader;
        //}

        //public static string emailFooter()
        //{

        //    String strFooter = "<tr><td style='padding-bottom:10px' colspan='2'><br />  Warm Regards,<br><b>Team Gaganz.com<br /></b></td></tr>";


        //    return strFooter;
        //}

        public static string sendEmailPass(String emailTo, string strbody1, Int32 moduleid)
        {
            string msg = "";
            try
            {

                plugingaganzEntities db = new plugingaganzEntities();

                
        

                //var item = (from m in db.tb_emailsDescriptions
                //            where m.SetModuleID == moduleid
                //            select m);
                //string strbody = strbody1 + "<br />";
                //string strSubject = "";
                //if (item.Count() > 0)
                //{
                //    var item1 = (from m in db.tb_emailsDescriptions
                //                 where m.SetModuleID == moduleid
                //                 select m).Single();
                //    strbody += item1.Description;
                //    strSubject = item1.EmailSubject;

                //}


                String strheader = "<table cellspacing='0' cellpadding='0' width='100%' border='0' align='center' style='border-bottom:#9a9a9a 1px solid;border-left:#9a9a9a 1px solid;width:600px;border-top:#9a9a9a 1px solid;border-right:#9a9a9a 1px solid'>";
                //strheader += "<tr><td style='padding-left:20px'><a target='_blank' href='http://www.gaganz.ca/'><img width='179' vspace='10' height='75' border='0' src='http://www.gaganz.ca/images/logo.jpg' alt=''></a></td>";
  //              strheader += "<td valign='top' align='right' style='padding-right:20px;padding-top:5px'><a target='_blank' href='http://www.gaganz.ca/login/LogOn' style='font:bold 11px arial;color:#D80303;text-decoration:none'>Login</a></td></tr>";


                String strFooter = "<tr><td style='padding-bottom:10px' colspan='2'><br />  Warm Regards,<br><b>Pacific West<br /></b></td></tr>";



                String strMiddle = "<tr><td style='padding-bottom:10px' colspan='2'> " + strbody1 + "</td></tr>";


                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                System.Net.NetworkCredential cred = new System.Net.NetworkCredential("support@gaganz.ca", "sup123");

                mail.To.Add(emailTo);
                mail.Subject = "User Name and Password Informatoin";

                mail.From = new System.Net.Mail.MailAddress("support@gaganz.ca");
                mail.Bcc.Add(new MailAddress("lal@gaganz.com"));
                mail.Bcc.Add(new MailAddress("baneeta@gaganz.com"));
                // mail.Bcc.Add(new MailAddress("ruddarpartap@gmail.com"));

                mail.Priority = MailPriority.High;
                mail.IsBodyHtml = true;
                mail.Body = strheader + strMiddle + strFooter;

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("relay-hosting.secureserver.net");
                smtp.UseDefaultCredentials = false;

                smtp.Credentials = cred;

                smtp.EnableSsl = false;
                smtp.Port = 25;

                smtp.Send(mail);
                msg = "Success";

            }
            catch (Exception ce)
            {
                msg = ce.Message;

            }

            return msg;
        }
        //public static string sendEmailBA(String emailTo, string strbody1, Int32 moduleid, string Profilename)
        //{
        //    string msg = "";
        //    try
        //    {
        //        pmsDataContext db = new pmsDataContext();

        //        var item = (from m in db.tb_emailsBAComps
        //                    where m.Autoid == moduleid
        //                    select m);
        //        string strbody = strbody1 + "<br />";
        //        string strSubject = "";
        //        if (item.Count() > 0)
        //        {
        //            var item1 = (from m in db.tb_emailsBAComps
        //                         where m.Autoid == moduleid
        //                         select m).Single();
        //            strbody += item1.Description.Replace("LinkName", Profilename);
        //            strSubject = item1.EmailSubject;

        //        }


        //        String strheader = "<table cellspacing='0' cellpadding='0' width='100%' border='0' align='center' style='border-bottom:#9a9a9a 1px solid;border-left:#9a9a9a 1px solid;width:600px;border-top:#9a9a9a 1px solid;border-right:#9a9a9a 1px solid'>";
        //        strheader += "<tr><td style='padding-left:20px'><a target='_blank' href='http://www.gaganz.ca/'><img width='179' vspace='10' height='75' border='0' src='http://www.gaganz.ca/images/logo.jpg' alt=''></a></td>";
        //        strheader += "<td valign='top' align='right' style='padding-right:20px;padding-top:5px'><a target='_blank' href='http://www.gaganz.ca/login/LogOn' style='font:bold 11px arial;color:#D80303;text-decoration:none'>Login</a></td></tr>";


        //        String strFooter = "<tr><td style='padding-bottom:10px' colspan='2'><br />  Warm Regards,<br><b>Team Gaganz.com<br /></b></td></tr>";
        //        String strMiddle = "<tr><td style='padding-bottom:10px' colspan='2'> " + strbody + "</td></tr>";


        //        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        //        System.Net.NetworkCredential cred = new System.Net.NetworkCredential("support@gaganz.ca", "sup123");

        //        mail.To.Add(emailTo);
        //        mail.Subject = strSubject;

        //        mail.From = new System.Net.Mail.MailAddress("support@gaganz.ca");
        //        mail.Bcc.Add(new MailAddress("ceo@gaganz.com"));
        //        /// mail.Bcc.Add(new MailAddress("ruddarpartap@gmail.com"));

        //        mail.Priority = MailPriority.High;
        //        mail.IsBodyHtml = true;
        //        mail.Body = strheader + strMiddle + strFooter;

        //        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("relay-hosting.secureserver.net");
        //        smtp.UseDefaultCredentials = false;

        //        smtp.Credentials = cred;

        //        smtp.EnableSsl = false;
        //        smtp.Port = 25;

        //        smtp.Send(mail);
        //        msg = "Success";

        //    }
        //    catch (Exception ce)
        //    {
        //        msg = ce.Message;

        //    }

        //    return msg;
        //}
        //public static string sendEmailForCounselling(String emailTo, string StrforReplace, Int32 moduleid, string assEmail)
        //{
        //    string msg = "";
        //    try
        //    {
        //        pmsDataContext db = new pmsDataContext();

        //        var item = (from m in db.tb_emailsDescriptions
        //                    where m.SetModuleID == moduleid
        //                    select m);
        //        string strbody = "";
        //        string strSubject = "";
        //        if (item.Count() > 0)
        //        {
        //            var item1 = (from m in db.tb_emailsDescriptions
        //                         where m.SetModuleID == moduleid
        //                         select m).Single();
        //            strbody += item1.Description.Replace("LinkClickHere", StrforReplace);
        //            strSubject = item1.EmailSubject;

        //        }


        //        String strheader = "<table cellspacing='0' cellpadding='0' width='100%' border='0' align='center' style='border-bottom:#9a9a9a 1px solid;border-left:#9a9a9a 1px solid;width:600px;border-top:#9a9a9a 1px solid;border-right:#9a9a9a 1px solid'>";
        //        strheader += "<tr><td style='padding-left:20px'><a target='_blank' href='http://www.gaganz.ca/'><img width='179' vspace='10' height='75' border='0' src='http://www.gaganz.ca/images/logo.jpg' alt=''></a></td>";
        //        strheader += "<td valign='top' align='right' style='padding-right:20px;padding-top:5px'><a target='_blank' href='http://www.gaganz.ca/login/LogOn' style='font:bold 11px arial;color:#D80303;text-decoration:none'>Login</a></td></tr>";


        //        String strFooter = "<tr><td style='padding-bottom:10px' colspan='2'><br />  Warm Regards,<br><b>Team Gaganz.com<br /></b></td></tr>";


        //        String strMiddle = "<tr><td style='padding-bottom:10px' colspan='2'> " + strbody + "</td></tr>";
        //        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        //        System.Net.NetworkCredential cred = new System.Net.NetworkCredential("support@gaganz.ca", "sup123");

        //        mail.To.Add(emailTo);
        //        mail.Subject = strSubject;

        //        mail.From = new System.Net.Mail.MailAddress("support@gaganz.ca");
        //        mail.Bcc.Add(new MailAddress("ceo@gaganz.com"));
        //        //  mail.Bcc.Add(new MailAddress("ruddarpartap@gmail.com"));

        //        if (assEmail != "")
        //        {
        //            mail.Bcc.Add(new MailAddress(assEmail));
        //        }
        //        mail.Priority = MailPriority.High;
        //        mail.IsBodyHtml = true;
        //        mail.Body = strheader + strMiddle + strFooter;

        //        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("relay-hosting.secureserver.net");
        //        smtp.UseDefaultCredentials = false;

        //        smtp.Credentials = cred;

        //        smtp.EnableSsl = false;
        //        smtp.Port = 25;

        //        smtp.Send(mail);
        //        msg = "Success";

        //    }
        //    catch (Exception ce)
        //    {
        //        msg = ce.Message;

        //    }

        //    return msg;
        //}
        //public static string sendEmailTofriend(String emailTo, String emailfrom, string strSubject, string strbody)
        //{
        //    string msg = "";
        //    try
        //    {

        //        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        //        System.Net.NetworkCredential cred = new System.Net.NetworkCredential("support@gaganz.ca", "sup123");

        //        mail.To.Add(emailTo);
        //        mail.Subject = strSubject;

        //        mail.From = new System.Net.Mail.MailAddress("support@gaganz.ca");
        //        mail.Bcc.Add(new MailAddress("ceo@gaganz.com"));
        //        // mail.Bcc.Add(new MailAddress("ruddarpartap@gmail.com"));

        //        mail.Priority = MailPriority.High;
        //        mail.IsBodyHtml = true;
        //        mail.Body = strbody;

        //        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("relay-hosting.secureserver.net");
        //        smtp.UseDefaultCredentials = false;

        //        smtp.Credentials = cred;

        //        smtp.EnableSsl = false;
        //        smtp.Port = 25;

        //        smtp.Send(mail);
        //        msg = "Success";

        //    }
        //    catch (Exception ce)
        //    {
        //        msg = ce.Message;
        //        emailSystem.errorLog(ce.Message, "Internal", "Any", 0);

        //    }

        //    return msg;
        //}
        //public static string sendBulkEmail(String emailTo, string strSubject, string strbody, string associateEmail)
        //{
        //    string msg = "";
        //    try
        //    {
        //        strbody = emailHeader() + "<br />" + strbody;
        //        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        //        System.Net.NetworkCredential cred = new System.Net.NetworkCredential("support@gaganz.ca", "sup123");

        //        mail.To.Add(emailTo);
        //        mail.Subject = strSubject;

        //        mail.From = new System.Net.Mail.MailAddress("support@gaganz.ca");
        //        mail.Bcc.Add(new MailAddress("ceo@gaganz.com"));
        //        //  mail.Bcc.Add(new MailAddress("ruddarpartap@gmail.com"));
        //        if (associateEmail != "")
        //        {
        //            mail.Bcc.Add(new MailAddress(associateEmail));

        //        }
        //        mail.Priority = MailPriority.High;
        //        mail.IsBodyHtml = true;
        //        mail.Body = strbody;

        //        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("relay-hosting.secureserver.net");
        //        smtp.UseDefaultCredentials = false;

        //        smtp.Credentials = cred;

        //        smtp.EnableSsl = false;
        //        smtp.Port = 25;

        //        smtp.Send(mail);
        //        msg = "Success";

        //    }
        //    catch (Exception ce)
        //    {
        //        msg = ce.Message;
        //        emailSystem.errorLog(ce.Message, "Internal", "Any", 0);

        //    }

        //    return msg;
        //}
        //public static string sendNewFormat(String emailTo, string strSubject, string strbody)
        //{
        //    string msg = "";
        //    try
        //    {

        //        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        //        System.Net.NetworkCredential cred = new System.Net.NetworkCredential("support@gaganz.ca", "sup123");

        //        mail.To.Add(emailTo);
        //        mail.Subject = strSubject;

        //        mail.From = new System.Net.Mail.MailAddress("noreply@gaganz.ca");
        //        mail.Bcc.Add(new MailAddress("adminceo@gaganz.com"));
        //       // mail.Bcc.Add(new MailAddress("ruddarpartap@gmail.com"));
                
        //        mail.Priority = MailPriority.High;
        //        mail.IsBodyHtml = true;
        //        mail.Body = strbody;

        //        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("relay-hosting.secureserver.net");
        //        smtp.UseDefaultCredentials = false;

        //        smtp.Credentials = cred;

        //        smtp.EnableSsl = false;
        //        smtp.Port = 25;

        //        smtp.Send(mail);

        //        msg = "Success";
        //        emailSystem.errorLog(emailTo + "->" + strSubject, "- Success", "sendNewFormat", 0);

        //    }
        //    catch (Exception ce)
        //    {
        //        msg = ce.Message;
        //        emailSystem.errorLog(emailTo + "->" + strSubject, " - Error", "sendNewFormat", 0);
        //    }

        //    return msg;
        //}
        //public static string sendComments(String emailTo, string strSubject, string strbody, string associateEmail)
        //{
        //    string msg = "";
        //    try
        //    {

        //        strbody = emailHeader() + "<br />" + strbody + "<br />" + emailFooter();


        //        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        //        System.Net.NetworkCredential cred = new System.Net.NetworkCredential("support@gaganz.ca", "sup123");

        //        mail.To.Add(emailTo);
        //        mail.Subject = strSubject;

        //        mail.From = new System.Net.Mail.MailAddress("noreply@gaganz.ca");
        //        mail.Bcc.Add(new MailAddress("ceo@gaganz.com"));
        //        // mail.Bcc.Add(new MailAddress("ruddarpartap@gmail.com"));
        //        if (associateEmail != "")
        //        {
        //            mail.Bcc.Add(new MailAddress(associateEmail));

        //        }
        //        mail.Priority = MailPriority.High;
        //        mail.IsBodyHtml = true;
        //        mail.Body = strbody;

        //        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("relay-hosting.secureserver.net");
        //        smtp.UseDefaultCredentials = false;

        //        smtp.Credentials = cred;

        //        smtp.EnableSsl = false;
        //        smtp.Port = 25;

        //        smtp.Send(mail);
        //        msg = "Success";

        //    }
        //    catch (Exception ce)
        //    {
        //        msg = ce.Message;
        //        emailSystem.errorLog(ce.Message, "Internal", "Any", 0);

        //    }

        //    return msg;
        //}

        //public static void createHistory(string ipadress, string pagename, Int32 userid, Int32 propertyid)
        //{
        //    pmsDataContext db = new pmsDataContext();
        //    tb_HistoryOfUser tb = new tb_HistoryOfUser();
        //    tb.IPAddress = ipadress;
        //    tb.Userid = userid;
        //    tb.ViewDateTime = DateTime.Now;
        //    tb.TypeOfView = pagename;
        //    tb.PropertyID = propertyid;
        //    db.tb_HistoryOfUsers.InsertOnSubmit(tb);
        //    db.SubmitChanges();
        //}
        //public static void errorLog(string errodesc, string ipadress, string pagename, Int32 userid)
        //{
        //    pmsDataContext db = new pmsDataContext();

        //    tb_realLogMaster tb = new tb_realLogMaster();
        //    tb.ErrorDesc = errodesc;
        //    tb.Ipaddress = ipadress;
        //    tb.PageName = pagename;
        //    tb.Userid = userid;
        //    tb.System = DateTime.Now;

        //    db.tb_realLogMasters.InsertOnSubmit(tb);
        //    db.SubmitChanges();

        //}
    }
}