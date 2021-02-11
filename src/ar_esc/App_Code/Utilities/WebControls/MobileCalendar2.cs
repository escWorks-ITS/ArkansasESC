using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections;
using region4.ObjectModel;
using escWeb.ar_esc.ObjectModel;

namespace escWeb.ar_esc.ObjectModel
{

    public class MobileCalendar2 : WebControl
    {
        protected override void Render(HtmlTextWriter writer)
        {
            HtmlTable table;
            SortedList<DateTime, region4.ObjectModel.SessionInfo> session = ReturnSessions();
            table = RenderTable(session);
            table.RenderControl(writer);
            base.Render(writer);
        }

        

        protected virtual HtmlTable RenderTable(SortedList<DateTime, region4.ObjectModel.SessionInfo> sessions)
        {
            HtmlTable result = new HtmlTable();
            result.Style.Add("border-collapse", "collapse");
            result.Width = Unit.Pixel(325).ToString();

            result.CellPadding = 2;
            result.CellSpacing = 0;
            DateTime currentDate = new DateTime(1902, 1, 1);

            HtmlTableRow row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            result.Rows.Add(row);

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            result.Rows.Add(row);

            int itemsAdded = 0;
            foreach (KeyValuePair<DateTime, region4.ObjectModel.SessionInfo> pair in sessions)
            {
                if (!pair.Value.DisplayOnWeb)
                    continue;
                DateTime sessionDate = new DateTime(pair.Value.StartDate.Year, pair.Value.StartDate.Month, pair.Value.StartDate.Day);
                LiteralControl control;
                if (currentDate != sessionDate)
                {
                    control = new LiteralControl(String.Format("<span class=\"mainBodyBold\">{0} {1}</span><br/>", System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.DayNames[(int)sessionDate.DayOfWeek], sessionDate.ToShortDateString()));
                    row.Cells[0].Controls.Add(control);
                }


                string shortDescription = String.Empty;
                if (pair.Value.Description.Length >= 100)
                {
                    shortDescription = pair.Value.Description.Substring(0, 99) + "...";
                }
                else
                {
                    shortDescription = pair.Value.Description;
                }
                control = new LiteralControl(String.Format("<span class=\"upcomingContent\"><a href=\"{0}catalog/session.aspx?session_id={1}\" class=\"upcomingLink\">{2}</a><br />{4}, {5}<br /><font style=\"color: black\">{3}</font><br /><br/></span>", ((region4.escWeb.BasePage)this.Page).PathToRoot, pair.Value.SessionID, pair.Value.Title, shortDescription, pair.Value.SiteName, pair.Value.RoomName));


                row.Cells[0].Controls.Add(control);

                itemsAdded++;
                currentDate = sessionDate;
            }

            if (itemsAdded == 0)
                row.Cells[0].Controls.Add(new LiteralControl(String.Format("<span class=\"upcomingContent\">There are no {0}</span>", region4.escWeb.SiteVariables.ObjectProvider.SessionPluralName)));



            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            result.Rows.Add(row);
            HtmlAnchor a = new HtmlAnchor();

            return result;
        }

        protected SortedList<DateTime, region4.ObjectModel.SessionInfo> ReturnSessions()
        {
            SortedList<DateTime, region4.ObjectModel.SessionInfo> result;
            SortedList<DateTime, region4.ObjectModel.SessionInfo> myResult = new SortedList<DateTime, region4.ObjectModel.SessionInfo>();
            string date = HttpContext.Current.Request.QueryString["date"];

            string location = HttpContext.Current.Request.QueryString["location"];

            DateTime startDate, endDate;
            if (date == null)
                startDate = Convert.ToDateTime(DateTime.Today.Month.ToString() + "/1/" + DateTime.Today.Year.ToString());
            else
                startDate = Convert.ToDateTime(date);

            endDate = startDate.AddMonths(1);

            result = region4.ObjectModel.SessionInfoList.UpcomingSessionsV2(startDate, endDate);

            //if (location == null || location == "")
            //{

            //        foreach (KeyValuePair<DateTime, region4.ObjectModel.SessionInfo> pair in result)
            //        {
            //            if ((pair.Value as SessionInfo).IsSTEM || (pair.Value as SessionInfo).IsEsc)
            //                myResult.Add(pair.Key, pair.Value);
            //        }
            //}
            //else
            //{
            //    foreach (KeyValuePair<DateTime, region4.ObjectModel.SessionInfo> pair in result)
            //    {
            //        if (pair.Value.LocationID.ToString() == location || pair.Value.SiteID.ToString() == location || pair.Value.OrganizationID.ToString() == location)
            //            myResult.Add(pair.Key, pair.Value);
            //    }
            //}
            foreach (KeyValuePair<DateTime, region4.ObjectModel.SessionInfo> pair in result)
            {
                if (pair.Value.DisplayOnWeb)
                {
                    if (location == "" || location == null)
                    {
                        if ((pair.Value as SessionInfo).IsSTEM || (pair.Value as SessionInfo).IsEsc)
                            myResult.Add(pair.Key, pair.Value);
                    }
                    else if (location == "12861") // ADE
                        myResult.Add(pair.Key, pair.Value);

                    else if (location == "99")  //All Cooperative
                    {

                        if ((pair.Value as SessionInfo).IsEsc && !(pair.Value as SessionInfo).IsSTEM)
                             myResult.Add(pair.Key, pair.Value);
                    }
                    else if (location == "100") //All Districts
                    {
                        if (!(pair.Value as SessionInfo).IsEsc && (pair.Value as SessionInfo).OwnerOrgId != 12861)
                            myResult.Add(pair.Key, pair.Value); 
                    }
                    else if ((pair.Value.SiteID == Convert.ToInt32(location) && !(pair.Value as SessionInfo).IsEsc)
                            || (pair.Value.OrganizationID == Convert.ToInt32(location) && (pair.Value as SessionInfo).IsEsc))
                    {
                        myResult.Add(pair.Key, pair.Value);
                    }
                    else if ((pair.Value.OrganizationID == Convert.ToInt32(location) && (pair.Value as SessionInfo).IsSTEM))
                        myResult.Add(pair.Key, pair.Value);

                    else if (location == "999") // all stems
                        if ((pair.Value as SessionInfo).IsSTEM)
                            myResult.Add(pair.Key, pair.Value);

                }
            }
            return myResult;
        }
    }
}
