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
using escWeb.ar_esc.ObjectModel;

public partial class catalog_session : region4.escWeb.BasePages.Catalog.session_aspx
{
    public string server = string.Empty;
    protected override void OnLoad(EventArgs e)
    {
        contentsTable.Visible = contentsTable1.Visible = true;
        base.OnLoad(e);
    }
    protected override void RenderSession(region4.ObjectModel.Session baseSession)
    {
        lblErrorMessage.Text = "";
        Session session = baseSession as Session;
        if (session == null || !session.DisplayOnWebOmitOnline)
        {
            lblErrorMessage.Text = Resources.catalog.unableToLoadSession;
            contentsTable1.Visible = contentsTable.Visible = false;
            return;
        }

        lblTitle.Text = session.Subtitle == "" ? session.Event.Title : String.Format("{0}<br /><em>{1}</em>", session.Event.Title, session.Subtitle);

        //panelRating.Visible = session.IsOnline;
        //radRatingSession.Value = session.AverageRating;
        //btnOpenReview.Text = "(" + session.CountRated.ToString() + " reviews)";
        //panelDetailedReviews.Controls.Add(base.ReturnRatingReviews(session));

        lblDescription.Text = session.Event.Description;
        lblWebComments.Text = session.WebComments;
        lblSessionID.Text = session.ID.ToString();

        lblCredits.Text = "";
        foreach (region4.ObjectModel.CreditItem item in session.Credits)
        {
            lblCredits.Text += String.Format("({0}) {1}<br />", item.Amount, item.Credit.Display);
        }

        if (session.Limit == 999999)
            lblSeatsFilled.Text = String.Format("{0}", session.NumberOfAttendeesRegistered);
        else
            lblSeatsFilled.Text = String.Format("{0} / {1}", session.NumberOfAttendeesRegistered, session.Limit);

        lblContactPerson.Text = String.Format("<a href=\"mailto:{0}\" class=\"link\">{1} {2}</a>", session.ContactPerson.PrimaryEmail, session.ContactPerson.FirstName, session.ContactPerson.LastName);

        SessionRegistration registration = (escWeb.ar_esc.ObjectModel.SessionRegistration)region4.escWeb.SiteVariables.ObjectProvider.ReturnSessionRegistration(session, this.CurrentUser);
        lblFee.Text = String.Format("{0:c}", registration.ReturnUserFee());

        System.Text.StringBuilder instructors = new System.Text.StringBuilder();
        //instructors.AppendFormat("{0} {1}", session.PrimaryInstructor.FirstName, session.PrimaryInstructor.LastName);
        foreach (User user in session.AdditionalInstructors)
            instructors.AppendFormat("{0} {1} <br/>", user.FirstName, user.LastName);
        lblInstructors.Text = instructors.ToString();


        foreach (region4.Item item in session.Event.Audiences)
        {
            lblAudiences.Text += item.Display + ", ";
        }
        if (lblAudiences.Text.Trim().Length > 1)
            lblAudiences.Text = lblAudiences.Text.Substring(0, lblAudiences.Text.Length - 2);
        if (lblAudiences.Text.Trim().Length == 0)
            lblAudience.Visible = false;
        pLocationPlaceHolder.Controls.Add(ReturnTimeLocationTable(session));
    }

    protected override HtmlTable ReturnTimeLocationTable(region4.ObjectModel.Session session)
    {
        if (session.IsOnline && (session.IsOnDemandOnline || session.IsSelfPacedOnline || session.IsInstructorLedOnline))
            return ReturnOnlineTimeLocationTable(session);

        HtmlTable table = new HtmlTable();
        HtmlTableRow row = new HtmlTableRow();
        table.Width = Unit.Percentage(100).ToString();
        table.Rows.Add(row);
        row.Cells.Add(new HtmlTableCell());
        row.Cells.Add(new HtmlTableCell());
        row.Cells.Add(new HtmlTableCell());
        table.Attributes.Add("class", "mainBody");

        row.Attributes.Add("style", "font-weight:bold");

        row.Cells[0].InnerText = "Date";
        row.Cells[0].Width = Unit.Pixel(80).ToString();
        row.Cells[1].InnerText = "Time"; 
        row.Cells[2].InnerText = "Location";
        row.Cells[2].Width = Unit.Pixel(420).ToString();

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
        foreach (region4.ObjectModel.ScheduleItem item in session.Schedule)
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


    protected override void AssignControlsToBase()
    {
        base._btnRegister = btnRegister;
        base._btnGroupRegister = btnGroupRegister;
        base._btnWaitinglist = btnWaitingList;
        base._btnRemove = btnRemoveFromCart;
        base._lblRegistrationStatus = lblRegistrationStatus;
        base._recommendedEvents = recommendedEvents;
    }
}
