using MVCSampleProject.DB;
using MVCSampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCSampleProject.Controllers
{
    public class HomeController : Controller
    {
        DataRepo db = new DataRepo();

        public ActionResult Index()
        {
            return View(db.GetAllJSONTable());
        }
      
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JSONTable JSONTable = db.GetJSONTable(id);
            if (JSONTable == null)
            {
                return HttpNotFound();
            }
            return View(JSONTable);
        }

      
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JSONTable obj)
        {
            if (ModelState.IsValid)
            {
                db.AddJSONTable(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

    
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JSONTable JSONTable = db.GetJSONTable(id);
            if (JSONTable == null)
            {
                return HttpNotFound();
            }
            return View(JSONTable);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JSONTable JSONTable)
        {
            if (ModelState.IsValid)
            {
                db.UpdateJSONTable(JSONTable);
                return RedirectToAction("Index");
            }
            return View(JSONTable);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JSONTable JSONTable = db.DeleteJSONTable(id);
            if (JSONTable == null)
            {
                return HttpNotFound();
            }
            return View(JSONTable);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JSONTable JSONTable = db.DeleteJSONTable(id);
            return RedirectToAction("Index");
        }
    }
}