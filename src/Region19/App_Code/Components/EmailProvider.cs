using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for EmailProvider
/// </summary>
public class EmailProvider : region4.Utilities.Email.baseEmailProvider
{
    protected override string CustomerLogoUrl
    {
        get
        {
            return "lib/img/R19-logo-small.jpg";
        }
    }

    public override  HtmlTable ReturnConfirmationReport(region4.ObjectModel.Attendee attendee, bool embedLogo)
    {
        //Render HtmlTable
        HtmlTable table = new HtmlTable();
        table.Width = "75%";

        HtmlTableRow row;

        if (CustomerLogo != null)
        {
            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].Align = "left";
            row.Cells[0].Width = "50%";
            row.Cells[0].InnerHtml = String.Format("<img src=\"{0}\" alt=\"Customer Logo\"/>", embedLogo ? "cid:customerLogo" : pathToRoot + CustomerLogoUrl);
            row.Cells.Add(new HtmlTableCell());
            row.Cells[1].Align = "right";
            row.Cells[1].Width = "50%";

            row.Cells[1].InnerHtml = String.Format("<a href=\"{0}\">Manage Your Account</a>&nbsp;|&nbsp;<a href=\"{1}\">Courses</a>",
                    region4.escWeb.SiteVariables.CustomerHostUrl + "shoebox/registration/default.aspx",
                    region4.escWeb.SiteVariables.CustomerHostUrl + "search.aspx"
                                                                    );

            table.Rows.Add(row);
        }

        //Date
        row = new HtmlTableRow();
        row.Cells.Add(new HtmlTableCell());
        row.Cells[0].ColSpan = 2;
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        builder.AppendFormat("<br /><br />{0}, {1} {2}, {3} at {4:t}<br /><br />", System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames[(int)attendee.RegistrationTime.DayOfWeek], System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames[(int)attendee.RegistrationTime.Month - 1], attendee.RegistrationTime.Day, attendee.RegistrationTime.Year, attendee.RegistrationTime);
        builder.AppendFormat("{0} {1} <br />", attendee.User.FirstName, attendee.User.LastName);

        if (!String.IsNullOrEmpty(attendee.User.Address))
        {
            builder.AppendFormat("{0}<br />", attendee.User.Address);
            builder.AppendFormat("{0}, {1} {2} <br /> <br />", attendee.User.City, attendee.User.State, attendee.User.Zip);
        }
        else
            builder.Append("<br /><br />");

        builder.AppendFormat("<div style=\"font-size: 12pt; font-weight: bold\">Confirmation Number: <font color=\"green\">{0}-{1}-{2}</font></div>", attendee.Session.Event.EventID, attendee.Session.ID, attendee.ID);
        builder.AppendFormat("<br />Thank you for your registration. This confirms your registration for the following class by {0}. If payment was required, your receipt is included in the Payments Received section below.<br/><br/>", attendee.Creator.FullName);

        builder.AppendFormat("<span style=\"font-weight: bold;\">{0}</span><br /><br /><b>{1}</b><br /><br/>", attendee.Session.Event.Title, string.IsNullOrEmpty(attendee.Session.Subtitle) ? attendee.Session.EventId.ToString() : attendee.Session.Subtitle);

        builder.AppendFormat("<strong>Session ID: </strong>{0}<br /><br />", attendee.Session.ID);

        row.Cells[0].InnerHtml = builder.ToString();

        table.Rows.Add(row);

        //For online session
        if (attendee.Session.IsOnline)
        {
            row = new HtmlTableRow(); //Location
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());

            row.Cells[0].InnerHtml = "<b>Location:<b>";
            row.Cells[1].InnerHtml = "Online";
            table.Rows.Add(row);

            if (attendee.Session.IsSelfPacedOnline || attendee.Session.IsOnDemandOnline)
            {
                row = new HtmlTableRow(); //Subscription length
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());

                row.Cells[0].InnerHtml = "<b>Subscription Length:<b>";
                row.Cells[1].InnerHtml = attendee.Session.SubscriptionLength;
                table.Rows.Add(row);

