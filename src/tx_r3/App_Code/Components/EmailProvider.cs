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
            return "lib/img/r3_logo_small.jpg";
        }
    }
    public override HtmlTable ReturnConfirmationReport(region4.ObjectModel.Attendee attendee, bool embedLogo)
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
            row.Cells[0].InnerHtml = String.Format("<img src=\"{0}\" alt=\"Customer Logo\" />", embedLogo ? "cid:customerLogo" : pathToRoot + CustomerLogoUrl);
            row.Cells.Add(new HtmlTableCell());
            row.Cells[1].Align = "right";
            row.Cells[1].Width = "50%";
            row.Cells[1].InnerHtml = String.Format("<a href=\"{0}\">Manage Your Account</a>&nbsp;|&nbsp;<a href=\"{1}\">Courses</a>",
                ConfigurationManager.AppSettings["database.activeserver"] == "dev" ? "http://dev.escweb.net/tx_r3/shoebox/registration/default.aspx" : "http://www.escweb.net/tx_r3/shoebox/registration/default.aspx",
                ConfigurationManager.AppSettings["database.activeserver"] == "dev" ? "http://dev.escweb.net/tx_r3/search.aspx" : "http://www.escweb.net/tx_r3/search.aspx");
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

        if (attendee.Creator != null)
            builder.AppendFormat("<br />Thank you for your registration. This confirms your registration for the following class by {0}. If payment was required, your receipt is included in the Payments Received section below.<br/><br/>", attendee.Creator.FullName);
        else
            builder.AppendFormat("<br />Thank you for your registration. This confirms your registration for the following class. If payment was required, your receipt is included in the Payments Received section below.<br/><br/>");


        if (!String.IsNullOrEmpty(attendee.Session.Subtitle))
            builder.AppendFormat("<span style=\"font-weight: bold;\">{0}</span><br />{1}<br />{2}<br /> <br />", attendee.Session.Event.Title, attendee.Session.Subtitle, attendee.Session.Event.Description);
        else
            builder.AppendFormat("<span style=\"font-weight: bold;\">{0}</span><br />{2}<br /> <br />", attendee.Session.Event.Title, attendee.Session.Subtitle, attendee.Session.Event.Description);

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
                row.Cells[1].InnerHtml = (attendee.Session.StartDate.ToString().Contains("12:00:00 AM") ? attendee.Session.StartDate.ToShortDateString() : attendee.Session.StartDate.ToString()) + " - " + (attendee.Session.EndDate.ToString().Contains("12:00:00 AM") ? attendee.Session.EndDate.ToShortDateString() : attendee.Session.EndDate.ToString());
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

        #region Net 3 Information

        //For Net3
        escWeb.tx_r3.ObjectModel.Event myEvent = attendee.Session.Event as escWeb.tx_r3.ObjectModel.Event;
        if (myEvent.IsNet3Event || myEvent.IsNet3StudentEvent)
        {
            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].ColSpan = 2;
            row.Cells[0].InnerHtml = String.Format("");
            table.Rows.Add(row);

            escWeb.tx_r3.ObjectModel.Attendee myAttendee = attendee as escWeb.tx_r3.ObjectModel.Attendee;
            if (myEvent.IsNet3StudentEvent)
            {
                //Requester Information
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                row.Cells[0].ColSpan = 2;
                row.Cells[0].InnerHtml = String.Format("<b>Requester Information:</b>");
                table.Rows.Add(row);

                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());
                row.Cells[0].InnerHtml = String.Format("Requester Name:");
                row.Cells[1].InnerHtml = String.Format("{0}", myAttendee.RequesterName);
                table.Rows.Add(row);

                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());
                row.Cells[0].InnerHtml = String.Format("Requester Email:");
                row.Cells[1].InnerHtml = String.Format("{0}", myAttendee.RequesterEmail);
                table.Rows.Add(row);

                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());
                row.Cells[0].InnerHtml = String.Format("Requester Phone:");
                row.Cells[1].InnerHtml = String.Format("{0}", myAttendee.RequesterPhone);
                table.Rows.Add(row);

                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());
                row.Cells[0].InnerHtml = String.Format("Requester Position:");
                row.Cells[1].InnerHtml = String.Format("{0}", myAttendee.RequesterPosition);
                table.Rows.Add(row);
            }

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].ColSpan = 2;
            row.Cells[0].InnerHtml = String.Format("");
            table.Rows.Add(row);

            //Teacher Information
            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].ColSpan = 2;
            row.Cells[0].InnerHtml = String.Format("<b>Teacher Information:</b>");
            table.Rows.Add(row);

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].InnerHtml = String.Format("Teacher Name:");
            row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._TeacherName);
            table.Rows.Add(row);

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].InnerHtml = String.Format("Teacher Email:");
            row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._TeacherEmail);
            table.Rows.Add(row);

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].InnerHtml = String.Format("Teacher Phone:");
            row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._TeacherPhone);
            table.Rows.Add(row);

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].InnerHtml = String.Format("District Name:");
            row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._TeacherDistrictName);
            table.Rows.Add(row);

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].InnerHtml = String.Format("Campus Name:", myAttendee._TeacherCampusName);
            row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._TeacherCampusName);
            table.Rows.Add(row);

            if (myEvent.IsNet3StudentEvent)
            {
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());
                row.Cells[0].InnerHtml = String.Format("Total Number of Students Viewing Program:");
                row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._TeacherTotalNumberStudents);
                table.Rows.Add(row);
            }

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].InnerHtml = String.Format("City:");
            row.Cells[0].InnerHtml = String.Format("{0}", myAttendee._TeacherCity);
            table.Rows.Add(row);

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].InnerHtml = String.Format("State:");
            row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._TeacherState);
            table.Rows.Add(row);

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].InnerHtml = String.Format("Zip Code:");
            row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._TeacherZipCode);
            table.Rows.Add(row);

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].InnerHtml = String.Format("Country:");
            row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._TeacherCountry);
            table.Rows.Add(row);

            if (myEvent.IsNet3StudentEvent)
            {
                if (!string.IsNullOrEmpty(myAttendee._Teacher2Name))
                {
                    row = new HtmlTableRow();
                    row.Cells.Add(new HtmlTableCell());
                    row.Cells.Add(new HtmlTableCell());
                    row.Cells[0].InnerHtml = String.Format("Teacher 2 Name:");
                    row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._Teacher2Name);
                    table.Rows.Add(row);
                }
                if (!string.IsNullOrEmpty(myAttendee._Teacher2Email))
                {
                    row = new HtmlTableRow();
                    row.Cells.Add(new HtmlTableCell());
                    row.Cells.Add(new HtmlTableCell());
                    row.Cells[0].InnerHtml = String.Format("Teacher 2 Email:");
                    row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._Teacher2Email);
                    table.Rows.Add(row);
                }

                if (!string.IsNullOrEmpty(myAttendee._Teacher3Name))
                {
                    row = new HtmlTableRow();
                    row.Cells.Add(new HtmlTableCell());
                    row.Cells.Add(new HtmlTableCell());
                    row.Cells[0].InnerHtml = String.Format("Teacher 3 Name:");
                    row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._Teacher3Name);
                    table.Rows.Add(row);
                }
                if (!string.IsNullOrEmpty(myAttendee._Teacher3Email))
                {
                    row = new HtmlTableRow();
                    row.Cells.Add(new HtmlTableCell());
                    row.Cells.Add(new HtmlTableCell());
                    row.Cells[0].InnerHtml = String.Format("Teacher 3 Email:");
                    row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._Teacher3Email);
                    table.Rows.Add(row);
                }

                if (!string.IsNullOrEmpty(myAttendee._Teacher4Name))
                {
                    row = new HtmlTableRow();
                    row.Cells.Add(new HtmlTableCell());
                    row.Cells.Add(new HtmlTableCell());
                    row.Cells[0].InnerHtml = String.Format("Teacher 4 Name:");
                    row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._Teacher4Name);
                    table.Rows.Add(row);
                }
                if (!string.IsNullOrEmpty(myAttendee._Teacher4Email))
                {
                    row = new HtmlTableRow();
                    row.Cells.Add(new HtmlTableCell());
                    row.Cells.Add(new HtmlTableCell());
                    row.Cells[0].InnerHtml = String.Format("Teacher 4 Email:");
                    row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._Teacher4Email);
                    table.Rows.Add(row);
                }

                if (!string.IsNullOrEmpty(myAttendee._Teacher5Name))
                {
                    row = new HtmlTableRow();
                    row.Cells.Add(new HtmlTableCell());
                    row.Cells.Add(new HtmlTableCell());
                    row.Cells[0].InnerHtml = String.Format("Teacher 5 Name:");
                    row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._Teacher5Name);
                    table.Rows.Add(row);
                }
                if (!string.IsNullOrEmpty(myAttendee._Teacher5Email))
                {
                    row = new HtmlTableRow();
                    row.Cells.Add(new HtmlTableCell());
                    row.Cells.Add(new HtmlTableCell());
                    row.Cells[0].InnerHtml = String.Format("Teacher 5 Email:");
                    row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._Teacher5Email);
                    table.Rows.Add(row);
                }

                if (!string.IsNullOrEmpty(myAttendee._InteractionQuestion1) || !string.IsNullOrEmpty(myAttendee._InteractionQuestion2) || !string.IsNullOrEmpty(myAttendee._InteractionQuestion3))
                {
                    row = new HtmlTableRow();
                    row.Cells.Add(new HtmlTableCell());
                    row.Cells[0].ColSpan = 2;
                    row.Cells[0].InnerHtml = String.Format("");
                    table.Rows.Add(row);

                    //Interaction Information
                    row = new HtmlTableRow();
                    row.Cells.Add(new HtmlTableCell());
                    row.Cells[0].ColSpan = 2;
                    row.Cells[0].InnerHtml = String.Format("<b>Interaction:</b>");
                    table.Rows.Add(row);

                    if (!string.IsNullOrEmpty(myAttendee._InteractionQuestion1))
                    {
                        row = new HtmlTableRow();
                        row.Cells.Add(new HtmlTableCell());
                        row.Cells.Add(new HtmlTableCell());
                        row.Cells[0].InnerHtml = String.Format("Question 1:");
                        row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._InteractionQuestion1);
                        table.Rows.Add(row);
                    }
                    if (!string.IsNullOrEmpty(myAttendee._InteractionQuestion2))
                    {
                        row = new HtmlTableRow();
                        row.Cells.Add(new HtmlTableCell());
                        row.Cells.Add(new HtmlTableCell());
                        row.Cells[0].InnerHtml = String.Format("Question 2:");
                        row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._InteractionQuestion2);
                        table.Rows.Add(row);
                    }
                    if (!string.IsNullOrEmpty(myAttendee._InteractionQuestion3))
                    {
                        row = new HtmlTableRow();
                        row.Cells.Add(new HtmlTableCell());
                        row.Cells.Add(new HtmlTableCell());
                        row.Cells[0].InnerHtml = String.Format("Question 3");
                        row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._InteractionQuestion3);
                        table.Rows.Add(row);
                    }
                }
            }

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].ColSpan = 2;
            row.Cells[0].InnerHtml = String.Format("");
            table.Rows.Add(row);

            //Technical Contact 
            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].ColSpan = 2;
            row.Cells[0].InnerHtml = String.Format("<b>Technical Contact:</b>");
            table.Rows.Add(row);

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].InnerHtml = String.Format("Technical Contact Name:");
            row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._TechnicalContactName);
            table.Rows.Add(row);

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].InnerHtml = String.Format("Technical Contact Email:");
            row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._TechnicalContactEmail);
            table.Rows.Add(row);

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].InnerHtml = String.Format("Technical Contact Phone:");
            row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._TechnicalContactPhone);
            table.Rows.Add(row);

            //Texas Viewing Locations
            //No ESC Selected, email Technical Contact
            if (myAttendee.TexasViewingRegion <= 0)
            {
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());
                row.Cells[0].InnerHtml = String.Format("Viewing Locations:");
                row.Cells[1].InnerHtml = String.Format("Outside of Texas");
                table.Rows.Add(row);
            }
            else if (myAttendee.TexasViewingRegion == 27537) //27537	Region 3 ESC - Victoria
            {
                Net3ViewingLocation location = Net3ViewingLocation.ReturnLocation(myAttendee.TexasViewingRegion3Site);
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());
                row.Cells[0].InnerHtml = String.Format("Viewing Locations:");
                row.Cells[1].InnerHtml = String.Format("Region 3, {0}", location.Display);
                table.Rows.Add(row);
            }
            else
            {
                escWeb.tx_r3.ObjectModel.Organization region = new escWeb.tx_r3.ObjectModel.Organization(myAttendee.TexasViewingRegion);
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());
                row.Cells[0].InnerHtml = String.Format("Viewing Locations:");
                row.Cells[1].InnerHtml = String.Format("{0}", region.Name);
                table.Rows.Add(row);
            }

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].ColSpan = 2;
            row.Cells[0].InnerHtml = String.Format("");
            table.Rows.Add(row);

            //Connection Information
            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].ColSpan = 2;
            row.Cells[0].InnerHtml = String.Format("<b>Connection Information:</b>");
            table.Rows.Add(row);

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].InnerHtml = String.Format("IP Number (H.323):");
            row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._ConnectionInfoIPNumber);
            table.Rows.Add(row);

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].InnerHtml = String.Format("System Type:");
            row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._ConnectionInfoSystemType);
            table.Rows.Add(row);

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].InnerHtml = String.Format("Bridge Information:");
            row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._ConnectionInfoBridgeInfo);
            table.Rows.Add(row);

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell()); row.Cells.Add(new HtmlTableCell());
            row.Cells[0].InnerHtml = String.Format("Connection Comments:");
            row.Cells[1].InnerHtml = String.Format("{0}", myAttendee._ConnectionInfoConnectionComments);
            table.Rows.Add(row);

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].ColSpan = 2;
            row.Cells[0].InnerHtml = String.Format("");
            table.Rows.Add(row);
        }

        #endregion 

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

        row.Cells[0].InnerHtml = "<strong><br />Cancellation Policy:</strong><br /> Cancellations must be completed online or sent to <a  href=\"mailto:cancellations@esc3.net\">cancellations@esc3.net</a>. no later than 7 calendar days prior to event for a refund. Phone cancellations are  not accepted. To help expedite your request, please include the session number or event title and date.  Registrations are transferrable. A processing fee of 25% of the registration cost will be applied to the refund. Sessions with a fee of less than $35 will be charged the full session fee.  No refunds for online courses, nonattendance, or late cancellations submitted one to six calendar days prior to the event. Participants will receive a full refund for events cancelled by Region 3.<br /><br />";

        table.Rows.Add(row);

        row = new HtmlTableRow();
        row.Cells.Add(new HtmlTableCell());
        row.Cells[0].ColSpan = 2;

        row.Cells[0].InnerHtml = "<br /><i>Thank you for choosing Region 3 ESC for your professional development needs.  Please plan to attend the training in its entirety and conduct yourself in a professional manner at all times.  We ask that during your time at Region 3 you do not bring children to the building.  We have the right to ask that you leave the session if you do not adhere to all rules.  Thank you.</i>";

        table.Rows.Add(row);   

        row = new HtmlTableRow();
        row.Cells.Add(new HtmlTableCell());
        row.Cells[0].ColSpan = 2;
        row.Cells[0].Align = "center";
        row.Cells[0].InnerHtml = String.Format("<br/><b>Questions?</b></br>Manage your <a href=\"{0}\">registrations online</a><br/><br/>",
             ConfigurationManager.AppSettings["database.activeserver"] == "dev" ? "http://dev.escweb.net/tx_r3/shoebox/registration/default.aspx" : "http://www.escweb.net/tx_r3/shoebox/registration/default.aspx");
        table.Rows.Add(row);

        row = new HtmlTableRow();
        row.Cells.Add(new HtmlTableCell());
        row.Cells[0].ColSpan = 2;
        row.Cells[0].Align = "center";
        row.Cells[0].InnerHtml = "&nbsp;";
        table.Rows.Add(row);

        row = new HtmlTableRow();
        row.Cells.Add(new HtmlTableCell());
        row.Cells[0].ColSpan = 2;
        row.Cells[0].Align = "center";

        row.Cells[0].InnerHtml = String.Format("<br /><br /><img src=\"{0}\"  alt=\"Customer Logo\" />", embedLogo ? "cid:escWorksLogo" : pathToRoot + "lib/img/pwrdby_clear.gif");
        table.Rows.Add(row);

        return table;
    }

    public override void AddAdditionalEmailAddresses(escWorks.BusinessObjects.SendEmail sendEmail, region4.ObjectModel.Attendee attendee)
    {
        escWeb.tx_r3.ObjectModel.Event myEvent = attendee.Session.Event as escWeb.tx_r3.ObjectModel.Event;
        if (!myEvent.IsNet3Event && !myEvent.IsNet3StudentEvent)
            return;

        escWeb.tx_r3.ObjectModel.Attendee myAttendee = attendee as escWeb.tx_r3.ObjectModel.Attendee;

        //For Net3 Student
        if (myEvent.IsNet3StudentEvent)
        {
            if (!string.IsNullOrEmpty(myAttendee.RequesterEmail) && (myAttendee.RequesterEmail != attendee.User.PrimaryEmail))
            {
                sendEmail.AddEmailBCC(myAttendee.RequesterEmail);
            }
            if (!string.IsNullOrEmpty(myAttendee.TeacherEmail) )
            {
                sendEmail.AddEmailBCC(myAttendee.TeacherEmail);
            }
            if (!string.IsNullOrEmpty(myAttendee.Teacher2Email))
            {
                sendEmail.AddEmailBCC(myAttendee.Teacher2Email);
            }
            if (!string.IsNullOrEmpty(myAttendee.Teacher3Email))
            {
                sendEmail.AddEmailBCC(myAttendee.Teacher3Email);
            }
            if (!string.IsNullOrEmpty(myAttendee.Teacher4Email))
            {
                sendEmail.AddEmailBCC(myAttendee.Teacher4Email);
            }
            if (!string.IsNullOrEmpty(myAttendee.Teacher5Email))
            {
                sendEmail.AddEmailBCC(myAttendee.Teacher5Email);
            }
        }

        //27537	Region 3 ESC - Victoria
        if ((myAttendee.TexasViewingRegion == 27537) && (myAttendee.TexasViewingRegion3Site > 0))//If Region 3 ESC, email site. Code store the email address
        {
            Net3ViewingLocation location = Net3ViewingLocation.ReturnLocation(myAttendee.TexasViewingRegion3Site);
            if(EmailProvider.IsValidEmailAddress(location.ContactEmail1))
                sendEmail.AddEmailBCC(location.ContactEmail1);
            if (EmailProvider.IsValidEmailAddress(location.ContactEmail2))
                sendEmail.AddEmailBCC(location.ContactEmail2);
        }
        else 
        {
            if (myAttendee.TexasViewingRegion > 0)
            {
                escWeb.tx_r3.ObjectModel.Organization org = region4.ObjectModel.ObjectProvider.ReturnOrganization(myAttendee.TexasViewingRegion) as escWeb.tx_r3.ObjectModel.Organization;
                if (!string.IsNullOrEmpty(org.ESCTechnicalContactEmail1) && EmailProvider.IsValidEmailAddress(org.ESCTechnicalContactEmail1))
                {
                    sendEmail.AddEmailBCC(org.ESCTechnicalContactEmail1);
                }
                if (!string.IsNullOrEmpty(org.ESCTechnicalContactEmail2) && EmailProvider.IsValidEmailAddress(org.ESCTechnicalContactEmail2))
                {
                    sendEmail.AddEmailBCC(org.ESCTechnicalContactEmail2);
                }
            }

            if (!string.IsNullOrEmpty(myAttendee.TechnicalContactEmail) && EmailProvider.IsValidEmailAddress(myAttendee.TechnicalContactEmail))
            {
                sendEmail.AddEmailBCC(myAttendee.TechnicalContactEmail);
            }
        }
    }

}
