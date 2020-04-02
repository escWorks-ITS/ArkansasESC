using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace escWeb.tx_r3.ObjectModel
{
    [Serializable]
    public class Site : region4.ObjectModel.Site
    {
        private int _district_identifier_id;
        public int DistrictIdentifierId
        {
            get{ return _district_identifier_id;}
            set { _district_identifier_id = value;}
        }

        private string _district_identifier_name;
        public string DistrictIdentiferName
        {
            get { return _district_identifier_name; }
            set { _district_identifier_name = value; }
        }

        private bool _isDistrictIdentifier;
        public bool IsDistrictIdentifier
        {
            get {

                if (ConfigurationManager.AppSettings["accountability.district.campus.identifiers"].Contains(_district_identifier_id.ToString()) && _district_identifier_id > 0)
                        _isDistrictIdentifier = true;
                    else
                        _isDistrictIdentifier = false;

                return _isDistrictIdentifier;
            }
            set { _isDistrictIdentifier = value; }
        }

        private bool _isDidNotMeetFirst;
        public bool IsDidNotMeetFirst
        {
            get { return _isDidNotMeetFirst; }
            set { _isDidNotMeetFirst = value; }
        }

        public Site(int obj_id)
            : base(obj_id)
        {
        }

        protected override void LoadCustomerData(SqlCommand cmd)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "[p.objectModel.Location.Site.CustomerSpec.Load]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@site_id", this.obj_id);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    _district_identifier_id = Convert.ToInt32(reader["identifier_id"].ToString());
                    _district_identifier_name = reader["identifier_name"].ToString();
                    _isDidNotMeetFirst = (bool)reader["DidNotMeetFirst"];
                }
                reader.Close();
            }
            cmd.CommandText = "";
            cmd.Parameters.Clear();
        }

    }

    [Serializable]
    public class Room : region4.ObjectModel.Room
    {
        private int _school_identifier_id;
        public int SchoolIdentifierId
        {
            get { return _school_identifier_id; }
            set { _school_identifier_id = value; }
        }

        private string _school_identifier_name;
        public string SchoolIdentiferName
        {
            get { return _school_identifier_name; }
            set { _school_identifier_name = value; }
        }

     
        private bool _isSchoolIdentifier;
        public bool IsSchoolIdentifier
        {
            get
            {

                if (ConfigurationManager.AppSettings["accountability.district.campus.identifiers"].Contains(_school_identifier_id.ToString()) && _school_identifier_id> 0)
                    _isSchoolIdentifier = true;
                else
                    _isSchoolIdentifier = false;

                return _isSchoolIdentifier;
            }

            set { _isSchoolIdentifier = value; }
        }

        public Room(int obj_id)
            : base(obj_id)
        {
        }

        protected override void LoadCustomerData(SqlCommand cmd)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "[p.objectModel.Location.room.CustomerSpec.Load]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@room_id", this.obj_id);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    _school_identifier_id = reader["identifier_id"]== DBNull.Value ?0:Convert.ToInt32(reader["identifier_id"].ToString());
                    _school_identifier_name = reader["identifier_name"].ToString();
                }
                reader.Close();
            }
            cmd.CommandText = "";
            cmd.Parameters.Clear();
        }
    }

    [Serializable]
    public class Organization : region4.ObjectModel.Organization
    {
        string _ESCTechnicalContactName1;
        string _ESCTechnicalContactEmail1;
        string _ESCTechnicalContactName2;
        string _ESCTechnicalContactEmail2;

        public string ESCTechnicalContactEmail1
        {
            get { return _ESCTechnicalContactEmail1.Trim(); }
        }

        public string ESCTechnicalContactEmail2
        {
            get { return _ESCTechnicalContactEmail2.Trim(); }
        }

        public Organization(int obj_id)
            : base(obj_id)
        {
        }

        protected override void LoadCustomerData(SqlCommand cmd)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "[p.objectModel.Location.Org.CustomerSpec.Load]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@site_id", this.obj_id);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    _ESCTechnicalContactName1 = reader["ESCTechnicalContactName1"] == DBNull.Value? string.Empty : reader["ESCTechnicalContactName1"].ToString();
                    _ESCTechnicalContactEmail1 = reader["ESCTechnicalContactEmail1"] == DBNull.Value ? string.Empty : reader["ESCTechnicalContactEmail1"].ToString();
                    _ESCTechnicalContactName2 = reader["ESCTechnicalContactName2"] == DBNull.Value ? string.Empty : reader["ESCTechnicalContactName2"].ToString();
                    _ESCTechnicalContactEmail2 = reader["ESCTechnicalContactEmail2"] == DBNull.Value ? string.Empty : reader["ESCTechnicalContactEmail2"].ToString();
                }
                reader.Close();
            }
            cmd.CommandText = "";
            cmd.Parameters.Clear();
        }
    }
}