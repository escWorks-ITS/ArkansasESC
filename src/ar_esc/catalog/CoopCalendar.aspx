<%@ Page Language="C#"  MasterPageFile="~/MasterPageDummy.master" AutoEventWireup="true" CodeFile="CoopCalendar.aspx.cs" Inherits="CoopCalendar" %>

<asp:content id="Content1" contentplaceholderid="mainBody" runat="Server"><a name="MainBody"></a>
    <span style="padding-right: 10px;"><button type="button" onclick="javascript:history.back()" class="formInput btn btn-ARESCblue btn-lg" role="button" style="width: 130px; font-size:small" ToolTip="Click here to go to previous page.">Previous</button></span>
    <br /><br />
<table role="presentation" width="100%" style="border-collapse: collapse;">
<tr>
<td colspan="2"><escWorks:Calendar runat="server" ID="cal1" PreviousText="&lt;&lt; Previous" NextText="Next &gt;&gt;" SetDateText="Go" CalendarPageUrl="Calendar.aspx" /></td>
</tr>
</table>

</asp:content>

