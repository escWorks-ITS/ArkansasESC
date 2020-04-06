using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace escWeb.tx_r19.ObjectModel
{
    /// <summary>
    /// Summary description for AttendeeInfo
    /// </summary>
    [Serializable]
    public class SessionInfo : region4.ObjectModel.SessionInfo
    {
        private bool _qcApproved;

        public bool QCApproved
        {
            get { return _qcApproved; }
        }
        
        public SessionInfo(DataRow reader) : base(reader)
        {
            //
            // TODO: Add constructor logic here
            //
        }

        protected override void LoadCustomerData(DataRow reader)
        {
            _qcApproved = (bool)(reader["QCApproved"]);
         
        }

        public override bool DisplayOnWebOmitOnline
        {
            get
            {
                //Omit excluded event types from showing on the web.
                bool excludedType = false;
                int[] excludedTypes = region4.escWeb.SiteVariables.eventTypesToNotDisplay;
                for (int lcv = 0; lcv < excludedTypes.Length; lcv++)
                    excludedType |= excludedTypes[lcv] == _eventType.ItemId;

                //Omit sessions created by someone not in the specified organizations
                bool orgOkay = true;
                if (region4.escWeb.SiteVariables.LimitSessionsToOrganizations)
                    orgOkay = region4.escWeb.SiteVariables.LimitSessionOrganizations.Contains(this._organizationID);

                //Omit sessions crated by someone not in the specified sites
                bool siteOkay = true;
                if (region4.escWeb.SiteVariables.LimitSessionsToSite)
                    siteOkay = region4.escWeb.SiteVariables.LimitSessionSites.Contains(this._siteID);

                //Omit sessions from site customers that aren't in thier specified front-ends
                bool siteCustomerOkay = true;
                if (region4.escWeb.SiteVariables.LimitToEscWorksSiteCustomerID > 0)
                    siteCustomerOkay = region4.escWeb.SiteVariables.LimitToEscWorksSiteCustomerID != this._siteID;

                return this._qcApproved && this._approved && this._active && !excludedType && orgOkay && siteOkay && siteCustomerOkay;
            }
        }
    }
}