using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public partial class QRcodeMultiDates : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {

            string attendee_id =  Request.QueryString["ID"].ToString();
            string firstname = "";
            string lastname = "";

            string location = "";
            string phone = "";
            string email = "";

            SqlConnection SQLConn = region4.Common.DataConnection.DbConnection;

            bool isValidipAddr=true;

           

            using (SqlCommand SQLCommand = new SqlCommand("[/qrcode/validipaddr]",SQLConn))
            {

                SQLCommand.CommandType = CommandType.StoredProcedure;

                SQLCommand.Parameters.AddWithValue("@ipaddr", System.Web.HttpContext.Current.Request.UserHostAddress);

                SQLCommand.Parameters.AddWithValue("@returnvalue", 0).Direction = ParameterDirection.ReturnValue;

                SQLCommand.Parameters.AddWithValue("@attendeeID", Convert.ToInt32(attendee_id));

                SQLCommand.Parameters.Add("@fname", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                SQLCommand.Parameters.Add("@lname", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;

                SQLCommand.Parameters.Add("@location", SqlDbType.NVarChar, 1024).Direction = ParameterDirection.Output;
                SQLCommand.Parameters.Add("@phone", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                SQLCommand.Parameters.Add("@email", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;

                 SQLCommand.Connection.Open();

                    try
                    {
                        SQLCommand.ExecuteNonQuery();
                        firstname = SQLCommand.Parameters[3].Value.ToString();
                        lastname = SQLCommand.Parameters[4].Value.ToString();
                        location = SQLCommand.Parameters[5].Value.ToString();
                        phone = SQLCommand.Parameters[6].Value.ToString();
                        email = SQLCommand.Parameters[7].Value.ToString();

                        if (Convert.ToBoolean(SQLCommand.Parameters[1].Value))
                        {
                            isValidipAddr = true;

                        }

                        else
                            isValidipAddr = false;
                    }

                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }


                   
                 finally
                    {
                        if (SQLCommand.Connection.State != ConnectionState.Closed)
                            SQLCommand.Connection.Close();

                        SQLCommand.Connection.Dispose();
                    }

            
            }

           

            if (isValidipAddr)
            {
                SqlConnection SQLConn2 = region4.Common.DataConnection.DbConnection;
            
                using (SqlCommand SQLCommand = new SqlCommand("[/qrcode/multidates/attendance]", SQLConn2))
                {
                    SQLCommand.CommandType = CommandType.StoredProcedure;
                    SQLCommand.Parameters.AddWithValue("@attendeeID", Convert.ToInt32(attendee_id));

                    SQLCommand.Parameters.AddWithValue("@returnvalue", 0).Direction = ParameterDirection.ReturnValue;

                    SQLCommand.Parameters.Add("@count", SqlDbType.Int,4).Direction = ParameterDirection.Output;
                    SQLCommand.Parameters.Add("@fname",SqlDbType.NVarChar,100).Direction = ParameterDirection.Output;
                    SQLCommand.Parameters.Add("@lname", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;

                    SQLCommand.Connection.Open();

                    try
                    {
                        SQLCommand.ExecuteNonQuery();
                        firstname = SQLCommand.Parameters[3].Value.ToString();
                        lastname = SQLCommand.Parameters[4].Value.ToString();


                        if (Convert.ToInt32(SQLCommand.Parameters[2].Value) == 1)
                        {

                            if (Convert.ToBoolean(SQLCommand.Parameters[1].Value))
                                namedisplay.Text = firstname + " " + lastname + ", Successfully marked Attended!";
                            else

                                namedisplay.Text = firstname + " " + lastname + ", Not Successfully marked Attended!";
                        }
                        else if (Convert.ToInt32(SQLCommand.Parameters[2].Value) > 1)
                        {
                            // plMultiSessions.Visible = true;

                            Response.Redirect("QRAttendanceMultidates2.aspx?user_id=" + Request.QueryString["ID"].ToString() + "&fname=" + firstname + "&lname=" + lastname);

                        }

                        else
                            namedisplay.Text = "Sorry, Nothing to take attendance, it could be this Session is happening in future, not today OR You are already marked attended";



                    }

                    catch (Exception ex)
                    {
                        //Response.Write(ex.Message);

                        Response.Write("Please run QRcode for sessions that are taking place today.");
                    }

                    finally
                    {
                        if (SQLCommand.Connection.State != ConnectionState.Closed)
                            SQLCommand.Connection.Close();

                        SQLCommand.Connection.Dispose();
                    }                       

                }


            }

            else
            {
               // namedisplay.Text = "Please try with scanning from Secured Region4 Network.";

                namedisplay.Text = firstname + ' ' + lastname;


                namedisplay.Text += "<br>";
                namedisplay.Text += location;
                namedisplay.Text += "<br>";
                namedisplay.Text += phone;
                namedisplay.Text += "<br>";
                namedisplay.Text += email;
                namedisplay.Text += "<br>";


            }


        }
        catch (Exception Ex)
        {
            System.Web.HttpContext.Current.Response.Write(Ex.Message);
           // Response.End();

        }
    }      
    
}