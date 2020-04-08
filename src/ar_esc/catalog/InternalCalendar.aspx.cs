
using System;
using System.Configuration;
public partial class catalog_InternalCalendar : region4.escWeb.BasePages.Catalog.calendar_aspx
{
    protected override void AssignControls()
    {
        //Calendar Control
        base._calendar = cal1;
        this._calendarType = "internal";
    }

    protected override void LoadInternalCalendarEvents(object sender, EventArgs e)
    {
        region4.WebControls.Calendar calendar = sender as region4.WebControls.Calendar;
        string location = LegacyCode.Strings.GetSafeString("location", LegacyCode.Strings.StringType.QueryString, "");

        if (ConfigurationManager.AppSettings["CustomerSiteId"] == "ar_ade")
        {   location = "12861";
            base._calendar.Location = "12861";
        
        }
        if (calendar == null)
            throw new Exception("expected a calendar but didn't get one");

        calendar.ClearCalendar();

        foreach (escWeb.ar_esc.ObjectModel.SessionInfo session in region4.ObjectModel.SessionInfoList.LoadInternalCalendarEvents(calendar.StartMonth))
        {
            if (session.DisplayOnWeb)
            {
                 if (_calendar.Location == "12861") // ADE
                    calendar.AddItem(session);
            }
        }
    }
}
