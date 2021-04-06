using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace escWeb.ar_esc.ObjectModel
{
    [Serializable]
    public class Session : region4.ObjectModel.Session
    {
        private bool _isStem;

        public bool isStem
        {
            get { return _isStem; }
            set { _isStem = value; }
        }

        private int _ownerOrgId;

        public int OwnerOrgId
        {
            get { return _ownerOrgId; }
            set { _ownerOrgId = value; }
        }

        public Session(int session_id) : base(session_id)
        {
                    
        }

        public override DateTime RegistrationEndDate
        {
            get
            {
                if (_regEnd == region4.ObjectModel.modelConstants.DefaultMaxDateTime)
                {
                    DateTime time;
                    if (!region4.escWeb.SiteVariables.EndRegistrationAtMidnight)
                        time = (IsOnline || IsMultiVenueOnline) ? new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, EndDate.Hour, EndDate.Minute, EndDate.Second)
                            : new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, StartDate.Hour, StartDate.Minute, StartDate.Second);
                    else
                        time = (IsOnline || IsMultiVenueOnline) ? new DateTime(EndDate.Year, EndDate.Month, EndDate.Day)
                            : new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, StartDate.Hour, StartDate.Minute, StartDate.Second);

                    return time.AddHours(0);
                }
                else
                {
                    return _regEnd;
                }
            }

        }

        protected override void LoadCustomerData(SqlDataReader reader)
        {
            _isStem = (bool)reader["isStem"];
            _ownerOrgId = (int)reader["ownerOrgId"];
        }

        public override bool DisplayOnWeb
        {
            get
            {
                if (ConfigurationManager.AppSettings["CustomerSiteId"] == "ar_esc")
                    return DisplayOnWebOmitOnline && !this._notOnline;
                else
                    return DisplayOnWebOmitOnline && !this._notOnline && OwnerOrgId == 12861;
            }
        }
    }
}