<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="checkout.aspx.cs" Inherits="catalog_register_checkout" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="Server"><a name="MainBody"></a>
    <span style="padding-right: 10px;"><button type="button" onclick="javascript:history.back()" class="formInput btn btn-ARESCblue btn-lg" role="button" style="width: 130px; font-size:small" ToolTip="Click here to go to previous page.">Previous</button></span>
    <br /><br />
    <asp:Label runat="server" ID="lblErrorMessage" CssClass="error" />
    <br />

<div class="container-fluid">
     <div class="row">
        <div class="col-xs-12 col-sm-12">
            <span style="font-size: 1.25em"> Click the 'Complete Checkout' button to register for the <%# region4.escWeb.SiteVariables.ObjectProvider.SessionPluralName %> displayed below.</span>
        </div>
    </div>    
    <br />

    <%--<span style="font-size: 1.25em">Click the 'Complete Checkout' button to register for
        the
        <%# region4.escWeb.SiteVariables.ObjectProvider.SessionPluralName %>
        displayed below.</span>--%>
    <escWorks:MobileCartDisplay runat="server" ID="cartDisplay1" DisplayRemoveButton="false" />
<%--    <br />
    <br />
    <escWorks:CartDisplay runat="server" ID="cart1" DisplayRemoveButton="false" />--%>
    <br />
    <div class="row">
        <div class="col-xs-12 col-sm-12">
            <asp:Label runat="server" ID="lblPaymentPrompt" Text="Please select a method of payment to continue" CssClass="smallFont" />
        </div>
     </div>
    <%--<asp:Label runat="server" ID="lblPaymentPrompt" Text="Please select a method of payment to continue" />--%>
    <br />
    <table role="presentation" class="mainBody">
        <tr >
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                <asp:RadioButtonList runat="server" ID="rblPaymentList" AutoPostBack="true" CssClass="mainBody">
                    <asp:ListItem Text="Check" Value="CK" />
                    <asp:ListItem Text="Money Order" Value="MO" />
                    <asp:ListItem Text="Purchase Order" Value="PO" />
                    <asp:ListItem Text="Cash" Value="CS" />
                </asp:RadioButtonList>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:Panel runat="server" ID="pCheck" Visible="false">
                </asp:Panel>
                <asp:Panel runat="server" ID="PDCheck" Visible="false">
                </asp:Panel>
                <asp:Panel runat="server" ID="pMoneyOrder" Visible="false">
                </asp:Panel>
                <asp:Panel runat="server" ID="pPurchaseOrder" Visible="false">
                    <asp:Label ID="PONumberLabel"
text="PO Number:"
AssociatedControlID="txtPONumber"
runat="server"></asp:Label>
                    <asp:TextBox runat="server" ID="txtPONumber" />
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
                    <asp:Label ID="AcctHolderNameLabel"
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
                    <asp:Label ID="CheckingAccountNumberLabel"
text="Checking Account Number:"
AssociatedControlID="txtCheckAcctNumber"
runat="server"></asp:Label>
                    <br />
                    <asp:TextBox runat="server" ID="txtCheckAcctNumber" />
                </asp:Panel>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Button runat="server" ID="btnCheckout" Text="Complete Checkout" CssClass="formInput btn btn-ARESCblue btn-lg" Style="width: 170px; font-size:small" />
    <%--<asp:ImageButton runat="server" alt="Complete Checkout Button" ID="btnCheckout" />--%>
</asp:Content>
