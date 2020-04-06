using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : region4.escWeb.BasePages.default_aspx
{
    public struct FileNameURL
    {
        public string FileName;
        public string URL;
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        List<FileNameURL> listFiles = new List<FileNameURL>();

        using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = region4.baseStoredProcedures.escWeb.HomePageLoadAdvertisementFile;
            cmd.Parameters.AddWithValue("@CustomerCode", region4.escWeb.SiteVariables.customer_id);
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
            hyperLink.ImageWidth = new Unit(450);
            hyperLink.ImageHeight = new Unit(300);
            hyperLink.Text = "Advertisement File";

            if (fileNameURL.URL.Contains(region4.escWeb.SiteVariables.CustomerHostUrl))
            {
                hyperLink.Target = "_self";
            }
            else
            {
                hyperLink.Target = "_blank";
            }
            divAdItems.Controls.Add(hyperLink);
        }
    }
}
