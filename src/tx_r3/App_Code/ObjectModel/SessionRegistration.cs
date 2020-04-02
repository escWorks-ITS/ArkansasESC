using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for Attendee
/// </summary>

namespace escWeb.tx_r3.ObjectModel
{
    [Serializable]
    public class SessionRegistration : region4.ObjectModel.SessionRegistration
    {
        public SessionRegistration(Session session, User user)
            : base(session, user)
        {
        }

        public SessionRegistration(Session session, User user, bool overrideLimit)
            : base(session, user, overrideLimit)
        {
        }

        //Requester Information
        public string _requesterName;
        public string _requesterEmail;
        public string _requesterPhone;
        public string _requesterPosition;

        //Teacher Information
        public string _TeacherName;
        public string _TeacherEmail;
        public string _TeacherPhone;
        public string _TeacherDistrictName;
        public string _TeacherCampusName;
        public int _TeacherTotalNumberStudents; //This only applies to Net3Student
        public string _TeacherCity;
        public string _TeacherState;
        public string _TeacherZipCode;
        public string _TeacherCountry;

        //AdditionalTeachers
        public string _Teacher2Name;
        public string _Teacher2Email;
        public string _Teacher3Name;
        public string _Teacher3Email;
        public string _Teacher4Name;
        public string _Teacher4Email;
        public string _Teacher5Name;
        public string _Teacher5Email;

        //Interaction
        public string _InteractionQuestion1;
        public string _InteractionQuestion2;
        public string _InteractionQuestion3;

        //Technical Contact
        public string _TechnicalContactName;
        public string _TechnicalContactEmail;
        public string _TechnicalContactPhone;

        //Texas Viewing Locations
        public int _TexasViewingRegion;
        public int _TexasViewingRegion3Site;

        //Connection INformation
        public string _ConnectionInfoIPNumber;
        public string _ConnectionInfoSystemType;
        public string _ConnectionInfoBridgeInfo;
        public string _ConnectionInfoConnectionComments;

        public bool IsNet3studentEvent
        {
            get
            {  //Modified by VM 4-28-2017
                escWeb.tx_r3.ObjectModel.Event myEvent;
                escWeb.tx_r3.ObjectModel.Conference myConference;
                escWeb.tx_r3.ObjectModel.MultiVenue myMultiVenue;

                if (this._session.Event.isConference)
                {
                    myConference = this._session.Event as escWeb.tx_r3.ObjectModel.Conference;
                    return myConference.IsNet3StudentEvent;
                }
                else if (this._session.Event.isMultiVenue)
                {
                    myMultiVenue = this._session.Event as escWeb.tx_r3.ObjectModel.MultiVenue;
                    return myMultiVenue.IsNet3StudentEvent;
                }
                else
                {
                    myEvent = this._session.Event as escWeb.tx_r3.ObjectModel.Event;
                    return myEvent.IsNet3StudentEvent;
                }
            }
        }

        public bool IsNet3Event
        {
            
            get
            { //Modified by VM 4-28-2017
                 escWeb.tx_r3.ObjectModel.Event myEvent;
                 escWeb.tx_r3.ObjectModel.Conference myConference;
                 escWeb.tx_r3.ObjectModel.MultiVenue myMultiVenue;

                if (this._session.Event.isConference)
                {
                    myConference = this._session.Event as escWeb.tx_r3.ObjectModel.Conference;
                    return myConference.IsNet3Event;
                }
                else if (this._session.Event.isMultiVenue)
                {
                    myMultiVenue = this._session.Event as escWeb.tx_r3.ObjectModel.MultiVenue;
                    return myMultiVenue.IsNet3Event;
                }
                else
                {
                    myEvent = this._session.Event as escWeb.tx_r3.ObjectModel.Event;
                    return myEvent.IsNet3Event;
                }
            }
        }