                row = new HtmlTableRow(); //Expiration Date
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());

                row.Cells[0].InnerHtml = "<b>Expiration Date:<b>";
                row.Cells[1].InnerHtml = attendee.Session.OnlineExpirationDate.ToShortDateString();
                table.Rows.Add(row);

            }
            else
            {
                row = new HtmlTableRow(); //Dates
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());

                row.Cells[0].InnerHtml = "<b>Dates:<b>";
                row.Cells[1].InnerHtml = attendee.Session.StartDate.ToShortDateString() + " - " + attendee.Session.EndDate.ToShortDateString();
                table.Rows.Add(row);

            }
        }
        else
        {
            //Date/Time Location
            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());


            DateTime currentStart, currentEnd;
            currentStart = currentEnd = new DateTime(1919, 10, 9);

            row.Cells[0].InnerHtml = "<b>Dates/Times:<b>";
            row.Cells[1].InnerHtml = "<b>Location:</b>";
            table.Rows.Add(row);

            foreach (region4.ObjectModel.ScheduleItem schedule in attendee.Session.Schedule)
            {
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());

                if (schedule.StartDate == currentStart && schedule.EndDate == currentEnd)
                    continue;
                row.Cells[0].InnerHtml = String.Format("{0:d} {0:t} - {1:t}<br />", schedule.StartDate, schedule.EndDate);
                currentStart = schedule.StartDate;
                currentEnd = schedule.EndDate;
                region4.ObjectModel.Room room = schedule.Location;
                row.Cells[1].InnerHtml += string.Format("{0}:{1} {2} {3}, {4} {5}<br />", room.Site.Name, room.Name,
                   room.Site.IsServiceCenter ? room.Site.Address1 : room.Address1,
                    room.Site.IsServiceCenter ? room.Site.City : room.City,
                    room.Site.IsServiceCenter ? room.Site.State : room.State,
                    room.Site.IsServiceCenter ? room.Site.Zip : room.Zip);
                table.Rows.Add(row);
            }
        }

        if (!String.IsNullOrEmpty(attendee.Session.ConfirmationComments))
        {
            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].ColSpan = 2;
            row.Cells[0].InnerHtml = String.Format("<b>Additional Information:</b><br />{0}", attendee.Session.ConfirmationComments);
            table.Rows.Add(row);
        }

        table.Rows.Add(row);


        if (attendee.Payments.Count > 0)
        {
            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].ColSpan = 2;

            row.Cells[0].InnerHtml = "<strong><br />Payments Received/Submitted:</strong><br />The following payments have been received for/submitted to your account:<br /><br />";

            table.Rows.Add(row);

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].ColSpan = 2;

            HtmlTable detailTable = new HtmlTable();
            HtmlTableRow detailRow = new HtmlTableRow();


            detailTable.Style.Add("border", "solid #c0c0c0 1px");
            detailTable.Style.Add("border-collapse", "collapse");
            detailTable.Align = "center";
            detailTable.Width = "100%";


            detailRow = new HtmlTableRow();
            detailRow.Cells.Add(new HtmlTableCell());
            detailRow.Cells.Add(new HtmlTableCell());
            detailRow.Cells.Add(new HtmlTableCell());
            detailRow.Cells.Add(new HtmlTableCell());
            detailRow.Cells.Add(new HtmlTableCell());


            detailRow.Style.Add("font-weight", "bold");

            detailRow.Cells[0].InnerText = "Date Submitted";
            detailRow.Cells[1].InnerText = "Payment Type";
            detailRow.Cells[2].InnerText = "Amount";
            detailRow.Cells[3].InnerText = "Status";
            detailRow.Cells[4].InnerText = "Reference/Receipt";

            detailTable.Rows.Add(detailRow);

            foreach (region4.ObjectModel.PaymentItem p in attendee.Payments)
            {
                detailRow = new HtmlTableRow();
                detailRow.Cells.Add(new HtmlTableCell());
                detailRow.Cells.Add(new HtmlTableCell());
                detailRow.Cells.Add(new HtmlTableCell());
                detailRow.Cells.Add(new HtmlTableCell());
                detailRow.Cells.Add(new HtmlTableCell());

                detailRow.Cells[0].Style.Add("border", "1px solid #c0c0c0");
                detailRow.Cells[1].Style.Add("border", "1px solid #c0c0c0");
                detailRow.Cells[2].Style.Add("border", "1px solid #c0c0c0");
                detailRow.Cells[3].Style.Add("border", "1px solid #c0c0c0");
                detailRow.Cells[4].Style.Add("border", "1px solid #c0c0c0");

                detailRow.Cells[0].InnerText = String.Format("{0:d}", p.timestamp.Date);
                detailRow.Cells[1].InnerText = p.type.Display;
                detailRow.Cells[2].InnerText = String.Format("{0:c}", p.amount);
                detailRow.Cells[3].InnerText = p.status;
                detailRow.Cells[4].InnerHtml = "&nbsp;" + p.reference;

                detailTable.Rows.Add(detailRow);
            }

            row.Cells[0].Controls.Add(detailTable);
            table.Rows.Add(row);
        }

        row = new HtmlTableRow();
        row.Cells.Add(new HtmlTableCell());
        row.Cells[0].ColSpan = 2;
        row.Cells[0].Align = "left";
        row.Cells[0].InnerHtml = String.Format("<br/><b>Questions?</b></br>Manage your <a href=\"{0}\">registrations online</a><br/><br/>",
                                        region4.escWeb.SiteVariables.CustomerHostUrl + "shoebox/registration/default.aspx");
        table.Rows.Add(row);

        //policies
        row = new HtmlTableRow();
        row.Cells.Add(new HtmlTableCell());
        row.Cells[0].ColSpan = 2;
        row.Cells[0].Align = "left";
        row.Cells[0].InnerHtml = "<b><u>Payment Policy: </u></b> For events that require a registration fee, payment must be received prior to the event. To facilitate the onsite registration process, present a copy of a purchase order or proof of payment.  Please email purchase order" +
                                " to <a href='mailto:eventsmanagement@esc19.net'>eventsmanagement@esc19.net</a> or fax to (915) 780-5034.  Certificate of Attendance will not be available until payment is received. <br /><br />" +
                                "<b><u>Cancellation and Refund Policy: </u></b>Cancellation requests will be considered on an individual basis and refunds are not guaranteed. Cancellation must be requested at least five business days prior to the workshop for a full refund. " +
                                "No refunds are given for cancellations less than five business days prior to the workshop. Telephone requests for cancellations will not be accepted.  Districts/campuses are encouraged to  substitute personnel if the person registered is unable " +
                                "to attend.<br /><br /> Refund request must include your name, address, daytime phone number, the event number and session name. Please allow up to four weeks to process your refund.  No refunds will be given on or after the first meeting date or " +
                                "for non-attendance. <br /><br /> Please email your cancellation request to <a href='mailto:eventsmanagement@esc19.net'>eventsmanagement@esc19.net</a> or fax to (915) 780-5034. For additional questions and/or assistance please contact:  " +
                                "Events Management at (915) 780-5055. <br /><br /><b><u>Other: </u></b>ESC-Region 19 is not equipped to safely accommodate children in our facility.  Please help us ensure the safety of your children by making other arrangements for their care, while attending any conference or session." +
                                "<br /><br /><b><u>Photo/Media Release Disclaimer: </u> </b> By registering you are consenting to the possibility of being photographed and/or recorded during this event for publications, news releases, instructional materials, online and in other communications related to the mission of Education Service Center - Region 19 and/or the organizer of the session or event.  Upon registration and attendance, you acknowledge and agree to the terms contained in the consent and release Education Service Center - Region 19 of any liability as related to any digital photography, video streaming, video recordings, and/or print images published.</br></br>";
        table.Rows.Add(row);

        row = new HtmlTableRow();
        row.Cells.Add(new HtmlTableCell());
        row.Cells[0].ColSpan = 2;
        row.Cells[0].Align = "center";
        row.Cells[0].InnerHtml = "<a href=\"http://www.esc19.net/\"><font color=\"green\">Region 19 Education Service Center</font></a> 6611 Boeing Drive, El Paso, TX 79925 | T (915) 780-5055  ";
        table.Rows.Add(row);

        row = new HtmlTableRow();
        row.Cells.Add(new HtmlTableCell());
        row.Cells[0].ColSpan = 2;
        row.Cells[0].Align = "right";

        row.Cells[0].InnerHtml = String.Format("<br /><br /><img src=\"{0}\" alt=\"Customer Logo\" />", embedLogo ? "cid:escWorksLogo" : pathToRoot + "lib/img/pwrdby_clear.gif");
        table.Rows.Add(row);

        return table;
    }
   
}
