using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DhotGroupNew.Models;
namespace DhotGroupNew.Controllers
{
    public class pagesController : Controller
    {
        plugingaganzEntities db = new plugingaganzEntities();

        public ActionResult test()
        {
            return View();

        }

        public ActionResult Index()
        {
            var model = (from m in db.tb_PageDescription
                         select m);

            return View(model);
        }
        //
        // GET: /emailsystem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        //
        // GET: /emailsystem/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /emailsystem/Create
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(tb_PageDescription model)
        {
            try
            {
                //tb_emailsDescription model2 = new tb_emailsDescription();
                //model2.Description = model.Description;
                //model2.EmailModule_ = model.EmailModule_;
                //model2.EmailSubject = model.EmailSubject;
                db.tb_PageDescription.AddObject(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /emailsystem/Edit/5

        public ActionResult Edit(int id)
        {
            var model = (from m in db.tb_PageDescription
                         where m.Pageid == id
                         select m).Single();

            return View(model);
        }

        //
        // POST: /emailsystem/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(int id, tb_PageDescription model)
        {
            try
            {
                var model2 = (from m in db.tb_PageDescription
                              where m.Pageid == id
                              select m).Single();
                model2.Description = model.Description;
                model2.PageName = model.PageName;
                model2.Title = model.Title;
                model2.SetModuleID = model.SetModuleID;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /emailsystem/Delete/5

        public ActionResult Delete(int id)
        {
            var model = (from m in db.tb_PageDescription
                         where m.Pageid == id
                         select m).Single();
            db.tb_PageDescription.DeleteObject(model);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /emailsystem/Delete/5

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
        //
        // GET: /pages/

       
       
      

    }
}
