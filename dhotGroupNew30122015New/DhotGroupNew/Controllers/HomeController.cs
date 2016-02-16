using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DhotGroupNew.Models;

namespace DhotGroupNew.Controllers
{
    public class HomeController : Controller
    {
        plugingaganzEntities db = new plugingaganzEntities();

        public ActionResult Index()
        {

            //if (emailSystem.GetCookie("NameCook") == null)
            //{
            //    HttpCookie myCookie = new HttpCookie("NameCook");
            //    myCookie.Value = "Lal Chand";
            //    myCookie.Expires.Date.AddDays(7);
            //    Response.Cookies.Add(myCookie);

            //    //emailSystem.SetCookie("NameCook", "Lal Chand");
            //}

            //else
            //{
            //    string name = emailSystem.GetCookie("NameCook").Value;

            //}
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";


            var tb1 = (from m in db.tb_PageDescription where m.Pageid == 1 select m).Single();

            // ViewData["pageTitle"] = tb1.PageName;
            // ViewData["PageDesc"] = tb1.Description;
            ViewBag.pageTitle = tb1.PageName;
            ViewBag.PageDesc = tb1.Description;

            var BannerIamges = from m in db.tb_ImagesDhot select m;
            string banner = "";
            foreach (var item in BannerIamges)
            {
                banner += "  	<a href=''><img src='/uploads/" + item.ImagePath + "' width='1100' height='342' alt='Your Text'/></a>";
            }

            //width='1100' height='342' 
            Session.Add("banner", banner);
            var tb13 = (from m in db.tb_PageDescription where m.Pageid == 13 select m).Single();
            Session.Add("HomeName1", tb13.Description);
            var tb14 = (from m in db.tb_PageDescription where m.Pageid == 14 select m).Single();
            Session.Add("HomeName2", tb14.Description);
            var tblogo = (from m in db.tb_ImagesHomeDhot where m.ImageID == 1 select m).Single();
            Session.Add("logohome", tblogo.ImagePath);


            var homeServices = (from m in db.tb_HomePageServicesDhot orderby m.displayorder select m).ToList();
            string strHomeSer = "";
            foreach (var item in homeServices)
            {
                strHomeSer += "<div class='container_box'>  ";
                strHomeSer += " <div class='container_box_img'>   <img src='/uploads/" + item.ImagePath + "' width='180px' height='122px' /> </div> ";
                strHomeSer += "<div class='container_box_heading'>" + item.Heading + "</div> ";
                // text limit
                string desc = "";
                if (item.Description != null)
                {
                    if (item.Description.Length > 155)
                    {
                        desc = (item.Description.Substring(0, 153));
                    }
                    else
                    {
                        desc = item.Description;
                    }

                }
                strHomeSer += "<div class='container_box_text'> " + desc + " </div>";

                strHomeSer += "<div class='container_box_read'>  <a href='" + item.urllink + "'>       <img src='images/read-more.png' /></a>       </div>";
                strHomeSer += "</div>";
            }

            ViewData["strHomeServices"] = strHomeSer;


            var tbTesti = (from m in db.tb_PageDescription where m.Pageid == 15 select m).Single();
            ViewData["testimonials"] = tbTesti.Description;

            var tbNews = (from m in db.tb_PageDescription where m.Pageid == 16 select m).Single();
            ViewData["News"] = tbNews.Description;


            return View();
        }
        public ActionResult contactus()
        {
            //ViewBag.Message = "Your app description page.";
            var tb1 = (from m in db.tb_PageDescription where m.Pageid == 4 select m).Single();
            ViewBag.pageTitle = tb1.PageName;
            ViewBag.PageDesc = tb1.Description;
            return View();
        }


        public ActionResult About()
        {
            //ViewBag.Message = "Your app description page.";

            var tb1 = (from m in db.tb_PageDescription where m.Pageid == 2 select m).Single();
            ViewBag.pageTitle = tb1.PageName;
            ViewBag.PageDesc = tb1.Description;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            var tb1 = (from m in db.tb_PageDescription where m.Pageid == 4 select m).Single();
            ViewBag.pageTitle = tb1.PageName;
            ViewBag.PageDesc = tb1.Description;

            return View();
        }

        public ActionResult services()
        {
            var tb1 = (from m in db.tb_PageDescription where m.Pageid == 3 select m).Single();
            ViewBag.pageTitle = tb1.PageName;
            ViewBag.PageDesc = tb1.Description;
            return View();

        }
    }
}
