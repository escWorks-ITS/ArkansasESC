<%@ Page Language="C#"  MasterPageFile="~/MasterPageDummy.master" AutoEventWireup="true" CodeFile="CoopCalendar.aspx.cs" Inherits="CoopCalendar" %>

<asp:content id="Content1" contentplaceholderid="mainBody" runat="Server">
<br />
<table width="100%" style="border-collapse: collapse;">
<tr>
<td colspan="2"><escWorks:Calendar runat="server" ID="cal1" PreviousText="&lt;&lt; Previous" NextText="Next &gt;&gt;" SetDateText="Go" CalendarPageUrl="Calendar.aspx" /></td>
</tr>
</table>

</asp:content>

