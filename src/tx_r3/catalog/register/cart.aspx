<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="cart.aspx.cs" Inherits="catalog_register_cart" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="Server">
    <br />
    <escWorks:CartDisplay runat="server" ID="cartDisplay1" DisplayRemoveButton="true"  />
    <br />
    <br />
   
<asp:Panel runat="server" ID="pPromoCode">
    <asp:Label ID="PromoCodeLabel"
        text="Promotional Code:"
        AssociatedControlID="txtPromoCode"
        runat="server"></asp:Label>
    <asp:TextBox runat="server" ID="txtPromoCode" />
    <asp:Button runat="server" ID="btnApplyCode" Text="Apply Code" />

    </asp:Panel><br /><br /><br />
    <asp:ImageButton runat="server" ID="btnCheckOut" AlternateText="Checkout Button" />    
</asp:Content>  
