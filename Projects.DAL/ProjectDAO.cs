using Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.DAL
{
    public class ProjectDAO
    {
        public const string tableName = "Project";
        public const string columnProjectID = "ProjectID";
        public const string columnProjectName = "ProjectName";
        public const string columnProjectDescription = "ProjectDescription";
        public const string columnDeveloperNotes = "DeveloperNotes";
        public const string columnStatusID = "StatusID";
        public const string columnSequence = "Seq";
        public const string columnAssignDate = "AssignDate";
        public const string columnStartDate = "StartDate";
        public const string columnDueDate = "DueDate";
        public const string columnCompleteDate = "CompleteDate";
        public const string columnLastWorkedOnDate = "LastWorkedOnDate";
        public const string columnCreateDate = "CreateDate";

        public static DataTable Select()
        {
            string sSQL = "SELECT * FROM " + tableName;

            Query q = new Query(sSQL);

            return q.GetDataTable();
        }

        public static DataRow Select(int iProjectID)
        {
            string sSQL = "SELECT * FROM " + tableName + " " +
                          "WHERE " + columnProjectID + " = @" + columnProjectID;

            Query q = new Query(sSQL);
            q.AddParameter("@" + columnProjectID, iProjectID, SqlDbType.Int);

            return q.GetDataRow();
        }

        public static void Update(int iProjectID, string sProjectName, string sProjectDescription, string sDeveloperNotes, int iStatusID, int iSequence, DateTime? dtAssignDate, DateTime? dtStartDate, DateTime? dtDueDate, DateTime? dtCompleteDate, DateTime? dtLastWorkedOnDate)
        {
            string sSQL = "UPDATE " + tableName + " SET " +
                                    columnProjectName + " = @" + columnProjectName + ", " +
                                    columnProjectDescription + " = @" + columnProjectDescription + ", " +
                                    columnDeveloperNotes + " = @" + columnDeveloperNotes + ", " +
                                    columnStatusID + " = @" + columnStatusID + ", " +
                                    columnSequence + " = @" + columnSequence + ", " +
                                    columnAssignDate + " = @" + columnAssignDate + ", " +
                                    columnStartDate + " = @" + columnStartDate + ", " +
                                    columnDueDate + " = @" + columnDueDate + ", " +
                                    columnCompleteDate + " = @" + columnCompleteDate + ", " +
                                    columnLastWorkedOnDate + " = @" + columnLastWorkedOnDate + " " +
                          "WHERE " + columnProjectID + " = @" + columnProjectID;

            Query q = new Query(sSQL);

            q.AddParameter("@" + columnProjectName, sProjectName, SqlDbType.VarChar);
            q.AddParameter("@" + columnProjectDescription, sProjectDescription, SqlDbType.Text);
            q.AddParameter("@" + columnDeveloperNotes, sDeveloperNotes, SqlDbType.Text);
            q.AddParameter("@" + columnStatusID, iStatusID, SqlDbType.Int);
            q.AddParameter("@" + columnSequence, iSequence, SqlDbType.Int);
            q.AddParameter("@" + columnAssignDate, dtAssignDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnStartDate, dtStartDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnDueDate, dtDueDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnCompleteDate, dtCompleteDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnLastWorkedOnDate, dtLastWorkedOnDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnProjectID, iProjectID, SqlDbType.Int);

            q.ExecuteNonQuery();
        }

        public static void Insert(string sProjectName, string sProjectDescription, string sDeveloperNotes, int iStatusID, int iSequence, DateTime? dtAssignDate, DateTime? dtStartDate, DateTime? dtDueDate, DateTime? dtCompleteDate, DateTime? dtLastWorkedOnDate)
        {
            string sSQL = "INSERT INTO " + tableName +
                          "         (" + columnProjectName + ", " + columnProjectDescription + ", " + columnDeveloperNotes + ", " + columnStatusID + ", " + columnSequence + ", " + columnAssignDate + ", " + columnStartDate + ", " + columnDueDate + ", " + columnCompleteDate + ", " + columnLastWorkedOnDate + ") " +
                          "VALUES   (@" + columnProjectName + ", @" + columnProjectDescription + ", @" + columnDeveloperNotes + ", @" + columnStatusID + ", @" + columnSequence + ", @" + columnAssignDate + ", @" + columnStartDate + ", @" + columnDueDate + ", @" + columnCompleteDate + ", @" + columnLastWorkedOnDate + ")";

            Query q = new Query(sSQL);

            q.AddParameter("@" + columnProjectName, sProjectName, SqlDbType.VarChar);
            q.AddParameter("@" + columnProjectDescription, sProjectDescription, SqlDbType.Text);
            q.AddParameter("@" + columnDeveloperNotes, sDeveloperNotes, SqlDbType.Text);
            q.AddParameter("@" + columnStatusID, iStatusID, SqlDbType.Int);
            q.AddParameter("@" + columnSequence, iSequence, SqlDbType.Int);
            q.AddParameter("@" + columnAssignDate, dtAssignDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnStartDate, dtStartDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnDueDate, dtDueDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnCompleteDate, dtCompleteDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnLastWorkedOnDate, dtLastWorkedOnDate, SqlDbType.DateTime);

            q.ExecuteNonQuery();
        }
    }
}
