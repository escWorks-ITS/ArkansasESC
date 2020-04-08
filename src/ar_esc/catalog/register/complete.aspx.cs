using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class catalog_register_complete : region4.escWeb.BasePages.Catalog.Register.complete_aspx //region4.escWeb.BasePage, System.Web.UI.INamingContainer
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void AssignControlsToBase()
    {
        base._registrationTable = registrationTable;
        base._panelPaymentVoucher = panelPaymentVoucher;
        base._lnkPaymentVoucher = aVoucher;
    }

    /*
    public Guid registrationId;
   // protected HtmlTable _registrationTable;
    protected HtmlAnchor _lnkPaymentVoucher;
    protected Panel _panelPaymentVoucher;
    protected Panel _panelOnDemand;
    protected Button _btnContinue;

    protected void Page_Init(object sender, EventArgs e)
    {
        string guid = escWorks.Tools.Strings.CleanUp("id", true, false);
        registrationId = new Guid(guid);

       

        if (_btnContinue != null)
            _btnContinue.Click += new EventHandler(btnContinue_Click);
    }

   // protected abstract void AssignControlsToBase();

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (this._btnContinue != null)
            this._btnContinue.Visible = this.ShoppingCart.ItemCount > 0;
    }

    protected override void CreateChildControls()
    {
        List<region4.ObjectModel.Attendee> attendees = region4.ObjectModel.Attendee.ReturnAttendeesByRegistrationID(registrationId);

        if (_lnkPaymentVoucher != null)
            _lnkPaymentVoucher.HRef = String.Format("javascript:openUrl('../../shoebox/registration/paymentvoucher.aspx?id={0}')", registrationId.ToString());

        if (_panelPaymentVoucher != null)
            _panelPaymentVoucher.Visible = true;

        if (_panelOnDemand != null)
        {
            foreach (region4.ObjectModel.Attendee attendee in attendees)
            {
                if (attendee.Session.IsOnDemandOnline)
                {
                    _panelOnDemand.Visible = true;
                    panelPaymentVoucher.Visible = false;
                    break;
                }
            }
        }
        else
        {

            foreach (region4.ObjectModel.Attendee attendee in attendees)
            {
                if (attendee.Session.SiteRoomDisplay == "University of Central Arkansas - UCA STEM  Institute, University of Central Arkansas - College of Education")
                {
                  
                    panelPaymentVoucher.Visible = false;
                    break;
                }
            }
        }

        RenderPage(attendees);
    }

    protected  void RenderPage(List<region4.ObjectModel.Attendee> attendees)
    {
        registrationTable.Rows.Clear();
        registrationTable.Width = Unit.Percentage(100).ToString();
        registrationTable.Border = 1;
        registrationTable.Style.Add("border-collapse", "collapse");
        registrationTable.Attributes.Add("class", "mainBody");


        HtmlTableRow row = new HtmlTableRow();
        row.Cells.Add(new HtmlTableCell());
        row.Cells.Add(new HtmlTableCell());
        row.Cells.Add(new HtmlTableCell());
        row.Cells.Add(new HtmlTableCell());
        row.Cells.Add(new HtmlTableCell());

        row.Cells[0].InnerHtml = "&nbsp;";
        row.Cells[1].InnerText = "Title";
        row.Cells[2].InnerText = String.Format("{0} ID", region4.escWeb.SiteVariables.ObjectProvider.SessionNameCapitalized);
        row.Cells[3].InnerText = "Start Date";
        row.Cells[4].InnerText = "Location";

        row.Cells[0].Attributes.Add("class", "tableHeading");
        row.Cells[1].Attributes.Add("class", "tableHeading");
        row.Cells[2].Attributes.Add("class", "tableHeading");
        row.Cells[3].Attributes.Add("class", "tableHeading");
        row.Cells[4].Attributes.Add("class", "tableHeading");

        registrationTable.Rows.Add(row);

        foreach (region4.ObjectModel.Attendee attendee in attendees)
        {
            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());

            ImageButton button = new ImageButton();
            button.ImageUrl = "~/lib/img/buttons/calendar.png";
            button.AlternateText = "Get Calendar";
            button.Click += new System.Web.UI.ImageClickEventHandler(btnGetCalendar_Click);
            button.CommandArgument = attendee.ID.ToString();

            bool isConference = attendee.Session.Event is region4.ObjectModel.Conference;

            row.Cells[0].Controls.Add(button);
            //                row.Cells[1].InnerHtml = isConference ? String.Format("{0}<br /><em>{1} ({2} {3})</em>",attendee.Session.Title, attendee.Session.Subtitle,attendee.User.FirstName, attendee.User.LastName) : attendee.Session.Title;
            row.Cells[1].InnerHtml = String.Format("{0}<br /><em>{1} ({2} {3})</em>", attendee.Session.Title, attendee.Session.Subtitle, attendee.User.FirstName, attendee.User.LastName);
            row.Cells[2].InnerText = attendee.Session.ID.ToString();
            row.Cells[3].InnerText = String.Format("{0:d} {0:t}", attendee.Session.StartDate, attendee.Session.StartDate);
            row.Cells[4].InnerText = attendee.Session.SiteRoomDisplay;

            registrationTable.Rows.Add(row);

        }
    }

    protected void btnGetCalendar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        ImageButton link = sender as ImageButton;
        if (link == null)
            throw new Exception("expected a ImageButton but didn't get one");

        int attendee_id;
        if (!Int32.TryParse(link.CommandArgument, out attendee_id))
            throw new Exception("Unable to parse attendee id");

        region4.ObjectModel.Attendee attendee = region4.escWeb.SiteVariables.ObjectProvider.ReturnAttendee(attendee_id);

        Response.Clear();
        Response.ClearHeaders();
        Response.ContentType = "text/calendar;name=" + attendee.Session.Title;
        Response.AddHeader("Content-disposition", "attachment; filename=" + attendee.Session.Title + ".ics");
        IcsFileBuilder iCalBuilder = new IcsFileBuilder(attendee);
        Response.Write(iCalBuilder.BuildOneIcsFile());
        Response.Flush();
        Response.End();

    }

    void btnContinue_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/catalog/register/cart.aspx");
    }
     * 
     * */
}
