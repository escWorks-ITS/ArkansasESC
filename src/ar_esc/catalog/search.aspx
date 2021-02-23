<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="search.aspx.cs" Inherits="catalog_search" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="server"><a name="MainBody"></a>
    <span style="padding-right: 10px;"><button type="button" onclick="javascript:history.back()" class="formInput btn btn-ARESCblue btn-lg" role="button" style="width: 130px; font-size:small" ToolTip="Click here to go to previous page.">Previous</button></span>
    <br /><br />

    <script src="../lib/js/calendar.js" type="text/javascript"></script>
    <asp:Panel runat="server" ID="pQuery">
        <table role="presentation" width="100%" >
            <tr valign="top">
                <td>
                    <table role="presentation" class="mainBody" style="border-top: solid 2px gray; border-bottom: solid 2px gray; ">
                        <tr>
                            <td colspan="2">
                                Search Professional Development Catalog For:
                                <br />
                                <asp:TextBox runat="server" ID="txtKeywords" cssClass="formInput" Width="220px"  /></td>
                        </tr>
                        <tr>
                            <td>
                                Audience
                                <br />
                                <asp:DropDownList runat="server" ID="ddlAudience" cssClass="formInput" /></td>
                            <td>
                                Start Date
                                <br />
                                <asp:TextBox runat="server" ID="txtStartDate" cssClass="formInput" 
                                    Width="99px" />&nbsp;<asp:ImageButton runat="server" ID="btnCalendar1" ImageUrl="~/lib/img/buttons/calendar.png" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate" PopupButtonID="btnCalendar1" />
                             
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Subject
                                <br />
                                <asp:DropDownList runat="server" ID="ddlSubject" cssClass="formInput" /></td>
                            <td>
                                End Date
                                <br />
                                <asp:TextBox runat="server" ID="txtEndDate" cssClass="formInput" Width="99px" /> <asp:ImageButton runat="server" ID="btnCalendar2" ImageUrl="~/lib/img/buttons/calendar.png" />
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="btnCalendar2" TargetControlID="txtEndDate" />
                                </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:ImageButton runat="server" ID="btnSearch" AlternateText="Search" /></td>
                        </tr>
                    </table>
                </td>
         <td>
                    <table role="presentation" class="mainBody" style="border-top: solid 2px gray; border-bottom: solid 2px gray; ">
                        <tr>
                            <td>
                                Already know the
                                <%# region4.escWeb.SiteVariables.ObjectProvider.SessionNameCapitalized%>
                                ID?</td>
                        </tr>
                        <tr>
                            <td>
                               <%# region4.escWeb.SiteVariables.ObjectProvider.SessionNameCapitalized%>
                                ID:<br />
                                <asp:TextBox runat="server" ID="txtSessionID" cssClass="formInput" /><br />
                             
                            </td>
                        </tr>
                        <tr><td align="right">   <asp:ImageButton runat="server" ID="btnSearchSession" AlternateText="Search Session" /></td></tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
    </asp:Panel>
    <asp:PlaceHolder runat="server" ID="pResults" Visible="false">
        <table role="presentation" class="mainBody" width="100%" class="mainBody">
        <tr>
        <td colspan="2">Click on a title for a listing of available <%# region4.escWeb.SiteVariables.ObjectProvider.SessionPluralName %></td>
        </tr>
        <tr>
        <td><asp:Label runat="server" ID="lblResultsDescription" /></td>
        <td align="right"><asp:ImageButton runat="server" ID="btnNewSearch" /></td>
        </tr>
        </table>
        <table role="presentation" runat="server" class="mainBody" id="tableResults" width="100%" />
    </asp:PlaceHolder>
    <asp:Label runat="server" class="error" ID="lblError" />
    <br />
</asp:Content>
