
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Xml;

public partial class _Default : region4.escWeb.BasePages.default_aspx
{

    protected string sloganBackgroundColor;
    protected string logoSpaceColor;
    protected string logoSmallSpaceColor;
    protected string sloganFontColor;
    protected string sloganImage;
    protected string textLine1, textLine2;
    protected string profDevBackColor;
    protected string goBtn;

    protected string flashBackgroundColor;
    protected string pdflash;
    protected string pdhtml;
    protected string upcomingBackgroundColor;
    protected string contactusFontColor;
    protected string myCustomerId = string.Empty;
    protected string url = string.Empty;
    protected string cid = string.Empty;


    public struct FileNameURL
    {
        public string FileName;
        public string URL;
    }


    protected override void OnPreInit(EventArgs e)
    {
        loadStyles();

        base.OnPreInit(e);




        // System.Web.HttpBrowserCapabilities bc = System.Web.HttpContext.Current.Request.Browser;
        string UserAgent = System.Web.HttpContext.Current.Request.UserAgent;
        string Browser = System.Web.HttpContext.Current.Request.Browser.Browser;
        string Browserversion = System.Web.HttpContext.Current.Request.Browser.Version;
        int majorversion = System.Web.HttpContext.Current.Request.Browser.MajorVersion;

        //System.Web.HttpContext.Current.Response.Write("Browser:" + Browser);
        //System.Web.HttpContext.Current.Response.Write("<br>");

        //System.Web.HttpContext.Current.Response.Write("majorversion:" + majorversion.ToString());

        //System.Web.HttpContext.Current.Response.Write("<br>");

        //System.Web.HttpContext.Current.Response.Write("Browserversion:" + Browserversion.ToString());
        //System.Web.HttpContext.Current.Response.Write("<br>");
        //System.Web.HttpContext.Current.Response.Write("Platform:" + System.Web.HttpContext.Current.Request.Browser.Platform.ToString());
        //System.Web.HttpContext.Current.Response.Write("<br>");
        //System.Web.HttpContext.Current.Response.Write("agent:" + UserAgent);
        //System.Web.HttpContext.Current.Response.Write("<br>");

        // _browserID.Text = "Agent:" + UserAgent + "<br>" + "browser:" + Browser + "<br>" + "browser version:" + Browserversion + "<br>" + "Major version:" + majorversion.ToString();

        //System.Web.HttpContext.Current.Response.Write("httpagent:"+Request.ServerVariables["HTTP_USER_AGENT"]);
        //System.Web.HttpContext.Current.Response.Write("<br>");

        if (Session["BS"] != "yes" &&
            ((Browser == "InternetExplorer" && System.Web.HttpContext.Current.Request.Browser.MajorVersion < Convert.ToInt32(ConfigurationManager.AppSettings["ieversion"].ToString()))
            || (Browser == "IE" && System.Web.HttpContext.Current.Request.Browser.MajorVersion < 7 && UserAgent.IndexOf(".NET4.0E") < 0)  // On few machine browser as IE
            || (Browser == "Chrome" && System.Web.HttpContext.Current.Request.Browser.MajorVersion < Convert.ToInt32(ConfigurationManager.AppSettings["chromeversion"].ToString()))
            || (UserAgent.IndexOf("Windows NT 5.1") > 0 && Browser == "IE")  //windows xp
            || (UserAgent.IndexOf("Windows NT 5.1") > 0 && Browser == "Chrome" && System.Web.HttpContext.Current.Request.Browser.MajorVersion < Convert.ToInt32(ConfigurationManager.AppSettings["chromeversion"].ToString())) //windows xp
            || (UserAgent.IndexOf("Windows NT 5.1") > 0 && Browser == "InternetExplorer") //windows xp
            || Browser == "Safari"
            || Browser == "Firefox"
            || (Browser == "IE" && System.Web.HttpContext.Current.Request.Browser.MajorVersion < Convert.ToInt32(ConfigurationManager.AppSettings["ieversion"].ToString()) && UserAgent.IndexOf(".NET4.0E") < 0)
            )
           )
        {
            // Response.Redirect("browsercheck.aspx");
            string url = "browsercheck.aspx";
            string ws = "window.open('" + url + "', 'popup_window', 'width=700,height=800,left=100,top=100,resizable=yes,scrollbars=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", ws, true);
            Session.Add("BS", "yes");

        }
    }


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
           
            if (cid == region4.escWeb.SiteVariables.CustomerSiteId) //if (Request.ApplicationPath.Contains(reader.GetAttribute("id")))
            {
                reader.ReadToFollowing("header");
                logoSpaceColor = reader.GetAttribute("space-color");
                logoSmallSpaceColor = reader.GetAttribute("space-color_s");

                reader.ReadToFollowing("slogan");
                sloganBackgroundColor = reader.GetAttribute("backgroundColor");
                profDevBackColor = reader.GetAttribute("profDevBackColor");
                sloganFontColor = reader.GetAttribute("fontColor");
                sloganImage = reader.GetAttribute("src");
                if (sloganImage == "")
                    logoSpaceColor = profDevBackColor;
                //else
                //    logoSpaceColor = reader.GetAttribute("space-color");


                textLine1 = reader.GetAttribute("textLine1");
                textLine2 = reader.GetAttribute("textLine2");
                goBtn = reader.GetAttribute("go");

                reader.ReadToFollowing("flash");
                flashBackgroundColor = reader.GetAttribute("backgroundColor");
                pdflash = "swf_files/" + cid + "/" + reader.GetAttribute("swf");
                pdhtml = "swf_files/" + cid + "/" + reader.GetAttribute("html");

                reader.ReadToFollowing("upcoming");
                upcomingBackgroundColor = reader.GetAttribute("backgroundColor");

                reader.ReadToFollowing("contactus");
                contactusFontColor = reader.GetAttribute("fontColor");
                break;
            }
        }
    }




    protected override void OnInit(EventArgs e)
    {

        base.OnInit(e);

        List<FileNameURL> listFiles = new List<FileNameURL>();

        using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = region4.baseStoredProcedures.escWeb.HomePageLoadAdvertisementFile;
            cmd.Parameters.AddWithValue("@CustomerCode", region4.escWeb.SiteVariables.CustomerSiteId);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int fileSize = Convert.ToInt32(reader["fileSize"].ToString());
                    string fileName = reader["filename"].ToString();
                    string URL = reader["URL"].ToString();
                    byte[] byteArray = new byte[fileSize];
                    long DataToRead = reader.GetBytes(reader.GetOrdinal("binary"), 0, byteArray, 0, fileSize);
                    DateTime timestampDB = reader.GetDateTime(reader.GetOrdinal("timestamp"));

                    FileNameURL fileNameURL = new FileNameURL();
                    fileNameURL.FileName = fileName;
                    fileNameURL.URL = URL;
                    listFiles.Add(fileNameURL);


                    try
                    {
                        string completeFilePath = HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath)
                                + "/swf_files/" + fileName;

                        bool bWriteFile = true;

                        if (File.Exists(completeFilePath))
                        {
                            DateTime timestampFile = File.GetLastWriteTime(completeFilePath);
                            //If timestamp from Database is newer than file timestamp, then overwrite file from database
                            if (timestampDB <= timestampFile)
                            {
                                bWriteFile = false;
                            }
                        }

                        if (bWriteFile)
                        {
                            // Open file for reading  
                            System.IO.FileStream fileStream = new System.IO.FileStream(completeFilePath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                            // Writes a block of bytes to this stream using data from a byte array.
                            fileStream.Write(byteArray, 0, byteArray.Length);
                            // close file stream
                            fileStream.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }

        //Loopthrough files
        foreach (FileNameURL fileNameURL in listFiles)
        {
            HyperLink hyperLink = new HyperLink();
            hyperLink.NavigateUrl = fileNameURL.URL;
            hyperLink.ImageUrl = "swf_files/" + fileNameURL.FileName;
            hyperLink.ImageWidth = new Unit(550);
            hyperLink.ImageHeight = new Unit(362);
            hyperLink.Text = "Advertiment File";

            if (fileNameURL.URL.Contains(region4.escWeb.SiteVariables.CustomerHostUrl))
            {
                hyperLink.Target = "_self";
            }
            else
            {
                hyperLink.Target = "_blank";
            }
            divAdItems.Controls.Add(hyperLink);


            //string completeFilePath = HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath) + "/swf_files/advertisement.html";
            //DateTime timestamp = region4.ObjectModel.modelConstants.DefaultDateTime;

            //if (File.Exists(completeFilePath))
            //{
            //    timestamp = File.GetLastWriteTime(completeFilePath);
            //}

            //using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
            //{
            //    SqlCommand cmd = conn.CreateCommand();
            //    cmd.CommandText = region4.baseStoredProcedures.escWeb.HomePageLoadAdvertisementFile;
            //    cmd.Parameters.AddWithValue("@timestamp", timestamp);
            //    cmd.Parameters.AddWithValue("@CustomerCode", region4.escWeb.SiteVariables.customer_id);
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //    cmd.Connection.Open();

            //    using (SqlDataReader reader = cmd.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            int fileSize = Convert.ToInt32(reader["fileSize"].ToString());
            //            byte[] byteArray = new byte[fileSize];
            //            long DataToRead = reader.GetBytes(reader.GetOrdinal("binary"), 0, byteArray, 0, fileSize);
            //            try
            //            {
            //                // Open file for reading  
            //                System.IO.FileStream fileStream = new System.IO.FileStream(completeFilePath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            //                // Writes a block of bytes to this stream using data from a byte array.
            //                fileStream.Write(byteArray, 0, byteArray.Length);
            //                // close file stream
            //                fileStream.Close();
            //            }
            //            catch (Exception ex)
            //            {
            //            }
            //        }
            //    }
            //}

        }
    }
}


