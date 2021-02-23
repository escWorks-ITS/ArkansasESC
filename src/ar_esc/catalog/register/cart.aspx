<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="cart.aspx.cs" Inherits="catalog_register_cart" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="Server"><a name="MainBody"></a>
    <span style="padding-right: 10px;"><button type="button" onclick="javascript:history.back()" class="formInput btn btn-ARESCblue btn-lg" role="button" style="width: 130px; font-size:small" ToolTip="Click here to go to previous page.">Previous</button></span>
    <br /><br />
    <escWorks:MobileCartDisplay runat="server" ID="cartDisplay1" DisplayRemoveButton="true" />
    <%--<escWorks:CartDisplay runat="server" ID="cartDisplay1" DisplayRemoveButton="true"  />--%>
    <br />
    <br />
   
<asp:Panel runat="server" ID="pPromoCode">
    Promotional Code:
    <asp:TextBox runat="server" ID="txtPromoCode" />
    <asp:Button runat="server" ID="btnApplyCode" alt="Apply Promo Code Button" Text="Apply Code" />

    </asp:Panel><br /><br /><br />
    <div class="row">
        <div class="col-xs-12 col-sm-4">
        <asp:Button runat="server" ID="btnCheckOut" Text="Checkout" CssClass="formInput btn btn-ARESCblue btn-lg" Style="width: 170px; font-size:small" ToolTip="Click here to checkout." />
        </div>
    </div>
    <%--<asp:ImageButton runat="server" alt="Checkout Button" ID="btnCheckOut" />--%>    
</asp:Content>  
