using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Net3ViewingLocation
/// </summary>
[Serializable]
public struct Net3ViewingLocation : IComparable
{
    public int obj_id;
    public string Display;
    public string ContactEmail1;
    public string ContactEmail2;

    public static Net3ViewingLocation ReturnLocation(int obj_id)
    {
        Net3ViewingLocation location = new Net3ViewingLocation();
        location.obj_id = obj_id;

        if (obj_id != 0)
        {
            using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "[p.ObjectModel.Net3ViewingLocation.ReturnLocation]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@obj_id", obj_id);

                try
                {
                    cmd.Connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        location.Display = reader["display"].ToString();
                        location.ContactEmail1 = reader["ContactEmail1"].ToString();
                        location.ContactEmail2 = reader["ContactEmail2"].ToString();
                        reader.Close();
                        reader.Dispose();
                    }

                }
                catch (Exception e)
                {
                    region4.ErrorReporter.ReportError(e, System.Web.HttpContext.Current, region4.ErrorReporter.Severity.notgiven, region4.ErrorReporter.Occurance.objectModel);
                    return location;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }

        return location;
    }

    public override int GetHashCode()
    {
        return ((int)region4.ObjectModel.BaseHashCodes.Item << 16) | this.obj_id;
    }

    public override bool Equals(object obj)
    {
        if (Object.ReferenceEquals(null, obj))
            return false;
        Net3ViewingLocation rhs;
        try
        {
            rhs = (Net3ViewingLocation)obj;
        }
        catch
        {
            return false;
        }
        return this.Display == rhs.Display && this.ContactEmail1 == rhs.ContactEmail1 && this.ContactEmail2 == rhs.ContactEmail2 && this.obj_id == rhs.obj_id;
    }

    public static bool operator ==(Net3ViewingLocation lhs, Net3ViewingLocation rhs)
    {
        return lhs.Equals(rhs);
    }

    public static bool operator !=(Net3ViewingLocation lhs, Net3ViewingLocation rhs)
    {
        return !lhs.Equals(rhs);
    }

    #region IComparable Members

    public int CompareTo(object obj)
    {
        Net3ViewingLocation item = (Net3ViewingLocation)obj;

        if (this.Display == item.Display && this.obj_id != item.obj_id)
            return this.obj_id - item.obj_id;

        return this.Display.CompareTo(item.Display);
    }

    #endregion
}


[Serializable]
public class Net3ViewingLocations
{
    private List<Net3ViewingLocation> locations = new List<Net3ViewingLocation>();

    public int Count { get { return locations.Count; } }

    public int Add(Net3ViewingLocation e)
    {
        if (!locations.Contains(e))
        {
            locations.Add(e);
        }
        return locations.Count;
    }

    public IEnumerator<Net3ViewingLocation> GetEnumerator()
    {
        foreach (Net3ViewingLocation e in locations)
            yield return (Net3ViewingLocation)e;
    }

    public static Net3ViewingLocations ReturnViewingLocations()
    {
        Net3ViewingLocations collection = new Net3ViewingLocations();

        using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "[p.ObjectModel.Net3ViewingLocation.ReturnLocations]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                cmd.Connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Net3ViewingLocation location = new Net3ViewingLocation();
                        location.obj_id = (int)reader["obj_id"];
                        location.Display = reader["display"].ToString();
                        location.ContactEmail1 = reader["ContactEmail1"] == DBNull.Value ? string.Empty : reader["ContactEmail1"].ToString();
                        location.ContactEmail2 = reader["ContactEmail2"] == DBNull.Value ? string.Empty : reader["ContactEmail2"].ToString();
                        collection.Add(location);
                    }

                    reader.Close();
                    reader.Dispose();
                }
            }
            catch (Exception e)
            {
                region4.ErrorReporter.ReportError(e, System.Web.HttpContext.Current, region4.ErrorReporter.Severity.notgiven, region4.ErrorReporter.Occurance.objectModel);
                return new Net3ViewingLocations();
            }
            finally
            {
                cmd.Connection.Close();
            }

        }

        return collection;
    }

}