/*using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : region4.escWeb.BasePages.default_aspx
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        string completeFilePath = HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath) + "/swf_files/advertisement.html";
        DateTime timestamp = region4.ObjectModel.modelConstants.DefaultDateTime;

        if (File.Exists(completeFilePath))
        {
            timestamp = File.GetLastWriteTime(completeFilePath);
        }

        using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = region4.baseStoredProcedures.escWeb.HomePageLoadAdvertisementFile;
            cmd.Parameters.AddWithValue("@timestamp", timestamp);
            cmd.Parameters.AddWithValue("@CustomerCode", region4.escWeb.SiteVariables.customer_id);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int fileSize = Convert.ToInt32(reader["fileSize"].ToString());
                    byte[] byteArray = new byte[fileSize];
                    long DataToRead = reader.GetBytes(reader.GetOrdinal("binary"), 0, byteArray, 0, fileSize);
                    try
                    {
                        // Open file for reading  
                        System.IO.FileStream fileStream = new System.IO.FileStream(completeFilePath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                        // Writes a block of bytes to this stream using data from a byte array.
                        fileStream.Write(byteArray, 0, byteArray.Length);
                        // close file stream
                        fileStream.Close();
                    }
                    catch (Exception ex)
                    {
                    }
 * 
                }
            }
        }
    }
}
*/