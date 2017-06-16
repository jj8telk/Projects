using Projects.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projects.MVC.Controllers
{
    public class TaskController : Controller
    {
        //
        // GET: /Task/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            Task t = new Task(id);

            ViewBag.Statuses = new SelectList(t.Statuses, "StatusID", "StatusName", t.StatusID);
            ViewBag.AppTypes = new SelectList(Task.AppTypes, "AppTypeID", "AppTypeName");

            return View(t);
        }

        [HttpPost]
        public ActionResult Edit(Task t)
        {
            t.Save();

            return RedirectToAction("", "Item", new { id = t.ItemID });
        }
	}
}