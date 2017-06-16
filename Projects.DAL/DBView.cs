using Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.DAL
{
    public class DBView
    {
        public const string tableName = "DBView";

        public static DataTable SelectByProjectID(int iProjectID)
        {
            string sSQL = "SELECT dv.* FROM " + ProjectDBObjectDAO.tableName + " p " +
                          " JOIN " + tableName + " dv ON dv." + DBObjectDAO.columnDBObjectID + " = p." + ProjectDBObjectDAO.columnDBObjectID + " " +
                          "WHERE p." + ProjectDBObjectDAO.columnProjectID + " = @" + ProjectDBObjectDAO.columnProjectID;

            Query q = new Query(sSQL);
            q.AddParameter("@" + ProjectDBObjectDAO.columnProjectID, iProjectID, SqlDbType.Int);

            return q.GetDataTable();
        }
    }
}
