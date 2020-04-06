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

public partial class catalog_register_cart : region4.escWeb.BasePages.Catalog.Register.cart_aspx
{

    protected override void AssignControlsToBase()
    {
        base._txtPromoCode = txtPromoCode;
        base._btnApplyPromoCode = btnApplyCode;
        base._cartDisplay = cartDisplay1;
        base._pPromoCode = pPromoCode;
        base._btnCheckout = btnCheckOut;
    }

    protected override void Render(HtmlTextWriter writer)
    {
        if (this.ShoppingCart.ItemCount == 0)
        {
            if (Session["isGroup"] != null)
                Session.Remove("isGroup");
        }

        base.Render(writer);
    }

    protected override void _btnCheckout_Click(object sender, EventArgs e)
    {
        if (this.ShoppingCart.HasMixedSessions)
        {
            this.ShoppingCart.MoveNonOnDemandItems(this.ShoppingCart2);
        }
       //string isGroup = escWorks.Tools.Strings.CleanUp("isGroup", true, false);

       Response.Redirect("~/catalog/register/confirmuserprofile.aspx");
    }
}
