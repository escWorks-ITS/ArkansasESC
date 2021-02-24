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
using System.Collections.Generic;
using System.Text.RegularExpressions;

public partial class catalog_calendar : region4.escWeb.BasePages.Catalog.calendar_aspx
{
    protected string date = string.Empty;
    protected string mode = string.Empty;
    protected override void AssignControls()
    {
        //Calendar Control
        base._calendar = cal1;
    }

    static Regex MobileCheck = new Regex(@"android|(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);
    static Regex MobileVersionCheck = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);
    public static bool IsMobileBrowser()
    {
        if (HttpContext.Current.Request != null && HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"] != null)
        {
            var u = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"].ToString();

            if (u.Length < 4)
                return false;

            if (MobileCheck.IsMatch(u) || MobileVersionCheck.IsMatch(u.Substring(0, 4)))
                return true;
        }

        return false;
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        if (IsMobileBrowser())
        {
            mobiledropdown.Visible = true;
            mobileCal.Visible = true;
        }
        else
        {
            desktopIPaddropdown.Visible = true;
        }
    }
    protected override void calendar_LoadCalendarEvents(object sender, EventArgs e)
    {
        region4.WebControls.Calendar calendar = sender as region4.WebControls.Calendar;
        string location = LegacyCode.Strings.GetSafeString("location", LegacyCode.Strings.StringType.QueryString, "");

        if (location == "" && ConfigurationManager.AppSettings["CustomerSiteId"] == "ar_ade")
        { 
            location = "12861";
            Session["location"] = location;
        }

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
