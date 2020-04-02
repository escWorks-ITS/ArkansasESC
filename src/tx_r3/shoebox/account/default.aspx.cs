using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web;
using System.Configuration;

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


    protected override void SetCustomerParameters(region4.ObjectModel.User user)
    {
        escWeb.tx_r3.ObjectModel.User u = user as escWeb.tx_r3.ObjectModel.User;
        u.SpecialNeedIds = specialneed.Value;
        u.SpecialNeedsComments = u.SpecialNeedIds.Contains(ConfigurationManager.AppSettings["user.specialneeds.other"]) ? txtSpecialNeedComments.Text.Trim() : "";

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
            + region4.escWeb.SiteVariables.ObjectProvider.SiteNameCapitalized + "</div>";
            err = true;
        }

        if (_region != null && !Int32.TryParse(_region.SelectedValue, out organization_id))
        {
            validationMessage += "<div class='error'>* Please select a " + region4.escWeb.SiteVariables.ObjectProvider.OrganizationNameCapitalized + "</div>";
            err = true;
        }

        if (_position != null && !Int32.TryParse(_position.SelectedValue, out position_id))
        {
            validationMessage += "<div class='error'>* Please select a position</div>";
            err = true;
        }

        //if (_saluation != null && !Int32.TryParse(_saluation.SelectedValue, out salutation_id))
        //{
        //    validationMessage += "<div class='error'>* Please select a salutation</div>";
        //    err = true;
        //}

        int gradelevel_id = 0;
        if (_gradeLevel != null && !Int32.TryParse(_gradeLevel.SelectedValue, out gradelevel_id))
        {
            gradelevel_id = 0;
        }

        if (specialneed.Value.Contains(ConfigurationManager.AppSettings["user.specialneeds.other"]) && txtSpecialNeedComments.Text.Trim() == "")
        {
            validationMessage += "<div class='error'>* Please fill in Special Accommodation Comments</div>";
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
        CurrentUser.GradeLevel = region4.Item.ReturnItem(gradelevel_id);

        SetCustomerParameters(CurrentUser);

        if (CurrentUser.Save())
        {
            Session.Remove("profile");
            Session["profile"] = CurrentUser;
            this.ShoppingCart.ChangeUser(CurrentUser);
            Response.Redirect("../subscriptions/default.aspx");
        }
        else
        {
            _errorMessage.Text = string.Format("<div class='error'>Oops. An error has occurred! {0}</div>", CurrentUser.LoadException.Message);
        }
        #endregion
    }

        //if (Request.QueryString["SourcePage"] != null)
        //{
        //    Response.Redirect("~/catalog/register/checkout.aspx"); 
        //}

    protected override void _position_Load(object sender, EventArgs e)
    {
        DropDownList list = sender as DropDownList;
        region4.ItemCollection items;
        if (list == null)
            throw new Exception("Expected a dropdownlist but didn't get one");

        if (list.Items.Count > 0)
            return;
        list.Items.Add(new ListItem("Please select a position...", ""));
        if (ddlSchool.SelectedValue == "37191")
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

    protected void OnChangePassword(object sender, EventArgs e)
    {
        string Email = this.txtPrimaryEmail.Text;

        string url = "password.aspx?mode=change&code=0" + "&email=" + Email;
        Response.Redirect(url);
    }

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
                ScriptManager.RegisterStartupScript((Page)HttpContext.Current.Handler, typeof(Page), "Message", script, false);
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
