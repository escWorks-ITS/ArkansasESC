

using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections;
using System.Net.Mail;
using region4;
using region4.escWeb;

/// <summary>
/// Summary description for CancelRegistration
/// </summary>


namespace escWeb.tx_r19.ObjectModel
{
    public class CancelRegistration : region4.Utilities.Financial.CancelRegistration
    {
        private bool _cancelStatus = false;
        public bool CancelStatus
        {
            get { return _cancelStatus; }
            set { _cancelStatus = value; }
        }
        
        public CancelRegistration()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        User u;

        public override void ProcessPORefund(DataSet DS, int Payment_id, region4.ObjectModel.Attendee attendee)
        {
            u = (escWeb.tx_r19.ObjectModel.User)HttpContext.Current.Session["profile"]; 

            using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
            {

                SqlCommand SQLCommand = conn.CreateCommand();
                SQLCommand.CommandText = baseStoredProcedures.CancelRegistration.RefundPOPayment;
                SQLCommand.CommandType = CommandType.StoredProcedure;


                double PORefundAmount = 0.0;
                DataView dv = DS.Tables[0].DefaultView;
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    DataRowView drv = dv[i];

                    PORefundAmount = Convert.ToDouble(Decimal.Round(Convert.ToDecimal(drv["amount"].ToString()), 2));
                    SQLCommand.Parameters.AddWithValue("@attendee_id", attendee.ID);
                    SQLCommand.Parameters.AddWithValue("@payment_id", Payment_id);
                    SQLCommand.Parameters.AddWithValue("@PORefundAmount", PORefundAmount);
                    SQLCommand.Parameters.AddWithValue("@modifySid", u.Sid);

                    SQLCommand.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        SQLCommand.Connection.Open();

                        SQLCommand.ExecuteNonQuery();

                        _cancelStatus = true;
                    }
                    catch (Exception Ex)
                    {
                        // Response.Write(Ex.Message);
                    }

                    finally
                    {
                        if (SQLCommand.Connection.State != ConnectionState.Closed)
                            SQLCommand.Connection.Close();

                    }
                }
            }


        }


        public override void ProcessCCRefund(DataSet DS, region4.ObjectModel.Attendee attendee)
        {
            region4.Utilities.Financial.CreditCardProcessor processor = new region4.Utilities.Financial.CreditCardProcessor();
            region4.Utilities.Financial.CreditCardTransaction RefundTransaction = new region4.Utilities.Financial.CreditCardTransaction();





            DataView dv = DS.Tables[0].DefaultView;
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                DataRowView drv = dv[i];
                RefundTransaction.PNREF = drv["pnref"].ToString();

                RefundTransaction.Amount = Decimal.Round(Convert.ToDecimal(drv["amount"].ToString()), 2);
             
                region4.ObjectModel.User Cuser = ((region4.escWeb.BasePage)System.Web.HttpContext.Current.CurrentHandler).CurrentUser;
                RefundTransaction.Comment1 = "Credit Refund|"
                    + "|LoginName:" + Cuser.FirstName + " " + Cuser.LastName
                    + "|Email:" + Cuser.PrimaryEmail;
                RefundTransaction.Comment2 = string.Format("{0}|" + drv["sessionID"].ToString() + "|escweb, cancel.aspx", SiteVariables.customer_id);

                //Added by Z
                if (Convert.ToDouble(Decimal.Round(Convert.ToDecimal(drv["amount"].ToString()), 2)) > 0)
                    processor.ProcessRefund(ref RefundTransaction, SiteVariables.customer_id);   

                if (RefundTransaction.RESULT != 0)
                {

                    string clientscript = "<script language=\"JavaScript\">";
                    clientscript += "\n ";
                    clientscript += "alert(\"" + RefundTransaction.RESPMSG + ".";

                    if ((RefundTransaction.RESULT == 1) && (RefundTransaction.RESPMSG == "User authentication failed: NDCE") || (RefundTransaction.RESULT == 1) && (RefundTransaction.RESPMSG == null))
                    {
                        clientscript += " This refund was not able to be processed, please contact ESD 105 for assistance.";
                    }

                    clientscript += "\");\n";
                    clientscript += "</script>";
                    // ClientScript.RegisterClientScriptBlock("client", clientscript);

                    MailMessage msg = new MailMessage();
                    msg.To.Add(ConfigurationManager.AppSettings["escWorksSupport"]);
                    msg.From = new MailAddress(ConfigurationManager.AppSettings["Mail.From"], ConfigurationManager.AppSettings["Mail.From.Name"]);
                    msg.IsBodyHtml = true;
                    msg.Subject = "Paypal Refund Error!";
                    msg.Body = string.Format("Failed to make refund for " + "Customer ID: {0}" + "<br/>", SiteVariables.customer_id);
                    msg.Body += "PNREF:" + RefundTransaction.PNREF + "<br/>";
                    msg.Body += "Reference PNREF:" + RefundTransaction.RefPNREF + "<br/>";
                    msg.Body += "RESPMSG:" + RefundTransaction.RESPMSG + "<br/>";
                    msg.Body += "RESULT:" + RefundTransaction.RESULT + "<br/>";
                    msg.Body += "Amount:" + RefundTransaction.Amount + "<br/>";
                    SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["Smtp_Server"]);
                    smtpClient.Send(msg);
                    if (RefundTransaction.Amount > 0)
                        RecordTransactionData(RefundTransaction, drv["transaction_pk"].ToString(), drv["amount"].ToString(), attendee);
                }
                else
                {
                    if (RefundTransaction.Amount > 0)
                    {
                        RecordTransactionData(RefundTransaction, drv["transaction_pk"].ToString(), drv["amount"].ToString(), attendee);
                        _cancelStatus = true;
                    }
                }
            }

        }

        protected override void RecordTransactionData(region4.Utilities.Financial.CreditCardTransaction transaction, string transaction_id, string amount, region4.ObjectModel.Attendee attendee)
        {
            using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
            {
                SqlCommand SQLCommand = conn.CreateCommand();
                SQLCommand.CommandText = baseStoredProcedures.CancelRegistration.RecordTransactionData;
                SQLCommand.CommandType = CommandType.StoredProcedure;

                SQLCommand.Parameters.Add("@pnref", SqlDbType.NVarChar, 25).Value = transaction.PNREF;
                SQLCommand.Parameters.AddWithValue("@amount", transaction.Amount);
                SQLCommand.Parameters.AddWithValue("@attendee_id", attendee.ID);
                SQLCommand.Parameters.AddWithValue("@result", transaction.RESULT);
                SQLCommand.Parameters.Add("@response", SqlDbType.NVarChar, 50).Value = transaction.RESPMSG;
                SQLCommand.Parameters.AddWithValue("@transaction_id", Convert.ToInt32(transaction_id));


                SQLCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    SQLCommand.Connection.Open();
                    SQLCommand.ExecuteNonQuery();
                }
                catch (Exception Ex)
                {
                    System.Web.HttpContext.Current.Response.Write(Ex.Message);
                }
                finally
                {
                    if (SQLCommand.Connection.State != ConnectionState.Closed)
                        SQLCommand.Connection.Close();
                }
            }
        }
    }
}
