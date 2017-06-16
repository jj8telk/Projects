using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.BL
{
    public class Status
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; }

        public string StatusColor;

        public enum StatusType
        {
            Open = 1,
            InProgress = 2,
            Complete = 3,
            OnHold = 4
        }

        public Status(int iStatusID)
        {
            StatusID = iStatusID;
            StatusName = ((StatusType)iStatusID).ToString();
            StatusColor = GetStatusColor((StatusType)iStatusID);
        }


        public static string GetStatusColor(StatusType st)
        {
            switch (st)
            {
                case StatusType.Complete:
                    return "success";
                case StatusType.Open:
                    return "default";
                case StatusType.InProgress:
                    return "warning";
                case StatusType.OnHold:
                    return "danger";
                default:
                    return "primary";
            }
        }
    }
}
