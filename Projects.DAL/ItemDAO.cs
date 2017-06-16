using Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.DAL
{
    public class ItemDAO
    {
        public const string tableName = "Item";
        public const string columnItemID = "ItemID";
        public const string columnProjectID = "ProjectID";
        public const string columnParentID = "ParentID";
        public const string columnItemName = "ItemName";
        public const string columnItemDescription = "ItemDescription";
        public const string columnItemType = "ItemType";
        public const string columnStatusID = "StatusID";
        public const string columnSequence = "Seq";
        public const string columnAssignDate = "AssignDate";
        public const string columnStartDate = "StartDate";
        public const string columnDueDate = "DueDate";
        public const string columnCompleteDate = "CompleteDate";
        public const string columnLastWorkedOnDate = "LastWorkedOnDate";
        public const string columnCreateDate = "CreateDate";

        public const string sprocGetBreadcrumb = "spGetBreadcrumb";
        public const string sprocUpdateStatus = "spUpdateStatusItem";

        public static DataTable Select()
        {
            string sSQL = "SELECT * FROM " + tableName;

            Query q = new Query(sSQL);

            return q.GetDataTable();
        }

        public static DataTable SelectByProjectAndType(int iProjectID, string sItemType, int iParentID)
        {
            string sSQL = "SELECT * FROM " + tableName + " " +
                          "WHERE " + columnProjectID + " = @" + columnProjectID + " " +
                          "  AND " + columnItemType + " = @" + columnItemType + " " +
                          "  AND " + columnParentID + " = @" + columnParentID;

            Query q = new Query(sSQL);
            q.AddParameter("@" + columnProjectID, iProjectID, SqlDbType.Int);
            q.AddParameter("@" + columnItemType, sItemType, SqlDbType.VarChar);
            q.AddParameter("@" + columnParentID, iParentID, SqlDbType.Int);

            return q.GetDataTable();
        }

        public static DataTable SelectParentsByProjectAndType(int iProjectID, string sItemType)
        {
            string sSQL = "SELECT * FROM " + tableName + " " +
                          "WHERE " + columnProjectID + " = @" + columnProjectID + " " +
                          "  AND " + columnItemType + " = @" + columnItemType + " " +
                          "  AND " + columnParentID + " IS NULL";

            Query q = new Query(sSQL);
            q.AddParameter("@" + columnProjectID, iProjectID, SqlDbType.Int);
            q.AddParameter("@" + columnItemType, sItemType, SqlDbType.VarChar);

            return q.GetDataTable();
        }

        public static DataRow Select(int iItemID)
        {
            string sSQL = "SELECT * " +
                          "FROM     " + tableName + " " +
                          "WHERE    " + columnItemID + " = @" + columnItemID;

            Query q = new Query(sSQL);
            q.AddParameter("@" + columnItemID, iItemID, SqlDbType.Int);

            return q.GetDataRow();
        }

        public static DataTable SelectByProjectID(int iProjectID)
        {
            string sSQL = "SELECT * " +
                          "FROM     " + tableName + " " +
                          "WHERE    " + columnProjectID + " = @" + columnProjectID + " " +
                          " AND     " + columnParentID + " IS NULL";

            Query q = new Query(sSQL);
            q.AddParameter("@" + columnProjectID, iProjectID, SqlDbType.Int);

            return q.GetDataTable();
        }

        public static DataTable SelectByParentID(int iParentID)
        {
            string sSQL = "SELECT * " +
                          "FROM     " + tableName + " " +
                          "WHERE    " + columnParentID + " = @" + columnParentID;

            Query q = new Query(sSQL);
            q.AddParameter("@" + columnParentID, iParentID, SqlDbType.Int);

            return q.GetDataTable();
        }

        public static void Update(int iItemID, int iProjectID, int? iParentID, string sItemName, string sItemDescription, string sItemType, int iStatusID, int iSequence, DateTime? dtAssignDate, DateTime? dtStartDate, DateTime? dtDueDate, DateTime? dtCompleteDate, DateTime? dtLastWorkedOnDate)
        {
            string sSQL = "UPDATE " + tableName + " SET " +
                                    columnProjectID + " = @" + columnProjectID + ", " +
                                    columnParentID + " = @" + columnParentID + ", " +
                                    columnItemName + " = @" + columnItemName + ", " +
                                    columnItemDescription + " = @" + columnItemDescription + ", " +
                                    columnItemType + " = @" + columnItemType + ", " +
                                    columnStatusID + " = @" + columnStatusID + ", " +
                                    columnSequence + " = @" + columnSequence + ", " +
                                    columnAssignDate + " = @" + columnAssignDate + ", " +
                                    columnStartDate + " = @" + columnStartDate + ", " +
                                    columnDueDate + " = @" + columnDueDate + ", " +
                                    columnCompleteDate + " = @" + columnCompleteDate + ", " +
                                    columnLastWorkedOnDate + " = @" + columnLastWorkedOnDate + " " +
                          "WHERE " + columnItemID + " = @" + columnItemID;

            Query q = new Query(sSQL);
            q.AddParameter("@" + columnProjectID, iProjectID, SqlDbType.Int);
            q.AddParameter("@" + columnParentID, iParentID, SqlDbType.Int);
            q.AddParameter("@" + columnItemName, sItemName, SqlDbType.VarChar);
            q.AddParameter("@" + columnItemDescription, sItemDescription, SqlDbType.VarChar);
            q.AddParameter("@" + columnItemType, sItemType, SqlDbType.VarChar);
            q.AddParameter("@" + columnStatusID, iStatusID, SqlDbType.Int);
            q.AddParameter("@" + columnSequence, iSequence, SqlDbType.Int);
            q.AddParameter("@" + columnAssignDate, dtAssignDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnStartDate, dtStartDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnDueDate, dtDueDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnCompleteDate, dtCompleteDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnLastWorkedOnDate, dtLastWorkedOnDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnItemID, iItemID, SqlDbType.Int);

            q.ExecuteNonQuery();

            q = new Query(sprocUpdateStatus);
            q.command_type = CommandType.StoredProcedure;
            q.AddParameter("@ItemID", iItemID, SqlDbType.Int);
            q.AddParameter("@StatusID", iStatusID, SqlDbType.Int);
            q.ExecuteNonQuery();
        }

        public static int Insert(int iProjectID, int? iParentID, string sItemName, string sItemDescription, string sItemType, int iStatusID, int iSequence, DateTime? dtAssignDate, DateTime? dtStartDate, DateTime? dtDueDate, DateTime? dtCompleteDate, DateTime? dtLastWorkedOnDate)
        {
            string sSQL = "INSERT INTO " + tableName +
                          "         (" + columnProjectID + ", " + columnParentID + ", " + columnItemName + ", " + columnItemDescription + ", " + columnItemType + ", " + columnStatusID + ", " + columnSequence + ", " + columnAssignDate + ", " + columnStartDate + ", " + columnDueDate + ", " + columnCompleteDate + ", " + columnLastWorkedOnDate + ") " +
                          "VALUES   (@" + columnProjectID + ", @" + columnParentID + ", @" + columnItemName + ", @" + columnItemDescription + ", @" + columnItemType + ", @" + columnStatusID + ", @" + columnSequence + ", @" + columnAssignDate + ", @" + columnStartDate + ", @" + columnDueDate + ", @" + columnCompleteDate + ", @" + columnLastWorkedOnDate + ")";

            Query q = new Query(sSQL);
            q.AddParameter("@" + columnProjectID, iProjectID, SqlDbType.Int);
            q.AddParameter("@" + columnParentID, iParentID, SqlDbType.Int);
            q.AddParameter("@" + columnItemName, sItemName, SqlDbType.VarChar);
            q.AddParameter("@" + columnItemDescription, sItemDescription, SqlDbType.VarChar);
            q.AddParameter("@" + columnItemType, sItemType, SqlDbType.VarChar);
            q.AddParameter("@" + columnStatusID, iStatusID, SqlDbType.Int);
            q.AddParameter("@" + columnSequence, iSequence, SqlDbType.Int);
            q.AddParameter("@" + columnAssignDate, dtAssignDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnStartDate, dtStartDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnDueDate, dtDueDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnCompleteDate, dtCompleteDate, SqlDbType.DateTime);
            q.AddParameter("@" + columnLastWorkedOnDate, dtLastWorkedOnDate, SqlDbType.DateTime);

            q.ExecuteNonQuery();

            sSQL = "SELECT " + columnItemID + " FROM " + tableName + " WHERE " + columnItemName + " = @" + columnItemName;

            q = new Query(sSQL);
            q.AddParameter("@" + columnItemName, sItemName, SqlDbType.VarChar);

            int iItemID = Convert.ToInt32(q.GetScalar());

            q = new Query(sprocUpdateStatus);
            q.command_type = CommandType.StoredProcedure;
            q.AddParameter("@ItemID", iItemID, SqlDbType.Int);
            q.AddParameter("@StatusID", iStatusID, SqlDbType.Int);
            q.ExecuteNonQuery();

            return iItemID;
        }

        public static void Delete(int iItemID)
        {
            string sSQL = "DELETE FROM " + tableName + " WHERE " + columnItemID + " = @" + columnItemID;

            Query q = new Query(sSQL);
            q.AddParameter("@" + columnItemID, iItemID, SqlDbType.Int);

            q.ExecuteNonQuery();
        }

        public static DataTable spGetBreadcrumb(int iItemID)
        {
            Query q = new Query(sprocGetBreadcrumb);
            q.command_type = CommandType.StoredProcedure;
            q.AddParameter("@ItemID", iItemID, SqlDbType.Int);

            return q.GetDataTable();
        }
    }
}