        protected override bool SaveAdditionalRegistrationData()
        {
            if (!IsNet3studentEvent && !IsNet3Event)
                return true;

            //Save the registration Entry
            using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "[p.ObjectModel.SessionRegistration.CustSpec.SaveRegistrationAdditionalData]";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandTimeout = 60;

                        cmd.Parameters.AddWithValue("@attendee_pk", _attendeeID);

                        if (this.IsNet3studentEvent)
                        {
                            //Requester Information
                            cmd.Parameters.AddWithValue("@RequesterName", _requesterName);
                            cmd.Parameters.AddWithValue("@RequesterEmail", _requesterEmail);
                            cmd.Parameters.AddWithValue("@RequesterPhone", _requesterPhone);
                            cmd.Parameters.AddWithValue("@RequesterPosition", _requesterPosition);

                            //Teacher Information
                            cmd.Parameters.AddWithValue("@TeacherTotalNumberStudents", _TeacherTotalNumberStudents);

                            //AdditionalTeachers
                            cmd.Parameters.AddWithValue("@Teacher2Name", _Teacher2Name);
                            cmd.Parameters.AddWithValue("@Teacher2Email", _Teacher2Email);
                            cmd.Parameters.AddWithValue("@Teacher3Name", _Teacher3Name);
                            cmd.Parameters.AddWithValue("@Teacher3Email", _Teacher3Email);
                            cmd.Parameters.AddWithValue("@Teacher4Name", _Teacher4Name);
                            cmd.Parameters.AddWithValue("@Teacher4Email", _Teacher5Email);
                            cmd.Parameters.AddWithValue("@Teacher5Name", _Teacher5Name);
                            cmd.Parameters.AddWithValue("@Teacher5Email", _Teacher5Email);

                            //Interaction
                            cmd.Parameters.AddWithValue("@InteractionQuestion1", _InteractionQuestion1);
                            cmd.Parameters.AddWithValue("@InteractionQuestion2", _InteractionQuestion2);
                            cmd.Parameters.AddWithValue("@InteractionQuestion3", _InteractionQuestion3);
                        }

                        //Teacher Information
                        cmd.Parameters.AddWithValue("@TeacherName", _TeacherName);
                        cmd.Parameters.AddWithValue("@TeacherEmail", _TeacherEmail);
                        cmd.Parameters.AddWithValue("@TeacherPhone", _TeacherPhone);
                        cmd.Parameters.AddWithValue("@TeacherDistrictName", _TeacherDistrictName);
                        cmd.Parameters.AddWithValue("@TeacherCampusName", _TeacherCampusName);
                        cmd.Parameters.AddWithValue("@TeacherCity", _TeacherCity);
                        cmd.Parameters.AddWithValue("@TeacherState", _TeacherState);
                        cmd.Parameters.AddWithValue("@TeacherZipCode", _TeacherZipCode);
                        cmd.Parameters.AddWithValue("@TeacherCountry", _TeacherCountry);

                        //Technical Contact
                        cmd.Parameters.AddWithValue("@TechnicalContactName", _TechnicalContactName);
                        cmd.Parameters.AddWithValue("@TechnicalContactEmail", _TechnicalContactEmail);
                        cmd.Parameters.AddWithValue("@TechnicalContactPhone", _TechnicalContactPhone);

                        //Texas Viewing Locations
                        cmd.Parameters.AddWithValue("@TexasViewingRegion", _TexasViewingRegion);
                        cmd.Parameters.AddWithValue("@TexasViewingRegion3Site", _TexasViewingRegion3Site);

                        //Connection Information
                        cmd.Parameters.AddWithValue("@ConnectionInfoIPNumber", _ConnectionInfoIPNumber);
                        cmd.Parameters.AddWithValue("@ConnectionInfoSystemType", _ConnectionInfoSystemType);
                        cmd.Parameters.AddWithValue("@ConnectionInfoBridgeInfo", _ConnectionInfoBridgeInfo);
                        cmd.Parameters.AddWithValue("@ConnectionInfoConnectionComments", _ConnectionInfoConnectionComments);

                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                }
            }
        }
    }
}