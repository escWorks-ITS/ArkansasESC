using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class catalog_register_checkout : region4.escWeb.BasePages.Catalog.Register.checkout_aspx
{

    protected override void AssignControlsToBase()
    {
        base._lblErrorMessage = lblErrorMessage;
        base._btnCheckout = btnCheckout;
        base._rblPaymentMethod = rblPaymentList;
        base._pCashDetails = pCash;
        base._pCCDetails = pCreditCard;
        base._pCheckDetails = pCheck;
        base._pDCheckDetails = PDCheck;
        base._pMODetails = pMoneyOrder;
        base._pPurchaseOrder = pPurchaseOrder;

        base._expMonth = ddlMonth;
        base._expYear = ddlYear;
        base._nameOnCard = txtNameOnCard;
        base._cardNumber = txtCardNumber;
        base._poNumber = txtPONumber;

        base._lblPaymentPrompt = lblPaymentPrompt;

        base._chkABANumber = txtABANumber;
        base._chkAccountHolder = txtChkAccountHolder;
        base._chkAccountNumber = txtCheckAcctNumber;
        base._pElectronicCheck = pElectronicCheck;
    }

    protected override void AssignCustomerPaymentMethod(string paymentMethod)
    {
        
    }

    protected override void HideCustomerPaymentPanels()
    {
        escWeb.tx_r3.ObjectModel.User currentUser = this.CurrentUser as escWeb.tx_r3.ObjectModel.User;

        if (!this.ShoppingCart.AllowPO)
        {
            if (_rblPaymentMethod.Items.Count > 1)
                _rblPaymentMethod.Items.RemoveAt(1); //Remove PO
        }

    }

    protected override region4.ObjectModel.IPaymentMethod SetCustomerPaymentMethodDisplay(string paymentMethod)
    {
        return null;
    }


    protected override void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (this.ShoppingCart.CartTotal > 0)
                lblCancellationPolicy.Text = "<b><u>Cancellation and Refund Policy:</u></b><br />   Cancellations <b>must</b> be submitted on line or sent to <a  href=\"mailto:cancellations@esc3.net\">cancellations@esc3.net</a> no later than 7 calendar days prior to event"
    + "for a refund. Phone cancellations are not accepted. To help expedite your request, please include the session number or event title and date.  Registrations are transferrable.<br />"
    + "<br />"
   + " A processing fee of 25% of the registration cost will be applied to the refund. Session with a fee of less than $35 will"
    + "be charged the full session fee."
    + "<br />"
    + "No refunds for online courses, nonattendance, or late cancellations submitted one to"
    + "six  calender days prior to the event. Participants will receive a full refund for events"
    + "cancelled by Region 3";

        }

        //Clear output message
        _lblErrorMessage.Text = "";

        //Remove items from cart if necessary
        ArrayList itemsToRemove = new ArrayList();
        string outputMessage = "This following items have been removed from your cart: <br /><br/>You are not currently able to register for this workshop. Please address any questions to the contact person listed for this workshop <br/><br/>";


        foreach (region4.ObjectModel.ICartItem item in this.ShoppingCart)
            if (!item.AvailableToCheckOut(ref outputMessage))
                itemsToRemove.Add(item);

        foreach (region4.ObjectModel.ICartItem item in itemsToRemove)
        {
            if (item is region4.ObjectModel.SessionRegistration)
            {
                region4.ObjectModel.SessionRegistration sessionRegistration = item as region4.ObjectModel.SessionRegistration;
                outputMessage += string.Format("{0} has been removed from {1} {2}. <p/>", sessionRegistration.User.FullName,
                                region4.escWeb.SiteVariables.ObjectProvider.SessionName, sessionRegistration.Session.ID);
            }
            else if (item is region4.ObjectModel.ConferenceRegistration)
            {
                region4.ObjectModel.ConferenceRegistration conferenceRegistration = item as region4.ObjectModel.ConferenceRegistration;
                outputMessage += string.Format("{0} has been removed from {1} {2}. <p/>", conferenceRegistration.User.FullName,
                                region4.escWeb.SiteVariables.ObjectProvider.EventName, conferenceRegistration.ConferenceID);
            }
            else if (item is region4.ObjectModel.ClockHourPurchase)
            {
                region4.ObjectModel.ClockHourPurchase clockHourPurchase = item as region4.ObjectModel.ClockHourPurchase;
                outputMessage += string.Format("{0} for {1} has been removed. <p/>", clockHourPurchase.Display,
                                clockHourPurchase.Description);
            }
            this.ShoppingCart.Remove(item);
        }

        if (itemsToRemove.Count > 0)
            _lblErrorMessage.Text = outputMessage;

        if (this.ShoppingCart.HasOnDemandSession) //Only Credit Cart valid
        {
            itemsToRemove = new ArrayList();
            foreach (ListItem item in _rblPaymentMethod.Items)
            {
                if (!((item.Value == "CC") || (item.Value == "PO" && ShoppingCart.AllowPO))) //Only keep CC && PO if AllowPO
                    itemsToRemove.Add(item);
            }
            foreach (ListItem item in itemsToRemove)
            {
                this._rblPaymentMethod.Items.Remove(item);
            }
        }
    }

    protected override void _btnCheckout_Click(object sender, EventArgs e)
    {
        if (_cbCancellationPolicy != null && !_cbCancellationPolicy.Checked)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "agreement", "<script language=\"javascript\">alert('You must click the checkbox to indicate you have read and understand our cancellation policy.')</script>");
            return;
        }
        if (this.ShoppingCart.ItemCount == 0)
            return;
        region4.ObjectModel.IPaymentMethod paymentMethod = null;

        //Assign payment method
        if (this.ShoppingCart.CartTotal != 0)
        {
            switch (_rblPaymentMethod.SelectedValue)
            {
                case "CC":
                    string cardNumber, nameOnCard;
                    DateTime expDate;

                    cardNumber = _cardNumber.Text.Trim();
                    nameOnCard = _nameOnCard.Text.Trim();
                    if (!DateTime.TryParse(String.Format("{0}/1/{1}", _expMonth.SelectedValue, _expYear.SelectedValue), out expDate))
                    {
                        _lblErrorMessage.Text = "Please select a valid expiration date";
                        return;
                    }

                    if (cardNumber == "")
                    {
                        _lblErrorMessage.Text = "Please enter your credit card number";
                        return;
                    }
                    if (nameOnCard == "")
                    {
                        _lblErrorMessage.Text = "Please enter the name on the credit card";
                        return;
                    }

                    paymentMethod = new region4.ObjectModel.Commerce.CreditCard(cardNumber, expDate, nameOnCard, this.ShoppingCart, this.CurrentUser);
                    break;
                case "ACH":
                    string accountNumber, accountHolder, abaNumber;
                    accountHolder = _chkAccountHolder.Text;
                    accountNumber = _chkAccountNumber.Text;
                    abaNumber = _chkABANumber.Text;

                    paymentMethod = new region4.ObjectModel.Commerce.ElectronicCheck(abaNumber, accountHolder, accountNumber, this.ShoppingCart, this.CurrentUser);

                    break;
                case "MO":
                    paymentMethod = new region4.ObjectModel.Commerce.MoneyOrder();
                    break;
                case "CK":
                    paymentMethod = new region4.ObjectModel.Commerce.CheckPayment();
                    break;
                case "DCK":
                    paymentMethod = new region4.ObjectModel.Commerce.DCheckPayment();
                    break;
                case "CS":
                    paymentMethod = new region4.ObjectModel.Commerce.CashPayment();
                    break;
                case "PO":
                    if (_poNumber.Text.Trim() == "") // Added by VM 4-23-2012
                    {
                        _lblErrorMessage.Text = "Please enter your PO number";
                        return;
                    }
                    if (_poDistrict == null) // Modified by VM 3-20-2012
                        paymentMethod = new region4.ObjectModel.Commerce.PurchaseOrder(_poNumber.Text);
                    else
                    {
                        if (_poDistrict.Text.Trim() == "") // Added by VM 4-23-2012
                        {
                            _lblErrorMessage.Text = "Please enter your district";
                            return;
                        }

                        paymentMethod = new region4.ObjectModel.Commerce.PurchaseOrder(_poNumber.Text, _poDistrict.Text);
                    }
                    break;
                case "SCK":
                    paymentMethod = new region4.ObjectModel.Commerce.SCheckPayment();
                    break;
                default:
                    paymentMethod = SetCustomerPaymentMethodDisplay(_rblPaymentMethod.SelectedValue);
                    if (paymentMethod == null)
                        return;
                    break;
            }
        }
        else
        {
            //If Session fee is $0, then NoFeeMethod, otherwise, CashMethod
            if (this.ShoppingCart.HasDiscountReason)
                paymentMethod = new region4.ObjectModel.Commerce.CashPayment();
            else
                paymentMethod = new region4.ObjectModel.Commerce.NoFeeMethod();
        }

        //Authorize the payment
        string output;
        if (!paymentMethod.AuthorizePayment(out output))
        {
            _lblErrorMessage.Text = output;
            return;
        }

        Guid registrationID = Guid.NewGuid();

        //Complete registration
        foreach (region4.ObjectModel.ICartItem item in this.ShoppingCart)
        {
            string message = string.Empty;
            if (item.AvailableToCheckOut(ref message))
                item.CompleteCheckOut(registrationID, paymentMethod, true);
        }

        this.ShoppingCart.Clear();

        //More items to checkout
        if (this.ShoppingCart2.ItemCount > 0)
        {
            this.ShoppingCart2.MoveItems(this.ShoppingCart);
        }

        this.CurrentUser.Clear(); //Reload user's RegistrationHistory

        Response.Redirect("~/catalog/register/complete.aspx?id=" + registrationID.ToString());

    }
}

