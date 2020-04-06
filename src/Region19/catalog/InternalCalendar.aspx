<%@ Page Language="C#" MasterPageFile="~/MasterPageDummy.master" AutoEventWireup="true"
    CodeFile="InternalCalendar.aspx.cs" Inherits="catalog_InternalCalendar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="Server">
    <br />
    <table width="100%" style="border-collapse: collapse;">
        <tr>
            <td colspan="2">
                <escWorks:Calendar runat="server" ID="cal1" PreviousText="&lt;&lt; Previous" NextText="Next &gt;&gt;"
                    SetDateText="Go" CalendarPageUrl="InternalCalendar.aspx" />
            </td>
        </tr>
    </table>
</asp:Content>
