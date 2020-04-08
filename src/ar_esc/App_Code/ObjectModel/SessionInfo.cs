using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace escWeb.ar_esc.ObjectModel
{
    /// <summary>
    /// Summary description for AttendeeInfo
    /// </summary>
    [Serializable]
    public class SessionInfo : region4.ObjectModel.SessionInfo
    {
        private bool _isEsc = true;

        public bool IsEsc
        {
            get { return this._isEsc; }
        }

        private bool _isSTEM = false;

        public bool IsSTEM
        {
            get { return this._isSTEM; }
        }

        private int _ownerOrgId;

        public int OwnerOrgId
        {
            get { return this._ownerOrgId; }
            set { _ownerOrgId = value; }
        }

        public SessionInfo(DataRow reader) : base(reader)
        {

        }

        protected override void LoadCustomerData(DataRow reader)
        {
            if (reader.Table.Columns.Contains("esc"))
               _isEsc = (bool)(reader["esc"] == DBNull.Value ? true : reader["esc"]);
                
            
            if(reader.Table.Columns.Contains("isSTEM"))
                _isSTEM = (bool)reader["isSTEM"];

            if (reader.Table.Columns.Contains("ownerOrgId"))
                _ownerOrgId = (int) reader["ownerOrgId"];
        }

        public override bool DisplayOnWeb
        {
            get
            {
                if (ConfigurationManager.AppSettings["CustomerSiteId"] == "ar_esc")
                    return DisplayOnWebOmitOnline && !this._notOnline;
                else
                    return DisplayOnWebOmitOnline && !this._notOnline && this.OwnerOrgId == 12861;
            }
        }
    }
}