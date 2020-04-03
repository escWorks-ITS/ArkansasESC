using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace escWeb.tx_r3.ObjectModel
{
    /// <summary>
    /// Summary description for AttendeeInfo
    /// </summary>
    [Serializable]
    public class SessionInfo : region4.ObjectModel.SessionInfo
    {
        public bool IsNet3Event
        {
            get
            {
                return (EventType.ItemId == int.Parse(ConfigurationManager.AppSettings["Net3EventTypeId"])); //1360
            }
        }

        public bool IsZoomEvent
        {
            get
            {
                return (EventType.ItemId == int.Parse(ConfigurationManager.AppSettings["ZoomEventTypeId"])); //8046
            }
        }

        public bool IsNet3StudentEvent
        {
            get
            {
                return (EventType.ItemId == int.Parse(ConfigurationManager.AppSettings["Net3StudentEventTypeId"]));
            }
        }

        public SessionInfo(DataRow reader) : base(reader)
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}