using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace escWeb.ar_esc.ObjectModel
{
    /// <summary>
    /// Summary description for SessionAttendee
    /// </summary>
    [Serializable]
    public class SessionInfoList : region4.ObjectModel.SessionInfoList
    {
        public SessionInfoList(DataSet dataset)
            : base(dataset)
        {
        }

        public static SessionInfoList DoSearch(bool faceToFace, bool online, bool free, bool weekend, string Keywords, int orgId)
        {
            SessionInfoList sessionInfoList = (escWeb.ar_esc.ObjectModel.SessionInfoList)ARLoadSearchSessions(orgId);
           // SessionInfoList sessionInfoList = (escWeb.ar_esc.ObjectModel.SessionInfoList)LoadSearchSessions(orgId);

          return sessionInfoList.SearchInMemory(faceToFace, online, free, weekend, Keywords, orgId);
        }




        protected SessionInfoList SearchInMemory(bool faceToFace, bool online, bool free, bool weekend, string Keywords, int orgId)
        {
            SessionInfoList result = (escWeb.ar_esc.ObjectModel.SessionInfoList)region4.ObjectModel.ObjectProvider.ReturnSessionInfoList(null);

            int number;
            bool isNumber = false;
            if (Int32.TryParse(Keywords, out number))
                isNumber = true;

            foreach (SessionInfo sessionInfo in this)
            {
                //If Keywords is SessionID, then use DisplayOnWebOmitOnline, otherwise, use DisplayOnWeb
                bool OKtoAdd;
                if (isNumber && (sessionInfo.SessionID == number) )
                    OKtoAdd = sessionInfo.DisplayOnWebOmitOnline;
                else
                    OKtoAdd = (sessionInfo.DisplayOnWeb);

                OKtoAdd &= (faceToFace && (sessionInfo.IsFaceToFace || sessionInfo.IsConference || sessionInfo.IsMultiVenue))
                        || (online && (sessionInfo.IsOnline || sessionInfo.IsMultiVenueOnline));

                if (free)
                    OKtoAdd &= (sessionInfo.Fee <= 0);

                if (weekend && (sessionInfo.IsFaceToFace || sessionInfo.IsConference || sessionInfo.IsMultiVenue))
                    OKtoAdd &= (sessionInfo.StartDate.DayOfWeek == DayOfWeek.Saturday || sessionInfo.StartDate.DayOfWeek == DayOfWeek.Sunday);

                if (orgId != 12861)
                {
                    if ((orgId > 0 && orgId != 99 && orgId != 999))
                        OKtoAdd &= (sessionInfo.OrganizationID == orgId); //orgId=12861 ADE


                    if (orgId == 99)
                        OKtoAdd &= (!(sessionInfo as escWeb.ar_esc.ObjectModel.SessionInfo).IsSTEM);

                    if (orgId == 999)
                        OKtoAdd &= ((sessionInfo as escWeb.ar_esc.ObjectModel.SessionInfo).IsSTEM);
                }

                if (Keywords.Length > 0)
                {
                    string[] SearchTerms = Keywords.Split(' ');
                    string SearchField = sessionInfo.SessionID.ToString() + "|" + sessionInfo.EventID.ToString() + "|"
                        + sessionInfo.Title + " " + sessionInfo.Description + " "
                        + sessionInfo.EventTypeDisplay + " " + sessionInfo.Subtitle + " "
                        + sessionInfo.SearchField;
                    foreach (string term in SearchTerms)
                    {
                        OKtoAdd &= SearchField.ToLower().Contains(term.ToLower());
                    }
                }
                if (OKtoAdd && sessionInfo.IsConference)//Conference only add once
                {
                    foreach (SessionInfo temp in result)
                    {
                        if (temp.EventID == sessionInfo.EventID)
                        {
                            OKtoAdd = false;
                            break;
                        }
                    }
                }

                if (OKtoAdd)
                    result.Add(sessionInfo);
            }
            return result;
        }
    }
}