using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DhotGroupNew.Models;
using System.IO;
namespace DhotGroupNew.Controllers
{
    public class ImagesHomeController : Controller
    {
        //
        // GET: /event/
        plugingaganzEntities db = new plugingaganzEntities();
    

        public class branch
        {
            public string id { get; set; }
            public string name { get; set; }

        }
        public ActionResult Index()
        {
            var tb = (from m in db.tb_ImagesHomeDhot select m).ToList();

            return View(tb);
        }

        //
        // GET: /event/Details/5

        public ActionResult Details()
        {
            return View();
        }

        //
        // GET: /event/Create

        public void setview()
        {
            var text = new[] { new branch { id = "Current Event", name = "Current Event" }, new branch { id = "Past Event", name = "Past Event" } };

            var list1 = new SelectList(text, "id", "name");

            ViewData["typeData"] = list1;
        }

        public ActionResult Create()
        {
            setview();

            return View();
        }

        //
        // POST: /event/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection, tb_ImagesHomeDhot model)
        {
            try
            {
                // TODO: Add insert logic here

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
                if (filename != "")
                {
                    model.ImagePath = filename;
                }

                db.tb_ImagesHomeDhot.AddObject(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /event/Edit/5

        public ActionResult Edit(int id)
        {
            setview();
            var tb = (from m in db.tb_ImagesHomeDhot where m.ImageID == id select m).Single();

            return View(tb);


        }

        //
        // POST: /event/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, tb_ImagesHomeDhot model)
        {
            try
            {
                // TODO: Add update logic here

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


                var tb = (from m in db.tb_ImagesHomeDhot where m.ImageID == id select m).Single();
                if (filename != "")
                {
                    tb.ImagePath = filename;
                }

                tb.Description = model.Description;

                tb.Name = model.Name;

                

                db.SaveChanges();


                // return RedirectToAction("Index");
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /event/Delete/5

        public ActionResult Delete(int id)
        {
            setview();
            var tb = (from m in db.tb_ImagesHomeDhot where m.ImageID == id select m).Single();

            return View(tb);
        }

        //
        // POST: /event/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                setview();
                var tb = (from m in db.tb_ImagesHomeDhot where m.ImageID == id select m).Single();
                db.tb_ImagesHomeDhot.DeleteObject (tb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
