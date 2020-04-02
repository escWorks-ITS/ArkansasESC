using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using region4;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Configuration;

public partial class catalog_register_confirmuserprofile : region4.escWeb.BasePage
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        if (ddlPosition != null) ddlPosition.Load += new EventHandler(_position_Load);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(lblErrorMessage.Text.Trim()))
        {
            if (!Page.IsPostBack)
            {
                CascadingDropDown1.SelectedValue = CurrentUser.Location.Site.Organization.LocationID.ToString();
                CascadingDropDown2.SelectedValue = CurrentUser.Location.Site.LocationID.ToString();
                CascadingDropDown3.SelectedValue = CurrentUser.Location.LocationID.ToString();
            }

        }
    }

    protected void OnCheckedChanged(Object sender, EventArgs e)
    {
        this.btnSaveUserProfile.Visible = this.checkboxCertify.Checked;
    }

    protected virtual void _position_Load(object sender, EventArgs e)
    {
        DropDownList list = sender as DropDownList;
        if (list == null)
            throw new Exception("Expected a dropdownlist but didn't get one");

        if (list.Items.Count > 0)
            return;
        list.Items.Add(new ListItem("Please select a position...", ""));
        ItemCollection items = ItemCollection.ReturnItemsByGroup(region4.escWeb.SiteVariables.ItemGroupIDs.Position);
        foreach (Item item in items)
            if (item.Enabled)
                list.Items.Add(new ListItem(item.Display, item.ItemId.ToString()));

        ListItem tmp = list.Items.FindByValue(CurrentUser.PrimaryPosition.ItemId.ToString());
        if (tmp != null)
            list.SelectedIndex = list.Items.IndexOf(tmp);
    }

    protected void btnSaveUserProfileClick(object sender, EventArgs e)
    {
        string validationMessage = string.Empty;
        bool err = false;

        int location_id, site_id, organization_id, position_id = 0;

        if (!Int32.TryParse(ddlRegion.SelectedValue, out organization_id))
        {
            validationMessage += "<div class='error'>* Please select a " + region4.escWeb.SiteVariables.ObjectProvider.OrganizationNameCapitalized + "</div>";
            err = true;
        }
        if (!Int32.TryParse(ddlDistrict.SelectedValue, out site_id))
        {
            validationMessage += "<div class='error'>* Please select a "
            + region4.escWeb.SiteVariables.ObjectProvider.SiteNameCapitalized + "</div>";
            err = true;
        }
        if (!Int32.TryParse(ddlSchool.SelectedValue, out location_id))
        {
            validationMessage += "<div class='error'>* Please select a "
                + region4.escWeb.SiteVariables.ObjectProvider.SchoolNameCapitalized + "</div>";
            err = true;
        }
        if (ddlPosition != null && !Int32.TryParse(ddlPosition.SelectedValue, out position_id))
        {
            validationMessage += "<div class='error'>* Please select a position</div>";
            err = true;
        }

        if (specialneed.Value.Contains(ConfigurationManager.AppSettings["user.specialneeds.other"]) && txtSpecialNeedComments.Text.Trim() == "")
        {
            validationMessage += "<div class='error'>* Please fill in Special Accommodation Comments</div>";
            err = true;
        }

        if (err)
        {
            lblErrorMessage.Text = validationMessage;
            return;
        }

        #region Save Profile
        escWeb.tx_r3.ObjectModel.User u = (escWeb.tx_r3.ObjectModel.User)CurrentUser;
        u.LocationID = location_id;
        u.Locationsite = site_id;
        u.PrimaryPosition = region4.Item.ReturnItem(position_id);
        u.SpecialNeedIds = specialneed.Value;
        u.SpecialNeedsComments = u.SpecialNeedIds.Contains(ConfigurationManager.AppSettings["user.specialneeds.other"]) ? txtSpecialNeedComments.Text.Trim() : "";
        u.Save();

        Response.Redirect("~/catalog/register/checkout.aspx");
    }

        #endregion

    protected void ddlSpecialNeedList_PreRender(object sender, EventArgs e)
    {
        DropDownList list = sender as DropDownList;
        region4.ItemCollection items;
        if (list == null)
            throw new Exception("Expected a dropdownlist but didn't get one");
        list.Items.Clear();
        if (list.Items.Count > 0)
            return;
        list.Items.Add(new ListItem("Please select a special need ...", ""));

        items = region4.ItemCollection.ReturnItemsByGroup(Convert.ToInt32(ConfigurationManager.AppSettings["user.specialneeds.group"]));

        foreach (region4.Item item in items)
            if (item.Enabled)
                list.Items.Add(new ListItem(item.Display, item.ItemId.ToString()));

        escWeb.tx_r3.ObjectModel.User myUser = (escWeb.tx_r3.ObjectModel.User)CurrentUser;
        if (!IsPostBack)
        {
            specialneed.Value = myUser.SpecialNeedIds;
            txtSpecialNeedComments.Text = myUser.SpecialNeedsComments;
        }

        if (specialneed.Value != "")
        {
            SetupMultiValueControl(ref lbSpecialNeed, ref ddlSpecialNeedList, ref specialneed, specialneed.Value);

            string script = string.Empty;
            if (specialneed.Value.Trim().Contains(ConfigurationManager.AppSettings["user.specialneeds.other"]))
            {
                script = "<script language='javascript' ID='Message'>openSpecial();</script>";
                ScriptManager.RegisterStartupScript((Page)System.Web.HttpContext.Current.Handler, typeof(Page), "Message", script, false);
            }

        }
    }

    protected void SetupMultiValueControl(ref ListBox listbox, ref DropDownList dropdownlist, ref HtmlInputHidden input, string value)
    {
        listbox.Items.Clear();

        string inputValue = string.Empty;

        foreach (string item in value.Split(','))
        {
            try
            {
                if (item != string.Empty)
                {
                    ListItem li = dropdownlist.Items.FindByValue(item);

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

                        ListItem newItem = new ListItem(li.Text, li.Value);
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

}