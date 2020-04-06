#define noCache
#undef noCache
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
/// Summary description for ObjectProvider
/// </summary>
public class ObjectProvider : region4.escWeb.SiteObjects.IObjectProvider
{


    public override string SessionName
    {
        get { return Resources.Names.Session; }
    }

    public override string EventName
    {
        get { return Resources.Names.Event; }
    }

    public override string EventPluralName
    {
        get { return Resources.Names.eventPlural; }
    }
    public override string SessionPluralName
    {
        get { return Resources.Names.SessionPlural; }
    }

    #region IObjectProvider Members
    
    public override string OrganizationName
    {
        get { return Resources.Names.Organization; }
    }

    public override string OrganizationPluralName
    {
        get { return Resources.Names.OrganizationPlural; }
    }

    public override string SiteName
    {
        get { return Resources.Names.Site; }
    }

    public override string SitePluralName
    {
        get { return Resources.Names.SitePlural; }
    }

    public override string SchoolName
    {
        get { return Resources.Names.School; }
    }

    public override string SchoolPluralName
    {
        get { return Resources.Names.SchoolPlural; }
    }

    #endregion

    protected override string ReturnBrowseCustomStoredProcedure(string browseType)
    {
        return "";
    }

    EmailProvider _email;
    public override region4.Utilities.Email.baseEmailProvider EmailProvider
    {
        get
        {
            if (_email == null)
                _email = new EmailProvider();
            return _email;
        }
    }
}
