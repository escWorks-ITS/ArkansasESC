using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dashboard_SSOSignin : region4.escWeb.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ////TTTTTTTTTTTTTTTT Single Sign On for DashBoard TTTTTTTTTTTTTTTTTTTTTTTTTTTTTT
        string SSOPortalURL = System.Web.Configuration.WebConfigurationManager.AppSettings["SSOPortal"];
        string redirectUrl;
        if (!string.IsNullOrEmpty(SSOPortalURL) && CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2452)
        {
            redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2452@aresc.net", "ExecDashboard2.aspx");
            HttpContext.Current.Response.Redirect(redirectUrl);
        }
        else if (!string.IsNullOrEmpty(SSOPortalURL) && CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2453)
        {
            redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2453@aresc.net", "ExecDashboard2.aspx");
            HttpContext.Current.Response.Redirect(redirectUrl);
        }

        else if (!string.IsNullOrEmpty(SSOPortalURL) && CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2454)
        {
            redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2454@ARESC.net", "ExecDashboard2.aspx");
            HttpContext.Current.Response.Redirect(redirectUrl);
        }

        else if (!string.IsNullOrEmpty(SSOPortalURL) && CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2455)
        {
            redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2455@ARESC.net", "ExecDashboard2.aspx");
            HttpContext.Current.Response.Redirect(redirectUrl);
        }

        else if (!string.IsNullOrEmpty(SSOPortalURL) && CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2456)
        {
            redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2456@ARESC.net", "ExecDashboard2.aspx");
            HttpContext.Current.Response.Redirect(redirectUrl);
        }
        else if (!string.IsNullOrEmpty(SSOPortalURL) && CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2457)
        {
            redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2457@ARESC.net", "ExecDashboard2.aspx");
            HttpContext.Current.Response.Redirect(redirectUrl);
        }

        else if (!string.IsNullOrEmpty(SSOPortalURL) && CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2458)
        {
            redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2458@ARESC.net", "ExecDashboard2.aspx");
            HttpContext.Current.Response.Redirect(redirectUrl);
        }

        else if (!string.IsNullOrEmpty(SSOPortalURL) && CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2459)
        {
            redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2459@ARESC.net", "ExecDashboard2.aspx");
            HttpContext.Current.Response.Redirect(redirectUrl);
        }

        else if (!string.IsNullOrEmpty(SSOPortalURL) && CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2460)
        {
            redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2460@ARESC.net", "ExecDashboard2.aspx");
            HttpContext.Current.Response.Redirect(redirectUrl);
        }

        else if (!string.IsNullOrEmpty(SSOPortalURL) && CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2461)
        {
            redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2461@ARESC.net", "ExecDashboard2.aspx");
            HttpContext.Current.Response.Redirect(redirectUrl);
        }

        else if (!string.IsNullOrEmpty(SSOPortalURL) && CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2462)
        {
            redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXEcARESC2462@ARESC.net", "ExecDashboard2.aspx");
            HttpContext.Current.Response.Redirect(redirectUrl);
        }

        else if (!string.IsNullOrEmpty(SSOPortalURL) && CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2463)
        {
            redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2463@ARESC.net", "ExecDashboard2.aspx");
            HttpContext.Current.Response.Redirect(redirectUrl);
        }

        else if (!string.IsNullOrEmpty(SSOPortalURL) && CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2464)
        {
            redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2464@ARESC.net", "ExecDashboard2.aspx");
            HttpContext.Current.Response.Redirect(redirectUrl);
        }

        else if (!string.IsNullOrEmpty(SSOPortalURL) && CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2465)
        {
            redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2465@ARESC.net", "ExecDashboard2.aspx");
            HttpContext.Current.Response.Redirect(redirectUrl);
        }

        else if (!string.IsNullOrEmpty(SSOPortalURL) && CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2466)
        {
            redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2466@ARESC.net", "ExecDashboard2.aspx");
            HttpContext.Current.Response.Redirect(redirectUrl);
        }

        else if (!string.IsNullOrEmpty(SSOPortalURL) && CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2467)
        {
            redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2467@ARESC.net", "ExecDashboard2.aspx");
            HttpContext.Current.Response.Redirect(redirectUrl);
        }

        else if (!string.IsNullOrEmpty(SSOPortalURL) && CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2577)
        {
            redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2577@ARESC.net", "ExecDashboard2.aspx");
            HttpContext.Current.Response.Redirect(redirectUrl);
        }

        else if (!string.IsNullOrEmpty(SSOPortalURL) && CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2846)
        {
            redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2846@ARESC.net", "ExecDashboard2.aspx");
            HttpContext.Current.Response.Redirect(redirectUrl);
        }
        else if (!string.IsNullOrEmpty(SSOPortalURL) && CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 12861)
        {
            redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC12861@ARESC.net", "ExecDashboard2.aspx");
            HttpContext.Current.Response.Redirect(redirectUrl);
        }

        else if (!string.IsNullOrEmpty(SSOPortalURL) && CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 25896)
        {
            redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC25896@ARESC.net", "ExecDashboard2.aspx");
            HttpContext.Current.Response.Redirect(redirectUrl);
        }













        ////LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL
    }

    private string EncodeSSOPortalUrl(string SSOPortalURL, string Email, string returnURL)
    {
        string SHARED_KEY = "70467023fcfcd40fe3b884b2b96f6c48";
        TimeSpan t = (DateTime.UtcNow - new DateTime(1970, 1, 1));
        int timestamp = (int)t.TotalSeconds;

        var payload = new System.Collections.Generic.Dictionary<string, object>() {
                { "userId", Email.Substring(0,Email.IndexOf('@')) },
                 { "userDirectory", "R04QLIK" },
                // { "url", region4.escWeb.SiteVariables.CustomerHostUrl + returnURL },
            };
        string token = JWT.JsonWebToken.Encode(payload, SHARED_KEY, JWT.JwtHashAlgorithm.HS256);
        //  string redirectUrl = SSOPortalURL + "login.aspx?" + "jwt=" + token;
        string redirectUrl = returnURL;
        return redirectUrl;
    }
}