<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="multivenue.aspx.cs" Inherits="catalog_multivenue"  Title="Multi-Venue Events"%>

<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="Server"><a name="MainBody"></a>
    <span style="padding-right: 10px;"><button type="button" onclick="javascript:history.back()" class="formInput btn btn-ARESCblue btn-lg" role="button" style="width: 130px; font-size:small" ToolTip="Click here to go to previous page.">Previous</button></span>
    <br /><br />
    <asp:Label runat="server" ID="txtTitle" CssClass="heading" />
    <br />
    <asp:Label runat="server" ID="txtDescription" Font-Italic="true" />
    <br />
    <escWorks:MultiVenueSessions runat="server" ID="sessionDisplay" />
</asp:Content>
