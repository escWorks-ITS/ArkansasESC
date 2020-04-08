using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;

public partial class about_contact : region4.escWeb.BasePages.About.contact_aspx
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            PopulateDropDownList(Cooperatives, "[/about/contact/ddCooperatives]");
            PopulateDropDownList(ddlCategory, "[/about/contact/ddCategories]");

            if (Request.IsAuthenticated)
            {
                Cooperatives.SelectedValue = this.CurrentUser.Location.Site.Organization.OrganizationID.ToString();
                this.txtName.Text = this.CurrentUser.FullName;
                this.txtEmail.Text = this.CurrentUser.PrimaryEmail;
                this.txtPhone.Text = this.CurrentUser.HomePhone;
            }
        }
    }

    protected override void AssignControlsToBase()
    {
        //base._ddlCategory = ddlCategory;
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

    public void PopulateDropDownList(DropDownList list, string spname)
    {
        list.Items.Clear();

        using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
        {
            SqlCommand SQLCommand = conn.CreateCommand();
            SQLCommand.CommandText = spname;
            SQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                SQLCommand.Connection.Open();
                using (SqlDataReader reader = SQLCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Items.Add(new ListItem(reader["display"].ToString(), reader["key"].ToString()));
                    }
                    reader.Close();
                    reader.Dispose();
                }
            }
            catch (Exception ex)
            {
                region4.ErrorReporter.ReportError(ex, System.Web.HttpContext.Current);
            }
            finally
            {
                SQLCommand.Connection.Close();
            }
        }
    }

    public override void _btnSubmit_Click(object sender, EventArgs e)
    {

        if (!ValidateSecurityImage())
            return;


        //Validate input
        _lblError.Text = "";

        int category_id;
        if (!ValidateInput(out category_id))
            return;

        EmailFeedBack();

        try
        {
            string CoopProviderEmail = string.Empty;
            Guid assignedGuid = Guid.Empty;

            #region switch coop
            switch (Cooperatives.SelectedItem.Value)
            {
                case "2452": // Arch Ford Education Service Cooperative
                    CoopProviderEmail = ConfigurationManager.AppSettings["ARFCOPEmail"];
                    assignedGuid = new Guid(ConfigurationManager.AppSettings["ARFCOOPGUID"]);
                    break;

                case "2453": // Arkansas River Education Service Cooperative
                    CoopProviderEmail = ConfigurationManager.AppSettings["ARCOPEmail"];
                    assignedGuid = new Guid(ConfigurationManager.AppSettings["ARCOOPGUID"]);
                    break;

                case "2454": // Crowleys Ridge Educational Cooperative
                    CoopProviderEmail = ConfigurationManager.AppSettings["CRCOPEmail"];
                    assignedGuid = new Guid(ConfigurationManager.AppSettings["CRCOOPGUID"]);
                    break;

                case "2455": // Dawson Education Service Cooperative
                    CoopProviderEmail = ConfigurationManager.AppSettings["DWCOPEmail"];
                    assignedGuid = new Guid(ConfigurationManager.AppSettings["DWCOOPGUID"]);
                    break;

                case "2456": // DeQueen/Mena Education Cooperative
                    CoopProviderEmail = ConfigurationManager.AppSettings["DQMCOPEmail"];
                    assignedGuid = new Guid(ConfigurationManager.AppSettings["DQMCOOPGUID"]);
                    break;

                case "2457": // Great Rivers Cooperative
                    CoopProviderEmail = ConfigurationManager.AppSettings["GRCOPEmail"];
                    assignedGuid = new Guid(ConfigurationManager.AppSettings["GRCOOPGUID"]);
                    break;

                case "2458": // Northcentral Arkansas Education Service Center
                    CoopProviderEmail = ConfigurationManager.AppSettings["NCACOPEmail"];
                    assignedGuid = new Guid(ConfigurationManager.AppSettings["NCACOOPGUID"]);
                    break;

                case "2459": // Northeast Arkansas Education Service Center E-Mail
                    CoopProviderEmail = ConfigurationManager.AppSettings["NEACOPEmail"];
                    assignedGuid = new Guid(ConfigurationManager.AppSettings["NEACOOPGUID"]);
                    break;

                case "2460": // NORTHWEST EDUCATION SERVICE COOPERATIVE
                    CoopProviderEmail = ConfigurationManager.AppSettings["NWCOPEmail"]; //"Lisa Chavis";
                    assignedGuid = new Guid(ConfigurationManager.AppSettings["NWCOOPGUID"]);
                    break;

                case "2461": // Ozarks Unlimited Resources Educational Cooperative
                    CoopProviderEmail = ConfigurationManager.AppSettings["OZCOPEmail"];
                    assignedGuid = new Guid(ConfigurationManager.AppSettings["OZCOOPGUID"]);
                    break;

                case "2462": // South Central Service Cooperative
                    CoopProviderEmail = ConfigurationManager.AppSettings["SCACOPEmail"];
                    assignedGuid = new Guid(ConfigurationManager.AppSettings["SCACOOPGUID"]);
                    break;

                case "2463": // Southeast Arkansas Education Service Center
                    CoopProviderEmail = ConfigurationManager.AppSettings["SEACOPEmail"];
                    assignedGuid = new Guid(ConfigurationManager.AppSettings["SEACOOPGUID"]);
                    break;

                case "2464": // Southwest Arkansas Educational Cooperative
                    CoopProviderEmail = ConfigurationManager.AppSettings["SWACOPEmail"];
                    assignedGuid = new Guid(ConfigurationManager.AppSettings["SWACOOPGUID"]);
                    break;

                case "2466": // Wilbur D. Mills Education Service Cooperative
                    CoopProviderEmail = ConfigurationManager.AppSettings["WDMCOPEmail"];
                    assignedGuid = new Guid(ConfigurationManager.AppSettings["WDMCOOPGUID"]);
                    break;

                case "2467": // Pulaski County
                    CoopProviderEmail = ConfigurationManager.AppSettings["PCCOPEmail"]; //"saltschul@pcssd.org"; //"DASK@pcssd.org";
                    assignedGuid = new Guid(ConfigurationManager.AppSettings["PCCOOPGUID"]);
                    break;

                case "2577": // Little Rock School District Group
                    CoopProviderEmail = ConfigurationManager.AppSettings["LRSCOPEmail"];
                    assignedGuid = new Guid(ConfigurationManager.AppSettings["LRSCOOPGUID"]);
                    break;

                case "2846": // North Little Rock School District Group
                    CoopProviderEmail = ConfigurationManager.AppSettings["NLRCOPEmail"]; //"pettits@nlrsd.k12.ar.us"; //"wassond@nlrsd.k12.ar.us";
                    assignedGuid = new Guid(ConfigurationManager.AppSettings["NLRCOOPGUID"]);
                    break;

                case "2465": // Western Arkansas Cooperative
                    CoopProviderEmail = ConfigurationManager.AppSettings["WACCOPEmail"]; //"waesc.tech@wscstarfish.com";
                    assignedGuid = new Guid(ConfigurationManager.AppSettings["WACCOOPGUID"]);
                    break;

                default:
                    CoopProviderEmail = ConfigurationManager.AppSettings["NCACOPEmail"];
                    assignedGuid = new Guid(ConfigurationManager.AppSettings["NCACOOPGUID"]);
                    break;
            }
            #endregion

            this.SaveTicket(this.CurrentUser.Sid,
                _txtName.Text, _txtEmail.Text, _txtPhone.Text, this.ddlCategory.SelectedItem.Text ,  _txtComments.Text,
                Convert.ToInt32(Cooperatives.SelectedItem.Value), -15, -23, Request.Browser.Browser, assignedGuid, 0);

            #region Email Coop
            if (CoopProviderEmail != string.Empty)
            {
                MailMessage mailMessage = new MailMessage();
                string[] emailToList = CoopProviderEmail.Replace(';', ',').Split(',');
                for (int i = 0; i < emailToList.Length; i++)
                {
                    if (emailToList[i] != "" || emailToList[i] != String.Empty)
                        mailMessage.To.Add(new MailAddress(emailToList[i]));
                }

                string mailBodyEmail, mailBodyName, mailBodyTel, mailBodySubject, mailBodyCoop;
                mailBodyEmail = txtEmail.Text;
                mailBodyName = txtName.Text;
                mailBodyTel = txtPhone.Text;
                mailBodyCoop = Cooperatives.SelectedItem.Text;
                //
                //Set Contact Category
                mailBodySubject = ddlCategory.SelectedItem.Text;
                mailMessage.Bcc.Add(new MailAddress(ConfigurationManager.AppSettings["escWorksSupport"]));
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["Mail.From"]);
                mailMessage.Subject = "New Helpdesk Ticket:" + mailBodySubject;
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = chkASAP.Checked ? MailPriority.High : MailPriority.Normal;

                string mailBody = string.Format(
                    "Message:<br><br>\n<div style=\"background-color:#EEEEEE;padding:5px;\">{0}</div><br><br>\n-------------------------------<br>\n     Support Information<br>\n-------------------------------<br>\nContact Person: {2}<br>\nContact Email: {3}<br>\nContact Phone: {4}<br><br>\nNOTE: DO NOT REPLY TO THIS MESSAGE.\n",
                    this.txtComments.Text,
                    (mailBodyCoop.Length < 0) ? "Cooperative: " + mailBodyCoop + "<br>\n" : "",
                    mailBodyName,
                    mailBodyEmail,
                    mailBodyTel
                    );

                //
                // Sending mail object to mail server
                //
                mailMessage.Body = mailBody;
                SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["Smtp_Server"]);
                smtpClient.Send(mailMessage);
            }
            #endregion
        }
        catch (Exception m)
        {
            region4.ErrorReporter.ReportError(m, Context, region4.ErrorReporter.Severity.notgiven, region4.ErrorReporter.Occurance.basePages);
        }

        _pStep1.Visible = false;
        _pStep2.Visible = true;

        string script = "<script language='javascript' ID='Message'>grecaptcha.reset();</script>";
        ScriptManager.RegisterStartupScript((Page)HttpContext.Current.Handler, typeof(Page), "Message", script, false);

    }


    public bool SaveTicket(Guid sid, string name, string email, string phone, string title, string description, int coop, int category, int supportType, string browser, Guid escworksAssignedID, int IsEscworks)
    {
        using (SqlCommand SQLCommand = new SqlCommand("[/helpdesk/create/SaveTicket]", region4.Common.DataConnection.DbConnection))
        {

            SQLCommand.CommandType = CommandType.StoredProcedure;
            SQLCommand.Connection.Open();
            SQLCommand.Parameters.AddWithValue("@sid", sid);
            SQLCommand.Parameters.AddWithValue("@coop", coop);
            SQLCommand.Parameters.AddWithValue("@product_id", category);
            SQLCommand.Parameters.AddWithValue("@type_id", supportType);
            SQLCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = name;
            SQLCommand.Parameters.Add("@email", SqlDbType.NVarChar, 200).Value = email;
            SQLCommand.Parameters.Add("@phone", SqlDbType.NVarChar, 50).Value = phone;
            SQLCommand.Parameters.Add("@title", SqlDbType.NVarChar, 200).Value = title;
            SQLCommand.Parameters.AddWithValue("@description", description);
            SQLCommand.Parameters.Add("@browser", SqlDbType.NVarChar, 50).Value = browser;
            SQLCommand.Parameters.AddWithValue("@escworksAssignedID", escworksAssignedID);
            SQLCommand.Parameters.AddWithValue("@IsEscworks", IsEscworks);

            try
            {
                SQLCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.ToString());
                return false;
            }
            finally
            {
                if (SQLCommand.Connection.State != ConnectionState.Closed)
                    SQLCommand.Connection.Close();
            }

        }
    }

    private void EmailFeedBack()
    {
        string mailBodyEmail, mailBodyName, mailBodyTel, mailBodySubject, mailBodyContact, emailSubject, mailBodyCoop;
        mailBodyEmail = txtEmail.Text;
        mailBodyName = txtName.Text;
        mailBodyTel = txtPhone.Text;

        //
        //Set Region Cooperative
        mailBodyCoop = Cooperatives.SelectedItem.Text;

        //
        //Set Contact Category
        mailBodySubject = ddlCategory.SelectedItem.Text;

        MailMessage mailMessage = new MailMessage();
        //
        //Set Contact
        if (chkASAP.Checked == true)
        {
            mailBodyContact = "Yes";
            mailMessage.Priority = MailPriority.High;
        }
        else
        {
            mailBodyContact = "No";
            mailMessage.Priority = MailPriority.Normal;
        }

        //
        //Set Email Subject
        emailSubject = "ESCWEB Feedback: " + mailBodySubject;

        //
        //Email Properties
        string[] emailToList = ddlCategory.SelectedItem.Value.Replace(';', ',').Split(',');
        for (int i = 0; i < emailToList.Length; i++)
        {
            if (emailToList[i].Trim().Length > 0 && emailToList[i].Trim().Contains("@"))
            {
                mailMessage.To.Add(new MailAddress(emailToList[i]));
            }
        }
        mailMessage.Bcc.Add(new MailAddress(ConfigurationManager.AppSettings["escWorksSupport"]));
        mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["Mail.From"]);
        mailMessage.Subject = emailSubject;
        mailMessage.IsBodyHtml = true;

        //
        //Build Email Content
        string mailBody = "<html><body><table>";
        mailBody += "<tr><td><b>Region Cooperative:&nbsp;</b></td><td>" + mailBodyCoop + "</td></tr>";
        mailBody += "<tr><td><b>Feedback Category:&nbsp;</b></td><td>" + mailBodySubject + "</td></tr>";
        mailBody += "<tr><td><b>Contact Requested?&nbsp;</b></td><td>" + mailBodyContact + "</td></tr><tr><td>&nbsp;</td></tr>";
        mailBody += "<tr><td><b>User Name:&nbsp;</b></td><td>" + mailBodyName + "</td></tr>";
        mailBody += "<tr><td><b>User Email:&nbsp;</b></td><td><a href=\"mailto:" + mailBodyEmail + "\">" + mailBodyEmail + "</a></td></tr>";
        mailBody += "<tr><td><b>User Telephone:&nbsp;</b></td><td>" + mailBodyTel + "</td></tr></table><br/>";
        mailBody += "<p><b>Comments:</b></p><p>";
        mailBody += txtComments.Text;
        mailBody += "</p><p><i>CustomerID:&nbsp;" + ConfigurationManager.AppSettings["CustomerId"].ToString() + "<br/>Authenticated:&nbsp;" + 
            Request.IsAuthenticated.ToString() + "<br/>Browser:&nbsp;" + 
            Request.ServerVariables["HTTP_USER_AGENT"] + "</p><p>Note: Do not reply to this message. It is sent from an unmonitored account.</i>";
        mailBody += "</p></body></html>";

        //
        //Send email
        try
        {
            mailMessage.Body = mailBody;
            SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["Smtp_Server"]);
            smtpClient.Send(mailMessage);
        }
        catch { }
    }

}
