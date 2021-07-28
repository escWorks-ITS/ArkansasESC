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

public partial class shoebox_account_signup : region4.escWeb.BasePages.ShoeBox.Account.signup_aspx
{
    public event UserCreatedHandler UserCreated;
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
        base._password = txtPassword;
        base._passwordConfirmation = txtConfirmPassword;
        base._errorMessage = lbErrorMessage;

        base._btnSubmit = btnSubmit;

        //base._gradeLevel = ddlGradeLevel;

        base._pSuccess = pSuccess;
        base._pFirst = pFirst;
    }

    protected override void SetCustomerParameters(region4.ObjectModel.User user)
    {
        escWeb.ar_esc.ObjectModel.User myUser = user as escWeb.ar_esc.ObjectModel.User;
        myUser.EmployeeNo = this.txtEmployeeNo.Text;
        myUser.AccommodationId = ddlAccommodation.SelectedValue == "" ? 0 : Convert.ToInt32(ddlAccommodation.SelectedValue);
    }
    protected override void _state_Load(object sender, EventArgs e)
    {
        DropDownList list = sender as DropDownList;
        if (list == null)
            throw new Exception("Expected a dropdownlist but didn't get one");

        if (list.Items.Count > 0)
            return;
        list.Items.Add(new ListItem(""));
        ItemCollection states = ItemCollection.ReturnItemsByGroup(SiteVariables.ItemGroupIDs.State);
        foreach (Item item in states)
            list.Items.Add(new ListItem(item.Display, item.Display));

        list.SelectedValue = "AR";
    }

    protected override void _btnSubmit_Click(object sender, EventArgs e)
    {
        #region Validation
        string validationMessage;
        if (!ValidateData(out validationMessage))
        {
            _errorMessage.Text = validationMessage;
            return;
        }

        if (!ValidateCustomerData(out validationMessage))
        {
            _errorMessage.Text = validationMessage;
            return;
        }

        bool err = false;

        int location_id = 0, site_id = 0, organization_id = 0, position_id = 0, salutation_id = 0, gradelevel_id = 0;

        if (_school != null && !Int32.TryParse(_school.SelectedValue, out location_id))
        {
            validationMessage += String.Format("<div class='error'>* Please select a {0}</div>", SiteVariables.ObjectProvider.SchoolName);
            err = true;
        }

        if (_district != null && !Int32.TryParse(_district.SelectedValue, out site_id))
        {
            //TODO: parameritze this
            validationMessage += String.Format("<div class='error'>* Please select a {0}</div>", SiteVariables.ObjectProvider.SiteName);
            err = true;
        }

        if (_region != null && !Int32.TryParse(_region.SelectedValue, out organization_id))
        {
            validationMessage += String.Format("<div class='error'>* Please select a {0}</div>", SiteVariables.ObjectProvider.OrganizationName);
            err = true;
        }

        if (_position != null && !Int32.TryParse(_position.SelectedValue, out position_id))
        {
            validationMessage += "<div class='error'>* Please select a position</div>";
            err = true;
        }

        if (_saluation != null && !Int32.TryParse(_saluation.SelectedValue, out salutation_id))
        {
            validationMessage += "<div class='error'>* Please select a salutation</div>";
            err = true;
        }

        if (_gradeLevel != null && !Int32.TryParse(_gradeLevel.SelectedValue, out gradelevel_id))
        {
            gradelevel_id = 0;
        }

        if (err)
        {
            _errorMessage.Text = validationMessage;
            return;
        }

        #endregion

        string password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(_password.Text.ToLower().Trim(), "sha1");

        region4.ObjectModel.User user = region4.ObjectModel.User.CreateUser(_lastName.Text, _firstName.Text, _middleName.Text, _homeAddress.Text, _city.Text, UserState,
            _zip.Text, _homePhone.Text, _workPhone.Text, location_id, site_id, organization_id, _primaryEmail.Text, _secondaryEmail.Text, position_id, salutation_id, gradelevel_id, password);

        if (!user.ExceptionOccurred)
        {
            SetCustomerParameters(user);
            user.Save();

            //If the a user created event has been registered then  fire the event
            if (UserCreated != null)
                UserCreated(user);

            if (this.ShoppingCart != null)
                this.ShoppingCart.ChangeUser(user);//In order to display the fee discount for the Conferences/Sessions, update user information when cart is not null Added by VM 4-2-2012

            if (!String.IsNullOrEmpty(Tools.Strings.CleanUp("conf_ref", true, false)))
            {
                string url = String.Format("../../catalog/conference.aspx?conf_ref={0}&email={1}&conference_id={2}", Tools.Strings.CleanUp("conf_ref", true, false), user.PrimaryEmail, Tools.Strings.CleanUp("conference_id", true, false));
                // Response.Redirect(Microsoft.Security.Application.Encoder.UrlEncode(url));
                Response.Redirect(url);
            }
            if (!String.IsNullOrEmpty(Tools.Strings.CleanUp("session_id", true, false)))
            {
                string url = String.Format("../../walkin/default.aspx?session_id={0}&emailID={1}", Tools.Strings.CleanUp("session_id", true, false).ToString(), Tools.Strings.CleanUp("emailID", true, false).ToString());
                //Response.Redirect(Microsoft.Security.Application.Encoder.UrlEncode(url));
                Response.Redirect(url);
            }
            else if (Tools.Strings.CleanUp("ReturnUrl", true, false) != "")
            {
                string url = System.Web.HttpUtility.UrlDecode(Request.QueryString["ReturnUrl"]);
                this.CurrentUser = user;
                Session.Remove("profile");
                Session["profile"] = user;

                //Session["User"] = user.FirstName + " " + user.LastName;
                Session["User"] = user.FirstName + " " + user.LastName;
                Session["UserFirstName"] = user.FirstName + " " + user.LastName.Substring(0, 1);
                if (url.Contains("/default.aspx"))
                {
                   
                    System.Web.Security.FormsAuthentication.RedirectFromLoginPage(user.Sid.ToString(), false);
                    Response.Redirect("~/default.aspx");
                }
                else
                    System.Web.Security.FormsAuthentication.RedirectFromLoginPage(user.Sid.ToString(), false);

                //System.Web.Security.FormsAuthentication.RedirectFromLoginPage(user.Sid.ToString(), false);
            }
            else
            {
                this.CurrentUser = user;
                Session.Remove("profile");
                Session["profile"] = user;

                //Session["User"] = user.FirstName + " " + user.LastName;
                Session["User"] = user.FirstName + " " + user.LastName;
                Session["UserFirstName"] = user.FirstName + " " + user.LastName.Substring(0, 1);


                System.Web.Security.FormsAuthentication.SetAuthCookie(user.Sid.ToString(), false);
                _pFirst.Visible = false;
                _pSuccess.Visible = true;

               //Response.Redirect("../../" + ConfigurationManager.AppSettings["CustomerId"] + "/default.aspx");
}

        }

    }

    protected void ddlAccommodation_PreRender(object sender, EventArgs e)
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
    }

}
