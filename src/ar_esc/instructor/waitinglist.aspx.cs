using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class instructor_waitinglist : region4.escWeb.BasePage
{
    private int _SessionId;
    public string SessionID
    {
        get { return this._SessionId.ToString(); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        gridWaitingList.DataSource = GetWaitingList(_SessionId);
        gridWaitingList.DataBind();
    }

    protected override void OnInit(EventArgs e)
    {
        this._SessionId = Convert.ToInt32(escWorks.Strings.GetSafeString("sessionid", escWorks.Strings.StringType.QueryString, -1));
        base.OnInit(e);
    }

    public string FormatRegistrationCode(string sessionid, string key, string regcode)
    {
        if (regcode != "")
        {
            return sessionid + "-" + key + "-" + regcode;
        }
        else
        {
            return string.Empty;
        }
    }

    public static DataSet GetWaitingList(int session_id)
    {
        using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "[/catalog/waitinglist/GetWaitingList]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@session_id", session_id);

            try
            {
                cmd.Connection.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception e)
            {
                region4.ErrorReporter.ReportError(e, System.Web.HttpContext.Current);
                return null;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
    }
}