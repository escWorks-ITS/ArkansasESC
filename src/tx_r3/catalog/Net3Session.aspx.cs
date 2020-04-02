using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class catalog_Net3Session : region4.escWeb.BasePage
{
    protected escWeb.tx_r3.ObjectModel.Session session;
    protected escWeb.tx_r3.ObjectModel.Event myEvent;
    protected bool IsInTexasState = false;

    protected void Page_Init(object sender, EventArgs e)
    {
        //Retreive session id from Query String
        int session_id;
        string tmp = escWorks.Tools.Strings.CleanUp("session_id", true, false);
        if (!Int32.TryParse(tmp, out session_id))
        {
            tmp = escWorks.Tools.Strings.CleanUp("sessionid", true, false);
            if (!Int32.TryParse(tmp, out session_id))
                session_id = -1;
        }

        session = (escWeb.tx_r3.ObjectModel.Session)region4.escWeb.SiteVariables.ObjectProvider.ReturnSession(session_id);

        //If an error occurred while loading the session set it to null
        if (session_id <= 0 || session.ExceptionOccurred)
        {
            session = null;
            Response.Redirect("~/catalog/Session.aspx?session_id=" + session_id);
        }

        myEvent = session.Event as escWeb.tx_r3.ObjectModel.Event;
        if( (myEvent != null) && !myEvent.IsNet3Event && !myEvent.IsNet3StudentEvent)
        {
            Response.Redirect("~/catalog/Session.aspx?session_id=" + session_id);
        }

        //If User logged in, prepopulate the fields
        if (HttpContext.Current.Request.IsAuthenticated && (this.CurrentUser.UserID > 0) && (this.CurrentUser.Sid != Guid.Empty))
        {
            if (myEvent.IsNet3StudentEvent)
            {
                this.txtRequesterName.Text = CurrentUser.FullName;
                this.txtRequesterEmail.Text = CurrentUser.PrimaryEmail;
                this.txtRequesterPhone.Text = CurrentUser.WorkPhone;
                this.txtRequesterPosition.Text = CurrentUser.PrimaryPosition.Display;
            }
            this.txtTeacherName.Text = CurrentUser.FullName;
            this.txtTeacherEmail.Text = CurrentUser.PrimaryEmail;
            this.txtTeacherPhone.Text = CurrentUser.WorkPhone;
            this.txtTeacherDistrictName.Text = CurrentUser.Location.Site.Name;
            this.txtTeacherCampusName.Text = CurrentUser.Location.Name;
            this.txtTeacherCity.Text = CurrentUser.City;
            this.txtTeacherState.Text = CurrentUser.State;
            this.txtTeacherZipCode.Text = CurrentUser.Zip;

            IsInTexasState = CurrentUser.State == "TX" || CurrentUser.State == "Texas";

            if (IsInTexasState)
            {
                this.pTexasViewingLocation.Visible = true;
            }
            else
            {
                pRegion3ViewingLocation.Visible = false;
                pTechnicalContact.Visible = true;
                pConnectionInformation.Visible = true;
            }
        }
        this.txtTeacherCountry.Text = "USA";
        ddlRegion.Load += new EventHandler(RegionLoad);
        ddlDistrict.Load += new EventHandler(SiteLoad);
        btnSubmit.Click += new EventHandler(btnSubmit_Click);
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        pRequestorInformation.Visible = myEvent.IsNet3StudentEvent;
        pAdditionalTeacher.Visible = myEvent.IsNet3StudentEvent;
        pInteraction.Visible = myEvent.IsNet3StudentEvent;
        placeHolderTotalNumberStudents.Visible = myEvent.IsNet3StudentEvent;
    }

    protected virtual bool ValidateData(out string validationMessage)
    {
        validationMessage = "";

        if (myEvent.IsNet3StudentEvent)
        {
            if (string.IsNullOrEmpty(txtRequesterName.Text))
            {
                validationMessage = "Please enter requester name";
                return false;                
            }

            if (!String.IsNullOrEmpty(txtRequesterEmail.Text) && !EmailProvider.IsValidEmailAddress(txtRequesterEmail.Text))
            {
                validationMessage = "The requester email address you have entered does not appear to be a valid email address";
                return false;
            }

            if (string.IsNullOrEmpty(txtRequesterPhone.Text))
            {
                validationMessage = "Please enter requester phone";
                return false;
            }

            if (string.IsNullOrEmpty(txtTotalNumberStudents.Text))
            {
                validationMessage = "Please enter Total Number of Students Viewing Program";
                return false;
            }
        }

        if (string.IsNullOrEmpty(txtTeacherName.Text))
        {
            validationMessage = "Please enter teacher name";
            return false;
        }

        if (!String.IsNullOrEmpty(txtTeacherEmail.Text) && !EmailProvider.IsValidEmailAddress(txtTeacherEmail.Text))
        {
            validationMessage = "The teacher email address you have entered does not appear to be a valid email address";
            return false;
        }

        if (string.IsNullOrEmpty(txtTeacherPhone.Text))
        {
            validationMessage = "Please enter teacher phone";
            return false;
        }

        if (string.IsNullOrEmpty(txtTeacherDistrictName.Text))
        {
            validationMessage = "Please enter district name";
            return false;
        }

        if (string.IsNullOrEmpty(txtTeacherCampusName.Text))
        {
            validationMessage = "Please enter campus name";
            return false;
        }

        if (string.IsNullOrEmpty(txtTeacherCity.Text))
        {
            validationMessage = "Please enter city";
            return false;
        }

        if (string.IsNullOrEmpty(txtTeacherState.Text))
        {
            validationMessage = "Please enter state";
            return false;
        }

        if (string.IsNullOrEmpty(txtTeacherZipCode.Text))
        {
            validationMessage = "Please enter Zip Code";
            return false;
        }

        if (string.IsNullOrEmpty(txtTeacherCountry.Text))
        {
            validationMessage = "Please enter txtTeacherCountry";
            return false;
        }

        if (!String.IsNullOrEmpty(txtTeacher2Email.Text) && !EmailProvider.IsValidEmailAddress(txtTeacher2Email.Text))
        {
            validationMessage = "The teacher 2 email address you have entered does not appear to be a valid email address";
            return false;
        }

        if (!String.IsNullOrEmpty(txtTeacher3Email.Text) && !EmailProvider.IsValidEmailAddress(txtTeacher3Email.Text))
        {
            validationMessage = "The teacher 3 email address you have entered does not appear to be a valid email address";
            return false;
        }

        if (!String.IsNullOrEmpty(txtTeacher4Email.Text) && !EmailProvider.IsValidEmailAddress(txtTeacher4Email.Text))
        {
            validationMessage = "The teacher 4 email address you have entered does not appear to be a valid email address";
            return false;
        }

        if (!String.IsNullOrEmpty(txtTeacher5Email.Text) && !EmailProvider.IsValidEmailAddress(txtTeacher5Email.Text))
        {
            validationMessage = "The teacher 5 email address you have entered does not appear to be a valid email address";
            return false;
        }

        if (!String.IsNullOrEmpty(txtTechnicalContactEmail.Text) && !EmailProvider.IsValidEmailAddress(txtTechnicalContactEmail.Text))
        {
            validationMessage = "The technical contact email address you have entered does not appear to be a valid email address";
            return false;
        }

        int organization_id;
        Int32.TryParse(ddlRegion.SelectedValue, out organization_id);

        //If Other, then System Type is required
        if (organization_id < 0)
        {
            validationMessage = "Please indicate which Regional Education Service Center (ESC) you receive videoconferencing services from";
            return false;
        }

        //If Region 3, then ViewingSite is required
        bool IsRegion3Esc = (organization_id == 27537); //27537	Region 3 ESC - Victoria

        int site_id;
        Int32.TryParse(ddlDistrict.SelectedValue, out site_id);

        if(IsRegion3Esc && site_id < 0)
        {
            validationMessage = "Please indicate your viewing site.";
            return false;
        }

        //If Other, then System Type is required
        if ((site_id == 80111 /* Other*/) && (this.txtConnectionInfoSystemType.Text.Trim().Length < 1))
        {
            validationMessage = "For NET3 member site 'Other', System Type is required!";
            return false;
        }

        return true;
    }

    protected virtual void btnSubmit_Click(object sender, EventArgs e)
    {
        string validationMessage;
        if (!ValidateData(out validationMessage))
        {
            //Display error message
            lbErrorMessage.Text = validationMessage;
            return;
        }

        region4.ObjectModel.SessionRegistration registration = region4.ObjectModel.ObjectProvider.ReturnSessionRegistration(session, CurrentUser);
        escWeb.tx_r3.ObjectModel.SessionRegistration mySessionRegistration = registration as escWeb.tx_r3.ObjectModel.SessionRegistration;

        if(mySessionRegistration.IsNet3studentEvent)
        {
            //Requester Information
            mySessionRegistration._requesterName = this.txtRequesterName.Text;
            mySessionRegistration._requesterEmail = this.txtRequesterEmail.Text;
            mySessionRegistration._requesterPhone = this.txtRequesterPhone.Text;
            mySessionRegistration._requesterPosition = this.txtRequesterPosition.Text;

            mySessionRegistration._TeacherTotalNumberStudents = int.Parse(this.txtTotalNumberStudents.Text);

            //AdditionalTeachers
            mySessionRegistration._Teacher2Name = this.txtTeacher2Name.Text;
            mySessionRegistration._Teacher2Email = this.txtTeacher2Email.Text;
            mySessionRegistration._Teacher3Name = this.txtTeacher3Name.Text;
            mySessionRegistration._Teacher3Email = this.txtTeacher3Email.Text;
            mySessionRegistration._Teacher4Name = this.txtTeacher4Name.Text;
            mySessionRegistration._Teacher4Email = this.txtTeacher4Email.Text;
            mySessionRegistration._Teacher5Name = this.txtTeacher5Name.Text;
            mySessionRegistration._Teacher5Email = this.txtTeacher5Email.Text;

            //Interaction
            mySessionRegistration._InteractionQuestion1 = this.txtInteractionQuestion1.Text;
            mySessionRegistration._InteractionQuestion2 = this.txtInteractionQuestion2.Text;
            mySessionRegistration._InteractionQuestion3 = this.txtInteractionQuestion3.Text;
        }

        //Teacher Information
        mySessionRegistration._TeacherName = this.txtTeacherName.Text;
        mySessionRegistration._TeacherEmail = this.txtTeacherEmail.Text;
        mySessionRegistration._TeacherPhone = this.txtTeacherPhone.Text;
        mySessionRegistration._TeacherDistrictName = this.txtTeacherDistrictName.Text;
        mySessionRegistration._TeacherCampusName = this.txtTeacherCampusName.Text;
        mySessionRegistration._TeacherCity = this.txtTeacherCity.Text;
        mySessionRegistration._TeacherState = this.txtTeacherState.Text;
        mySessionRegistration._TeacherZipCode = this.txtTeacherZipCode.Text;
        mySessionRegistration._TeacherCountry = this.txtTeacherCountry.Text;

        //Technical Contact
        mySessionRegistration._TechnicalContactName = this.txtTechnicalContactName.Text;
        mySessionRegistration._TechnicalContactEmail = this.txtTechnicalContactEmail.Text;
        mySessionRegistration._TechnicalContactPhone = this.txtTechnicalContactPhone.Text;

        //Texas Viewing Locations
        int site_id, organization_id;

        Int32.TryParse(ddlRegion.SelectedValue, out organization_id);
        Int32.TryParse(ddlDistrict.SelectedValue, out site_id);

        mySessionRegistration._TexasViewingRegion = organization_id;
        mySessionRegistration._TexasViewingRegion3Site = site_id;

        //Connection INformation
        mySessionRegistration._ConnectionInfoIPNumber = this.txtConnectionInfoIPNumber.Text;
        mySessionRegistration._ConnectionInfoSystemType = this.txtConnectionInfoSystemType.Text;
        mySessionRegistration._ConnectionInfoBridgeInfo = this.txtConnectionInfoBridgeInfo.Text;
        mySessionRegistration._ConnectionInfoConnectionComments = this.txtConnectionInfoConnectionComments.Text;

        if (ShoppingCart.NumberOfSeatsAvailable(mySessionRegistration.Session.ID) >= 1)
        {
            ShoppingCart.Add(mySessionRegistration);
        }

        Response.Redirect(region4.escWeb.SiteVariables.RelativeURLs.shoppingCart);
    }

    protected virtual void RegionLoad(object sender, EventArgs e)
    {
        if (ddlRegion.Items.Count > 0)
            return;

        ddlRegion.Items.Add(new ListItem("Please select an ESC...", "-1"));
        using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "[p.objectModel.Location.Org.GetNet3ViewingOrganizationList]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                cmd.Connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string _displayName = reader["display"].ToString();
                        int _objId = (int)reader["obj_id"];
                        ddlRegion.Items.Add(new ListItem(_displayName, _objId.ToString()));
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
                cmd.Connection.Close();
            }
        }
    }

    protected virtual void SiteLoad(object sender, EventArgs e)
    {
        DropDownList list = sender as DropDownList;
        if (list == null)
            throw new Exception("Expected a dropdownlist but didn't get one");

        if (list.Items.Count > 0)
            return;
        list.Items.Add(new ListItem("Please select a viewing site...", "-1"));

        Net3ViewingLocations locations = Net3ViewingLocations.ReturnViewingLocations();
        foreach (Net3ViewingLocation location in locations)
            list.Items.Add(new ListItem(location.Display, location.obj_id.ToString()));
    }

    protected void RegionalEscChanged(object sender, EventArgs e)
    {
        lbErrorMessage.Text = string.Empty;

        int organization_id;
        Int32.TryParse(ddlRegion.SelectedValue, out organization_id);
        bool IsRegion3Esc = (organization_id == 27537); //27537	Region 3 ESC - Victoria

        if (IsRegion3Esc) //If it is Region 3 ESC
        {
            pRegion3ViewingLocation.Visible = true; 
            pTechnicalContact.Visible = false;      
            pConnectionInformation.Visible = false;
        }
        else
        {
            pRegion3ViewingLocation.Visible = false;
            pTechnicalContact.Visible = true;
            pConnectionInformation.Visible = true;
        }
    }

    protected void ViewingSiteChanged(object sender, EventArgs e)
    {
        lbErrorMessage.Text = string.Empty;

        int site_id;
        Int32.TryParse(ddlDistrict.SelectedValue, out site_id);

        //If Other, then System Type is required
        if (site_id == 80111) //	Other
        {
            pTechnicalContact.Visible = false;
            pConnectionInformation.Visible = true;
            pConnectionInfoIPNumber.Visible = false;
            labelConnectionInfoSystemType.Visible = true;
            pConnectionInfoSystemType.Visible = true;
            pConnectionInfoBridgeInfo.Visible = false;
        }
    }
}