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
    
}
