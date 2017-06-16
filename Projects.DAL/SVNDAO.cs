using Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.DAL
{
    public class SVNDAO
    {
        public const string tableName = "SVN";

        public const string columnSVNID = "SVNID";
        public const string columnSVNName = "SVNName";
        public const string columnSVNLocation = "SVNLocation";

        public static DataTable Select()
        {
            string sSQL = "SELECT * FROM " + tableName;

            Query q = new Query(sSQL);

            return q.GetDataTable();
        }

        public static DataTable SelectByLetters(string sLetters)
        {
            string sSQL = "SELECT * FROM " + tableName + " " +
                          "    WHERE " + columnSVNName + " LIKE '%" + sLetters + "%'";

            Query q = new Query(sSQL);

            return q.GetDataTable();
        }

        public static int Insert(string sSVNName, string sSVNLocation)
        {
            string sSQL = "INSERT INTO " + tableName + " (" + columnSVNName + ", " + columnSVNLocation + ") VALUES " +
                          "(@" + columnSVNName + ", @" + columnSVNLocation + ")";

            Query q = new Query(sSQL);
            q.AddParameter("@" + columnSVNName, sSVNName, SqlDbType.VarChar);
            q.AddParameter("@" + columnSVNLocation, sSVNLocation, SqlDbType.VarChar);

            q.ExecuteNonQuery();

            sSQL = "SELECT " + columnSVNID + " FROM " + tableName + " WHERE " + columnSVNName + " = @" + columnSVNName;

            q = new Query(sSQL);
            q.AddParameter("@" + columnSVNName, sSVNName, SqlDbType.VarChar);

            return Convert.ToInt32(q.GetScalar());
        }
    }
}
