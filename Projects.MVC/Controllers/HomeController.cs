using Projects.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projects.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(Project.GetProjectList().OrderBy(x => x.StatusID));
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Project p)
        {
            p.StatusID = 1;
            p.Sequence = 999;
            p.Save();

            return RedirectToAction("Index", "Home");
        }
    }
}