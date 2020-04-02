using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
namespace escWeb.tx_r3.ObjectModel
{
    [Serializable]
    public class Event : region4.ObjectModel.Event
    {
        public Event(int event_id) : base(event_id)
        {
        }

        public bool IsNet3Event
        {
            get
            {
                return (EventType.ItemId ==  int.Parse(ConfigurationManager.AppSettings["Net3EventTypeId"]) ); //1360
            }
        }

        public bool IsNet3StudentEvent
        {
            get
            {
                return (EventType.ItemId == int.Parse(ConfigurationManager.AppSettings["Net3StudentEventTypeId"])); 
            }
        }

    }

    [Serializable]
    public class Conference : region4.ObjectModel.Conference
    {
        public Conference(int conference_id) : base(conference_id)
        {

        }

        //Added by VM 4-28-2017
        public bool IsNet3Event
        {
            get
            {
                return (EventType.ItemId == int.Parse(ConfigurationManager.AppSettings["Net3EventTypeId"])); //1360
            }
        }

        public bool IsNet3StudentEvent
        {
            get
            {
                return (EventType.ItemId == int.Parse(ConfigurationManager.AppSettings["Net3StudentEventTypeId"]));
            }
        }

        protected override void LoadCustomerData(SqlDataReader reader)
        {
            _dimensions = reader["dimensions"].ToString();
            _standards = reader["standards"].ToString();

        }
    }


    [Serializable]
    public class MultiVenue : region4.ObjectModel.MultiVenue
    {
        public MultiVenue(int event_id)
            : base(event_id)
        {

        }

        //Added by VM 4-28-2017
        public bool IsNet3Event
        {
            get
            {
                return (EventType.ItemId == int.Parse(ConfigurationManager.AppSettings["Net3EventTypeId"])); //1360
            }
        }

        public bool IsNet3StudentEvent
        {
            get
            {
                return (EventType.ItemId == int.Parse(ConfigurationManager.AppSettings["Net3StudentEventTypeId"]));
            }
        }
    }
}