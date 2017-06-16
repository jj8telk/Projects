using Projects.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.BL
{
    public class DBObject
    {
        public int DBObjectID { get; set; }
        public int DBID { get; set; }
        public string DBObjectName { get; set; }
        public string DBObjectType { get; set; }
        public string Notes { get; set; }
        public int StatusID { get; set; }

        public Status Status
        {
            get
            {
                return new Status(StatusID);
            }
        }

        public DB DB { get; set; }
        public DBServer DBServer { get; set; }

        public DBObject()
        {

        }

        public static void DataRowToObject(DataRow dr, DBObject obj)
        {
            obj.DBObjectID = Convert.ToInt32(dr[DBObjectDAO.columnDBObjectID]);
            obj.DBID = Convert.ToInt32(dr[DBObjectDAO.columnDBID]);
            obj.DBObjectName = dr[DBObjectDAO.columnDBObjectName].ToString();
            obj.DBObjectType = dr[DBObjectDAO.columnDBObjectType].ToString();
            obj.Notes = dr[DBObjectDAO.columnNotes].ToString();
            obj.StatusID = Convert.ToInt32(dr[DBObjectDAO.columnStatusID]);
        }
    }
}
