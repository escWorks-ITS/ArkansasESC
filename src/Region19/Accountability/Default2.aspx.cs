using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.SqlClient;
using Csla;

using Telerik.Web.UI;
using Csla.Validation;
using demo.BusinessObect.Accountability; 


public partial class Accountability_Default : System.Web.UI.Page
{
    private escWeb.tx_r19.ObjectModel.User user;
    private List<demo.BusinessObect.Accountability.Assistance> dailyList;
    private List<AssistanceDisplay> dailyListDisplay;
    private demo.BusinessObect.Accountability.Assistances myList;
    private demo.BusinessObect.Accountability.AssistancesDisplay myListDisplay;   
    private string date = string.Empty;
    private string strObjId = string.Empty;
    private string strDetail = string.Empty;
    private ConfigurationInfo ci;
    public string sid = string.Empty;
    public string url = string.Empty;
    public string report_time_sheet_id = string.Empty;
    public string report_summary_id = string.Empty;

    protected void Page_Init(object sender, EventArgs e)
    {
        //PopulateDropDownList(ddlRegion, "[p.Accountability.Location.Region.Load]", 0, "dropdownlsit_region", 60);
        PopulateDropDownList(ddlServiceLength, "[p.Accountability.DropdownLists.Load]", region4.escWeb.SiteVariables.AccountabilityTimeLength, "dropdownlsit_servicelength", 60);
        PopulateDropDownList(ddlTravelTime, "[p.Accountability.DropdownLists.Load]", region4.escWeb.SiteVariables.AccountabilityTimeLength, "dropdownlsit_traveltime", 60);
        PopulateDropDownList(ddlContactMethod, "[p.Accountability.DropdownLists.Load]", region4.escWeb.SiteVariables.AccountabilityContactMethod, "dropdownlsit_contactmethod", 60);
        PopulateDropDownList(ddlActivities, "[p.Accountability.DropdownLists.Load]", region4.escWeb.SiteVariables.AccountabilityActivity, "dropdownlsit_activities", 5);
        PopulateDropDownList(ddlTEC, "[p.Accountability.DropdownLists.Load]", region4.escWeb.SiteVariables.AccountabilityTEC, "dropdownlsit_tec", 60);

        PopulateDropDownList(AudienceList, "[p.Accountability.DropdownLists.Load]", region4.escWeb.SiteVariables.AccountabilityAudience, "dropdownlsit_audienceList", 5);
        PopulateCombBox(ddlClient);               

        if (Session["profile"] != null)
            user = (escWeb.tx_r19.ObjectModel.User)Session["profile"];
        litEmployeeName.Text = user.FirstName + " " + user.LastName;

        PopulateDropDownList(ddlFocus, "[p.Accountability.Focus.Load]", 0, "dropdownlsit_focus", 3);
        PopulateDropDownList(ddlBudgetCode, "[p.Accountability.BudgetCode.Load]", 0, "dropdownlsit_budgetcode", 3);

        sid = user.Sid.ToString();
        url = region4.escWeb.SiteVariables.escWorksReportServer;
        report_time_sheet_id = region4.escWeb.SiteVariables.AccountabilityTimeSheetReport.ToString();
        report_summary_id = region4.escWeb.SiteVariables.AccountabilitySimmaryReport.ToString();

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        date = LegacyCode.Strings.GetSafeString("date", LegacyCode.Strings.StringType.QueryString);
        strObjId = LegacyCode.Strings.GetSafeString("obj_id", LegacyCode.Strings.StringType.QueryString);
        strDetail = LegacyCode.Strings.GetSafeString("detail", LegacyCode.Strings.StringType.QueryString);

        if (!Page.IsPostBack && !Page.IsCallback)
        {
            if (strDetail == "")
                myListDisplay = demo.BusinessObect.Accountability.AssistancesDisplay.GetAssistancesDisplay(new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1), user.Sid);
            else
                myListDisplay = ((demo.BusinessObect.Accountability.AssistancesDisplay)Session["myListDisplay"]);

            Session["myListDisplay"] = myListDisplay;

            if (myListDisplay.Count == 0)
            {
                //no records
                btnCopy.Enabled = false;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
            }

            if (date != "" && strObjId != "")
            {
                dailyList = ((demo.BusinessObect.Accountability.Assistances)Session["myList"]).GetAssistancesByDateRange(Convert.ToDateTime(date), Convert.ToDateTime(date));
                Session["dailyList"] = dailyList;
                foreach (demo.BusinessObect.Accountability.Assistance a in dailyList)
                {
                    ((demo.BusinessObect.Accountability.Assistances)Session["myList"]).Index++;

                    if (a.ObjId == Convert.ToInt32(strObjId))
                    {
                        BindingData(a);
                        break;
                    }
                }
                if (dailyList.Count > 1) //Added 7-20-2012
                {
                    btnNext.Visible = true;
                    btnPrev.Visible = true;

                }
                else
                {
                    btnNext.Visible = false;
                    btnPrev.Visible = false;
                }
                pnlDetail.Visible = true;
                pnlReports.Visible = !pnlDetail.Visible;

                myList = (demo.BusinessObect.Accountability.Assistances)Session["myList"];

                litDayHours.Text = myList.GetHours(Convert.ToDateTime(date), Convert.ToDateTime(date)).ToString();
                litThisWeekHours.Text = ((demo.BusinessObect.Accountability.AssistancesDisplay)Session["myListDisplay"]).GetHours(Convert.ToDateTime(date).AddDays(7 - (int)Convert.ToDateTime(date).DayOfWeek).AddDays(-7), Convert.ToDateTime(date).AddDays(7 - (int)Convert.ToDateTime(date).DayOfWeek).AddDays(-1)).ToString();
                litDate.Text = "<b>" + Convert.ToDateTime(date).ToShortDateString() + "</b>";

                panelSpace.Visible = false;
            }
            else
            {
                btnNext.Visible = false;
                btnPrev.Visible = false;

                litDayHours.Text = myListDisplay.GetHours(DateTime.Today, DateTime.Today).ToString();
                litThisWeekHours.Text = myListDisplay.GetHours(DateTime.Today.AddDays(7 - (int)DateTime.Today.DayOfWeek).AddDays(-7), DateTime.Today.AddDays(7 - (int)DateTime.Today.DayOfWeek).AddDays(-1)).ToString();
                litDate.Text = "<b>" + DateTime.Today.ToShortDateString() + "</b>";
            }

        }


