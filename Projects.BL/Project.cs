using Projects.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.BL
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string DeveloperNotes { get; set; }
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

        public List<DBObject> DBObjects { get; set; }

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

        public Project()
        {

        }

        public Project(int iProjectID)
        {
            DataRowToObject(ProjectDAO.Select(iProjectID), this);
        }

        public static void DataRowToObject(DataRow dr, Project obj)
        {
            obj.ProjectID = Convert.ToInt32(dr[ProjectDAO.columnProjectID]);
            obj.ProjectName = dr[ProjectDAO.columnProjectName].ToString();
            obj.ProjectDescription = dr[ProjectDAO.columnProjectDescription].ToString();
            obj.DeveloperNotes = dr[ProjectDAO.columnDeveloperNotes].ToString();
            obj.StatusID = Convert.ToInt32(dr[ProjectDAO.columnStatusID]);
            obj.Sequence = Convert.ToInt32(dr[ProjectDAO.columnSequence]);

            if (!(dr[ProjectDAO.columnAssignDate] is DBNull))
                obj.AssignDate = Convert.ToDateTime(dr[ProjectDAO.columnAssignDate]);
            if (!(dr[ProjectDAO.columnStartDate] is DBNull))
                obj.StartDate = Convert.ToDateTime(dr[ProjectDAO.columnStartDate]);
            if (!(dr[ProjectDAO.columnDueDate] is DBNull))
                obj.DueDate = Convert.ToDateTime(dr[ProjectDAO.columnDueDate]);
            if (!(dr[ProjectDAO.columnCompleteDate] is DBNull))
                obj.CompleteDate = Convert.ToDateTime(dr[ProjectDAO.columnCompleteDate]);
            if (!(dr[ProjectDAO.columnLastWorkedOnDate] is DBNull))
                obj.LastWorkedOnDate = Convert.ToDateTime(dr[ProjectDAO.columnLastWorkedOnDate]);

            obj.CreateDate = Convert.ToDateTime(dr[ProjectDAO.columnCreateDate]);
        }


        public List<Item> GetItems()
        {
            List<Item> lst = new List<Item>();

            foreach (DataRow dr in ItemDAO.SelectByProjectID(ProjectID).Rows)
            {
                Item i = new Item();
                Item.DataRowToObject(dr, i);
                lst.Add(i);
            }

            return lst.OrderBy(x => x.Sequence).ToList();
        }

        public static List<Project> GetProjectList()
        {
            List<Project> lst = new List<Project>();

            foreach (DataRow dr in ProjectDAO.Select().Rows)
            {
                Project p = new Project();
                DataRowToObject(dr, p);
                lst.Add(p);
            }

            return lst;
        }

        public void GetDBObjects()
        {
            DBObjects = new List<DBObject>();

            foreach (DataRow dr in DBView.SelectByProjectID(ProjectID).Rows)
            {
                DBObject i = new DBObject();
                DBObject.DataRowToObject(dr, i);
                
                DB d = new DB();
                DB.DataRowToObject(dr, d);
                i.DB = d;

                DBServer s = new DBServer();
                DBServer.DataRowToObject(dr, s);
                i.DBServer = s;

                DBObjects.Add(i);
            }
        }

        public List<SVN> GetSVN()
        {
            List<SVN> lst = new List<SVN>();

            foreach (DataRow dr in ProjectSVNDAO.SelectByProjectID(ProjectID).Rows)
            {
                SVN s = new SVN();
                SVN.DataRowToObject(dr, s);
                lst.Add(s);
            }

            return lst;
        }

        public List<Item> GetParentItemsByType(string sItemType)
        {
            List<Item> lst = new List<Item>();

            foreach (DataRow dr in ItemDAO.SelectParentsByProjectAndType(ProjectID, sItemType).Rows)
            {
                Item i = new Item();
                Item.DataRowToObject(dr, i);
                lst.Add(i);
            }

            return lst;
        }

        public void Save()
        {
            if (ProjectID > 0)
                ProjectDAO.Update(ProjectID, ProjectName, ProjectDescription, DeveloperNotes, StatusID, Sequence, AssignDate, StartDate, DueDate, CompleteDate, LastWorkedOnDate);
            else
                ProjectDAO.Insert(ProjectName, ProjectDescription, DeveloperNotes, StatusID, Sequence, AssignDate, StartDate, DueDate, CompleteDate, LastWorkedOnDate);
        }
    }
}
