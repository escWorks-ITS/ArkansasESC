
using System.Web;
using System.Collections;

using System.Web.Services.Protocols;

using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Services;
using AjaxControlToolkit;
using System.Collections.Specialized;
using System.Data.SqlClient;


/// <summary>
/// Summary description for locationService
/// </summary>

public class locationService : region4.escWeb.WebServices.locationservices_asmx
{



    [WebMethod]
    public override CascadingDropDownNameValue[] GePositionsFromSchool(string knownCategoryValues, string category)
    {


        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

        int school_id;
        if (!kv.ContainsKey("Room") || !Int32.TryParse(kv["Room"], out school_id))
            return null;

        List<CascadingDropDownNameValue> result = new List<CascadingDropDownNameValue>();

        using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = region4.baseStoredProcedures.Item.ReturnPositions;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@school_id", school_id);

            try
            {
                cmd.Connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string _displayName = reader["display"].ToString();
                        int _objId = (int)reader["item_pk"];
                        result.Add(new CascadingDropDownNameValue(_displayName, _objId.ToString()));
                    }
                    reader.Close();
                    reader.Dispose();
                }
            }
            catch (Exception e)
            {
                region4.ErrorReporter.ReportError(e, System.Web.HttpContext.Current);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        return result.ToArray();
    }

}

