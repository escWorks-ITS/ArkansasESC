using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using region4.ObjectModel;



public partial class catalog_calendar : region4.escWeb.BasePages.Catalog.calendar_aspx
{
    
    protected override void AssignControls()
    {
        //Calendar Control
        base._calendar = cal1;
    }

    protected override void calendar_LoadCalendarEvents(object sender, EventArgs e)
    {
        region4.WebControls.Calendar calendar = sender as region4.WebControls.Calendar;

        if (calendar == null)
            throw new Exception("expected a calendar but didn't get one");
        calendar.ClearCalendar();
        DateTime today = DateTime.Today;
        if ((today.Year == calendar.StartMonth.Year && (today.Month - calendar.StartMonth.Month) <= 1) || ((today.Year - calendar.StartMonth.Year) == 1 && today.Month == 1 && calendar.StartMonth.Month == 12) || today.Year < calendar.StartMonth.Year) // display past sessions one month back - VM 1-12-2015
        {
            foreach (SessionInfo session in SessionInfoList.LoadCalendarEvents(calendar.StartMonth))
            {
                if (session.DisplayOnWeb && _calendar.Location == "") // Modified by VM 3-20-2014
                    calendar.AddItem(session);
                else
                {
                    if (session.DisplayOnWeb)
                    {
                        if (session.SiteID == Convert.ToInt32(_calendar.Location) || session.OrganizationID == Convert.ToInt32(_calendar.Location) || session.LocationID == Convert.ToInt32(_calendar.Location))
                        {
                            calendar.AddItem(session);
                        }
                    }
                }
            }
        }
    }

}
