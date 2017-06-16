using Projects.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.BL
{
    public class Task
    {
        public int TaskID { get; set; }
        public int ItemID { get; set; }
        public string TaskDescription { get; set; }
        public int StatusID { get; set; }
        public int Sequence { get; set; }
        public string AppTypeID { get; set; }
        public string AppProjectName { get; set; }
        public string AppFile { get; set; }
        public string LineNumbers { get; set; }
        public DateTime? AssignDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompleteDate { get; set; }
        public DateTime? LastWorkedOnDate { get; set; }
        public DateTime CreateDate { get; set; }

        public AppType AppType
        {
            get
            {
                return new AppType(AppTypeID);
            }
        }

        public Status Status
        {
            get
            {
                return new Status(StatusID);
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

        public IEnumerable<Status> Statuses =
            new List<Status>
            {
                new Status(1),
                new Status(2),
                new Status(3),
                new Status(4)
            };

        public static IEnumerable<AppType> AppTypes =
            new List<AppType>
            {
                new AppType("P"),
                new AppType("D")
            };

        public Task()
        {

        }

        public Task(int iTaskID)
        {
            DataRowToObject(TaskDAO.Select(iTaskID), this);
        }

        public static void DataRowToObject(DataRow dr, Task obj)
        {
            obj.TaskID = Convert.ToInt32(dr[TaskDAO.columnTaskID]);
            obj.ItemID = Convert.ToInt32(dr[TaskDAO.columnItemID]);
            obj.TaskDescription = dr[TaskDAO.columnTaskDescription].ToString();
            obj.StatusID = Convert.ToInt32(dr[TaskDAO.columnStatusID]);
            obj.Sequence = Convert.ToInt32(dr[TaskDAO.columnSequence]);
            obj.AppTypeID = dr[TaskDAO.columnAppType].ToString();
            obj.AppProjectName = dr[TaskDAO.columnAppProjectName].ToString();
            obj.AppFile = dr[TaskDAO.columnAppFile].ToString();
            obj.LineNumbers = dr[TaskDAO.columnLineNumbers].ToString();

            if (!(dr[TaskDAO.columnAssignDate] is DBNull))
                obj.AssignDate = Convert.ToDateTime(dr[TaskDAO.columnAssignDate]);
            if (!(dr[TaskDAO.columnStartDate] is DBNull))
                obj.StartDate = Convert.ToDateTime(dr[TaskDAO.columnStartDate]);
            if (!(dr[TaskDAO.columnDueDate] is DBNull))
                obj.DueDate = Convert.ToDateTime(dr[TaskDAO.columnDueDate]);
            if (!(dr[TaskDAO.columnCompleteDate] is DBNull))
                obj.CompleteDate = Convert.ToDateTime(dr[TaskDAO.columnCompleteDate]);
            if (!(dr[TaskDAO.columnLastWorkedOnDate] is DBNull))
                obj.LastWorkedOnDate = Convert.ToDateTime(dr[TaskDAO.columnLastWorkedOnDate]);

            obj.CreateDate = Convert.ToDateTime(dr[TaskDAO.columnCreateDate]);
        }

        public void Save()
        {
            if (TaskID > 0)
                TaskDAO.Update(TaskID, ItemID, TaskDescription, StatusID, Sequence, AppTypeID, AppProjectName, AppFile, LineNumbers, AssignDate, StartDate, DueDate, CompleteDate, LastWorkedOnDate);
            else
                TaskDAO.Insert(ItemID, TaskDescription, StatusID, Sequence, AppTypeID, AppProjectName, AppFile, LineNumbers, AssignDate, StartDate, DueDate, CompleteDate, LastWorkedOnDate);
        }
    }
}
