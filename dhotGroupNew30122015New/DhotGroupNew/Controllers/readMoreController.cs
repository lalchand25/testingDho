using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DhotGroupNew.Models;



namespace DhotGroupNew.Controllers
{
    public class readMoreController : Controller
    {
        //
        // GET: /readMore/
        plugingaganzEntities db = new plugingaganzEntities();

        public ActionResult Index(int id)
        {
          
            var item = (from m in db.tb_HomePageServicesDhot where m.AutoID == id select m).Single();
            ViewBag.pageTitle= item.Heading;
            ViewBag.PageDesc = item.Description;
            ViewBag.ImagePath = "<img src='/uploads/" + item.ImagePath + "' width='230px' height='155px' /> ";

     
            return View();
        }

        //
        // GET: /readMore/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /readMore/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /readMore/Create

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
        // GET: /readMore/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /readMore/Edit/5

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
        // GET: /readMore/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /readMore/Delete/5

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
