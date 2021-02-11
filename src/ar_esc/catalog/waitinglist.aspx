<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="waitinglist.aspx.cs" Inherits="catalog_waitinglist" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" Runat="Server"><a name="MainBody"></a>
    <span style="padding-right: 10px;"><button type="button" onclick="javascript:history.back()" class="formInput btn btn-ARESCblue btn-lg" role="button" style="width: 130px; font-size:small" ToolTip="Click here to go to previous page.">Previous</button></span>
    <br /><br />
<asp:PlaceHolder runat="server" ID="pResults" />
</asp:Content>

