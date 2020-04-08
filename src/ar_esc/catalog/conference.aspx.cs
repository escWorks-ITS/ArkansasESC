using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class catalog_conference : region4.escWeb.BasePages.Catalog.conference_aspx
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void AssignControlsToBase()
    {
        base._txtDescription = txtDescription;
        base._txtTitle = txtTitle;
        base._conferenceSelector = sessionDisplay;
    }
}
