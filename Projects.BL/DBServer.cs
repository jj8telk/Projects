using Projects.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.BL
{
    public class DBServer
    {
        public int DBServerID { get; set; }
        public string DBServerName { get; set; }

        public static void DataRowToObject(DataRow dr, DBServer obj)
        {
            obj.DBServerID = Convert.ToInt32(dr[DBServerDAO.columnDBServerID]);
            obj.DBServerName = dr[DBServerDAO.columnDBServerName].ToString();
        }
    }
}
