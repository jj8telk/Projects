using Projects.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projects.MVC.Controllers
{
    public class ItemController : Controller
    {
        //
        // GET: /Item/
        public ActionResult Index(int id)
        {
            Item i = new Item(id);
            i.SetProject();

            return View(i);
        }

        public ActionResult Edit(int id)
        {
            Item i = new Item(id);
            i.SetProject();

            ViewBag.Statuses = new SelectList(i.Statuses, "StatusID", "StatusName", i.StatusID);

            return View(i);
        }

        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Item i)
        {
            i.SetProject();
            i.Save();

            return RedirectToAction("Edit", "Item", new { id = i.ItemID });
        }


        public ActionResult AddSubItem(int id)
        {
            Item i = new Item(id);
            i.SetProject();

            return View(i);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddSubItem(Item i)
        {
            i.SetProject();
            i.StatusID = 1;
            i.ParentID = i.ItemID;
            i.ItemID = 0;
            i.Save();

            return RedirectToAction("AddSubItem", "Item", new { id = i.ParentID });
        }

        public ActionResult AddTask(int id)
        {
            Item i = new Item(id);
            i.SetProject();
                        
            ViewBag.Item = i;
            List<Item> lst = i.GetItems();
            ViewBag.ItemList = lst;
            ViewBag.AppTypes = new SelectList(Task.AppTypes, "AppTypeID", "AppTypeName");

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddTask(Task t, int id)
        {
            t.ItemID = id;
            t.StatusID = 1;
            t.Sequence = 999;

            t.Save();

            return RedirectToAction("", "Item", new { id = t.ItemID });
        }
	}
}