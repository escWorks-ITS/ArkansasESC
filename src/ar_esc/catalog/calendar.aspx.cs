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
using System.Data.SqlClient;
using region4.WebControls;

public partial class catalog_calendar : region4.escWeb.BasePages.Catalog.calendar_aspx
{
    protected string date = string.Empty;
    protected string mode = string.Empty;
    protected override void AssignControls()
    {
        //Calendar Control
        base._calendar = cal1;
    }

    protected override void calendar_LoadCalendarEvents(object sender, EventArgs e)
    {
        region4.WebControls.Calendar calendar = sender as region4.WebControls.Calendar;
        string location = LegacyCode.Strings.GetSafeString("location", LegacyCode.Strings.StringType.QueryString, "");

        if (location == "" && ConfigurationManager.AppSettings["CustomerSiteId"] == "ar_ade")
            location = "12861";
       
        if (this.CurrentUser.UserID != 0 && location.Length==0 && !IsPostBack)
        {
            base._calendar.Location = this.CurrentUser.Location.Site.Organization.OrganizationID.ToString();          
        }
        else
        {
            if (ConfigurationManager.AppSettings["CustomerSiteId"] == "ar_ade")
            {
                base._calendar.Location = "12861";
                Labelcoop.Visible = false;
                ddlcooperative.Visible = false;

                LabelcoopMobile.Visible = false;
                ddlcooperativeMobile.Visible = false;

                Labeldistrict.Visible = false;
                ddldistrict.Visible = false;

                LabeldistrictMobile.Visible = false;
                ddldistrictMobile.Visible = false;

            }
        }
        if (calendar == null)
            throw new Exception("expected a calendar but didn't get one");
        calendar.ClearCalendar();

        foreach (escWeb.ar_esc.ObjectModel.SessionInfo session in region4.ObjectModel.SessionInfoList.LoadCalendarEvents(calendar.StartMonth))
        {
            if (session.DisplayOnWeb)
            {
                if (_calendar.Location == "")
                {
                    if(session.IsEsc || (session as escWeb.ar_esc.ObjectModel.SessionInfo).IsSTEM)
                        calendar.AddItem(session);
                }
                else if (_calendar.Location == "12861") // ADE
                    calendar.AddItem(session);

                else if (_calendar.Location == "99")  //All Cooperative
                {

                    if (session.IsEsc && !(session as escWeb.ar_esc.ObjectModel.SessionInfo).IsSTEM)
                        calendar.AddItem(session);
                }
                else if (_calendar.Location == "100") //All Districts
                {
                    if (!session.IsEsc && session.OwnerOrgId != 12861)
                        calendar.AddItem(session);
                }
                else if ((session.SiteID == Convert.ToInt32(_calendar.Location) && !session.IsEsc)
                        || (session.OrganizationID == Convert.ToInt32(_calendar.Location) && session.IsEsc))
                {
                    calendar.AddItem(session);
                }
                else if ((session.OrganizationID == Convert.ToInt32(_calendar.Location) && session.IsSTEM))
                    calendar.AddItem(session);

                else if (_calendar.Location == "999") // all stems
                    if ((session as escWeb.ar_esc.ObjectModel.SessionInfo).IsSTEM)
                        calendar.AddItem(session);
                 
            }
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        string location = LegacyCode.Strings.GetSafeString("location", LegacyCode.Strings.StringType.QueryString, "");
        string isCoop = LegacyCode.Strings.GetSafeString("iscooperative", LegacyCode.Strings.StringType.QueryString, "");
        date = LegacyCode.Strings.GetSafeString("date", LegacyCode.Strings.StringType.QueryString, DateTime.Today.Month.ToString() + "/1/" + DateTime.Today.Year.ToString());
        mode = LegacyCode.Strings.GetSafeString("mode", LegacyCode.Strings.StringType.QueryString, "");
        //cal2 = cal1;

        string selectedCooperative = string.Empty;
        if (this.CurrentUser.UserID != 0 && location.Length ==0)
        {
            selectedCooperative = this.CurrentUser.Location.Site.Organization.OrganizationID.ToString();
            if(!IsPostBack)
            { 
                GetCooperatives(ddlcooperative, true, Convert.ToInt32(selectedCooperative));
                GetCooperatives(ddlcooperativeMobile, true, Convert.ToInt32(selectedCooperative));
            }
            else
            { 
                GetCooperatives(ddlcooperative, true, Convert.ToInt32(ddlcooperative.SelectedValue == "" ? "0" : ddlcooperative.SelectedValue));
                GetCooperatives(ddlcooperativeMobile, true, Convert.ToInt32(ddlcooperativeMobile.SelectedValue == "" ? "0" : ddlcooperativeMobile.SelectedValue));
            }
        }

        else
        {
            GetCooperatives(ddlcooperative, true, ddlcooperative.SelectedValue == "" ? 0 : Convert.ToInt32(ddlcooperative.SelectedValue));
            GetCooperatives(ddlcooperativeMobile, true, ddlcooperativeMobile.SelectedValue == "" ? 0 : Convert.ToInt32(ddlcooperativeMobile.SelectedValue));
        }
        GetSite(ddldistrict, ddldistrict.SelectedValue == "" ? 0 : Convert.ToInt32(ddldistrict.SelectedValue));
        GetSite(ddldistrictMobile, ddldistrictMobile.SelectedValue == "" ? 0 : Convert.ToInt32(ddldistrictMobile.SelectedValue));

        if (!IsPostBack)
        {
            if (location != "")
            {
                if (isCoop == "1")
                {
                    ddldistrict.SelectedIndex = 0;
                    ddlcooperative.SelectedValue = location;

                    ddldistrictMobile.SelectedIndex = 0;
                    ddlcooperativeMobile.SelectedValue = location;
                }
                else if (isCoop == "0")
                {
                    
                    ddldistrict.SelectedValue = location;
                    ddlcooperative.SelectedIndex = 0;

                    ddldistrictMobile.SelectedValue = location;
                    ddlcooperativeMobile.SelectedIndex = 0;
                }
                else
                {
                    if (ddlcooperative.Items.FindByValue(location) != null)
                        ddlcooperative.SelectedValue = location;
                    else
                        ddldistrict.SelectedValue = location;

                    if (ddlcooperativeMobile.Items.FindByValue(location) != null)
                        ddlcooperativeMobile.SelectedValue = location;
                    else
                        ddldistrictMobile.SelectedValue = location;
                }

                if (location == "999" || ConfigurationManager.AppSettings["stemOrgId"].Contains(location))
                { 
                    ddldistrict.Enabled = false;
                    ddldistrictMobile.Enabled = false;
                }
                else
                { 
                    ddldistrict.Enabled = true;
                    ddldistrictMobile.Enabled = true;
                }
            }
        }
    }
   
    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {

        HttpContext.Current.Response.Redirect("calendar.aspx?location=" + ddldistrict.SelectedValue + "&iscooperative=0" + "&date=" + date);
    }
    protected void ddldistrictMobile_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["location"] = ddldistrictMobile.SelectedValue;
        Session["iscoop"] = "0";
        HttpContext.Current.Response.Redirect("calendar.aspx?location=" + ddldistrictMobile.SelectedValue + "&iscooperative=0" + "&date=" + date);
    }

