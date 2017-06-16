using Projects.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projects.MVC.Controllers
{
    public class ProjectSVNController : Controller
    {
        //
        // GET: /ProjectSVN/
        public ActionResult Index(int id)
        {
            ProjectSVN p = new ProjectSVN(id);

            return View(p);
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(ProjectSVN p)
        {
            int iSVNID = p.SVNID;

            if (iSVNID == 0)
                iSVNID = SVN.Save(p.SVNName, "svn://");           

            ProjectSVN.Save(p.ProjectID, iSVNID, 999);

            return RedirectToAction("Index", "ProjectSVN");
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(ProjectSVN p)
        {
            ProjectSVN.Delete(p.ProjectID, p.SVNID);

            return RedirectToAction("Index", "ProjectSVN");
        }
	}
}