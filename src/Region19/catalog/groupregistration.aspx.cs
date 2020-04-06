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

public partial class catalog_groupregistration : region4.escWeb.BasePages.catalog.groupregistration_aspx
{
    protected override void AssignControlsToBase()
    {
        this._listBoxAvailableUsers = listBoxAvailableUsers;
        this._hiddenFieldSelectedUsers = hiddenFieldSelectedUsers;
        this._hiddenFieldSessionID = hiddenFieldSessionID;
        this._btnCheckout = btnCheckout;
    }

    protected override void RenderSession(region4.ObjectModel.Session session)
    {
        this.lblTitle.Text = session.Title;
        this.lblSessionID.Text = session.ID.ToString();
        this.lblDescription.Text = session.Description;
        this.hiddenFieldAvailableSeats.Value = this.ShoppingCart.NumberOfSeatsAvailable(session.ID).ToString();
        this.hiddenFieldSessionID.Value = session.ID.ToString();
    }

    protected override void btnAddSessionToCart_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this._hiddenFieldSelectedUsers.Value.Trim()))
        {
            string[] selectedUsers = this._hiddenFieldSelectedUsers.Value.Trim().Split('|');
            foreach (string sid in selectedUsers)
            {
                region4.ObjectModel.User user = region4.escWeb.SiteVariables.ObjectProvider.ReturnUser(new Guid(sid), true);
                region4.ObjectModel.SessionRegistration registration = region4.escWeb.SiteVariables.ObjectProvider.ReturnSessionRegistration(session, user);
                if (ShoppingCart.NumberOfSeatsAvailable(registration.Session.ID) >= 1)
                {
                    if (session.GroupDiscounts.Count > 0)
                    {
                        ShoppingCart.ItemAdded += new region4.escWeb.SiteObjects.ShoppingCart.ICartItemEventHandler(registration.OnItemsAdded);
                        ShoppingCart.ItemRemoved += new region4.escWeb.SiteObjects.ShoppingCart.ICartItemEventHandler(registration.OnItemsRemoved);
                    }
                    ShoppingCart.Add(registration);
                }
            }

            Session["isGroup"] = "1";

            Response.Redirect(region4.escWeb.SiteVariables.RelativeURLs.shoppingCart);
        }
    }
}