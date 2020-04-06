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
using escWeb.tx_r19.ObjectModel;
using region4.ObjectModel;

public partial class catalog_session : region4.escWeb.BasePages.Catalog.session_aspx
{

    protected override void OnLoad(EventArgs e)
    {
        contentsTable.Visible = contentsTable1.Visible = true;
        base.OnLoad(e);
    }
    protected override void RenderSession(region4.ObjectModel.Session baseSession)
    {
        lblErrorMessage.Text = "";
        region4.ObjectModel.Session session = baseSession as region4.ObjectModel.Session;
        if (session == null || !session.DisplayOnWebOmitOnline)
        {
            lblErrorMessage.Text = Resources.catalog.unableToLoadSession;
            contentsTable1.Visible = contentsTable.Visible = false;
            return;
        }
        
        lblTitle.Text = session.Subtitle == "" ? session.Event.Title : String.Format("{0}<br /><em>{1}</em>",session.Event.Title, session.Subtitle);

        //panelRating.Visible = session.IsOnline;
        //radRatingSession.Value = session.AverageRating;
        //btnOpenReview.Text = "(" + session.CountRated.ToString() + " reviews)";
        //panelDetailedReviews.Controls.Add(base.ReturnRatingReviews(session));
        
        lblDescription.Text = session.Event.Description;

        escWeb.tx_r19.ObjectModel.Session mySession = session as escWeb.tx_r19.ObjectModel.Session;
        if (mySession.Dimensions != string.Empty)
        {
            plttess.Visible = true;
            lblTPESS.Text = mySession.Dimensions;
        }

        if (mySession.Standards != string.Empty)
        {
            plttess.Visible = true;
            if (mySession.Standards != string.Empty && mySession.Dimensions != string.Empty)
                lblTPESS.Text += "; " + mySession.Standards;
            else
                lblTPESS.Text += mySession.Standards;
        }

        lblWebComments.Text = session.WebComments;
        lblSessionID.Text = session.ID.ToString();

        lblCredits.Text = "";
        foreach (region4.ObjectModel.CreditItem item in session.Credits)
        {
            lblCredits.Text += String.Format("({0}) {1}<br />", item.Amount, item.Credit.Display);
        }

        if (session.Limit == 999999)
            lblSeatsFilled.Text = "No Limits"; //String.Format("{0}", session.NumberOfAttendeesRegistered);
        else
            lblSeatsFilled.Text = session.NumberOfSeatsAvailable.ToString();
        //if(session.Limit == 999999)
        //    lblSeatsFilled.Text = String.Format("{0}", session.NumberOfAttendeesRegistered);
        //else
        //    lblSeatsFilled.Text = String.Format("{0} / {1}", session.NumberOfAttendeesRegistered, session.Limit);

        lblContactPerson.Text = String.Format("<a href=\"mailto:{0}\" class=\"link\">{1} {2}</a>", session.ContactPerson.PrimaryEmail, session.ContactPerson.FirstName, session.ContactPerson.LastName);

        region4.ObjectModel.SessionRegistration registration = (escWeb.tx_r19.ObjectModel.SessionRegistration)region4.escWeb.SiteVariables.ObjectProvider.ReturnSessionRegistration(session, this.CurrentUser);
        lblFee.Text = String.Format("{0:c}", registration.ReturnUserFee());

        System.Text.StringBuilder instructors = new System.Text.StringBuilder();
        //instructors.AppendFormat("{0} {1}", session.PrimaryInstructor.FirstName, session.PrimaryInstructor.LastName);
     
        foreach (region4.ObjectModel.User user in session.AdditionalInstructors)
        {
            if(user.FirstName.ToLower()!="other")
                instructors.AppendFormat("{0} {1} <br/>", user.FirstName, user.LastName);
        }

        if (mySession.NonRegion19Instructors != "")
            instructors.Append(mySession.NonRegion19Instructors);
        
        lblInstructors.Text = instructors.ToString();

        System.Text.StringBuilder audiences = new System.Text.StringBuilder();
        foreach (region4.Item i in session.Event.Audiences)
            audiences.AppendFormat("{0} <br/>", i.Display);
        lblAudience.Text = audiences.ToString();

        pLocationPlaceHolder.Controls.Add(ReturnTimeLocationTable(session));

        if (session.NextSessionID > 0 || session.PrevSessionID > 0)
        {
            this.panelOnDemand.Visible = true;
        }

    }

   


