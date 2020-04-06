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

public partial class about_contact : region4.escWeb.BasePages.About.contact_aspx
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!this.IsPostBack)
        //    //Create a random code and store it in the Session object.
        //    this.Session["CaptchaImageText"] = GenerateRandomCode(5);
    }

    //public override bool ValidateSecurityImage()
    //{
    //    // Make sure the there's a code value
    //    if (string.IsNullOrEmpty(this.Session["CaptchaImageText"].ToString()))
    //    {
    //        this.Session["CaptchaImageText"] = GenerateRandomCode(5);
    //        return false;
    //    }

    //    // On as postback
    //    if (Page.IsPostBack)
    //    {
    //        //// Check the user input. Make sure code is still in the session state.
    //        if ((this.txtCodeNumber.Text != this.Session["CaptchaImageText"].ToString()) || (this.Session["CaptchaImageText"] == null))
    //        {
    //            // Clear the input and create a new random code.
    //            this.txtCodeNumber.Text = "";
    //            this.Session["CaptchaImageText"] = GenerateRandomCode(5);
    //            this.lblError.Text = "The code is incorrect!";
    //            return false;
    //        }
    //        else
    //        {
    //            return true;
    //        }
    //    }
    //    return true;
    //}


    protected override void AssignControlsToBase()
    {
        base._ddlCategory = ddlCategory;
        base._txtComments = txtComments;
        base._txtName = txtName;
        base._txtEmail = txtEmail;
        base._txtPhone = txtPhone;
        base._chkASAP = chkASAP;

        base._btnSubmit = btnSubmit;
        base._btnCancel = btnCancel;

        base._lblError = lblError;

        base._pStep1 = pStep1;
        base._pStep2 = pStep2;

    }
}
