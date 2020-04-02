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

public partial class shoebox_account_signup : region4.escWeb.BasePages.ShoeBox.Account.signup_aspx
{

    public event UserCreatedHandler UserCreated;
    private string subjects = string.Empty;


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
        base._password = txtPassword;
        base._passwordConfirmation = txtConfirmPassword;
        base._errorMessage = lbErrorMessage;

        base._btnSubmit = btnSubmit;

        //base._gradeLevel = ddlGradeLevel;

        base._pSuccess = pSuccess;
        base._pFirst = pFirst;

   


    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!Page.IsPostBack)
        //{
        //    CascadingDropDown1.SelectedValue = "27537";
        //}

        //subjects = escWorks.Strings.GetSafeString(Subjects.UniqueID, escWorks.Strings.StringType.Form, "");
        if (specialneed.Value.Trim() != "") 
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
            _errorMessage.Text = validationMessage;
            return;
        }

        if (!ValidateCustomerData(out validationMessage))
        {
            _errorMessage.Text = validationMessage;
            return;
        }

        bool err = false;

        int location_id, site_id, organization_id, position_id = 0, salutation_id = 0, gradelevel_id = 0;

         if (!Int32.TryParse(_school.SelectedValue, out location_id))
        {
            validationMessage += String.Format("<div class='error'>* Please select a {0}</div>", region4.escWeb.SiteVariables.ObjectProvider.SchoolName);
            err = true;
        }

        if (!Int32.TryParse(_district.SelectedValue, out site_id))
        {
            //TODO: parameritze this
            validationMessage += String.Format("<div class='error'>* Please select a {0}</div>", region4.escWeb.SiteVariables.ObjectProvider.SiteName);
            err = true;
        }

        if (!Int32.TryParse(_region.SelectedValue, out organization_id))
        {
            validationMessage += String.Format("<div class='error'>* Please select a {0}</div>", region4.escWeb.SiteVariables.ObjectProvider.OrganizationName);
            err = true;
        }

        if (_position != null && !Int32.TryParse(_position.SelectedValue, out position_id))
        {
            validationMessage += "<div class='error'>* Please select a position</div>";
            err = true;
        }

        if (specialneed.Value.Contains(ConfigurationManager.AppSettings["user.specialneeds.other"]) && txtSpecialNeedComments.Text.Trim() == "")
        {
            validationMessage += "<div class='error'>* Please fill in Special Accommodation Comments</div>";
            err = true;
        }

        //if (_saluation != null && !Int32.TryParse(_saluation.SelectedValue, out salutation_id))
        //{
        //    validationMessage += "<div class='error'>* Please select a salutation</div>";
        //    err = true;
        //}

        //if (_gradeLevel != null && !Int32.TryParse(_gradeLevel.SelectedValue, out gradelevel_id))
        //{
        //    gradelevel_id = 0;
        //}

        if (err)
        {
            _errorMessage.Text = validationMessage;
            return;
        }

        #endregion

        string password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(_password.Text.ToLower().Trim(), "sha1");

        region4.ObjectModel.User user = region4.ObjectModel.User.CreateUser(_lastName.Text, _firstName.Text, _middleName.Text, _homeAddress.Text, _city.Text, UserState,
            _zip.Text, _homePhone.Text,  _workPhone.Text, location_id, site_id, organization_id, _primaryEmail.Text, _secondaryEmail.Text, position_id, salutation_id, gradelevel_id, password);

        //process subjects unfo

        if (!user.ExceptionOccurred)
        {
            SetCustomerParameters(user);
            user.Save();

            //If the a user created event has been registered then  fire the event
            if (UserCreated != null)
                UserCreated(user);

            if (this.ShoppingCart != null)
                this.ShoppingCart.ChangeUser(user);//In order to display the fee discount for the Conferences/Sessions, update user information when cart is not null Added by VM 4-2-2012

            if (!String.IsNullOrEmpty(Request.QueryString["conf_ref"]))
            {
                string url = String.Format("../../catalog/conference.aspx?conf_ref={0}&email={1}&conference_id={2}", Request.QueryString["conf_ref"], user.PrimaryEmail, Request.QueryString["conference_id"]);
                Response.Redirect(url);
            }
            if (!String.IsNullOrEmpty(Request.QueryString["session_id"]) && !String.IsNullOrEmpty(Request.QueryString["emailID"]))
            {
                string url = String.Format("../../walkin/default.aspx?session_id={0}&emailID={1}", Request.QueryString["session_id"].ToString(), Request.QueryString["emailID"].ToString());
                Response.Redirect(url);
            }
            else if (Request.QueryString["ReturnUrl"] != "")
            {
                string url = System.Web.HttpUtility.UrlDecode(Request.QueryString["ReturnUrl"]);

                this.CurrentUser = user;
                Session.Remove("profile");
                Session["profile"] = user;
                if (url.Contains("/" + ConfigurationManager.AppSettings["CustomerId"] + "/default.aspx"))
                {
                    System.Web.Security.FormsAuthentication.SetAuthCookie(user.Sid.ToString(), false);
                    Response.Redirect("../subscriptions/default.aspx");
                }
                else
                    System.Web.Security.FormsAuthentication.RedirectFromLoginPage(user.Sid.ToString(), false);
            }
            else
            {
                this.CurrentUser = user;
                Session.Remove("profile");
                Session["profile"] = user;
                System.Web.Security.FormsAuthentication.SetAuthCookie(user.Sid.ToString(), false);
                _pFirst.Visible = false;
                _pSuccess.Visible = true;
            }

        }
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
        if (ddlSchool.SelectedValue == "37191")
        {
            items = region4.ItemCollection.ReturnItemsByGroup(region4.escWeb.SiteVariables.ItemGroupIDs.StaffPosition);
        }
        else
            items = region4.ItemCollection.ReturnItemsByGroup(region4.escWeb.SiteVariables.ItemGroupIDs.Position);

        foreach (region4.Item item in items)
            if (item.Enabled)
                list.Items.Add(new ListItem(item.Display, item.ItemId.ToString()));
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


