<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="checkout.aspx.cs" Inherits="catalog_register_checkout" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="Server">
    <br />
    <br />
    <asp:Label runat="server" ID="lblErrorMessage" CssClass="error" />
    <br />
    <span style="font-size: 1.25em">Click the 'Complete Checkout' button to register for
        the
        <%# region4.escWeb.SiteVariables.ObjectProvider.SessionPluralName %>
        displayed below.</span>
    <br />
    <br />
    <escWorks:CartDisplay runat="server" ID="cart1" DisplayRemoveButton="false" />
    <br />
 <%--   <b>Cancellation and Refund Policy: </b>
    <br />
    Cancellations <b>must</b> be submitted on line or sent to <a  href="mailto:cancellations@esc3.net">cancellations@esc3.net</a> no later than 7 calendar days prior to event
    for a refund. Phone cancellations are not accepted. Registrations are transferrable.<br />
    <br />
    A processing fee of 25% of the registration cost will be applied to the refund. Session with a fee of less than $35 will
    be charged the full session fee.
    <br />
    No refunds for online courses, nonattendance, or late cancellations submitted one to
    six  calender days prior to the event. Participants will receive a full refund for events
    cancelled by Region 3.--%>

    <asp:Label runat="server" ID="lblPaymentPrompt" Text="Please select a method of payment to continue" />
    <br />
    <table class="mainBody">
        <tr >
            <td>
                <asp:RadioButtonList runat="server" ID="rblPaymentList" AutoPostBack="true" CssClass="mainBody">
                <%--    <asp:ListItem Text="Check" Value="CK" />
                    <asp:ListItem Text="Money Order" Value="MO" />--%>
                    
                    <asp:ListItem Text="Credit Card" Value="CC" />
                    <asp:ListItem Text="Purchase Order" Value="PO" />
                 <%--   <asp:ListItem Text="Cash" Value="CS" />
                    <asp:ListItem Text="Electronic Check" Value="ACH" />--%>
                </asp:RadioButtonList>
            </td>
            <td>
            &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
            </td>
            <td>
                <asp:Panel runat="server" ID="pCheck" Visible="false">
                </asp:Panel>
                <asp:Panel runat="server" ID="PDCheck" Visible="false">
                </asp:Panel>
                <asp:Panel runat="server" ID="pMoneyOrder" Visible="false">
                </asp:Panel>
                <asp:Panel runat="server" ID="pPurchaseOrder" Visible="false">
                    <asp:Label Id="PONumberLabel"
                        text="PO Number:"
                        AssociatedControlID="txtPONumber"
                        runat="server"></asp:Label>
                    <asp:TextBox runat="server" ID="txtPONumber" />
                </asp:Panel>
                <asp:Panel runat="server" ID="pCreditCard" Visible="false">
                    <asp:Label ID="CreditCardNumberLabel"
                        text="Credit Card Number:"
                        AssociatedControlID="txtCardNumber"
                        runat="server"></asp:Label>
                    <asp:TextBox runat="server" ID="txtCardNumber" />
                    <br />
                    <asp:Label ID="CCExpMonthLabel"
                        text="Exp&nbsp;"
                        AssociatedControlID="ddlMonth"
                        runat="server">
                    </asp:Label> 
                    
                    <asp:Label ID="CCExpYearLabel"
                        text="Date:"
                        AssociatedControlID="ddlYear"
                        runat="server"></asp:Label>

                    <asp:DropDownList runat="server" ID="ddlMonth" />
                    <asp:DropDownList runat="server" ID="ddlYear" />
                    <br />
                    <asp:Label ID="NameOnCardLabel"
                        text="Name as it appears on card:"
                        AssociatedControlID="txtNameOnCard"
                        runat="server"></asp:Label>
                    <asp:TextBox runat="server" ID="txtNameOnCard" />
                </asp:Panel>
                <asp:Panel runat="server" ID="pCash" Visible="false">
                </asp:Panel>
                <asp:Panel runat="server" ID="pElectronicCheck" Visible="false">
                    Please provide the following information. All information is required
                    <br />
                    <asp:Label ID="AccountHolderNameLabel"
                        text="Account Holder's Name:"
                        AssociatedControlID="txtChkAccountHolder"
                        runat="server"></asp:Label>
                    <br />
                    <asp:TextBox runat="server" ID="txtChkAccountHolder" />
                    <br />
                    <asp:Label ID="ABARoutingNumberLabel"
                        text="ABA Routing Number:"
                        AssociatedControlID="txtABANumber"
                        runat="server"></asp:Label>
                    <br />
                    <asp:TextBox runat="server" ID="txtABANumber" />
                    <br />
                    <asp:Label ID="ChkAcctNumberlabel"
                        text="Checking Account Number:"
                        AssociatedControlID="txtCheckAcctNumber"
                        runat="server"></asp:Label>
                    <br />
                    <asp:TextBox runat="server" ID="txtCheckAcctNumber" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br /><br />
                <asp:Panel runat="server" ID="pCancellationPolicy">
                    
                    <asp:Label ID="lblCancellationPolicy" runat="server"></asp:Label>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:ImageButton runat="server" ID="btnCheckout" alt="Checkout Button"/>
</asp:Content>
