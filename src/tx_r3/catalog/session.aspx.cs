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
using escWeb.tx_r3.ObjectModel;

public partial class catalog_session : region4.escWeb.BasePages.Catalog.session_aspx
{
    protected override void OnLoad(EventArgs e)
    {
        contentsTable.Visible = contentsTable1.Visible = true;
        base.OnLoad(e);
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
        
        lblTitle.Text = session.Subtitle == "" ? session.Event.Title : String.Format("{0}<br /><em>{1}</em>",session.Event.Title, session.Subtitle);

        //panelRating.Visible = session.IsOnline;
        //radRatingSession.Value = session.AverageRating;
        //btnOpenReview.Text = "(" + session.CountRated.ToString() + " reviews)";
        //panelDetailedReviews.Controls.Add(base.ReturnRatingReviews(session));
        
        lblDescription.Text = session.Event.Description;
        lblWebComments.Text = session.WebComments;

        if (session.Dimensions != string.Empty)
        {
            plttess.Visible = true;
            lblTPESS.Text = session.Dimensions;
        }

        if (session.Standards != string.Empty)
        {
            plttess.Visible = true;
            if (session.Standards != string.Empty && session.Dimensions != string.Empty)
                lblTPESS.Text += "; " + session.Standards;
            else
                lblTPESS.Text += session.Standards;
        }

        lblSessionID.Text = session.ID.ToString();

        lblCredits.Text = "";
        foreach (region4.ObjectModel.CreditItem item in session.Credits)
        {
            lblCredits.Text += String.Format("({0}) {1}<br />", item.Amount, item.Credit.Display);
        }
        
        if(session.Limit == 999999)
            lblSeatsFilled.Text = String.Format("{0}", session.NumberOfAttendeesRegistered);
        else
            lblSeatsFilled.Text = String.Format("{0}", (session.Limit - session.NumberOfAttendeesRegistered) <= 0 ? "No Seats" : (session.Limit - session.NumberOfAttendeesRegistered).ToString());

        lblContactPerson.Text = String.Format("<a href=\"mailto:{0}\" class=\"link\">{1} {2}</a>", session.ContactPerson.PrimaryEmail, session.ContactPerson.FirstName, session.ContactPerson.LastName);

        SessionRegistration registration = (escWeb.tx_r3.ObjectModel.SessionRegistration)region4.escWeb.SiteVariables.ObjectProvider.ReturnSessionRegistration(session, this.CurrentUser);
        lblFee.Text = String.Format("{0:c}", registration.ReturnUserFee());

        System.Text.StringBuilder instructors = new System.Text.StringBuilder();
        //instructors.AppendFormat("{0} {1}", session.PrimaryInstructor.FirstName, session.PrimaryInstructor.LastName);
        foreach(User user in session.AdditionalInstructors)
            instructors.AppendFormat("{0} {1} <br/>", user.FirstName, user.LastName);
        lblInstructors.Text = instructors.ToString();

        if (session.IsSelfPacedOnline)
            pnlSeatsFilled.Visible = false;
        else
            pnlSeatsFilled.Visible = true;
        pLocationPlaceHolder.Controls.Add(base.ReturnTimeLocationTable(session));

    }

    protected override void btnAddSessionToCart_Click(object sender, EventArgs e)
    {
        //If Net3 Session, redirect to a different page
        if (((escWeb.tx_r3.ObjectModel.Event)session.Event).IsNet3Event || ((escWeb.tx_r3.ObjectModel.Event)session.Event).IsNet3StudentEvent)
        {
            Response.Redirect("~/catalog/Net3Session.aspx?session_id=" + session.ID);
        }
        else
        {
            escWeb.tx_r3.ObjectModel.SessionRegistration registration = (escWeb.tx_r3.ObjectModel.SessionRegistration)region4.escWeb.SiteVariables.ObjectProvider.ReturnSessionRegistration(session, CurrentUser);
            if (ShoppingCart.NumberOfSeatsAvailable(registration.Session.ID) >= 1)
            {
                ShoppingCart.Add(registration);
            }
            Response.Redirect(region4.escWeb.SiteVariables.RelativeURLs.shoppingCart);
        }
    }

}
