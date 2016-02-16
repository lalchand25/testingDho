using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DhotGroupNew.Models;
using System.IO;
using DhotGroupNew.Models;


namespace DhotGroupNew.Controllers
{
    public class HomePageServiceController : Controller
    {
        //
        // GET: /HomePageService/

        plugingaganzEntities db = new plugingaganzEntities();
        public ActionResult Index()
        {
            var tbTest = (from m in db.tb_HomePageServicesDhot select m).ToList();
            return View(tbTest);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, FormCollection collection, tb_HomePageServicesDhot model)
        {
            try
            {
                // TODO: Add insert logic here

                string filename = "";
                foreach (string inputTagName in Request.Files)
                {
                    //HttpPostedFileBase file = Request.Files[inputTagName];
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
                if (filename != "")
                {
                    model.ImagePath = filename;
                }

                db.tb_HomePageServicesDhot.AddObject(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {

            var tb = (from m in db.tb_HomePageServicesDhot where m.AutoID == id select m).Single();

            return View(tb);


        }

        //
        // POST: /event/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, HttpPostedFileBase file, FormCollection collection, tb_HomePageServicesDhot model)
        {
            try
            {
                string filename = "";
                // TODO: Add update logic here
                if (file != null)
                {

                    foreach (string inputTagName in Request.Files)
                    {
                        //HttpPostedFileBase file = Request.Files[inputTagName];
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
                }

                var tb = (from m in db.tb_HomePageServicesDhot where m.AutoID == id select m).Single();
                if (filename != "")
                {
                    tb.ImagePath = filename;
                }



                tb.Description = model.Description;
                tb.Heading = model.Heading;
                tb.urllink = model.urllink;





                db.SaveChanges();


                // return RedirectToAction("Index");
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

    }
}
