using Projects.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.BL
{
    public class DB
    {
        public int DBID { get; set; }
        public int DBServerID { get; set; }
        public string DBName { get; set; }

        public DB()
        {

        }

        public static void DataRowToObject(DataRow dr, DB obj)
        {
            obj.DBID = Convert.ToInt32(dr[DBDAO.columnDBID]);
            obj.DBServerID = Convert.ToInt32(dr[DBDAO.columnDBServerID]);
            obj.DBName = dr[DBDAO.columnDBName].ToString();
        }
    }
}
