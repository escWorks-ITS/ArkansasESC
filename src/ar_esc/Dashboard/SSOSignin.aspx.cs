using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Security.Cryptography;
using System.Net;
//using System.Net.Http;
//using System.Net.Http.Headers;
using System.Text;
using System.Security.Cryptography.X509Certificates;

using Newtonsoft.Json;
using region4.Utilities.Qlik;
using System.Configuration;


public partial class Dashboard_SSOSignin : region4.escWeb.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ////TTTTTTTTTTTTTTTT Single Sign On for DashBoard TTTTTTTTTTTTTTTTTTTTTTTTTTTTTT
        ///
        /*
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

    */

        //string SSOPortalURL = System.Web.Configuration.WebConfigurationManager.AppSettings["SSOPortal"];
        //string redirectUrl;


        TicketRequest ticket_request = null;
        TicketResponse ticket_response = null;

        try
        {

            if (CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2452)
            {
                //redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2452@aresc.net", "ExecDashboard2.aspx");
                //HttpContext.Current.Response.Redirect(redirectUrl);

                ticket_request = TicketRequestFromConfiguration(new TicketBody
                {
                    UserDirectory = "R04QLIK",
                    //  UserId = "collin.kruger",
                    UserId = "EXECARESC2452",
                    Attributes = new KeyValuePair<string, string>[0]
                });

            }
            else if (CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2453)
            {
                //redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2453@aresc.net", "ExecDashboard2.aspx");
                //HttpContext.Current.Response.Redirect(redirectUrl);

                ticket_request = TicketRequestFromConfiguration(new TicketBody
                {
                    UserDirectory = "R04QLIK",
                    //  UserId = "collin.kruger",
                    UserId = "EXECARESC2453",
                    Attributes = new KeyValuePair<string, string>[0]
                });
            }

            else if (CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2454)
            {
                //redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2454@ARESC.net", "ExecDashboard2.aspx");
                //HttpContext.Current.Response.Redirect(redirectUrl);

                ticket_request = TicketRequestFromConfiguration(new TicketBody
                {
                    UserDirectory = "R04QLIK",
                    //  UserId = "collin.kruger",
                    UserId = "EXECARESC2454",
                    Attributes = new KeyValuePair<string, string>[0]
                });

            }

            else if (CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2455)
            {
                //redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2455@ARESC.net", "ExecDashboard2.aspx");
                //HttpContext.Current.Response.Redirect(redirectUrl);

                ticket_request = TicketRequestFromConfiguration(new TicketBody
                {
                    UserDirectory = "R04QLIK",
                    //  UserId = "collin.kruger",
                    UserId = "EXECARESC2455",
                    Attributes = new KeyValuePair<string, string>[0]
                });

            }

            else if (CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2456)
            {
                //redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2456@ARESC.net", "ExecDashboard2.aspx");
                //HttpContext.Current.Response.Redirect(redirectUrl);

                ticket_request = TicketRequestFromConfiguration(new TicketBody
                {
                    UserDirectory = "R04QLIK",
                    //  UserId = "collin.kruger",
                    UserId = "EXECARESC2456",
                    Attributes = new KeyValuePair<string, string>[0]
                });

            }
            else if (CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2457)
            {
                //redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2457@ARESC.net", "ExecDashboard2.aspx");
                //HttpContext.Current.Response.Redirect(redirectUrl);

                ticket_request = TicketRequestFromConfiguration(new TicketBody
                {
                    UserDirectory = "R04QLIK",
                    //  UserId = "collin.kruger",
                    UserId = "EXECARESC2457",
                    Attributes = new KeyValuePair<string, string>[0]
                });


            }

            else if (CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2458)
            {
                //redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2458@ARESC.net", "ExecDashboard2.aspx");
                //HttpContext.Current.Response.Redirect(redirectUrl);

                ticket_request = TicketRequestFromConfiguration(new TicketBody
                {
                    UserDirectory = "R04QLIK",
                    //  UserId = "collin.kruger",
                    UserId = "EXECARESC2458",
                    Attributes = new KeyValuePair<string, string>[0]
                });

            }

            else if (CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2459)
            {
                //redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2459@ARESC.net", "ExecDashboard2.aspx");
                //HttpContext.Current.Response.Redirect(redirectUrl);

                ticket_request = TicketRequestFromConfiguration(new TicketBody
                {
                    UserDirectory = "R04QLIK",
                    //  UserId = "collin.kruger",
                    UserId = "EXECARESC2459",
                    Attributes = new KeyValuePair<string, string>[0]
                });


            }

            else if (CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2460)
            {
                //redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2460@ARESC.net", "ExecDashboard2.aspx");
                //HttpContext.Current.Response.Redirect(redirectUrl);

                ticket_request = TicketRequestFromConfiguration(new TicketBody
                {
                    UserDirectory = "R04QLIK",
                    //  UserId = "collin.kruger",
                    UserId = "EXECARESC2460",
                    Attributes = new KeyValuePair<string, string>[0]
                });

            }

            else if (CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2461)
            {
                //redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2461@ARESC.net", "ExecDashboard2.aspx");
                //HttpContext.Current.Response.Redirect(redirectUrl);

                ticket_request = TicketRequestFromConfiguration(new TicketBody
                {
                    UserDirectory = "R04QLIK",
                    //  UserId = "collin.kruger",
                    UserId = "EXECARESC2461",
                    Attributes = new KeyValuePair<string, string>[0]
                });

            }

            else if (CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2462)
            {
                //redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXEcARESC2462@ARESC.net", "ExecDashboard2.aspx");
                //HttpContext.Current.Response.Redirect(redirectUrl);

                ticket_request = TicketRequestFromConfiguration(new TicketBody
                {
                    UserDirectory = "R04QLIK",
                    //  UserId = "collin.kruger",
                    UserId = "EXEcARESC2462",
                    Attributes = new KeyValuePair<string, string>[0]
                });


            }

            else if (CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2463)
            {
                //redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2463@ARESC.net", "ExecDashboard2.aspx");
                //HttpContext.Current.Response.Redirect(redirectUrl);


                ticket_request = TicketRequestFromConfiguration(new TicketBody
                {
                    UserDirectory = "R04QLIK",
                    //  UserId = "collin.kruger",
                    UserId = "EXECARESC2463",
                    Attributes = new KeyValuePair<string, string>[0]
                });

            }

            else if (CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2464)
            {
                //redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2464@ARESC.net", "ExecDashboard2.aspx");
                //HttpContext.Current.Response.Redirect(redirectUrl);

                ticket_request = TicketRequestFromConfiguration(new TicketBody
                {
                    UserDirectory = "R04QLIK",
                    //  UserId = "collin.kruger",
                    UserId = "EXECARESC2464",
                    Attributes = new KeyValuePair<string, string>[0]
                });

            }

            else if (CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2465)
            {
                //redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2465@ARESC.net", "ExecDashboard2.aspx");
                //HttpContext.Current.Response.Redirect(redirectUrl);


                ticket_request = TicketRequestFromConfiguration(new TicketBody
                {
                    UserDirectory = "R04QLIK",
                    //  UserId = "collin.kruger",
                    UserId = "EXECARESC2465",
                    Attributes = new KeyValuePair<string, string>[0]
                });

            }

            else if (CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2466)
            {
                //redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2466@ARESC.net", "ExecDashboard2.aspx");
                //HttpContext.Current.Response.Redirect(redirectUrl);

                ticket_request = TicketRequestFromConfiguration(new TicketBody
                {
                    UserDirectory = "R04QLIK",
                    //  UserId = "collin.kruger",
                    UserId = "EXECARESC2466",
                    Attributes = new KeyValuePair<string, string>[0]
                });

            }

            else if (CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2467)
            {
                //redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2467@ARESC.net", "ExecDashboard2.aspx");
                //HttpContext.Current.Response.Redirect(redirectUrl);

                ticket_request = TicketRequestFromConfiguration(new TicketBody
                {
                    UserDirectory = "R04QLIK",
                    //  UserId = "collin.kruger",
                    UserId = "EXECARESC2467",
                    Attributes = new KeyValuePair<string, string>[0]
                });

            }

            else if (CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2577)
            {
                //redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2577@ARESC.net", "ExecDashboard2.aspx");
                //HttpContext.Current.Response.Redirect(redirectUrl);

                ticket_request = TicketRequestFromConfiguration(new TicketBody
                {
                    UserDirectory = "R04QLIK",
                    //  UserId = "collin.kruger",
                    UserId = "EXECARESC2577",
                    Attributes = new KeyValuePair<string, string>[0]
                });

            }

            else if (CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 2846)
            {
                //redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC2846@ARESC.net", "ExecDashboard2.aspx");
                //HttpContext.Current.Response.Redirect(redirectUrl);


                ticket_request = TicketRequestFromConfiguration(new TicketBody
                {
                    UserDirectory = "R04QLIK",
                    //  UserId = "collin.kruger",
                    UserId = "EXECARESC2846",
                    Attributes = new KeyValuePair<string, string>[0]
                });

            }
            else if (CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 12861)
            {
                //redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC12861@ARESC.net", "ExecDashboard2.aspx");
                //HttpContext.Current.Response.Redirect(redirectUrl);


                ticket_request = TicketRequestFromConfiguration(new TicketBody
                {
                    UserDirectory = "R04QLIK",
                    //  UserId = "collin.kruger",
                    UserId = "EXECARESC12861",
                    Attributes = new KeyValuePair<string, string>[0]
                });


            }

            else if (CurrentUser.IsInRole("execdashboard") && CurrentUser.Location.OrganizationId == 25896)
            {
                //redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "EXECARESC25896@ARESC.net", "ExecDashboard2.aspx");
                //HttpContext.Current.Response.Redirect(redirectUrl);

                ticket_request = TicketRequestFromConfiguration(new TicketBody
                {
                    UserDirectory = "R04QLIK",
                    //  UserId = "collin.kruger",
                    UserId = "EXECARESC25896",
                    Attributes = new KeyValuePair<string, string>[0]
                });
            }


                //ticket_request = Requests.TicketRequestFromConfiguration(new TicketBody
                //{
                //    UserDirectory = "R04QLIK",
                //    //  UserId = "collin.kruger",
                //    UserId = "texasdashboard6",
                //    Attributes = new KeyValuePair<string, string>[0]
                //});

                ticket_response = region4.Utilities.Qlik.Qlik.GetTicket(ticket_request, "iuygs6~kjas9");

                if (String.IsNullOrWhiteSpace(ticket_response.Ticket))
                    throw new Exception("Unexpected response from QlikSense");
            
        }
        catch (Exception EX)
        {
            var response_string = ticket_response != null
                                  && ticket_response.Raw() != null
                                  ? ticket_response.Raw().ToString()
                                  : "";

            region4.ErrorReporter.ReportError(EX, System.Web.HttpContext.Current, region4.ErrorReporter.Severity.severe, region4.ErrorReporter.Occurance.objectModel, "res: " + response_string);
            Response.ClearContent();
            Response.Redirect("/");
        }

        Response.ClearContent();
        // Response.Redirect(Qlik.GenRedirectURL(ticket_request, ticket_response));
        //Response.Redirect(String.Format("https://{0}?qlikTicket={1}", "www.escweb.net/tx_esc_04Mobile/Dashboard/ExecDashboard2.aspx", ticket_response.Ticket));
        Response.Redirect("https://qlik.escworks.app/iuygs6~kjas9/sense/app/bc59defc-9e0e-4bc6-9802-76560c98bd42?qlikTicket=" + ticket_response.Ticket); // change vitual proxy name per customer



        ////LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL
    }

    private static TicketRequest TicketRequestFromConfiguration(TicketBody body)
    {
        return new TicketRequest
        {
            Host = ConfigurationManager.AppSettings["qliksense.host"],
            Port = Convert.ToInt32(ConfigurationManager.AppSettings["qliksense.port"]),
            VirtualProxy = "iuygs6~kjas9",//SettingStr("qliksense.virtualproxy"), // change vitual proxy name per customer
            Body = body
        };
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
