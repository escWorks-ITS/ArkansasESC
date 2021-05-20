using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace escWeb.ar_esc.ObjectModel
{
    [Serializable]
    public class User : region4.ObjectModel.User
    {
        private string _employeeNo = string.Empty;

        public string EmployeeNo
        {
            get { return _employeeNo; }
            set { _employeeNo = value; }
        }

        private int _accommodationId;
        public int AccommodationId
        {
            get { return _accommodationId; }
            set { _accommodationId = value; }
        }

        public User(int user_pk)
            : base(user_pk)
        {
        }

        public User(Guid sid)
            : base(sid)
        {
        }

        protected override void LoadCustomerInfo(System.Data.SqlClient.SqlCommand cmd)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "[p.objectModel.User.CustomerSpec.Load]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sid", this.Sid);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    _accommodationId = (reader["SpecialNeed_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SpecialNeed_ID"]);
                }
                reader.Close();
            }
            cmd.CommandText = "";
            cmd.Parameters.Clear();
        }

        protected override void SaveCustomerInfo(System.Data.SqlClient.SqlCommand cmd)
        {
            string query = string.Empty;

            cmd.Parameters.Clear();
            cmd.CommandText = "[p.objectModel.User.CustomerSpec.Save]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sid", this.Sid);
            cmd.Parameters.AddWithValue("@special_needs_id", AccommodationId);
           
            cmd.ExecuteNonQuery();

            cmd.CommandText = "";
            cmd.Parameters.Clear();

        }

        protected override void SaveCustomerInfo(SqlParameterCollection sqc)
        {
            sqc.AddWithValue("@employeeNo", this._employeeNo);
            sqc.AddWithValue("@facilitator", base._facilitator);
        }

        protected override void LoadCustomerInfo(DataRow reader)
        {
            this._employeeNo = reader["employeeNo"].ToString();
        }

        protected override void LoadCustomerInfo(SqlDataReader reader)
        {
            this._employeeNo = reader["employeeNo"].ToString();
        }



        public virtual string[] GetUserRoles()
        {
            //We already have data! 
            if (ALroles.Count > 0)
            {
                string[] roles = new string[ALroles.Count];
                for (int j = 0; j < ALroles.Count; j++)
                {
                    roles[j] = ALroles[j].ToString();
                }
                return roles;
            }

            using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
            {
                SqlCommand cmd = conn.CreateCommand();
                try
                {
                    if (cmd.Connection.State != System.Data.ConnectionState.Open)
                        cmd.Connection.Open();

                    cmd.CommandText = region4.baseStoredProcedures.escWeb.GetUserRoles;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@sid", this.Sid);
                   // cmd.Parameters.AddWithValue("@sid", this.PrimaryEmail);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ALroles.Add("authenticateduser");
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                if (Convert.ToBoolean(reader.GetSqlValue(i).ToString()))
                                    ALroles.Add(reader.GetName(i).ToLower());
                            }
                        }
                    }
                    string[] roles = new string[ALroles.Count];
                    for (int j = 0; j < ALroles.Count; j++)
                    {
                        roles[j] = ALroles[j].ToString();
                    }
                    return roles;
                }
                catch (Exception ex)
                {
                    region4.ErrorReporter.ReportError(ex, System.Web.HttpContext.Current, region4.ErrorReporter.Severity.notgiven, region4.ErrorReporter.Occurance.objectModel);
                    SetLoadingException(ex);
                    return null;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }

    }
}