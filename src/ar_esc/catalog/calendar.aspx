<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="calendar.aspx.cs" Inherits="catalog_calendar" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" Runat="Server">
<br />
<table width="100%" style="border-collapse: collapse;">

<tr>
    <td><asp:Label ID="Labelcoop"
text="Co-op:"
AssociatedControlID="ddlcooperative"
runat="server"></asp:Label>
        <asp:DropDownList ID="ddlcooperative" runat="server" AutoPostBack="true" CssClass="dropdown" OnSelectedIndexChanged ="ddlcooperative_SelectedIndexChanged"></asp:DropDownList>
    </td>
    <td><asp:Label ID="Labeldistrict"
text="District:"
AssociatedControlID="ddldistrict"
runat="server"></asp:Label>
        <asp:DropDownList ID="ddldistrict" runat="server" AutoPostBack="true" CssClass="dropdown" OnSelectedIndexChanged ="ddldistrict_SelectedIndexChanged"></asp:DropDownList>
    </td>
</tr>

<tr>
<td colspan="2"><escWorks:Calendar runat="server" ID="cal1" PreviousText="&lt;&lt; Previous" NextText="Next &gt;&gt;" SetDateText="Go"  /></td>
</tr>
</table>

</asp:Content>

