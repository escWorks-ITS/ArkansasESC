using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using region4.ObjectModel;
using System.Web.UI;

namespace escWeb.tx_r19.ObjectModel
{
    [Serializable]
    public class Session : region4.ObjectModel.Session
    {
        private bool _qcApproved;

        public bool QCApproved
        {
            get { return _qcApproved; }
        }

        private string _nonRegion19Instructors;
        public string NonRegion19Instructors
        {
            get { return _nonRegion19Instructors; }
        }

        private string _dimensions = string.Empty;
        public string Dimensions { get { return this._dimensions; } }

        private string _standards = string.Empty;
        public string Standards { get { return this._standards; } }


        public Session(int session_id) : base(session_id)
        {
                    
        }

        protected override void LoadCustomerData(SqlDataReader reader)
        {
            this._allowPO = Convert.ToBoolean(reader["allowPO"]);
            this._qcApproved = Convert.ToBoolean(reader["QCApproved"]);
            this._nonRegion19Instructors = reader["NonRegion19Instructors"].ToString();
            this._dimensions = reader["dimensions"].ToString();
            this._standards = reader["standards"].ToString();
            this._PrevSessionID = (int)(reader["PrerequisiteSessionID"] == DBNull.Value ? -1 : reader["PrerequisiteSessionID"]);
            this._NextSessionID = (int)(reader["NextSessionID"] == DBNull.Value ? -1 : reader["NextSessionID"]);
        }



        public override bool DisplayOnWebOmitOnline
        {
            get
            {
                //Omit excluded event types from showing on the web.
                bool excludedType = false;
                int[] excludedTypes = region4.escWeb.SiteVariables.eventTypesToNotDisplay;
                for (int lcv = 0; lcv < excludedTypes.Length; lcv++)
                    excludedType |= excludedTypes[lcv] == this.Event.EventType.ItemId;

                //Omit sessions created by someone not in the specified organizations
                bool orgOkay = true;
                if (region4.escWeb.SiteVariables.LimitSessionsToOrganizations)
                    orgOkay = region4.escWeb.SiteVariables.LimitSessionOrganizations.Contains(this.ObjectCreator.Location.Site.Organization.OrganizationID);

                //Omit sessions crated by someone not in the specified sites
                bool siteOkay = true;
                if (region4.escWeb.SiteVariables.LimitSessionsToSite)
                    siteOkay = region4.escWeb.SiteVariables.LimitSessionSites.Contains(this.ObjectCreator.Location.Site.SiteID);

                //Omit sessions from site customers that aren't in thier specified front-ends
                bool siteCustomerOkay = true;
                if (region4.escWeb.SiteVariables.LimitToEscWorksSiteCustomerID > 0)
                    siteCustomerOkay = region4.escWeb.SiteVariables.LimitToEscWorksSiteCustomerID != this.ObjectCreator.Location.Site.SiteID;

                return this._qcApproved && this._approved && this._active && !excludedType && orgOkay && siteOkay && siteCustomerOkay;
            }
        }

        public override int Limit
        {
            get
            {
                if (IsSelfPacedOnline || (IsOnDemandOnline && _limit == 0))
                    return 999999;
                else
                    return _limit;
            }

        }

        public override  HtmlTableRow DisplayOneBreakoutSessionForConference(System.Web.HttpContext context, region4.escWeb.BasePage page, bool sessionTimesSame, int conferenceId, int ItemId)
        {
            HtmlTableRow row;

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].Attributes.Add("class", "breakoutAltRow");

            string result = string.Empty;
            //SessionRegistration registration = new SessionRegistration(this, page.CurrentUser);
            region4.ObjectModel.SessionRegistration registration = region4.escWeb.SiteVariables.ObjectProvider.ReturnSessionRegistration(this, page.CurrentUser);
            decimal userFee = registration.ReturnUserFee();
            if (sessionTimesSame)
                result = String.Format("<b>Session ID: {0}</b><br/>{1}<br/>Seats Filled: {2} / {3}", ID, Subtitle, NumberOfAttendeesRegistered, Limit);
            else
                result = String.Format("<b>Session ID: {0}</b><br/>{1}<br/>Date/Time: {4:D} {4:t} - {5:t}<br />Seats Filled: {2} / {3}",
                                                                ID, Subtitle, NumberOfAttendeesRegistered, Limit, StartDate, EndDate);
            result += "<br/> Contact Person: " + String.Format("<a href=\"mailto:{0}\" class=\"link\">{1}</a>", ContactPerson.PrimaryEmail, ContactPerson.FullName);  

            if (userFee > 0)
                result += String.Format("<br />Fee: {0:c}", userFee);

            result += "<br />Location:" + SiteRoomDisplay;

            if (!String.IsNullOrEmpty(WebComments))
                result += "<br /><br /><b>Important Breakout Information:</b><br />" + WebComments;

            result += "<hr />";

            row.Cells[0].InnerHtml = result;

            Button button = new Button();
            button.CommandArgument = this.ID.ToString();
            button.ID = String.Format("btnRegister_Session_{0}", this.ID);
            button.Attributes.Add("aria-label", "Select Session ID " + this.ID.ToString()); //508 complaince
            button.Attributes.Add("aria-labelledby", ItemId.ToString());
            //button.Attributes.Add("aria-describedby", this.ID.ToString()); //508 complaince

            bool bDisplayRegisterButton = false;
            if (page.CurrentUser.isDistrictRegister || page.CurrentUser.isCampusRegister || page.CurrentUser.isGlobalRegister)
            {
                bDisplayRegisterButton = region4.escWeb.SiteVariables.ObjectProvider.DisplayGroupRegisterButton(this, page, context);
            }
            else
            {
                bDisplayRegisterButton = region4.escWeb.SiteVariables.ObjectProvider.DisplayRegisterButton(this, page, context);
            }
            button.Visible = bDisplayRegisterButton;
            row.Cells[1].Controls.Add(button);

            ConferenceRegistration conferenceRegistration = region4.WebControls.ConferenceSelection.GetCurrentConferenceRegistration(conferenceId, region4.escWeb.SiteVariables.ObjectProvider.ReturnUser(Guid.Empty));

            if (SessionSelected(conferenceRegistration.SessionIDList, this.ID))
            {
                button.Text = "Remove";
                button.OnClientClick = "SelectButtonClick(this, " + conferenceId + ", " + this.ID.ToString() + ");return false;";
            }
            else
            {
                button.Text = "Select";
                button.OnClientClick = "SelectButtonClick(this, " + conferenceId + ", " + this.ID.ToString() + ");return false;";
            }

            LiteralControl lblSessionFull = new LiteralControl(this.RegistrationStatusForConference(context, page, page.CurrentUser.isDistrictRegister || page.CurrentUser.isCampusRegister || page.CurrentUser.isGlobalRegister));
            lblSessionFull.Visible = !bDisplayRegisterButton;
            row.Cells[1].Controls.Add(lblSessionFull);
            //row.Cells[0].InnerHtml += String.Format("<br/>");
            row.Cells[1].Style.Add("text-align", "center");

            return row;
        }
    }
}