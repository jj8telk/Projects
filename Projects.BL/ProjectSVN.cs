using Projects.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.BL
{
    public class ProjectSVN
    {
        public int ProjectID { get; set; }
        public int SVNID { get; set; }
        public string SVNName { get; set; }

        public Project Project;
        public List<SVN> SVN;

        public ProjectSVN()
        {

        }

        public ProjectSVN(int iProjectID)
        {
            ProjectID = iProjectID;

            Project = new Project(iProjectID);
            SVN = Project.GetSVN();
        }

        public static void Save(int iProjectID, int iSVNID, int Sequence)
        {
            ProjectSVNDAO.Insert(iProjectID, iSVNID, Sequence);
        }

        public static void Delete(int iProjectID, int iSVNID)
        {
            ProjectSVNDAO.Delete(iProjectID, iSVNID);
        }

    }
}
