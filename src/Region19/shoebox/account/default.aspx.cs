using System;
using System.Web.UI;
using region4.escWeb;
using escWorks;
using System.Web.UI.WebControls;


public partial class shoebox_account_default : region4.escWeb.BasePages.ShoeBox.Account.default_aspx
{
    protected override void AssignControlsToBase()
    {
        base._primaryEmail = txtPrimaryEmail;
        base._secondaryEmail = txtSecondaryEmail;
        base._saluation = ddlSalutation;
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
            CascadingDropDown1.SelectedValue = CurrentUser.Location.Site.Organization.LocationID.ToString();
            CascadingDropDown2.SelectedValue = CurrentUser.Location.Site.LocationID.ToString();
            CascadingDropDown3.SelectedValue = CurrentUser.Location.LocationID.ToString();
            CascadingDropDown4.SelectedValue = CurrentUser.PrimaryPosition.ItemId.ToString();
        }
    }

    protected override void _btnSubmit_Click(object sender, EventArgs e)
    {
        #region Validation
        string validationMessage;
        if (!ValidateData(out validationMessage))
        {
            //Display error message
            _errorMessage.Text = validationMessage;
            return;
        }

        if (!ValidateCustomerData(out validationMessage))
        {
            _errorMessage.Text = validationMessage;
            return;
        }

        bool err = false;

        int location_id, site_id, organization_id, position_id = 0, salutation_id = 0;
        //location_id = 1002;

        if (!Int32.TryParse(_school.SelectedValue, out location_id))
        {
            validationMessage += "<div class='error'>* Please select a "
                + region4.escWeb.SiteVariables.ObjectProvider.SchoolNameCapitalized + "</div>";
            err = true;
        }


        if (!Int32.TryParse(_district.SelectedValue, out site_id))
        {
            //TODO: parameritze this
            validationMessage += "<div class='error'>* Please select a "
            + region4.escWeb.SiteVariables.ObjectProvider.SiteNameCapitalized + "/District </div>";
            err = true;
        }

        if (_region != null && !Int32.TryParse(_region.SelectedValue, out organization_id))
        {
            validationMessage += "<div class='error'>* Please select a " + region4.escWeb.SiteVariables.ObjectProvider.OrganizationNameCapitalized + "/Region </div>";
            err = true;
        }

        if (_position != null && !Int32.TryParse(_position.SelectedValue, out position_id))
        {
            validationMessage += "<div class='error'>* Please select a position.</div>";
            err = true;
        }

        if (err)
        {
            _errorMessage.Text = validationMessage;
            return;
        }
        #endregion

        #region Save Profile
        CurrentUser.SecondaryEmail = _secondaryEmail.Text;
        CurrentUser.LastName = _lastName.Text;
        CurrentUser.FirstName = _firstName.Text;
        CurrentUser.MiddleName = _middleName.Text;
        CurrentUser.Address = _homeAddress.Text;
        CurrentUser.City = _city.Text;
        CurrentUser.State = UserState;
        CurrentUser.Zip = _zip.Text;
        CurrentUser.HomePhone = _homePhone.Text;
        CurrentUser.WorkPhone = _workPhone.Text;

        CurrentUser.LocationID = location_id;
        CurrentUser.Locationsite = site_id;
        CurrentUser.PrimaryPosition = region4.Item.ReturnItem(position_id);
        CurrentUser.Salutation = region4.Item.ReturnItem(salutation_id);
        CurrentUser.GradeLevel = region4.Item.ReturnItem(0);

        SetCustomerParameters(CurrentUser);

        if (CurrentUser.Save())
        {
            if (Request.QueryString["SourcePage"] == null)
                Response.Redirect("../subscriptions/default.aspx");
            else
                Response.Redirect("~/catalog/register/checkout.aspx");
        }
        else
        {
            _errorMessage.Text = string.Format("<div class='error'>Oops. An error has occurred! {0}</div>", CurrentUser.LoadException.Message);
        }
        #endregion

        //if (Request.QueryString["SourcePage"] != null)
        //{
        //    Response.Redirect("~/catalog/register/checkout.aspx"); 
        //}

        //RedirectToCheckOut();
    }
    protected override void SetCustomerParameters(region4.ObjectModel.User user)
    {
        escWeb.tx_r19.ObjectModel.User u = user as escWeb.tx_r19.ObjectModel.User;

        //u.SpecialNeeds_Id = ddlSpecialNeeds.SelectedValue == "" ? 0 : Convert.ToInt32(ddlSpecialNeeds.SelectedValue);

    }

    protected void OnChangePassword(object sender, EventArgs e)
    {
        string Email = this.txtPrimaryEmail.Text;

        string url = "password.aspx?mode=change&code=0" + "&email=" + Email;
        Response.Redirect(url);
    }

    protected void specialNeeds_PreRender(object sender, EventArgs e)
    {
        DropDownList list = sender as DropDownList;
        if (list == null)
            throw new Exception("Expected a dropdownlist but didn't get one");

        if (list.Items.Count > 0)
            return;
        list.Items.Add(new ListItem("Please select ...", ""));
        region4.ItemCollection items = region4.ItemCollection.ReturnItemsByGroup(3011);
        foreach (region4.Item item in items)
            if (item.Enabled)
                list.Items.Add(new ListItem(item.Display, item.ItemId.ToString()));

        //if (CurrentUser.Sid != Guid.Empty)
        //{
        //    ddlSpecialNeeds.SelectedValue = ((escWeb.tx_r19.ObjectModel.User)CurrentUser).SpecialNeeds_Id.ToString();

        //}
    }

    protected override void _position_Load(object sender, EventArgs e)
    {
        DropDownList list = sender as DropDownList;
        region4.ItemCollection items;
        if (list == null)
            throw new Exception("Expected a dropdownlist but didn't get one");

        if (list.Items.Count > 0)
            return;
        list.Items.Add(new ListItem("Please select a position...", ""));
        if (this.CurrentUser.isStaff)
        {
            items = region4.ItemCollection.ReturnItemsByGroup(region4.escWeb.SiteVariables.ItemGroupIDs.StaffPosition);
        }
        else
            items = region4.ItemCollection.ReturnItemsByGroup(region4.escWeb.SiteVariables.ItemGroupIDs.Position);

        foreach (region4.Item item in items)
            if (item.Enabled)
                list.Items.Add(new ListItem(item.Display, item.ItemId.ToString()));


        ListItem tmp = list.Items.FindByValue(CurrentUser.PrimaryPosition.ItemId.ToString());
        if (tmp != null)
            list.SelectedIndex = list.Items.IndexOf(tmp);

    }
}
