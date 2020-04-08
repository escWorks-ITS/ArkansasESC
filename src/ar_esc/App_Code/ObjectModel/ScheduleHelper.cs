using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using region4.ObjectModel;
namespace escWeb.ar_esc.ObjectModel
{

    /// <summary>
    /// Summary description for ScheduleHelper
    /// </summary>
    /// 
    [Serializable]
    public class ScheduleHelper : region4.ObjectModel.ScheduleHelper
    {
        public ScheduleHelper()
        {
        }

        public override string Locations
        {
            get
            {
                string result = "";
                List<Room> itemsToRemove = new List<Room>();
                List<Room> copy = new List<Room>();
                foreach (Room r in locations)
                    copy.Add(r);

                while (copy.Count > 0)
                {
                    Room location = copy[0];
                    itemsToRemove.Add(location);
                    foreach (Room l in copy)
                        if (l == location)
                            continue;
                        else if (l.Site == location.Site)
                            itemsToRemove.Add(l);
                    string temp = "";
                    foreach (Room r in itemsToRemove)
                    {
                        if (r.ExceptionOccurred)
                            continue;
                        if (temp.Length == 0)
                            temp += r.Site.Organization.Name +  " - " + r.Site.Name + " - " + r.Name;
                        else
                            temp += ", " + r.Name;
                    }
                    if (
                         (location.Site.IsServiceCenter && (!String.IsNullOrEmpty(location.Site.Address1) && !String.IsNullOrEmpty(location.Site.City) && !String.IsNullOrEmpty(location.Site.Zip)))
                           || (!location.Site.IsServiceCenter && (!String.IsNullOrEmpty(location.Address1) && !String.IsNullOrEmpty(location.City) && !String.IsNullOrEmpty(location.Zip))))
                        temp += String.Format("<br /><a style\"font-size: 8pt; font-style:italic;\">{0}, {1}, {2}</a><br />", location.Site.IsServiceCenter ? location.Site.Address1 : location.Address1,
                            location.Site.IsServiceCenter ? location.Site.City : location.City,
                            location.Site.IsServiceCenter ? location.Site.Zip : location.Zip);
                    result += temp;
                    foreach (Room r in itemsToRemove)
                        copy.Remove(r);
                }
                return result;
            }
        }

    }
}