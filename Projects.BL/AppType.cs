using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.BL
{
    public class AppType
    {
        public string AppTypeID { get; set; }
        public string AppTypeName { get; set; }

        public string Color;

        public enum AppTypeType
        {
            Program,
            Database
        }

        public AppType(string sAppTypeID)
        {
            AppTypeID = sAppTypeID;
            AppTypeName = GetAppType(sAppTypeID);
            Color = GetColor(sAppTypeID);
        }

        public static string GetAppType(string sAppTypeID)
        {
            switch (sAppTypeID)
            {
                case "P":
                    return "Program";
                case "D":
                    return "Database";
                default:
                    return "";
            }
        }

        public static string GetColor(string at)
        {
            switch (at)
            {
                case "D":
                    return "warning";
                case "P":
                    return "success";
                default:
                    return "primary";
            }
        }

    }
}