    protected override void AssignControlsToBase()
    {
        base._btnRegister = btnRegister;
        base._btnGroupRegister = btnGroupRegister;
        base._btnWaitinglist = btnWaitingList;
        base._btnRemove = btnRemoveFromCart;
        base._lblRegistrationStatus = lblRegistrationStatus;
        base._recommendedEvents = recommendedEvents;
    }

    protected override HtmlTable ReturnTimeLocationTable(region4.ObjectModel.Session session)
    {
        if (session.IsOnline && (session.IsOnDemandOnline || session.IsSelfPacedOnline || session.IsInstructorLedOnline))
            return ReturnOnlineTimeLocationTable(session);

        HtmlTable table = new HtmlTable();
        table.Attributes.Add("border", "0");
        HtmlTableRow row = new HtmlTableRow();
        table.Rows.Add(row);

        //508 complaince
        row.Cells.Add(new HtmlTableCell("th"));
        row.Cells.Add(new HtmlTableCell("th"));
        row.Cells.Add(new HtmlTableCell("th"));

        table.Attributes.Add("class", "mainBody");
        table.Width = Unit.Percentage(100).ToString();
        row.Attributes.Add("style", "font-weight:bold");
        row.Cells[0].Attributes.Add("align", "left");
        row.Cells[0].Width = Unit.Percentage(25).ToString();
        row.Cells[1].Attributes.Add("align", "left");
        //row.Cells[1].Width = Unit.Percentage(22.5).ToString();
        row.Cells[2].Attributes.Add("align", "left");
        string Browser = System.Web.HttpContext.Current.Request.Browser.Browser;
        if (Browser == "InternetExplorer")
            row.Cells[2].Width = Unit.Percentage(52).ToString();
        else
            row.Cells[2].Width = Unit.Percentage(54).ToString();

        row.Cells[0].InnerText = "Date";
        row.Cells[1].InnerText = "Time";
        row.Cells[2].InnerText = "Location";

        row = new HtmlTableRow();
        table.Rows.Add(row);
        row.Cells.Add(new HtmlTableCell());
        row.Cells.Add(new HtmlTableCell());
        row.Cells.Add(new HtmlTableCell());
        row.Attributes.Add("valign", "top");

        string[] monthNames = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames;

        ArrayList groups = new ArrayList();
        DateTime currentStart, currentEnd;
        currentStart = currentEnd = new DateTime(1902, 1, 1);
        ScheduleHelper helper = new ScheduleHelper();
        foreach (ScheduleItem item in session.Schedule)
        {
            if (item.StartDate == currentStart && item.EndDate == currentEnd)//currentStart.Hour = item.StartDate.Hour && currentEnd.Hour == item.EndDate.Hour && currentStart.Minute == item.StartDate.Minute && currentEnd.Minute == item.EndDate.Minute)
            {
                helper.locations.Add(item.Location);
                helper.schedules.Add(item);
            }
            else
            {
                helper = new ScheduleHelper();
                helper.locations.Add(item.Location);
                helper.schedules.Add(item);
                groups.Add(helper);
            }
            currentEnd = item.EndDate;
            currentStart = item.StartDate;
        }

        foreach (ScheduleHelper h in groups)
        {
            row = new HtmlTableRow();
            table.Rows.Add(row);
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());
            row.Attributes.Add("valign", "top");

            row.Cells[0].InnerText = h.Dates;
            row.Cells[1].InnerText = h.Time;
            row.Cells[2].InnerHtml = h.Locations;
        }
        return table;
    }
}