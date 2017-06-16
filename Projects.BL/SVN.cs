using Projects.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.BL
{
    public class SVN
    {
        public int SVNID { get; set; }
        public string SVNName { get; set; }
        public string SVNLocation { get; set; }

        public SVN()
        {

        }
        
        public static void DataRowToObject(DataRow dr, SVN obj)
        {
            obj.SVNID = Convert.ToInt32(dr[SVNDAO.columnSVNID]);
            obj.SVNName = dr[SVNDAO.columnSVNName].ToString();
            obj.SVNLocation = dr[SVNDAO.columnSVNLocation].ToString();
        }

        public static int Save(string sSVNName, string sSVNLocation)
        {
            return SVNDAO.Insert(sSVNName, sSVNLocation);
        }


        public static List<SVN> GetSVNs()
        {
            List<SVN> lst = new List<SVN>();

            foreach (DataRow dr in SVNDAO.Select().Rows)
            {
                SVN s = new SVN();
                DataRowToObject(dr, s);
                lst.Add(s);
            }

            return lst;
        }

        public static List<SVN> GetSVNs(string sLetters)
        {
            List<SVN> lst = new List<SVN>();

            foreach (DataRow dr in SVNDAO.SelectByLetters(sLetters).Rows)
            {
                SVN s = new SVN();
                DataRowToObject(dr, s);
                lst.Add(s);
            }

            return lst;
        }
    }
}
