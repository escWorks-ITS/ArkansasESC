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
using System.IO;
using System.Data.SqlClient;

public partial class MasterPageDummy : region4.escWeb.MasterPage
{
    public override void AssignControlsToBase()
    {
        base._pageTitle = this.pageTitle;
    }
}