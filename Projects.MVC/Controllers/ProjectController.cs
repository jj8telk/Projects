using Projects.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projects.MVC.Controllers
{
    public class ProjectController : Controller
    {
        //
        // GET: /Project/
        public ActionResult Index(int id)
        {
            Project p = new Project(id);
            p.GetDBObjects();

            return View(p);
        }


        //
        // GET: /Project/SVN/{ProjectID}
        public ActionResult SVN(int id)
        {
            ProjectSVN p = new ProjectSVN(id);

            return View(p);
        }

        // POST: /Project/SVN/{ProjectID}
        [HttpPost]
        public ActionResult SVN(ProjectSVN p)
        {
            
            return View(p);
        }

        public ActionResult Items(int id, string type)
        {
            Project p = new Project(id);

            return View(p);
        }


        //
        // Backend

        public string Autocomplete()
        {
            string json = "[";

            foreach (SVN s in Projects.BL.SVN.GetSVNs(Request.QueryString["q"].ToString()))
                json += "{\"value\" : \"" + s.SVNID.ToString() + "\", \"label\" : \"" + s.SVNName + "\"},";

            json = json.Substring(0, json.Length - 1);
            json += "]";

            return json;
        }
	}
}