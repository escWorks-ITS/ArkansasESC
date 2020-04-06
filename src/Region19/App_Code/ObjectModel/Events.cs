using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace escWeb.tx_r19.ObjectModel
{
    [Serializable]
    public class Event : region4.ObjectModel.Event
    {
        public Event(int event_id) : base(event_id)
        {
        }

    }

    [Serializable]
    public class Conference : region4.ObjectModel.Conference
    {
        public Conference(int conference_id) : base(conference_id)
        {

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
    }
}