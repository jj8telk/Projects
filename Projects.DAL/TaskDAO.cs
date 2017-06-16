using Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.DAL
{
    public class TaskDAO
    {
        public const string tableName = "Task";
        public const string columnTaskID = "TaskID";
        public const string columnItemID = "ItemID";
        public const string columnTaskDescription = "TaskDescription";
        public const string columnStatusID = "StatusID";
        public const string columnSequence = "Seq";
        public const string columnAppType = "AppType";
        public const string columnAppProjectName = "AppProjectName";
        public const string columnAppFile = "AppFile";
        public const string columnLineNumbers = "LineNumbers";
        public const string columnAssignDate = "AssignDate";
        public const string columnStartDate = "StartDate";
        public const string columnDueDate = "DueDate";
        public const string columnCompleteDate = "CompleteDate";
        public const string columnLastWorkedOnDate = "LastWorkedOnDate";
        public const string columnCreateDate = "CreateDate";

        public const string sprocUpdateStatus = "spUpdateStatusTask";

        public static DataTable Select()
        {
            string sSQL = "SELECT * FROM " + tableName;

            Query q = new Query(sSQL);

            return q.GetDataTable();
        }

        public static DataRow Select(int iTaskID)
        {
            string sSQL = "SELECT * FROM " + tableName + " " +
                          "WHERE " + columnTaskID + " = @" + columnTaskID;

            Query q = new Query(sSQL);
            q.AddParameter("@" + columnTaskID, iTaskID, SqlDbType.Int);

            return q.GetDataRow();
        }

        public static DataTable SelectByItemID(int iItemID)
        {
            string sSQL = "SELECT * FROM " + tableName + " " +
                          "WHERE " + columnItemID + " = @" + columnItemID;

            Query q = new Query(sSQL);
            q.AddParameter("@" + columnItemID, iItemID, SqlDbType.Int);

            return q.GetDataTable();
        }

        public static void Update(int iTaskID, int iItemID, string sTaskDescription, int iStatusID, int iSequence, string sAppType, string sAppProjectName, string sAppFile, string sLineNumbers, DateTime? dtAssignDate, DateTime? dtStartDate, DateTime? dtDueDate, DateTime? dtCompleteDate, DateTime? dtLastWorkedOnDate)
        {
            string sSQL = "UPDATE " + tableName + " SET " +
                                    columnItemID + " = @" + columnItemID+ ", " +
                                    columnTaskDescription+ " = @" + columnTaskDescription+ ", " +
                                    columnStatusID + " = @" + columnStatusID + ", " +
                                    columnSequence + " = @" + columnSequence + ", " +
                                    columnAppType + " = @" + columnAppType + ", " +
                                    columnAppProjectName + " = @" + columnAppProjectName + ", " +
                                    columnAppFile + " = @" + columnAppFile + ", " +
                                    columnLineNumbers + " = @" + columnLineNumbers + ", " +
                                    columnAssignDate + " = @" + columnAssignDate + ", " +
                                    columnStartDate + " = @" + columnStartDate + ", " +
                                    columnDueDate + " = @" + columnDueDate + ", " +
                                    columnCompleteDate + " = @" + columnCompleteDate + ", " +
                                    columnLastWorkedOnDate + " = @" + columnLastWorkedOnDate + " " +
                          "WHERE " + columnTaskID + " = @" + columnTaskID;

            Query q = new Query(sSQL);
            q.AddParameter("@" + columnItemID, iItemID, SqlDbType.Int);
            q.AddParameter("@" + columnTaskDescription, sTaskDescription, SqlDbType.VarChar);            
            q.AddParameter("@" + columnStatusID, iStatusID, SqlDbType.Int);
            q.AddParameter("@" + columnSequence, iSequence, SqlDbType.Int);
            q.AddParameter("@" + columnAppType, sAppType, SqlDbType.VarChar);
            q.AddParameter("@" + columnAppProjectName, sAppProjectName, SqlDbType.VarChar);
            q.AddParameter("@" + columnAppFile, sAppFile, SqlDbType.VarChar);
            q.AddParameter("@" + columnLineNumbers, sLineNumbers, SqlDbType.VarChar);
            q.AddParameter("@" + columnAssignDate, dtAssignDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnStartDate, dtStartDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnDueDate, dtDueDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnCompleteDate, dtCompleteDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnLastWorkedOnDate, dtLastWorkedOnDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnTaskID, iTaskID, SqlDbType.Int);

            q.ExecuteNonQuery();

            q = new Query(sprocUpdateStatus);
            q.command_type = CommandType.StoredProcedure;
            q.AddParameter("@TaskID", iTaskID, SqlDbType.Int);
            q.AddParameter("@StatusID", iStatusID, SqlDbType.Int);
            q.ExecuteNonQuery();

        }

        public static void Insert(int iItemID, string sTaskDescription, int iStatusID, int iSequence, string sAppType, string sAppProjectName, string sAppFile, string sLineNumbers, DateTime? dtAssignDate, DateTime? dtStartDate, DateTime? dtDueDate, DateTime? dtCompleteDate, DateTime? dtLastWorkedOnDate)
        {
            string sSQL = "INSERT INTO " + tableName +
                          "         (" + columnItemID + ", " + columnTaskDescription + ", " + columnStatusID + ", " + columnSequence + ", " + columnAppType + ", " + columnAppProjectName + ", " + columnAppFile + ", " + columnLineNumbers + ", " + columnAssignDate + ", " + columnStartDate + ", " + columnDueDate + ", " + columnCompleteDate + ", " + columnLastWorkedOnDate + ") " +
                          "VALUES   (@" + columnItemID + ", @" + columnTaskDescription + ", @" + columnStatusID + ", @" + columnSequence + ", @" + columnAppType + ", @" + columnAppProjectName + ", @" + columnAppFile + ", @" + columnLineNumbers + ", @" + columnAssignDate + ", @" + columnStartDate + ", @" + columnDueDate + ", @" + columnCompleteDate + ", @" + columnLastWorkedOnDate + ")";

            Query q = new Query(sSQL);
            q.AddParameter("@" + columnItemID, iItemID, SqlDbType.Int);
            q.AddParameter("@" + columnTaskDescription, sTaskDescription, SqlDbType.VarChar);
            q.AddParameter("@" + columnStatusID, iStatusID, SqlDbType.Int);
            q.AddParameter("@" + columnSequence, iSequence, SqlDbType.Int);
            q.AddParameter("@" + columnAppType, sAppType, SqlDbType.VarChar);
            q.AddParameter("@" + columnAppProjectName, sAppProjectName, SqlDbType.VarChar);
            q.AddParameter("@" + columnAppFile, sAppFile, SqlDbType.VarChar);
            q.AddParameter("@" + columnLineNumbers, sLineNumbers, SqlDbType.VarChar);
            q.AddParameter("@" + columnAssignDate, dtAssignDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnStartDate, dtStartDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnDueDate, dtDueDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnCompleteDate, dtCompleteDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnLastWorkedOnDate, dtLastWorkedOnDate, SqlDbType.DateTime);

            q.ExecuteNonQuery();

            q = new Query("SELECT " + columnTaskID + " FROM " + tableName + " WHERE " + columnTaskDescription + " = @" + columnTaskDescription);
            q.AddParameter("@" + columnTaskDescription, sTaskDescription, SqlDbType.VarChar);
            int iTaskID = Convert.ToInt32(q.GetScalar());

            q = new Query(sprocUpdateStatus);
            q.command_type = CommandType.StoredProcedure;
            q.AddParameter("@TaskID", iTaskID, SqlDbType.Int);
            q.AddParameter("@StatusID", iStatusID, SqlDbType.Int);
            q.ExecuteNonQuery();
        }
    }
}