        if (date == "")
            calActivity.VisibleDate = DateTime.Today;
        else
            calActivity.VisibleDate = Convert.ToDateTime(date);

        litMessage.Text = string.Empty;

    }

    //Calendar Events

    protected void calActivity_DayRender(object sender, DayRenderEventArgs e)
    {
        if (Session["myListDisplay"] != null)
        {

            dailyListDisplay = ((AssistancesDisplay)Session["myListDisplay"]).GetAssistancesDisplayByDateRange(e.Day.Date, e.Day.Date);
            if (dailyListDisplay.Count > 0)
            {
                e.Cell.Text = "<a style=\"cursor:pointer;text-decoration: underline\" onClick=\"OpenWindow('" + e.Day.Date.ToShortDateString() + "');\">" + e.Day.Date.Day.ToString() + "</a>";
                e.Cell.BackColor = ((AssistancesDisplay)Session["myListDisplay"]).GetColor(e.Day.Date);
            }
            else
                e.Cell.Text = e.Day.Date.Day.ToString();
        }
        else
        {
            e.Cell.Text = e.Day.Date.Day.ToString();
        }

    }

    protected void calActivity_VisibleMonthChanged(object sender, System.Web.UI.WebControls.MonthChangedEventArgs e)
    {
        myListDisplay = demo.BusinessObect.Accountability.AssistancesDisplay.GetAssistancesDisplay(new DateTime(e.NewDate.Year, e.NewDate.Month, 1), new DateTime(e.NewDate.Year, e.NewDate.Month, 1).AddMonths(1).AddDays(-1), user.Sid);
        Session["myListDisplay"] = myListDisplay;
        ClearForm();
        panelSpace.Visible = true;
        pnlDetail.Visible = false;
    }

    protected void PopulateCombBox(RadComboBox combo)
    {
        DataTable clients = new DataTable();
        using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "[p.Accountability.Location.Client.Load_2]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using (SqlDataAdapter SqlDa = new SqlDataAdapter(cmd))
            {
                SqlDa.Fill(clients);

                foreach (DataRow row in clients.Rows)
                {
                    RadComboBoxItem item = new RadComboBoxItem(row["display"].ToString(), row["side_id"].ToString());
                    combo.Items.Add(item);
                }
            }
        }
    }

    protected void PopulateCombBox(RadComboBox combo, int key)
    {
        DataTable clients = new DataTable();
        using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "[p.Accountability.Location.Site.Load]";
            cmd.Parameters.AddWithValue("@id", key);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using (SqlDataAdapter SqlDa = new SqlDataAdapter(cmd))
            {
                SqlDa.Fill(clients);

                foreach (DataRow row in clients.Rows)
                {
                    RadComboBoxItem item = new RadComboBoxItem(row["display"].ToString(), row["key"].ToString());
                    combo.Items.Add(item);
                }
            }
        }
    }

    protected void ddlClient_ItemsRequested(object o, RadComboBoxItemsRequestedEventArgs e)
    {
        RadComboBox combo = (RadComboBox)o;
        combo.Items.Clear();

        DataTable clients = new DataTable();
        using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "[p.Accountability.Location.Client.Load]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@text", e.Text);
            using (SqlDataAdapter SqlDa = new SqlDataAdapter(cmd))
            {
                SqlDa.Fill(0, 50, clients);

                foreach (DataRow row in clients.Rows)
                {
                    RadComboBoxItem item = new RadComboBoxItem(row["display"].ToString(), row["side_id"].ToString());
                    combo.Items.Add(item);
                }
            }
        }
    }


    protected void ddlClient_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {

        if (ddlSite.Items.Count > 1)
            ddlSite.Items.Clear();

        if (ddlClient.SelectedValue == "")
        {
            ddlClient.SelectedIndex = -1;
            ddlClient.Text = string.Empty;
            litMessage.Text = "<font color=\"red\">Please select a client.</font>";

            RadScriptManager1.SetFocus(ddlClient.ClientID + "_Input");
            return;
        }


        PopulateCombBox(ddlSite, Convert.ToInt32(ddlClient.SelectedValue));

        //ddlRegion.SelectedValue = getRegionId(Convert.ToInt32(ddlClient.SelectedValue)).ToString();

        // set focus to ddlSit
        ddlSite.SelectedIndex = -1;
        ddlSite.Text = ddlSite.EmptyMessage;

        RadScriptManager1.SetFocus(ddlSite.ClientID + "_Input");

    }

    protected void ddlSite_SelectedIndexChanged(object o, EventArgs e)
    {
        // set focus to ddlActivities
        if (ddlSite.SelectedValue == "")
        {
            ddlSite.SelectedIndex = -1;
            ddlSite.Text = string.Empty;
            litMessage.Text = "<font color=\"red\">Please select a specific site.</font>";

            RadScriptManager1.SetFocus(ddlSite.ClientID + "_Input");
            return;
        }
        //ddlActivities.Focus();
    }

    protected void ddlActivities_SelectedIndexChanged(object o, EventArgs e)
    {
        if (ddlActivities.SelectedItem.Text.ToLower() == "leave")
        {
            litContactMethod.Visible = false;
            litBudgetCode.Visible = false;
            litTEC.Visible = false;
            litAudience.Visible = false;
            
        }
        else
        {
            litContactMethod.Visible = true;
            litBudgetCode.Visible = true;
            litTEC.Visible = true;
            litAudience.Visible = true;
            
        }

    }

    protected void PopulateDropDownList(DropDownList ddControl, string spname, int key, string cacheKey, int cacheMinutes)
    {
        using (SqlCommand SQLCommand = new SqlCommand(spname, region4.Common.DataConnection.DbConnection))
        {
            SQLCommand.CommandType = CommandType.StoredProcedure;
            if (spname == "[p.Accountability.BudgetCode.Load]")
                SQLCommand.Parameters.AddWithValue("@sid", user.Sid);
            SQLCommand.Parameters.AddWithValue("@id", key);
            try
            {
                SQLCommand.Connection.Open();
                SqlDataReader SQLdr = SQLCommand.ExecuteReader(CommandBehavior.CloseConnection);

                ddControl.Items.Add(new ListItem("Please select ...", "0"));

                while (SQLdr.Read())
                {
                    ListItem li = new ListItem();
                    li.Text = SQLdr["display"].ToString();
                    li.Value = SQLdr["key"].ToString();
                    li.Attributes.Add("title", li.Text);

                    ddControl.Items.Add(li);
                }
                ddControl.Attributes.Add("onmouseover", "this.title=this.options[this.selectedIndex].title");
                HttpContext.Current.Cache.Add(cacheKey, ddControl.Items, null, DateTime.Now.AddMinutes(cacheMinutes), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            catch (Exception EX)
            {
                System.Web.HttpContext.Current.Response.Write(EX.Message);
            }
            finally
            {
                if (SQLCommand.Connection.State != ConnectionState.Closed)
                    SQLCommand.Connection.Close();
            }
        }
    }

    protected void PopulateDropDownList(DropDownList ddControl, ListItemCollection cachedListItems)
    {
        foreach (ListItem itm in cachedListItems)
            ddControl.Items.Add(itm);
    }

    protected void BindingData(demo.BusinessObect.Accountability.Assistance assistance)
    {
        if (!assistance.isEditable())
        {
            disableFormControls();
        }

        txtDate.Text = assistance.Service_Date.ToShortDateString();
        ddlServiceLength.SelectedValue = assistance.Service_Hour_Id.ToString();
        ddlContactMethod.SelectedValue = assistance.Contact_Id.ToString();
        PopulateCombBox(ddlSite, assistance.Site_Id);

        ddlClient.SelectedIndex = -1;
        ddlClient.Text = string.Empty;
        ddlSite.SelectedIndex = -1;
        ddlSite.Text = string.Empty;
        //ddlRegion.SelectedIndex = -1;

        ddlActivities.SelectedValue = assistance.Activity_Id.ToString();
        ddlTravelTime.SelectedValue = assistance.Travel_Hour_Id.ToString();
        ddlFocus.SelectedValue = assistance.Focus_Id.ToString();
        ddlBudgetCode.SelectedValue = assistance.Budget_Id.ToString();
        ddlTEC.SelectedValue = assistance.TEC_Purpose_Id.ToString();
        txtComments.Text = assistance.Comments;

        AudienceListBox.Items.Clear();
        if (assistance.LocationAudiences.Count > 0)
        {
            for (int i = 0; i < assistance.LocationAudiences.Count; i++)
            {
                ListItem itm = new ListItem(assistance.LocationAudiences[i].OrganizationName + " | " + assistance.LocationAudiences[i].SiteName + " | " + assistance.LocationAudiences[i].RoomName + " | " + assistance.LocationAudiences[i].AudienceName + " | " + assistance.LocationAudiences[i].Amount.ToString(),
                    assistance.LocationAudiences[i].OrgId.ToString() + "|" + assistance.LocationAudiences[i].SiteId.ToString() + "|" + assistance.LocationAudiences[i].RoomId.ToString() + "|" + assistance.LocationAudiences[i].AudienceId.ToString() + "|" + assistance.LocationAudiences[i].Amount.ToString());

                AudienceListBox.Items.Add(itm);
            }
        }

        //lbLocationList.Items.Clear();

        //if (assistance.Organizations.Count > 0)
        //{
        //    for (int i = 0; i < assistance.Organizations.Count; i++)
        //    {
        //        ListItem itm = new ListItem(assistance.Organizations[i].OrganizationName + " | " + assistance.Sites[i].SiteName +
        //            " | " + (assistance.Rooms.Count == 0 ? "" : assistance.Rooms[i].RoomName), assistance.Organizations[i].OrgId.ToString() + "|" + assistance.Sites[i].SiteId.ToString() +
        //            "|" + (assistance.Rooms.Count == 0 ? "-1" : assistance.Rooms[i].RoomId.ToString()));

        //        lbLocationList.Items.Add(itm);
        //    }
        //}

        txtObjID.Text = assistance.ObjId.ToString();

        if (assistance.Activity_Name.ToLower() == "leave")
        {
            litContactMethod.Visible = false;
            litBudgetCode.Visible = false;
            litTEC.Visible = false;
            litAudience.Visible = false;
        }
        else
        {
            litContactMethod.Visible = true;
            litBudgetCode.Visible = true;
            litTEC.Visible = true;
            litAudience.Visible = true;
        }
    }

    protected void ClearForm()
    {
        txtDate.Text = string.Empty;
        ddlServiceLength.SelectedIndex = -1;
        ddlClient.SelectedIndex = -1;
        ddlContactMethod.SelectedIndex = -1;
        ddlClient.Text = ddlClient.EmptyMessage;
        ddlSite.SelectedIndex = -1;
        ddlSite.Text = ddlSite.EmptyMessage;
        //ddlRegion.SelectedIndex = -1;
        ddlActivities.SelectedIndex = -1;
        ddlTravelTime.SelectedIndex = -1;
        ddlFocus.SelectedIndex = -1;
        ddlBudgetCode.SelectedIndex = -1;
        ddlTEC.SelectedIndex = -1;

        AudienceListBox.Items.Clear();
        AudienceValue.Text = string.Empty;
        AudienceList.SelectedIndex = -1;

        txtComments.Text = string.Empty;
        txtObjID.Text = string.Empty; //Added by VM 7-25-2012
        litMessage.Text = string.Empty;
        //lbLocationList.Items.Clear();
    }

    protected void SetupMultiValueTextBoxControl(ref ListBox listbox, ref DropDownList dropdownlist, ref HtmlInputHidden input, string value)
    {

        listbox.Items.Clear();

        string inputValue = string.Empty;

        foreach (string item in value.Split(','))
        {
            try
            {
                if (item != string.Empty)
                {
                    string[] itm = item.Split(':');
                    ListItem li = dropdownlist.Items.FindByValue(itm[0].ToString());
                    if (li != null)
                    {
                        if (inputValue.Length == 0)
                        {
                            inputValue = item;
                        }
                        else
                        {
                            inputValue += "," + item;
                        }

                        ListItem newItem = new ListItem(li.Text + " | " + itm[1], li.Value + ":" + itm[1]);
                        listbox.Items.Add(newItem);
                    }
                }
            }
            catch
            {
            }
        }

        input.Value = inputValue;
    }

    //protected void lnkLogOut_Click(object sender, EventArgs e)
    //{
    //    escWorks.BusinessObjects.Region13UserLogIn.Logout();
    //    if (Session["user"] != null) { Session.Remove("user"); }
    //    Response.Redirect("security/signin.aspx");
    //}

    protected void lnkChangePassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("shoebox/account/password.aspx");
    }

    protected void btnNext_Click(object sender, ImageClickEventArgs e)
    {

        BindingData((demo.BusinessObect.Accountability.Assistance)((demo.BusinessObect.Accountability.Assistances)Session["myList"]).MoveNext((List<demo.BusinessObect.Accountability.Assistance>)Session["dailyList"]));

        if (((demo.BusinessObect.Accountability.Assistances)Session["myList"]).IsLastItem)
        {
            btnNext.Visible = false;
            if (!btnPrev.Visible)
                btnPrev.Visible = true;
        }
        else
        {
            if (!btnPrev.Visible)
                btnPrev.Visible = true;
        }
    }

    protected void btnPrev_Click(object sender, ImageClickEventArgs e)
    {
        BindingData(((demo.BusinessObect.Accountability.Assistance)((demo.BusinessObect.Accountability.Assistances)Session["myList"]).MovePrev((List<demo.BusinessObect.Accountability.Assistance>)Session["dailyList"])));

        if (((demo.BusinessObect.Accountability.Assistances)Session["myList"]).IsFirstItem)
        {
            btnPrev.Visible = false;
            if (!btnNext.Visible)
                btnNext.Visible = true;
        }
        else
        {
            if (!btnNext.Visible)
                btnNext.Visible = true;
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        ClearForm();
        enableFormControls();
        pnlDetail.Visible = true;
        pnlReports.Visible = !pnlDetail.Visible;
        btnCopy.Visible = false;
        btnDelete.Visible = false;
        btnNext.Visible = false;
        btnPrev.Visible = false;

        btnNew.Visible = false; //Added 6-25-2012
        btnCancel.Visible = true; //Added 6-25-2012

        if (!btnSave.Enabled) //Added 7-14-2012
            btnSave.Enabled = true;

        demo.BusinessObect.Accountability.Assistances assistanceList = (demo.BusinessObect.Accountability.Assistances)Session["myList"];
        if (assistanceList != null)
        {
            assistanceList.Action = demo.BusinessObect.Accountability.Assistances.ActionType.New;
            Session["myList"] = assistanceList;
        }

        txtDate.Text = DateTime.Today.ToShortDateString();
        if (user.Focus_Id.ToString() == "0") // if no focus, then select the first item 
            ddlFocus.SelectedIndex = 1;
        else
            ddlFocus.SelectedValue = user.Focus_Id.ToString();

        panelSpace.Visible = false;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string script = string.Empty;

        if (strObjId == "" && txtObjID.Text == string.Empty)
        {
            script = "<script language='javascript' ID='NeedId'>alert('Please select a record to delete.')</script>";
            ScriptManager.RegisterStartupScript((Page)HttpContext.Current.Handler, typeof(Page), "NeedId", script, false);
            return;
        }


        demo.BusinessObect.Accountability.Assistances assistanceList = (demo.BusinessObect.Accountability.Assistances)Session["myList"];
        assistanceList.Action = demo.BusinessObect.Accountability.Assistances.ActionType.Delete;
        demo.BusinessObect.Accountability.Assistance a = assistanceList.GetAssistanceByObjId(Convert.ToInt32(txtObjID.Text));

        if (!a.isEditable())
        {
            ShowError("The closing date has passed, you cannot delete an entry.");
            btnCancel_Click(this, null);
            return;
        }

        dailyList = assistanceList.Delete(Convert.ToInt32(txtObjID.Text), Convert.ToDateTime(date));
        assistanceList.Save();
        if (dailyList.Count <= 1) //Modified by VM 7-20-2012
        {
            if (dailyList.Count == 1)
            {
                BindingData(dailyList[0]);
                pnlDetail.Visible = true;
            }
            else
                pnlDetail.Visible = false;

            pnlReports.Visible = !pnlDetail.Visible;

            btnNext.Visible = false;
            btnPrev.Visible = false;
        }
        else
        {
            Session["dailyList"] = dailyList;
            ClearForm();
            BindingData(dailyList[0]);

            btnNext.Visible = true;
            btnPrev.Visible = false;
        }

        Session["myList"] = assistanceList;

        myListDisplay = demo.BusinessObect.Accountability.AssistancesDisplay.GetAssistancesDisplay(new DateTime(a.Service_Date.Year, a.Service_Date.Month, 1), new DateTime(a.Service_Date.Year, a.Service_Date.Month, 1).AddMonths(1).AddDays(-1), user.Sid);
        Session["myListDisplay"] = myListDisplay;

        litMessage.Text = "<font color=\"green\">The record has been deleted successfully.</font>";

        litDayHours.Text = ((demo.BusinessObect.Accountability.Assistances)Session["myList"]).GetHours(a.Service_Date, a.Service_Date).ToString();
        litThisWeekHours.Text = ((demo.BusinessObect.Accountability.AssistancesDisplay)Session["myListDisplay"]).GetHours(Convert.ToDateTime(date).AddDays(7 - (int)Convert.ToDateTime(date).DayOfWeek).AddDays(-7), Convert.ToDateTime(date).AddDays(7 - (int)Convert.ToDateTime(date).DayOfWeek).AddDays(-1)).ToString();

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Session["myList"] != null)
        {
            if (((demo.BusinessObect.Accountability.Assistances)Session["myList"]).Action == demo.BusinessObect.Accountability.Assistances.ActionType.New)
            {
                ClearForm();
                ((demo.BusinessObect.Accountability.Assistances)Session["myList"]).Action = demo.BusinessObect.Accountability.Assistances.ActionType.None;
                Session["myList"] = ((demo.BusinessObect.Accountability.Assistances)Session["myList"]);

                btnCopy.Visible = true;
                btnDelete.Visible = true;
                btnNew.Visible = true; //Added 6-25-2012
                btnCancel.Visible = false; //Added 6-25-2012
                pnlDetail.Visible = false;
                pnlReports.Visible = !pnlDetail.Visible;
            }
            else
            {
                if (Session["dailyList"] != null)
                {
                    foreach (demo.BusinessObect.Accountability.Assistance a in (List<demo.BusinessObect.Accountability.Assistance>)Session["dailyList"])
                    {
                        if (a.ObjId == (Convert.ToInt32(strObjId)))
                            BindingData(a);
                    }

                    if (((List<Assistance>)Session["dailyList"]).Count > 1) // Added 7-20-2012
                    {
                        btnNext.Visible = true;
                        btnPrev.Visible = true;
                    }
                    else
                    {
                        btnNext.Visible = false;
                        btnPrev.Visible = false;
                    }

                    btnNew.Visible = true;
                    btnDelete.Visible = true;
                    btnCopy.Visible = true;
                }

            }
        }
        else
        {
            btnNew.Visible = true;
            btnCopy.Visible = true;
            btnDelete.Visible = true;
            btnSave.Enabled = false;
        }

        btnCancel.Visible = false; //Added on 6-25-2012
    }

    protected void btnCopy_Click(object sender, EventArgs e)
    {
        string script = string.Empty;

        if (strObjId == "")
        {
            script = "<script language='javascript' ID='NeedId'>alert('Please select a record to copy.')</script>";
            ScriptManager.RegisterStartupScript((Page)HttpContext.Current.Handler, typeof(Page), "NeedId", script, false);
            return;
        }
        else
        {
            enableFormControls();
            btnDelete.Visible = false;
            btnNew.Visible = false;
            btnNext.Visible = false;
            btnPrev.Visible = false;
            btnCopy.Visible = false; // Added 6-25-2012
            btnCancel.Visible = true; // Added 6-25-2012

            demo.BusinessObect.Accountability.Assistances assistanceList = (demo.BusinessObect.Accountability.Assistances)Session["myList"];
            assistanceList.Action = demo.BusinessObect.Accountability.Assistances.ActionType.Copy;
            Session["myList"] = assistanceList;
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        demo.BusinessObect.Accountability.Assistances assistanceList = (demo.BusinessObect.Accountability.Assistances)Session["myList"];
        if (assistanceList == null) // Added 7-14-2012 If no records
        {
            assistanceList = demo.BusinessObect.Accountability.Assistances.CreateNew();
            assistanceList.Action = demo.BusinessObect.Accountability.Assistances.ActionType.New;
        }

        string script = string.Empty;

        if (DateTime.Today < (txtDate.Text == "" ? DateTime.MinValue : Convert.ToDateTime(txtDate.Text)))
        {
            ShowError("You could not insert an entry.");
            btnCancel_Click(this, null);
            return;
        }

        if (assistanceList.Action == demo.BusinessObect.Accountability.Assistances.ActionType.New || assistanceList.Action == demo.BusinessObect.Accountability.Assistances.ActionType.Copy) //Add a new activity
        {
            demo.BusinessObect.Accountability.Assistance a = demo.BusinessObect.Accountability.Assistance.CreateNew();
            a.Service_Date = txtDate.Text == "" ? DateTime.MinValue : Convert.ToDateTime(txtDate.Text);
            if (!a.isEditable())
            {
                ShowError("The closing date has passed or a closing date has not been set for the current month, you cannot create an entry.");
                txtDate.Text = string.Empty;
                return;
            }
            a.Sid = user.Sid;
            a.User_Id = user.UserID;
            a.Room_Id = -1;
            a.Site_Id = -1;
            //region4.ObjectModel.Site s = region4.ObjectModel.ObjectProvider.ReturnSite(a.Site_Id);
            a.SiteType_Id = 0; // s.SiteTypeID;
            a.Org_Id = -1;
            a.Focus_Id = Convert.ToInt32(ddlFocus.SelectedValue);
            a.Team_Id = user.Team_Id;
            a.Department_Id = user.Department_Id;
            a.Division_Id = user.Division_Id;
            a.Service_Hour_Id = Convert.ToInt32(ddlServiceLength.SelectedValue);
            a.Service_Hour_Amount = a.GetHours(a.Service_Hour_Id);
            a.Contact_Id = Convert.ToInt32(ddlContactMethod.SelectedValue);
            a.Activity_Id = Convert.ToInt32(ddlActivities.SelectedValue);
            a.Activity_Name = ddlActivities.SelectedItem.Text;
            a.Budget_Id = Convert.ToInt32(ddlBudgetCode.SelectedValue);
            a.Travel_Hour_Id = Convert.ToInt32(ddlTravelTime.SelectedValue);
            a.Travel_Hour_Amount = a.GetHours(a.Travel_Hour_Id);
            a.Cross_Divisional_Focus = false;
            a.TEC_Purpose_Id = Convert.ToInt32(ddlTEC.SelectedValue);
            a.ESC_Strand_Id = -1; //Convert.ToInt32(ddlESC.SelectedValue);
            a.ESC_U_Competency_Id = 0; //Convert.ToInt32(ddlCompetencies.SelectedValue);
            a.ECampus = string.Empty; //txtECampus.Text.ToString();
            a.Manager_Sid = Guid.Empty; //user.Manager_Sid;
            a.Comments = txtComments.Text;

            //get locations and audiences
            foreach (ListItem item in AudienceListBox.Items) //Added by VM 9-18-2014
            {
                string[] itm_value = item.Value.Split('|');
                string[] itm_text = item.Text.Split('|');

                LocationAudience la = LocationAudience.CreateNew();
                la.ObjId = a.ObjId;
                la.OrgId = itm_value[0] == "" ? 0 : Convert.ToInt32(itm_value[0]);
                la.OrganizationName = itm_text[0].ToString();
                la.SiteId = itm_value[1] == "" ? 0 : Convert.ToInt32(itm_value[1]);
                la.SiteName = itm_text[1].ToString();
                la.RoomId = itm_value[2] == "" ? 0 : Convert.ToInt32(itm_value[2]);
                la.RoomName = itm_text[2].ToString();
                la.AudienceId = itm_value[3] == "" ? 0 : Convert.ToInt32(itm_value[3]);
                la.AudienceName = itm_text[3].ToString();
                la.Amount = itm_value[4] == "" ? 0 : Convert.ToInt32(itm_value[4]);

                a.LocationAudiences.AddNew(la);
            }

            
            a.CallCheckRules(a);
            if (a.BrokenRulesCollection.Count > 0)
            {
                System.Text.StringBuilder message = new System.Text.StringBuilder();

                foreach (Csla.Validation.BrokenRule rule in a.BrokenRulesCollection)
                    message.AppendFormat(@"{0}\n\r", rule.Description);

                ShowError(message.ToString());

                return;

            }
            else
            {
                ClearForm();

                dailyList = assistanceList.AddNew(a, a.Service_Date);

                assistanceList.Save();
                assistanceList = demo.BusinessObect.Accountability.Assistances.GetAssistances(a.Service_Date, a.Service_Date, user.Sid);
                dailyList = assistanceList.GetAssistancesByDateRange(a.Service_Date, a.Service_Date);
                myListDisplay = demo.BusinessObect.Accountability.AssistancesDisplay.GetAssistancesDisplay(new DateTime(a.Service_Date.Year, a.Service_Date.Month, 1), new DateTime(a.Service_Date.Year, a.Service_Date.Month, 1).AddMonths(1).AddDays(-1), user.Sid);
                if (((demo.BusinessObect.Accountability.AssistancesDisplay)Session["myListDisplay"]).Count > 0)
                {
                    if (((demo.BusinessObect.Accountability.AssistancesDisplay)Session["myListDisplay"])[0].Service_Date.Month == a.Service_Date.Month)
                        Session["myListDisplay"] = myListDisplay;
                }

                Session["myList"] = assistanceList;
                Session["dailyList"] = dailyList;

                BindingData(dailyList[dailyList.Count - 1]);
                assistanceList.Index = dailyList.Count - 1;

                txtObjID.Text = dailyList[dailyList.Count - 1].ObjId.ToString();

                if (dailyList.Count > 1) //Added by VM 7-20-2012
                {
                    btnNext.Visible = true;
                    btnPrev.Visible = true;
                }
                else
                {
                    btnNext.Visible = false;
                    btnPrev.Visible = false;
                }

                if (!btnDelete.Enabled)
                    btnDelete.Enabled = true;

                btnDelete.Visible = true;


                /*
                 * Added on 6-25-2012
                 */
                btnNew.Visible = true;

                if (!btnCopy.Enabled)
                    btnCopy.Enabled = true;

                btnCopy.Visible = true;
                btnCancel.Visible = false;

                litMessage.Text = "<font color=\"green\">The record has been added successfully.</font>";
                assistanceList.Action = demo.BusinessObect.Accountability.Assistances.ActionType.Edit;


            }

            litDayHours.Text = ((demo.BusinessObect.Accountability.Assistances)Session["myList"]).GetHours(a.Service_Date, a.Service_Date).ToString();
            litThisWeekHours.Text = myListDisplay.GetHours(Convert.ToDateTime(a.Service_Date).AddDays(7 - (int)Convert.ToDateTime(a.Service_Date).DayOfWeek).AddDays(-7), Convert.ToDateTime(a.Service_Date).AddDays(7 - (int)Convert.ToDateTime(a.Service_Date).DayOfWeek).AddDays(-1)).ToString();
            litDate.Text = "<b>" + a.Service_Date.ToShortDateString() + "</b>";

        }
        else if (assistanceList.Action != demo.BusinessObect.Accountability.Assistances.ActionType.Delete) // edit
        {
            int currPos;
            if (strObjId == "" && txtObjID.Text == string.Empty)
            {
                script = "<script language='javascript' ID='NeedId'>alert('Please select a record to update.')</script>";
                ScriptManager.RegisterStartupScript((Page)HttpContext.Current.Handler, typeof(Page), "NeedId", script, false);
                return;
            }

            demo.BusinessObect.Accountability.Assistance a = assistanceList.GetAssistanceByObjId(Convert.ToInt32(txtObjID.Text));
            if (a.ObjId == Convert.ToInt32(txtObjID.Text))
            {
                a.Service_Date = Convert.ToDateTime(txtDate.Text);
                if (!a.isEditable())
                {
                    ShowError("The closing date has passed, you cannot update an entry.");
                    btnCancel_Click(this, null);
                    return;
                }

                a.Sid = user.Sid;
                a.User_Id = user.UserID;

                a.Room_Id = -1;
                a.Site_Id = -1;
                //region4.ObjectModel.Site s = region4.ObjectModel.ObjectProvider.ReturnSite(a.Site_Id);
                a.SiteType_Id = 0; // s.SiteTypeID;

                a.Org_Id = -1;
                a.Focus_Id = Convert.ToInt32(ddlFocus.SelectedValue);
                a.Team_Id = user.Team_Id;
                a.Department_Id = user.Department_Id;
                a.Division_Id = user.Division_Id;
                a.Service_Hour_Id = Convert.ToInt32(ddlServiceLength.SelectedValue);
                a.Service_Hour_Amount = a.GetHours(a.Service_Hour_Id);
                a.Contact_Id = Convert.ToInt32(ddlContactMethod.SelectedValue);
                a.Activity_Id = Convert.ToInt32(ddlActivities.SelectedValue);
                a.Activity_Name = ddlActivities.SelectedItem.Text;
                a.Budget_Id = Convert.ToInt32(ddlBudgetCode.SelectedValue);
                a.Travel_Hour_Id = Convert.ToInt32(ddlTravelTime.SelectedValue);
                a.Travel_Hour_Amount = a.GetHours(a.Travel_Hour_Id);

                a.Cross_Divisional_Focus = false;
                a.TEC_Purpose_Id = Convert.ToInt32(ddlTEC.SelectedValue);
                a.ESC_Strand_Id = -1; // Convert.ToInt32(ddlESC.SelectedValue);
                a.ESC_U_Competency_Id = 0; //Convert.ToInt32(ddlCompetencies.SelectedValue);
                a.ECampus = string.Empty; // txtECampus.Text.ToString();
                a.Manager_Sid = Guid.Empty; //user.Manager_Sid;
                a.Comments = txtComments.Text;

                a.LocationAudiences.Clear();
                foreach (ListItem item in AudienceListBox.Items) //Added by VM 9-18-2014
                {
                    string[] itm_value = item.Value.Split('|');
                    string[] itm_text = item.Text.Split('|');

                    LocationAudience la = LocationAudience.CreateNew();
                    la.ObjId = a.ObjId;
                    la.OrgId = itm_value[0] == "" ? 0 : Convert.ToInt32(itm_value[0]);
                    la.OrganizationName = itm_text[0].ToString();
                    la.SiteId = itm_value[1] == "" ? 0 : Convert.ToInt32(itm_value[1]);
                    la.SiteName = itm_text[1].ToString();
                    la.RoomId = itm_value[2] == "" ? 0 : Convert.ToInt32(itm_value[2]);
                    la.RoomName = itm_text[2].ToString();
                    la.AudienceId = itm_value[3] == "" ? 0 : Convert.ToInt32(itm_value[3]);
                    la.AudienceName = itm_text[3].ToString();
                    la.Amount = itm_value[4] == "" ? 0 : Convert.ToInt32(itm_value[4]);

                    a.LocationAudiences.AddNew(la);
                }

            
          

                a.CallCheckRules(a);

                if (a.BrokenRulesCollection.Count > 0)
                {
                    System.Text.StringBuilder message = new System.Text.StringBuilder();

                    foreach (Csla.Validation.BrokenRule rule in a.BrokenRulesCollection)
                        message.AppendFormat(@"{0}\n\r", rule.Description);


                    ShowError(message.ToString());
                    return;
                }
                else
                {
                    assistanceList.Save();

                    BindingData(a);
                    currPos = assistanceList.Index;
                    assistanceList = demo.BusinessObect.Accountability.Assistances.GetAssistances(a.Service_Date, a.Service_Date, user.Sid);
                    assistanceList.Index = currPos;
                    Session["myList"] = assistanceList;
                    dailyList = assistanceList.GetAssistancesByDateRange(Convert.ToDateTime(txtDate.Text), Convert.ToDateTime(txtDate.Text));
                    Session["dailyList"] = dailyList;

                    myListDisplay = demo.BusinessObect.Accountability.AssistancesDisplay.GetAssistancesDisplay(new DateTime(a.Service_Date.Year, a.Service_Date.Month, 1), new DateTime(a.Service_Date.Year, a.Service_Date.Month, 1).AddMonths(1).AddDays(-1), user.Sid);
                    Session["myListDisplay"] = myListDisplay;

                    litMessage.Text = "<font color=\"green\">The record has been updated successfully.</font>";
                }

            }

            litDayHours.Text = ((demo.BusinessObect.Accountability.Assistances)Session["myList"]).GetHours(a.Service_Date, a.Service_Date).ToString();
            litThisWeekHours.Text = ((demo.BusinessObect.Accountability.AssistancesDisplay)Session["myListDisplay"]).GetHours(Convert.ToDateTime(date).AddDays(7 - (int)Convert.ToDateTime(date).DayOfWeek).AddDays(-7), Convert.ToDateTime(date).AddDays(7 - (int)Convert.ToDateTime(date).DayOfWeek).AddDays(-1)).ToString();
            litDate.Text = "<b>" + a.Service_Date.ToShortDateString() + "</b>";
        }

    }

    protected void disableFormControls()
    {
        pnlDetail.Enabled = false;

        string script = "<script language='javascript' ID='Message'>disableButtons();</script>";
        ScriptManager.RegisterStartupScript((Page)HttpContext.Current.Handler, typeof(Page), "Message", script, false);

        txtDate.Enabled = false;
        btnAdd.Enabled = false;
        btnDeleteLocationList.Enabled = false;
        //txtDate.Enabled = false;
        //ddlServiceLength.Enabled = false;
        //ddlContactMethod.Enabled = false;
        //ddlClient.Enabled = false;
        //ddlSite.Enabled = false;
        ////ddlRegion.Enabled = false;
        //ddlActivities.Enabled = false;
        //ddlTravelTime.Enabled = false;
        //ddlFocus.Enabled = false;
        //ddlBudgetCode.Enabled = false;
        //ddlTEC.Enabled = false;
        //txtComments.Enabled = false;
        //AudienceListBox.Enabled = false;
        //AudienceList.Enabled = false;
        //AudienceValue.Enabled = false;
    }

    protected void enableFormControls()
    {
        pnlDetail.Enabled = true;

        string script = "<script language='javascript' ID='Message'>enableButtons();</script>";
        ScriptManager.RegisterStartupScript((Page)HttpContext.Current.Handler, typeof(Page), "Message", script, false);

        txtDate.Enabled = true;
        btnAdd.Enabled = true;
        btnDeleteLocationList.Enabled = true;

        //txtDate.Enabled = true;
        //ddlServiceLength.Enabled = true;
        //ddlContactMethod.Enabled = true;
        //ddlClient.Enabled = true;
        //ddlSite.Enabled = true;

        ////ddlRegion.Enabled = true;
        //ddlActivities.Enabled = true;
        //ddlTravelTime.Enabled = true;
        //ddlFocus.Enabled = true;
        //ddlBudgetCode.Enabled = true;
        //ddlTEC.Enabled = true;
        //txtComments.Enabled = true;
        //AudienceListBox.Enabled = true;
        //AudienceList.Enabled = true;
        //AudienceValue.Enabled = true;
    }

    protected void ShowError(string Message)
    {

        string script = "<script language='javascript' ID='Message'>alert('" + Message + "')</script>";
        ScriptManager.RegisterStartupScript((Page)HttpContext.Current.Handler, typeof(Page), "Message", script, false);

    }

    protected int getRegionId(int siteId)
    {
        int regionId = -1;

        using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "[p.Accountability.Location.GetRegionId]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@siteId", siteId);
            cmd.Parameters.AddWithValue("@regionId", -1).Direction = ParameterDirection.Output;

            try
            {
                cmd.Connection.Open();

                cmd.ExecuteNonQuery();

                regionId = Convert.ToInt32(cmd.Parameters[1].Value);

            }
            catch (Exception exc)
            {
                System.Web.HttpContext.Current.Response.Write(exc.Message);
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();

                cmd.Connection.Dispose();
            }
        }

        return regionId;

    }

    protected int getSiteTypeId(int siteId)
    {
        int regionId = -1;

        using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "[p.Accountability.Location.GetSiteTypeId]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@siteId", siteId);
            cmd.Parameters.AddWithValue("@siteTypeId", -1).Direction = ParameterDirection.Output;

            try
            {
                cmd.Connection.Open();

                cmd.ExecuteNonQuery();

                regionId = Convert.ToInt32(cmd.Parameters[1].Value);

            }
            catch (Exception exc)
            {
                System.Web.HttpContext.Current.Response.Write(exc.Message);
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();

                cmd.Connection.Dispose();
            }
        }

        return regionId;

    }

    protected void lnkHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("default2.aspx");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int siteTypeId = -1;
        int amount;

        if (ddlClient.Text == string.Empty)
        {
            ShowError("Please select a client.");
            return;
        }

        region4.ObjectModel.Site s = region4.ObjectModel.ObjectProvider.ReturnSite(Convert.ToInt32(ddlClient.SelectedValue));

        if (ddlSite.SelectedIndex == -1)
        {
            siteTypeId = s.SiteTypeID;
            if ((siteTypeId == 521 || siteTypeId == 522) && ddlSite.Text != "No Sites")
            {
                ShowError("Please select a site.");
                return;
            }
        }

        if (AudienceList.SelectedIndex == 0)
        {
            ShowError("Please select audience.");
            return;
        }

        if (AudienceValue.Text == string.Empty || !Int32.TryParse(AudienceValue.Text, out amount))
        {
            ShowError("Invalid Served #.");
            return;
        }

        ListItem itm = new ListItem(s.Organization.Name + " | " + ddlClient.Text + " | " + ddlSite.Text + " | " + AudienceList.SelectedItem.Text + " | " + AudienceValue.Text,
           s.Organization.OrganizationID.ToString() + "|" + ddlClient.SelectedValue + "|" + ddlSite.SelectedValue + "|" + AudienceList.SelectedValue + "|" + AudienceValue.Text);

        AudienceListBox.Items.Add(itm);
        ddlClient.SelectedIndex = -1;
        ddlClient.Text = string.Empty;
        ddlSite.SelectedIndex = -1;
        ddlSite.Text = string.Empty;
        AudienceList.SelectedIndex = -1;
        AudienceValue.Text = string.Empty;

    
    }

    protected void btnDeleteLocationList_Click(object sender, EventArgs e)
    {
        ListItem itm = AudienceListBox.SelectedItem;
        AudienceListBox.Items.Remove(itm);

      
    }
}
