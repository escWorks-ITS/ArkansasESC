using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Telerik.Web.UI;
using escWeb.ar_esc.ObjectModel;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

using System.Configuration;

using System.Xml;
using System.IO;


public partial class Search : System.Web.UI.UserControl
{
   

    string appPath = string.Empty;
    int orgId;

    protected string cid = string.Empty;
    protected string mySkin;


    protected void loadStyles()
    {
        string xmlSource;
        string[] path = System.IO.Directory.GetFiles(HttpContext.Current.Server.MapPath("~"), "looknfeel.xml");
        StreamReader reader = new StreamReader(path[0]);
        xmlSource = reader.ReadToEnd();
        reader.Close();
        getStyleFromXml(xmlSource);

        //string path = Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, @"looknfeel.xml");
        //XmlDocument xmlDocument = new XmlDocument();
        //xmlDocument.Load(path);
        //getStyleFromXml(xmlDocument.OuterXml);
    }

    protected void getStyleFromXml(string xmlSource)
    {
        StringReader stream = new StringReader(xmlSource);
        XmlTextReader reader = new XmlTextReader(stream);

        while (reader.Read())
        {
            reader.ReadToFollowing("customerID");
            cid = (reader.GetAttribute("id"));
            if (region4.escWeb.SiteVariables.CustomerSiteId.Contains(reader.GetAttribute("id"))) //if (Request.ApplicationPath.Contains(reader.GetAttribute("id")))
            {
                reader.ReadToFollowing("search");
                mySkin = reader.GetAttribute("searchSkin");
                break;
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        GetCooperatives(ddOrganizationId, true, -1);
    }

    public void GetCooperatives(DropDownList list, bool HaveSessions, int CooperativeId)
    {
        list.Items.Clear();
        list.Items.Add(new ListItem("All", ""));
        list.Items.Add(new ListItem("All Cooperatives", "99"));

        ListItemCollection stemList = new ListItemCollection();

        using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
        {
            SqlCommand SQLCommand = conn.CreateCommand();
            SQLCommand.CommandText = "[p.catalog.cooperatives]";
            SQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SQLCommand.Parameters.AddWithValue("@sessions", HaveSessions);
            SQLCommand.Parameters.AddWithValue("@cooperative_id", CooperativeId);

            try
            {
                SQLCommand.Connection.Open();

                using (SqlDataReader reader = SQLCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if ((!(bool)reader["isSTEM"]))
                            list.Items.Add(new ListItem(reader["display"].ToString(), reader["key"].ToString()));
                        else
                            stemList.Add(new ListItem(reader["display"].ToString(), reader["key"].ToString()));
                    }

                    if (stemList.Count > 0)
                    {
                        list.Items.Add(new ListItem("All STEMS", "999"));

                        foreach (ListItem i in stemList)
                            list.Items.Add(i);
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["SearchCriteria"] != null)
            {
                txtSearch.Text = Request.QueryString["SearchCriteria"].ToString();
            }
            

        }
        loadStyles();
        LoadData();
    }




    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadData();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtSearch.Text = string.Empty;
        chkWeekend.Checked = false;
        chkFree.Checked = false;
        LoadData();
        lbError.Visible = false;
    }

    private void LoadData()
    {
       

        appPath = region4.escWeb.SiteVariables.CustomerSiteId; //Request.ApplicationPath;
        string[] sites = ConfigurationManager.AppSettings["ar.siteId"].Split('|');

        int orgId = -1;

        foreach (string site in sites)
        {
            string[] orgs = site.Split(':');
            if (appPath.Contains(orgs[0]))
            {
                orgId = Convert.ToInt32(orgs[1]);
                break;
            }
        }
        if (orgId == 12861)
        {
            plESC.Visible = false;

            grdSearch.DataSource = SessionInfoList.DoSearch(true, false, chkFree.Checked, chkWeekend.Checked, this.txtSearch.Text.Trim(), orgId);
            grdSearchMobile.DataSource = SessionInfoList.DoSearch(true, false, chkFree.Checked, chkWeekend.Checked, this.txtSearch.Text.Trim(), orgId);

        }
        else
        {

            if (!string.IsNullOrEmpty(ddOrganizationId.SelectedValue))
            {
                orgId = int.Parse(ddOrganizationId.SelectedValue);
            }

            grdSearch.DataSource = SessionInfoList.DoSearch(true, false, chkFree.Checked, chkWeekend.Checked, this.txtSearch.Text.Trim(), orgId);
            grdSearch.DataBind();
            grdSearchMobile.DataSource = SessionInfoList.DoSearch(true, false, chkFree.Checked, chkWeekend.Checked, this.txtSearch.Text.Trim(), orgId);
            grdSearchMobile.DataBind();
        }
    }
}
