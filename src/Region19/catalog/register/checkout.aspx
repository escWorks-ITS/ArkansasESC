<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="checkout.aspx.cs" Inherits="catalog_register_checkout" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="Server">
    <script type="text/javascript">
        function DisableButton() {
            document.getElementById("<%=btnCheckout.ClientID %>").disabled = true;
        }
        window.onbeforeunload = DisableButton;
    </script>
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
    <div style="padding:5px">
     <b><u>Payment Policy: </u></b>
      For events that require a registration fee, payment must be received prior to the event.  
      To facilitate the onsite registration process, present a copy of a purchase order or proof 
      of payment.  Please email purchase order to <a href="mailto:eventsmanagement@esc19.net">eventsmanagement@esc19.net</a> 
      or fax to (915) 780-5034.  Certificate of Attendance will not be available until payment is received.
    </div>
    <br />
    <div style="padding:5px">
     <b><u>Cancellation and Refund Policy: </u></b>
      Cancellation requests will be considered on an individual basis and refunds are not guaranteed.  
      Cancellation must be requested at least five business days prior to the workshop for a full refund. 
      No refunds are given for cancellations less than five business days prior to the workshop.  
      Telephone requests for cancellations will not be accepted.  Districts/campuses are encouraged to 
      substitute personnel if the person registered is unable to attend.<br /><br />
      Refund request must include your name, address, daytime phone number, the event number and session name. 
      Please allow up to four weeks to process your refund.  No refunds will be given on or after the first 
      meeting date or for non-attendance. <br /><br />
      Please email your cancellation request to <a href="mailto:eventsmanagement@esc19.net">eventsmanagement@esc19.net</a> or fax to (915) 780-5034. 
      For additional questions and/or assistance please contact:  Events Management at (915) 780-5055. <br /><br /><b><u>Other: </u></b>ESC-Region 19 is not equipped to safely accommodate children in our facility.  Please help us ensure the safety of your children by making other arrangements for their care, while attending any conference or session.
      </div>
    <br />
    <br />
    <asp:Label runat="server" ID="lblPaymentPrompt" Text="Please select a method of payment to continue" />
    <br />

    <table class="mainBody">
        <tr>
            <td>
                <asp:RadioButtonList runat="server" ID="rblPaymentList" AutoPostBack="true" CssClass="mainBody">
                    <asp:ListItem Text="Purchase Order" Value="PO" />
                    <asp:ListItem Text="Credit Card" Value="CC" />
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
                     <asp:Label ID="PONumberLabel"
                         text="PO/TR/ISR Number (i.e., PO###, TR###, ISR###):"
                         AssociatedControlID="txtPONumber"
                         runat="server"></asp:Label>
                    <asp:TextBox runat="server" ID="txtPONumber" /><br />
                </asp:Panel>
                <asp:Panel runat="server" ID="pCreditCard" Visible="false">
                    <asp:Label ID="CCNumberLabel"
                        text="Credit Card Number:"
                        AssociatedControlID="txtCardNumber"
                        runat="server"></asp:Label>
                    <asp:TextBox runat="server" ID="txtCardNumber" />
                    <br />
                    <asp:Label ID="CCExpMonthLabel"
                        text="Exp&nbsp;"
                        AssociatedControlID="ddlMonth"
                        runat="server"></asp:Label> 
                    <asp:Label ID="CCExpYearLabel"
                        text="Date:"
                        AssociatedControlID="ddlYear"
                        runat="server"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlMonth" />
                    <asp:DropDownList runat="server" ID="ddlYear" />
                    <br />
                    <asp:Label ID="NameonCardLabel"
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
                    <asp:Label ID="AcctHolderNameLabel"
                        text="Account Holder's Name:"
                        AssociatedControlID="txtChkAccountHolder"
                        runat="server"></asp:Label>
                    <br />
                    <asp:TextBox runat="server" ID="txtChkAccountHolder" />
                    <br />
                    <asp:Label ID="ABANumberLabel"
                        text="ABA Routing Number:"
                        AssociatedControlID="txtABANumber"
                        runat="server"></asp:Label>
                    <br />
                    <asp:TextBox runat="server" ID="txtABANumber" />
                    <br />
                    <asp:Label ID="ChkgAcctNumberLabel"
                        text="Checking Account Number:"
                        AssociatedControlID="txtCheckAcctNumber"
                        runat="server"></asp:Label>
                    <br />
                    <asp:TextBox runat="server" ID="txtCheckAcctNumber" />
                </asp:Panel>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:ImageButton runat="server" alt="Complete Checkout Button" ID="btnCheckout" />
</asp:Content>
