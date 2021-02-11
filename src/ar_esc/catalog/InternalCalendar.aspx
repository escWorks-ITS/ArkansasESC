<%@ Page Language="C#" MasterPageFile="~/MasterPageDummy.master" AutoEventWireup="true"
    CodeFile="InternalCalendar.aspx.cs" Inherits="catalog_InternalCalendar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="Server"><a name="MainBody"></a>
    <span style="padding-right: 10px;"><button type="button" onclick="javascript:history.back()" class="formInput btn btn-ARESCblue btn-lg" role="button" style="width: 130px; font-size:small" ToolTip="Click here to go to previous page.">Previous</button></span>
    <br /><br />
    <table role="presentation" width="100%" style="border-collapse: collapse;">
        <tr>
            <td colspan="2">
                <escWorks:Calendar runat="server" ID="cal1" PreviousText="&lt;&lt; Previous" NextText="Next &gt;&gt;"
                    SetDateText="Go" CalendarPageUrl="InternalCalendar.aspx" />
            </td>
        </tr>
    </table>
</asp:Content>

