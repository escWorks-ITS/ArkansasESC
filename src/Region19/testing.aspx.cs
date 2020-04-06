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
using System.Net;
using System.Xml;

public partial class testing : region4.escWeb.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["online"] = false;


        WebClient client = new WebClient ();
        string xmlstring = client.DownloadString(" https://www.escweb.net/demo/session.ashx");


        XmlDocument xml = new XmlDocument();
        xml.LoadXml(xmlstring); // suppose that myXmlString contains "<Names>...</Names>"

        XmlNodeList xnList = xml.SelectNodes("/list/event");
        foreach (XmlNode xn in xnList)
        {
            string SessionID = xn["obj_id"].InnerText;
            string Title = xn["title"].InnerText;

            string Subtitle = xn["subtitle"].InnerText;

            string Instructor = xn["instructor"].InnerText;
            string Location = xn["location"].InnerText;
            string RoomID = xn["roomId"].InnerText;
            string RoomName = xn["roomName"].InnerText;
            string Date = xn["date"].InnerText;
            string BeginTime = xn["beginTime"].InnerText;
            string EndTime = xn["endTime"].InnerText;
            string URL = xn["URL"].InnerText;
            string Begin = xn["begin"].InnerText;


            Response.Write(string.Format("DigitalSinage Data: <br>SessionID:{0}<br> Title:{1} <br>SubTitle:{2}", SessionID, Title, Subtitle));


        }



       
    }
   
}
