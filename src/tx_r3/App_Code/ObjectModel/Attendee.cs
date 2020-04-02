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
    public class Attendee : region4.ObjectModel.Attendee
    {

        public Attendee(Session session, User user)
            : base(session, user)
        {
        }

        public Attendee(int attendee_pk)
            : base(attendee_pk)
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

        public string RequesterName { get { return _requesterName; } }
        public string RequesterEmail { get { return _requesterEmail; } }
        public string RequesterPhone { get { return _requesterPhone; } }
        public string RequesterPosition { get { return _requesterPosition; } }
        public string TeacherEmail { get { return _TeacherEmail; } }
        public string Teacher2Email { get { return _Teacher2Email; } }
        public string Teacher3Email { get { return _Teacher3Email; } }
        public string Teacher4Email { get { return _Teacher4Email; } }
        public string Teacher5Email { get { return _Teacher5Email; } }
        public int TexasViewingRegion { get { return _TexasViewingRegion; } }
        public string TechnicalContactEmail { get { return _TechnicalContactEmail; } }
        public int TexasViewingRegion3Site { get { return _TexasViewingRegion3Site; } }

        protected override void LoadCustomerData()
        {
            escWeb.tx_r3.ObjectModel.Event myEvent = this.Session.Event as escWeb.tx_r3.ObjectModel.Event;
            if (myEvent == null || (!myEvent.IsNet3Event && !myEvent.IsNet3StudentEvent))
                return;

            using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "[p.ObjectModel.Attendee.LoadAdditionalData]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@attendee_pk", this._attendeeID);

                try
                {
                    cmd.Connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return;
                        }
	                    _requesterName = reader["RequesterName"].ToString(); 
	                    _requesterEmail = reader["RequesterEmail"].ToString(); 
	                    _requesterPhone = reader["RequesterPhone"].ToString(); 
	                    _requesterPosition = reader["RequesterPosition"].ToString(); 
                        _TeacherTotalNumberStudents = reader["TeacherTotalNumberStudents"] == DBNull.Value? 0 : (int) reader["TeacherTotalNumberStudents"];
	                            
	                    _Teacher2Name = reader["Teacher2Name"].ToString(); 
	                    _Teacher2Email = reader["Teacher2Email"].ToString(); 

	                    _Teacher3Name = reader["Teacher3Name"].ToString(); 
	                    _Teacher3Email = reader["Teacher3Email"].ToString(); 

	                    _Teacher4Name = reader["Teacher4Name"].ToString(); 
	                    _Teacher4Email = reader["Teacher4Email"].ToString(); 
	                    _Teacher5Name = reader["Teacher5Name"].ToString(); 
	                    _Teacher5Email = reader["Teacher5Email"].ToString(); 

	                    _InteractionQuestion1 = reader["InteractionQuestion1"].ToString(); 
	                    _InteractionQuestion2 = reader["InteractionQuestion2"].ToString(); 
	                    _InteractionQuestion3 = reader["InteractionQuestion3"].ToString();
 
	                    _TeacherName = reader["TeacherName"].ToString(); 
	                    _TeacherEmail = reader["TeacherEmail"].ToString(); 
	                    _TeacherPhone = reader["TeacherPhone"].ToString(); 
	                    _TeacherDistrictName = reader["TeacherDistrictName"].ToString(); 
	                    _TeacherCampusName = reader["TeacherCampusName"].ToString(); 
	                    _TeacherCity = reader["TeacherCity"].ToString(); 
	                    _TeacherState = reader["TeacherState"].ToString(); 
	                    _TeacherZipCode = reader["TeacherZipCode"].ToString(); 
	                    _TeacherCountry = reader["TeacherCountry"].ToString(); 
	                    _TeacherEmail = reader["TeacherEmail"].ToString(); 

	                    _TechnicalContactName = reader["TechnicalContactName"].ToString(); 
	                    _TechnicalContactEmail = reader["TechnicalContactEmail"].ToString(); 
	                    _TechnicalContactPhone = reader["TechnicalContactPhone"].ToString(); 

                        _TexasViewingRegion = reader["TexasViewingRegion"] == DBNull.Value ? 0 : (int)reader["TexasViewingRegion"];
                        _TexasViewingRegion3Site = reader["TexasViewingRegion3Site"] == DBNull.Value? 0: (int)reader["TexasViewingRegion3Site"];

	                    _ConnectionInfoIPNumber = reader["ConnectionInfoIPNumber"].ToString(); 
	                    _ConnectionInfoSystemType = reader["ConnectionInfoSystemType"].ToString(); 
	                    _ConnectionInfoBridgeInfo = reader["ConnectionInfoBridgeInfo"].ToString(); 
	                    _ConnectionInfoConnectionComments = reader["ConnectionInfoConnectionComments"].ToString(); 

                        reader.Close();
                        reader.Dispose();
                    }

                }
                catch (Exception e)
                {
                    region4.ErrorReporter.ReportError(e, System.Web.HttpContext.Current, region4.ErrorReporter.Severity.notgiven, region4.ErrorReporter.Occurance.objectModel);
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }
    }

}