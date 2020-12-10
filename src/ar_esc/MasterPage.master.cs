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
using System.Xml;

public partial class MasterPage : region4.escWeb.MasterPage
{
    protected string pageBackgroundColor;
    protected string escBorder = "";
    protected string BannerTheme;
    protected string PushyMenu;
    protected string logo;
    protected string logoBackgroundColor;
    protected string logoSpaceColor;
    protected string logoLink;
    protected string logoTitle;

    protected string mainBodyBackgroundColor;
    protected string contentBackgroundColor;
    protected System.Drawing.Color pageTitleBackgroundColor;
    protected string mainBodyBorderStyle;
    protected string mainBodyBorderWidth;
    protected string mainBodyBorderColor;

    protected string menuBackgroundColor;
    protected string menuBorderColor;
    protected string menuBorderWidth;
    protected string menuBorderStyle;
    protected string menuHeight;

    protected string quickLinkColor;
    protected string pdfDownloadFontColor;
    protected string pdfDownloadLabel;
    protected string linklogo;


    protected string footerBackgroundColor;
    protected string footerFontColor;
    protected string footerText;

    protected string cssMaster;
    protected string cssPageTitle;
    protected string cssMenu;
    protected string cssCalendar;
    protected string cssShoppingCart;
    protected string cssJscalendar;

    protected string cid = string.Empty;



    public override void AssignControlsToBase()
    {
      base._pageTitle = this.pageTitle;
        base._stagingIndicator = lblStagingServer;
    }
    protected override void OnLoad(EventArgs e)
    {

        base.OnLoad(e);
    }
    protected override void OnInit(EventArgs e)
    {
        //loadFiles();
        loadStyles();
        base.OnInit(e);
    }

