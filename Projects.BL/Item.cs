using Projects.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.BL
{
    public class Item
    {
        public int ItemID { get; set; }
        public int ProjectID { get; set; }
        public int? ParentID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemType { get; set; }
        public int StatusID { get; set; }
        public int Sequence { get; set; }
        public DateTime? AssignDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompleteDate { get; set; }
        public DateTime? LastWorkedOnDate { get; set; }
        public DateTime CreateDate { get; set; }

        public Status Status
        {
            get
            {
                return new Status(StatusID);
            }
        }

        public string ItemTypeFormatted
        {
            get
            {
                switch (ItemType)
                {
                    case "U":
                        return "Update";
                    case "D":
                        return "Development";
                    case "B":
                        return "Bug";
                    default:
                        return "";
                }
            }
        }

        public string AssignDateFormatted
        {
            get
            {
                if (AssignDate != null)
                    return ((DateTime)AssignDate).ToShortDateString();
                else
                    return "--";
            }
        }

        public string StartDateFormatted
        {
            get
            {
                if (StartDate != null)
                    return ((DateTime)StartDate).ToShortDateString();
                else
                    return "--";
            }
        }

        public string DueDateFormatted
        {
            get
            {
                if (DueDate != null)
                    return ((DateTime)DueDate).ToShortDateString();
                else
                    return "--";
            }
        }

        public string CompleteDateFormatted
        {
            get
            {
                if (CompleteDate != null)
                    return ((DateTime)CompleteDate).ToShortDateString();
                else
                    return "--";
            }
        }

        public string LastWorkedOnDateFormatted
        {
            get
            {
                if (LastWorkedOnDate != null)
                    return ((DateTime)LastWorkedOnDate).ToShortDateString();
                else
                    return "--";
            }
        }

        public Project Project;

        public static string GetItemType(string sItemType)
        {
            switch (sItemType)
            {
                case "U":
                    return "Updates";
                case "D":
                    return "Development";
                case "B":
                    return "Bugs";
                default:
                    return "";
            }
        }

        public string IsStatus(int iStatusID)
        {
            if (iStatusID == StatusID)
                return "selected";

            return "";
        }

        public IEnumerable<Status> Statuses =
            new List<Status>
            {
                new Status(1),
                new Status(2),
                new Status(3),
                new Status(4)
            };

        public Item()
        {

        }

        public Item(int iItemID)
        {
            DataRowToObject(ItemDAO.Select(iItemID), this);
        }

        public static void DataRowToObject(DataRow dr, Item obj)
        {
            obj.ItemID = Convert.ToInt32(dr[ItemDAO.columnItemID]);
            obj.ProjectID = Convert.ToInt32(dr[ItemDAO.columnProjectID]);
            if (!(dr[ItemDAO.columnParentID] is DBNull))
                obj.ParentID = Convert.ToInt32(dr[ItemDAO.columnParentID]);
            obj.ItemName = dr[ItemDAO.columnItemName].ToString();
            obj.ItemDescription = dr[ItemDAO.columnItemDescription].ToString();
            obj.ItemType = dr[ItemDAO.columnItemType].ToString();
            obj.StatusID = Convert.ToInt32(dr[ItemDAO.columnStatusID]);
            obj.Sequence = Convert.ToInt32(dr[ItemDAO.columnSequence]);

            if (!(dr[ItemDAO.columnAssignDate] is DBNull))
                obj.AssignDate = Convert.ToDateTime(dr[ItemDAO.columnAssignDate]);
            if (!(dr[ItemDAO.columnStartDate] is DBNull))
                obj.StartDate = Convert.ToDateTime(dr[ItemDAO.columnStartDate]);
            if (!(dr[ItemDAO.columnDueDate] is DBNull))
                obj.DueDate = Convert.ToDateTime(dr[ItemDAO.columnDueDate]);
            if (!(dr[ItemDAO.columnCompleteDate] is DBNull))
                obj.CompleteDate = Convert.ToDateTime(dr[ItemDAO.columnCompleteDate]);
            if (!(dr[ItemDAO.columnLastWorkedOnDate] is DBNull))
                obj.LastWorkedOnDate = Convert.ToDateTime(dr[ItemDAO.columnLastWorkedOnDate]);

            obj.CreateDate = Convert.ToDateTime(dr[ItemDAO.columnCreateDate]);
        }

        public int Save()
        {
            if (ItemID > 0)
                ItemDAO.Update(ItemID, ProjectID, ParentID, ItemName, ItemDescription, ItemType, StatusID, Sequence, AssignDate, StartDate, DueDate, CompleteDate, LastWorkedOnDate);
            else
                return ItemDAO.Insert(ProjectID, ParentID, ItemName, ItemDescription, ItemType, StatusID, Sequence, AssignDate, StartDate, DueDate, CompleteDate, LastWorkedOnDate);

            return ItemID;
        }

        public void Delete()
        {
            ItemDAO.Delete(ItemID);
        }


        public List<Item> GetItems()
        {
            List<Item> lst = new List<Item>();

            foreach (DataRow dr in ItemDAO.SelectByParentID(ItemID).Rows)
            {
                Item i = new Item();
                DataRowToObject(dr, i);
                lst.Add(i);
            }

            return lst;
        }

        public List<Task> GetTasks()
        {
            List<Task> lst = new List<Task>();

            foreach (DataRow dr in TaskDAO.SelectByItemID(ItemID).Rows)
            {
                Task t = new Task();
                Task.DataRowToObject(dr, t);
                lst.Add(t);
            }

            return lst;
        }

        public void SetProject()
        {
            Project = new Project(ProjectID);
        }

        public List<Item> GetBreadCrumb()
        {
            List<Item> lst = new List<Item>();

            foreach (DataRow dr in ItemDAO.spGetBreadcrumb(ItemID).Rows)
            {
                Item i = new Item();
                DataRowToObject(dr, i);
                lst.Add(i);
            }

            return lst;
        }
    }
}
