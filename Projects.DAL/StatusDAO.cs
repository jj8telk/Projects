using Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.DAL
{
    public class StatusDAO
    {
        public const string tableName = "Status";
        public const string columnStatusID = "StatusID";
        public const string columnStatusName = "StatusName";

        public static DataTable Select()
        {
            string sSQL = "SELECT * FROM " + tableName;

            Query q = new Query(sSQL);

            return q.GetDataTable();
        }

        public static DataRow Select(int iStatusID)
        {
            string sSQL = "SELECT * FROM " + tableName + " " +
                          "WHERE " + columnStatusID + " = @" + columnStatusID;

            Query q = new Query(sSQL);
            q.AddParameter("@" + columnStatusID, iStatusID, SqlDbType.Int);

            return q.GetDataRow();

        }
    }
}
