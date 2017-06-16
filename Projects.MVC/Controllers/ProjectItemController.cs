using Projects.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projects.MVC.Controllers
{
    public class ProjectItemController : Controller
    {
        //
        // GET: /ProjectItem/
        public ActionResult Index(int id, string type)
        {
            ProjectItem p = new ProjectItem(id, type);

            p.ProjectID = id;
            p.ItemType = type;

            return View(p);
        }

        public ActionResult Edit(int id, string type)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(ProjectItem p)
        {
            Item i = new Item();
            i.ItemName = p.ItemName;
            i.ItemType = p.ItemType;
            i.ProjectID = p.ProjectID;
            i.StatusID = 1;
            i.Sequence = 999;
            i.Save();

            return RedirectToAction("Index", "ProjectItem", new { id = p.ProjectID, type = p.ItemType });
        }

        public ActionResult Delete(int id, string type)
        {
            Item i = new Item(id);
            int iProjectID = i.ProjectID;
            i.Delete();

            return RedirectToAction("Index", "ProjectItem", new { id = iProjectID, type = type });
        }
	}
}