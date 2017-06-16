using Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.DAL
{
    public class ProjectSVNDAO
    {
        public const string tableName = "ProjectSVN";

        public const string columnProjectID = "ProjectID";
        public const string columnSVNID = "SVNID";
        public const string columnSequence = "Seq";

        public static DataTable SelectByProjectID(int iProjectID)
        {
            string sSQL = "SELECT s.* FROM " + tableName + " ps " +
                          "  JOIN " + SVNDAO.tableName + " s ON s." + SVNDAO.columnSVNID + " = ps." + columnSVNID + " " +
                          "WHERE ps." + columnProjectID + " = @" + columnProjectID;
            
            Query q = new Query(sSQL);
            q.AddParameter("@" + columnProjectID, iProjectID, SqlDbType.Int);

            return q.GetDataTable();
        }

        public static void Insert(int iProjectID, int iSVNID, int iSequence)
        {
            string sSQL = "INSERT INTO " + tableName + " (" + columnProjectID + ", " + columnSVNID + ", " + columnSequence + ") VALUES " +
                          "(@" + columnProjectID + ", @" + columnSVNID + ", @" + columnSequence + ")";

            Query q = new Query(sSQL);
            q.AddParameter("@" + columnProjectID, iProjectID, SqlDbType.Int);
            q.AddParameter("@" + columnSVNID, iSVNID, SqlDbType.Int);
            q.AddParameter("@" + columnSequence, iSequence, SqlDbType.Int);

            q.ExecuteNonQuery();
        }

        public static void Delete(int iProjectID, int iSVNID)
        {
            string sSQL = "DELETE FROM " + tableName + " " +
                          "WHERE " + columnProjectID + " = @" + columnProjectID + " " +
                          "  AND " + columnSVNID + " = @" + columnSVNID;

            Query q = new Query(sSQL);
            q.AddParameter("@" + columnProjectID, iProjectID, SqlDbType.Int);
            q.AddParameter("@" + columnSVNID, iSVNID, SqlDbType.Int);

            q.ExecuteNonQuery();
        }
    }
}
