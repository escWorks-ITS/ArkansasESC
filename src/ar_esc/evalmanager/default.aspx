<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="evalmanager_default"  MasterPageFile="~/MasterPage.master"%>
<asp:Content runat="server"  ContentPlaceHolderID="mainBody"><a name="MainBody"></a>
    <span style="padding-right: 10px;"><button type="button" onclick="javascript:history.back()" class="formInput btn btn-ARESCblue btn-lg" role="button" style="width: 130px; font-size:small" ToolTip="Click here to go to previous page.">Previous</button></span>
    <br /><br />

    <asp:Label ID="SessionIDLabel"
text=<%# region4.escWeb.SiteVariables.ObjectProvider.SessionNameCapitalized %>
AssociatedControlID="txtSessionID"
runat="server"></asp:Label>

 ID: <asp:TextBox runat="server" ID="txtSessionID" />&nbsp;&nbsp;<asp:Button runat="server" ID="btnFind" Text="Search" />
<br /><br />
<asp:PlaceHolder runat="server" ID="pResults" />

</asp:Content>

