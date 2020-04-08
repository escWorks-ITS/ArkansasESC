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

public partial class shoebox_registration_cancel : region4.escWeb.BasePages.ShoeBox.registration.cancel_aspx
{

    protected override void AssignControlsToBase()
    {
        base._pCancelDetails = pCancelDetails;
        base._pError = pError;
        base._pSuccess = pSuccess;
        base._pUnavailable = pUnavailable;
        base._btnSubmit = btnSubmit;
    }

    protected override void RenderPage(region4.ObjectModel.Attendee attendee)
    {
        lblDescription.Text = attendee.Session.Event.Description;
        lblTitle.Text = lblTitle2.Text = attendee.Session.Title;
        lblStartDate.Text = lblStartDate2.Text = String.Format("{0:d} at {0:t}", attendee.Session.StartDate);
        lblLocation.Text = lblLocation2.Text = String.Format("{0}, {1}", attendee.Session.Schedule[0].Location.Site.Name, attendee.Session.Schedule[0].Location.Name);
        lblFee.Text = String.Format("{0:c}", attendee.Fee);
        lblSessionID.Text = lblSessionId2.Text = attendee.Session.ID.ToString();
    }
}