    protected void ddlcooperative_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        HttpContext.Current.Response.Redirect("calendar.aspx?location=" + ddlcooperative.SelectedValue + "&iscooperative=1" + "&date=" + date);
    }
    protected void ddlcooperativeMobile_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["location"] = ddlcooperativeMobile.SelectedValue;
        Session["iscoop"] = "1";
        HttpContext.Current.Response.Redirect("calendar.aspx?location=" + ddlcooperativeMobile.SelectedValue + "&iscooperative=1" + "&date=" + date);
    }
    public void GetSite(DropDownList list,int site_id)
    {
        list.Items.Clear();
        list.Items.Add(new ListItem("Select District...", ""));
        list.Items.Add(new ListItem("All Districts", "100")); //All Districts
        using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
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
                region4.ErrorReporter.ReportError(ex, System.Web.HttpContext.Current);
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

    public void GetCooperatives(DropDownList list, bool HaveSessions, int CooperativeId)
    {
        list.Items.Clear();
        list.Items.Add(new ListItem("All", ""));
        list.Items.Add(new ListItem("All Cooperatives", "99"));
        ListItemCollection stemList =  new ListItemCollection();

        using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
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
                        if (!(bool)reader["isSTEM"])
                            list.Items.Add(new ListItem(reader["display"].ToString(), reader["key"].ToString()));
                        else
                            stemList.Add(new ListItem(reader["display"].ToString(), reader["key"].ToString()));
                    }

                    list.Items.Add(new ListItem("All STEMS", "999"));

                    if (stemList.Count > 0)
                    {
                        
                        foreach (ListItem i in stemList)
                            list.Items.Add(i);
                    }
                    reader.Close();
                    reader.Dispose();
                }

            }
            catch (Exception ex)
            {
                region4.ErrorReporter.ReportError(ex, System.Web.HttpContext.Current);
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
}
