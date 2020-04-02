using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace txr3WebControls
{
    //This is for Region 3, but it might be also used for other clients. 
    public class SevenDayOutlooks : region4.WebControls.SevenDayOutlook
    {
        protected override void Render(HtmlTextWriter writer)
        {
            HtmlTable table;
            SortedList<DateTime, region4.ObjectModel.SessionInfo> session = ReturnSessions();
            table = RenderTable(session);
            table.RenderControl(writer);
            base.Render(writer);
        }

        protected int _itemsToDisplay=10;

        public int ItemsToDisplay
        {
            get { return _itemsToDisplay; }
            set { _itemsToDisplay = value; }
        }

        private HtmlTable RenderTable(SortedList<DateTime, region4.ObjectModel.SessionInfo> sessions)
        {
            HtmlTable result = new HtmlTable();
            result.Style.Add("border-collapse", "collapse");
            result.Width = Unit.Pixel(400).ToString();
            result.CellPadding = 2;
            result.CellSpacing = 0;
            DateTime currentDate = new DateTime(1902, 1, 1);
            
            HtmlTableRow row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            result.Rows.Add(row);
            //row.Cells[0].InnerHtml = String.Format("<nobr>Upcoming {0}</nobr>", escWeb.SiteVariables.ObjectProvider.SessionPluralNameCapitalized);
            //row.Cells[0].Attributes.Add("class","upcomingSessionHeader");

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            result.Rows.Add(row);

            int itemsAdded = 0;
            foreach (KeyValuePair<DateTime, region4.ObjectModel.SessionInfo> pair in sessions)
            {
                if (itemsAdded > _itemsToDisplay)
                    break;
                if (!pair.Value.DisplayOnWeb)
                    continue;
                DateTime sessionDate = new DateTime(pair.Value.StartDate.Year, pair.Value.StartDate.Month, pair.Value.StartDate.Day);
                LiteralControl control;
                if (currentDate != sessionDate)
                {
                    control = new LiteralControl( String.Format("<span class=\"mainBodyBold\">{0} {1}</span><br/>",System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.DayNames[(int)sessionDate.DayOfWeek], sessionDate.ToShortDateString()));
                    row.Cells[0].Controls.Add(control);
                }
                control = new LiteralControl(String.Format("<span class=\"upcomingContent\"><a href=\"{0}catalog/session.aspx?session_id={1}\" class=\"upcomingLink\">{2}</a><br />{3}, {4}<br/></span>", ((region4.escWeb.BasePage)this.Page).PathToRoot, pair.Value.SessionID, pair.Value.Title, pair.Value.SiteName, pair.Value.RoomName));
                row.Cells[0].Controls.Add(control);

                itemsAdded++;
                currentDate = sessionDate;
            }

            if (itemsAdded == 0)
                row.Cells[0].Controls.Add(new LiteralControl(String.Format("<span class=\"upcomingContent\">There are no upcoming {0}</span>", region4.escWeb.SiteVariables.ObjectProvider.SessionPluralName)));

            //row = new HtmlTableRow();
            //row.Cells.Add(new HtmlTableCell());
            //result.Rows.Add(row);
            //HtmlAnchor a = new HtmlAnchor();
            //a.HRef = "~/catalog/calendar.aspx";
            //a.InnerHtml = String.Format("<nobr>more {0}...</nobr>", escWeb.SiteVariables.ObjectProvider.SessionPluralName);
            //row.Cells[0].Controls.Add(a);
            //a.Attributes.Add("class", "upcomingSessionFooter");

            return result;
        }

        private SortedList<DateTime, region4.ObjectModel.SessionInfo> ReturnSessions()
        {
            SortedList<DateTime, region4.ObjectModel.SessionInfo> result;

            DateTime startDate = DateTime.Now.AddDays(1);
            DateTime endDate = startDate.AddDays(region4.escWeb.SiteVariables.NumberOfDaysOfUpcomingEventsToDisplay);
            string cacheKey = String.Format("{0} - upcoming Events", region4.escWeb.SiteVariables.customer_id);
            result = System.Web.HttpContext.Current.Cache[cacheKey] as SortedList<DateTime, region4.ObjectModel.SessionInfo>;

            if (result == null)
            {
                result = region4.ObjectModel.SessionInfoList.UpcomingSessionsV2(startDate, endDate);
                System.Web.HttpContext.Current.Cache.Add(cacheKey, result, null, DateTime.Now.AddSeconds(15), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.AboveNormal, null);
            }

            return result;
        }
    }

    public class OnlineSessions : WebControl
    {
        protected override void Render(HtmlTextWriter writer)
        {
            HtmlTable table;
            SortedList<DateTime, region4.ObjectModel.SessionInfo> session = region4.ObjectModel.SessionInfoList.UpcomingOnlineSessions();
            table = RenderTable(session);
            table.RenderControl(writer);
            base.Render(writer);
        }

        protected int _itemsToDisplay = 10;

        public int ItemsToDisplay
        {
            get { return _itemsToDisplay; }
            set { _itemsToDisplay = value; }
        }

        private HtmlTable RenderTable(SortedList<DateTime, region4.ObjectModel.SessionInfo> sessions)
        {
            HtmlTable result = new HtmlTable();
            result.Style.Add("border-collapse", "collapse");
            result.Width = Unit.Pixel(400).ToString();
            result.CellPadding = 2;
            result.CellSpacing = 0;
            DateTime currentDate = new DateTime(1902, 1, 1);

            HtmlTableRow row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            result.Rows.Add(row);
            //row.Cells[0].InnerHtml = String.Format("<nobr>Upcoming {0}</nobr>", escWeb.SiteVariables.ObjectProvider.SessionPluralNameCapitalized);
            //row.Cells[0].Attributes.Add("class","upcomingSessionHeader");

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            result.Rows.Add(row);

            int itemsAdded = 0;
            foreach (KeyValuePair<DateTime, region4.ObjectModel.SessionInfo> pair in sessions)
            {
                if (itemsAdded > _itemsToDisplay)
                    break;
                if (!pair.Value.DisplayOnWeb)
                    continue;
                DateTime sessionDate = new DateTime(pair.Value.StartDate.Year, pair.Value.StartDate.Month, pair.Value.StartDate.Day);
                LiteralControl control;
                if (currentDate != sessionDate)
                {
                    control = new LiteralControl(String.Format("<span class=\"mainBodyBold\">{0} {1}</span><br/>", System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.DayNames[(int)sessionDate.DayOfWeek], sessionDate.ToShortDateString()));
                    row.Cells[0].Controls.Add(control);
                }
                control = new LiteralControl(String.Format("<span class=\"upcomingContent\"><a href=\"{0}catalog/session.aspx?session_id={1}\" class=\"upcomingLink\">{2}</a><br />{3}, {4}<br/></span>", ((region4.escWeb.BasePage)this.Page).PathToRoot, pair.Value.SessionID, pair.Value.Title, pair.Value.SiteName, pair.Value.RoomName));
                row.Cells[0].Controls.Add(control);

                itemsAdded++;
                currentDate = sessionDate;
            }

            if (itemsAdded == 0)
                row.Cells[0].Controls.Add(new LiteralControl(String.Format("<span class=\"upcomingContent\">There are no upcoming {0}</span>", region4.escWeb.SiteVariables.ObjectProvider.SessionPluralName)));

            //row = new HtmlTableRow();
            //row.Cells.Add(new HtmlTableCell());
            //result.Rows.Add(row);
            //HtmlAnchor a = new HtmlAnchor();
            //a.HRef = "~/catalog/calendar.aspx";
            //a.InnerHtml = String.Format("<nobr>more {0}...</nobr>", escWeb.SiteVariables.ObjectProvider.SessionPluralName);
            //row.Cells[0].Controls.Add(a);
            //a.Attributes.Add("class", "upcomingSessionFooter");

            return result;
        }

    }
}
