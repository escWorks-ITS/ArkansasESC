using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using escWeb.ar_esc.ObjectModel;

namespace region4.escWeb.BasePages.Catalog
{
    public abstract class LocalCalendar : BasePage
    {
        protected WebControls.Calendar _calendar;
        protected ImageButton _nextButton;
        protected ImageButton _previousButton;
        protected ImageButton _setDateButton;

        protected DropDownList _monthList;
        protected DropDownList _yearList;
        protected DropDownList _campusList;
        protected DropDownList _cooperativelist;

        protected Label _calendarTitle;
        private int CooperativeId =-1 ;
        private int site_id = 0;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            AssignControls();
            _calendar.LoadCalendarEvents += new EventHandler(calendar_LoadCalendarEvents);
            _campusList.SelectedIndexChanged += new EventHandler(campusList_SelectedIndexChanged);
            _cooperativelist.SelectedIndexChanged += new EventHandler(cooperativeList_SelectedIndexChanged);
            
            //On the first page response set the calendar date to today.
            _calendar.StartDate = DateTime.Now;
        }

        protected override void OnPreLoad(EventArgs e)
        {
             site_id = Convert.ToInt32(LegacyCode.Strings.GetSafeString("campus", LegacyCode.Strings.StringType.QueryString, "0"));
            CooperativeId = Convert.ToInt32(LegacyCode.Strings.GetSafeString("cooperative", LegacyCode.Strings.StringType.QueryString, "0"));
            if (!IsPostBack)
            {
                _campusList.Items.Clear();
                _cooperativelist.Items.Clear();
                //PopulateRoomList(_campusList, site_id);
                GetCooperatives(_cooperativelist, true,CooperativeId);
                GetSite(_campusList,site_id);
            }
        }

       public void GetCooperatives(DropDownList list, bool HaveSessions, int CooperativeId)
        {
             list.Items.Clear();
             list.Items.Add(new ListItem("All Cooperatives", ""));
            using (SqlConnection conn = Common.DataConnection.DbConnection)
            {
                SqlCommand SQLCommand = conn.CreateCommand();
                SQLCommand.CommandText = "[p.catalog.cooperatives]";
                SQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                SQLCommand.Parameters.AddWithValue("@sessions", HaveSessions);
                SQLCommand.Parameters.AddWithValue("@cooperative_id", CooperativeId);

                try
                {
                    SQLCommand.Connection.Open();                   

                    using (SqlDataReader reader = SQLCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Items.Add(new ListItem(reader["display"].ToString(), reader["key"].ToString()));
                        }
                        reader.Close();
                        reader.Dispose();
                    }

                 }
                catch (Exception ex)
                {
                    ErrorReporter.ReportError(ex, System.Web.HttpContext.Current);
                }
                finally
                {
                    SQLCommand.Connection.Close();
                }
                if (CooperativeId > 0)
                {
                    list.SelectedIndex = list.Items.IndexOf(list.Items.FindByValue(CooperativeId.ToString()));
                }
                else
                {
                    list.SelectedIndex = 0;
                }
            }
        
        }

        public void GetSite(DropDownList list,int site_id)
        {
            list.Items.Clear();
            list.Items.Add(new ListItem("All Districts", ""));
            using (SqlConnection conn = Common.DataConnection.DbConnection)
            {
                SqlCommand SQLCommand = conn.CreateCommand();
                SQLCommand.CommandText = "[catalog.calander.site]";
                SQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                try
                 {
                     SQLCommand.Connection.Open();

                     using (SqlDataReader reader = SQLCommand.ExecuteReader())
                     {
                         while (reader.Read())
                         {
                             list.Items.Add(new ListItem(reader["display"].ToString(), reader["key"].ToString()));
                         }
                         reader.Close();
                         reader.Dispose();
                     }

                 }

                catch (Exception ex)
                {
                    ErrorReporter.ReportError(ex, System.Web.HttpContext.Current);
                }

                finally
                {
                    SQLCommand.Connection.Close();

                }


            }
            if (site_id > 0)
            {
                list.SelectedIndex = list.Items.IndexOf(list.Items.FindByValue(site_id.ToString()));
            }
            else
            {
                list.SelectedIndex = 0;
            }
        }

        void calendar_Click(object sender, EventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void campusList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["campusid"] = _campusList.SelectedValue;
            HttpContext.Current.Response.Redirect("calendar.aspx?campus=" +  _campusList.SelectedValue);
        }
        void cooperativeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["coopid"] = _cooperativelist.SelectedValue;
            HttpContext.Current.Response.Redirect("calendar.aspx?cooperative=" + _cooperativelist.SelectedValue);
        }

        //void calendar_LoadCalendarEvents(object sender, EventArgs e)
        //{
        //    region4.WebControls.Calendar calendar = sender as region4.WebControls.Calendar;

        //    if (calendar == null)
        //        throw new Exception("expected a calendar but didn't get one");
        //    calendar.ClearCalendar();

        //    site_id = Convert.ToInt32(LegacyCode.Strings.GetSafeString("campus", LegacyCode.Strings.StringType.QueryString, "0"));
        //    CooperativeId = Convert.ToInt32(LegacyCode.Strings.GetSafeString("cooperative", LegacyCode.Strings.StringType.QueryString, "0"));
        //    SessionInfoList sessionInfoList;
        //    if (site_id > 0)
        //    {
        //        sessionInfoList = SessionInfoList.LoadCalendarEvents(calendar.StartMonth, CooperativeId, site_id, 0);
        //    }
        //    else
        //    {
        //        sessionInfoList = SessionInfoList.LoadCalendarEvents(calendar.StartMonth, CooperativeId, site_id, 1);
        //    }
        //    foreach (SessionInfo session in sessionInfoList)
        //    {
        //        if (session.DisplayOnWeb)
        //            calendar.AddItem(session);
        //    }
        //}

        void calendar_LoadCalendarEvents(object sender, EventArgs e)
        {
            region4.WebControls.Calendar calendar = sender as region4.WebControls.Calendar;

            if (calendar == null)
                throw new Exception("expected a calendar but didn't get one");
            calendar.ClearCalendar();

            site_id = Convert.ToInt32(LegacyCode.Strings.GetSafeString("campus", LegacyCode.Strings.StringType.QueryString, "0"));
            CooperativeId = Convert.ToInt32(LegacyCode.Strings.GetSafeString("cooperative", LegacyCode.Strings.StringType.QueryString, "0"));
            if (site_id == 0 && Session["campusid"] != "")
            {
                site_id = Convert.ToInt32(Session["campusid"]);
            }
            if (CooperativeId == 0 && Session["coopid"] != "")
            {
                CooperativeId = Convert.ToInt32(Session["coopid"]);
            }
            region4.ObjectModel.SessionInfoList sessionInfoList = region4.ObjectModel.SessionInfoList.LoadCalendarEvents(calendar.StartMonth);
            foreach (SessionInfo session in sessionInfoList)
            {
                if (session.DisplayOnWeb)
                {
                    if ((site_id > 0 && session.SiteID == site_id) 
                        || (CooperativeId > 0 && session.OrganizationID == CooperativeId) 
                        || (site_id <= 0 && CooperativeId <= 0))
                    {
                        calendar.AddItem(session);
                    }
                }
            }
        }

        protected abstract void AssignControls();
    }
}