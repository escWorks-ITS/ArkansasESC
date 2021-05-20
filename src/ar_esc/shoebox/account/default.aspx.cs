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
using Telerik.Web.UI;
using System.Text.RegularExpressions;
using escWorks;
using Microsoft.Security.Application;
using region4;
using region4.escWeb;



public partial class shoebox_account_default : region4.escWeb.BasePages.ShoeBox.Account.default_aspx
{
    protected override void AssignControlsToBase()
    {
        base._primaryEmail = txtPrimaryEmail;
        base._secondaryEmail = txtSecondaryEmail;
        //base._saluation = ddlSalutation;
        base._lastName = txtLastName;
        base._firstName = txtFirstName;
        base._middleName = txtMiddleName;
        base._homeAddress = txtHomeAddress;
        base._city = txtCity;
        base._state = ddState;
        base._zip = txtZip;
        base._homePhone = txtHomePhone;
        base._workPhone = txtWorkPhone;
        base._region = ddlRegion;
        base._district = ddlDistrict;
        base._school = ddlSchool;
        base._position = ddlPosition;
        base._errorMessage = lbErrorMessage;

        base._btnSubmit = btnSubmit;

        base._pSuccess = pSuccess;
        base._pFirst = pFirst;

        //base._gradeLevel = ddlGradeLevel;

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //escWeb.ar_esc.ObjectModel.User myUser = CurrentUser as escWeb.ar_esc.ObjectModel.User;
            //ddlAccommodation.SelectedValue = myUser.AccommodationId.ToString();

            CascadingDropDown1.SelectedValue = CurrentUser.Location.Site.Organization.LocationID.ToString();
            CascadingDropDown2.SelectedValue = CurrentUser.Location.Site.LocationID.ToString();
            CascadingDropDown3.SelectedValue = CurrentUser.Location.LocationID.ToString();
        }
    }


    protected override void LoadCustomerParameters(region4.ObjectModel.User user)
    {
        escWeb.ar_esc.ObjectModel.User myUser = user as escWeb.ar_esc.ObjectModel.User;
        this.txtEmployeeNo.Text = myUser.EmployeeNo;
        ddlAccommodation.SelectedValue = myUser.AccommodationId.ToString();
    }

    protected override void SetCustomerParameters(region4.ObjectModel.User user)
    {
        escWeb.ar_esc.ObjectModel.User myUser = user as escWeb.ar_esc.ObjectModel.User;
        myUser.EmployeeNo = this.txtEmployeeNo.Text;
        myUser.AccommodationId = ddlAccommodation.SelectedValue == "" ? 0 : Convert.ToInt32(ddlAccommodation.SelectedValue);
    }
    protected void OnChangePassword(object sender, EventArgs e)
    {
        string Email = this.txtPrimaryEmail.Text;

        string url = "password.aspx?mode=change&code=0" + "&email=" + Email;
        Response.Redirect(url);
    }

    protected void ddlAccommodation_OnLoad(object sender, EventArgs e)
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

        escWeb.ar_esc.ObjectModel.User myUser = CurrentUser as escWeb.ar_esc.ObjectModel.User;
        ddlAccommodation.SelectedValue = myUser.AccommodationId.ToString();
    }
}
