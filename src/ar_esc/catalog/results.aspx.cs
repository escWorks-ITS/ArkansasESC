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
using System.Collections.Generic;
using System.Data.SqlClient;
using region4;

public partial class catalog_results :  region4.escWeb.BasePages.Catalog.result_aspx
{

    protected override void AssignControlsToBase()
    {
        base._tableResults = this.resultsTable;
    }

    protected override List<region4.ObjectModel.Event> ReturnConferenceEvents()
    {
        List<region4.ObjectModel.Event> result = new List<region4.ObjectModel.Event>();
        string custId = ConfigurationManager.AppSettings["CustomerSiteId"];
        using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
        {

            SqlCommand cmd = conn.CreateCommand();
            try
            {
                cmd.Connection.Open();
                cmd.Parameters.Clear();
                cmd.CommandText = baseStoredProcedures.Conference.ReturnConferences;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ownerOrgId", (custId=="ar_esc") ? -1 : 12861);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        region4.ObjectModel.Event e = region4.escWeb.SiteVariables.ObjectProvider.ReturnEvent((int)reader["eventid"]);
                        result.Add(e);
                    }
                    reader.Close();
                    reader.Dispose();
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        return result;
    }
}