    protected void loadStyles()
    {
        string path = Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, @"looknfeel.xml");
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(path);
        getStyleFromXml(xmlDocument.OuterXml);
    }


    protected void getStyleFromXml(string xmlSource)
    {
        StringReader stream = new StringReader(xmlSource);
        XmlTextReader reader = new XmlTextReader(stream);

        while (reader.Read())
        {
            reader.ReadToFollowing("customerID");
            cid = (reader.GetAttribute("id"));
            flList.Visible = false;

            if (cid == "ar_ade")
                panelFooter.Visible = true;
            else
                panelFooter.Visible = false;
            //if (cid == "nd_s")
            //{
            //    panelFooterCus.Visible = true;
            //    panelFooter.Visible = false;
            //}
            //else
            //{
            //    panelFooterCus.Visible = false;
            //    panelFooter.Visible = true;
            //}



            if (region4.escWeb.SiteVariables.CustomerSiteId == cid)
            {
                if (region4.escWeb.SiteVariables.CustomerSiteId == "ar_esc")
                {
                    BannerTheme = "summerhead";                   
                    PushyMenu = "~/lib/img/pushy.png";
                    escBorder = "id='escBorder' style = 'outline: 5px solid #c91e26;'";
                }
                else
                {
                    BannerTheme = "summerhead2";
                    //PushyMenu = "ResolveUrl('~/lib/img/ar_ade/logo320pushy.png')";
                    PushyMenu = "~/lib/img/ar_ade/logo320pushy.png";
                }
                reader.ReadToFollowing("page");
                pageBackgroundColor = reader.GetAttribute("color");
                reader.ReadToFollowing("header");
                logo = reader.GetAttribute("logo");
                logoBackgroundColor = reader.GetAttribute("background-color");
                logoSpaceColor = reader.GetAttribute("space-color");
                logoLink = reader.GetAttribute("logoLink");
                logoTitle = reader.GetAttribute("logoTitle");

                reader.ReadToFollowing("mainBody");
                mainBodyBackgroundColor = reader.GetAttribute("backgroundColor");
                pageTitleBackgroundColor = System.Drawing.Color.FromName(reader.GetAttribute("pageTitleBackgroundColor"));
                contentBackgroundColor = reader.GetAttribute("contentBackgroundColor");
                mainBodyBorderStyle = reader.GetAttribute("borderStyle");
                mainBodyBorderWidth = reader.GetAttribute("borderWidth");
                mainBodyBorderColor = reader.GetAttribute("borderColor");

                reader.ReadToFollowing("menu");
                menuBackgroundColor = reader.GetAttribute("backgroundColor");
                menuBorderStyle = reader.GetAttribute("borderStyle");
                menuBorderColor = reader.GetAttribute("borderColor");
                menuBorderWidth = reader.GetAttribute("borderWidth");
                menuHeight = reader.GetAttribute("menuHeight");

                reader.ReadToFollowing("quickLinkLogo");
                quickLinkColor = reader.GetAttribute("fontColor");
                linklogo = reader.GetAttribute("linklogo");

                reader.ReadToFollowing("pdfdownload");
                pdfDownloadFontColor = reader.GetAttribute("fontColor");
                pdfDownloadLabel = reader.GetAttribute("label");
                reader.ReadToFollowing("footer");
                footerBackgroundColor = reader.GetAttribute("backgroundColor");
                footerText = reader.GetAttribute("text");
                footerFontColor = reader.GetAttribute("fontColor");

                reader.ReadToFollowing("cssRoot");

                StringReader cssStream = new StringReader(reader.ReadInnerXml());
                XmlTextReader cssXmlReader = new XmlTextReader(cssStream);

                cssXmlReader.ReadToFollowing("css");
                while (cssXmlReader.Name == "css")
                {

                    if (cssXmlReader.GetAttribute("name") == "master") { cssMaster = cssXmlReader.GetAttribute("path"); }
                    if (cssXmlReader.GetAttribute("name") == "pageTitle") { cssPageTitle = cssXmlReader.GetAttribute("path"); }
                    if (cssXmlReader.GetAttribute("name") == "menu") { cssMenu = cssXmlReader.GetAttribute("path"); }
                    if (cssXmlReader.GetAttribute("name") == "calendar") { cssCalendar = cssXmlReader.GetAttribute("path"); }
                    if (cssXmlReader.GetAttribute("name") == "shoppingCart") { cssShoppingCart = cssXmlReader.GetAttribute("path"); }

                    cssXmlReader.ReadToFollowing("css");
                }

                break;
            }
            else
            {
                if (region4.escWeb.SiteVariables.CustomerSiteId == "ar_esc")
                {
                    BannerTheme = "summerhead";
                    PushyMenu = "/lib/img/pushy.png";
                    escBorder = "style = 'border: 5px solid #c91e26'";
                }
                else
                {
                    BannerTheme = "summerhead2";
                    //PushyMenu = "ResolveUrl('~/lib/img/ar_ade/logo320pushy.png')";
                    PushyMenu = "/lib/img/ar_ade/logo320pushy.png";
                }
            }
        }
    }

    /*private void loadFiles()
    {
        using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select ID, Filename from FileAttachments";
            Table tbl = (Table)this.FindControl("lftlinks");

            try
            {
                cmd.Connection.Open();
                SqlDataReader sqlReader = cmd.ExecuteReader();
                TableRow fileRow = null;
                TableCell fileCell = null;
                TableCell fileDelCell = null;
                while (sqlReader.Read())
                {
                    fileRow = new TableRow();
                    fileCell = new TableCell();
                    fileDelCell = new TableCell();
                    fileDelCell.Text = "<a href='Default.aspx?ID=" + sqlReader[0].ToString() + "'><img border='0' width='10' height='10' src='http://localhost:2317/tx_gccisd/lib/img/delete.bmp'></a>";
                    fileRow.Cells.Add(fileDelCell);
                    fileCell.HorizontalAlign = HorizontalAlign.Left;
                    fileCell.Text = "<b><a href='FileDisplay.aspx?ID=" + sqlReader[0].ToString() + "' target='_new'>" + sqlReader[1].ToString() + "</a></b>";
                    fileRow.Cells.Add(fileCell);
                    tbl.Rows.Add(fileRow);
                }
            }
            catch
            {

            }
            finally
            {
                cmd.Connection.Close();
            }
        }
    }*/
}
