using Projects.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.BL
{
    public class ProjectItem
    {
        public int ProjectID { get; set; }
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }

        public Project Project;
        public List<Item> Items;

        public ProjectItem()
        {

        }

        public ProjectItem(int iProjectID, string sItemType)
        {
            ProjectID = iProjectID;

            Project = new Project(iProjectID);
            Items = Project.GetParentItemsByType(sItemType);
        }
    }
}
