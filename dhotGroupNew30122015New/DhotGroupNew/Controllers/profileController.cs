using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DhotGroupNew.Models;

namespace DhotGroupNew.Controllers
{
    public class profileController : Controller
    {
        //
        // GET: /profile/
        plugingaganzEntities db = new plugingaganzEntities();

        public ActionResult Index()
        {
            return View();
        }




        public ActionResult profile()
        {
            var tb13 = (from m in db.tb_PageDescription where m.Pageid == 13 select m).Single();
            Session.Add("HomeName1", tb13.Description);
            var tb14 = (from m in db.tb_PageDescription where m.Pageid == 14 select m).Single();
            Session.Add("HomeName2", tb14.Description);
            var tblogo = (from m in db.tb_ImagesHomeDhot where m.ImageID == 1 select m).Single();
            Session.Add("logohome", tblogo.ImagePath);

            return View();
        }

        //
        // GET: /profile/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /profile/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /profile/Create

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
        // GET: /profile/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /profile/Edit/5

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
        // GET: /profile/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /profile/Delete/5

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
