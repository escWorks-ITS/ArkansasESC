using System;
using System.Collections.Generic;
using System.Text;

namespace escWeb.ar_esc.ObjectModel
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