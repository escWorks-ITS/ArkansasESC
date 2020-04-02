<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="session.aspx.cs" Inherits="catalog_session" Title="Untitled Page" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="Server">

    <script language="javascript" type="text/javascript">

        function OnClientOpenView() {
            var tooltip = $find("<%=radToolTipReviews.ClientID %>");
            tooltip.show();
        }

        function CloseToolTip() {
            var tooltip = Telerik.Web.UI.RadToolTip.getCurrent();
            if (tooltip) {
                tooltip.hide();
            }
        }
    </script>

    <asp:Label runat="server" ID="lblErrorMessage" CssClass="error" />
    <br />
    <table style="width: 100%; border-collapse: collapse;" runat="server" id="contentsTable"
        class="mainBody">
        <tr valign="top">
            <td>
                <img runat="server" src="~/lib/img/buttons/previous.png" alt="Previous" onclick="javascript:history.back();" />
                <a runat="server" href="~/search.aspx">
                    <img runat="server" src="~/lib/img/buttons/newsearch.png" alt="New Search" border="0" /></a>
            </td>
            <td rowspan="2" valign="middle">
                <asp:ImageButton runat="server" ID="btnRegister" AlternateText="Register" />
                <asp:ImageButton runat="server" ID="btnGroupRegister" AlternateText="Group Regsiter" />
                <asp:ImageButton runat="server" ID="btnWaitingList" AlternateText="Waiting List" />
                <asp:ImageButton runat="server" ID="btnRemoveFromCart" AlternateText="Remove" />
                <br />
                <%# base.SharePageButton %>
                <br />
                <br />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="lblTitle" CssClass="mainBodyBold" /><br />
                <asp:Panel runat="server" ID="panelRating" Visible="false">
                    <telerik:RadRating ID="radRatingSession" runat="server" ItemCount="5" SelectionMode="Continuous"
                        Precision="Exact" ReadOnly="true" Skin="Default">
                    </telerik:RadRating>
                    <asp:LinkButton ID="btnOpenReview" CssClass="link" OnClientClick="OnClientOpenView();return false;"
                        runat="server"></asp:LinkButton>
                    <telerik:RadToolTip ID="radToolTipReviews" runat="server" ShowEvent="FromCode" HideEvent="FromCode"
                        TargetControlID="btnOpenReview" RelativeTo="Element" Skin="Default" Position="MiddleLeft"
                        OffsetX="-15" Animation="Slide">
                        <asp:Panel ID="panelDetailedReviews" runat="server">
                        </asp:Panel>
                        <asp:Button ID="btnCloseReview" OnClientClick="CloseToolTip();return false;" runat="server" Text="Close" />
                    </telerik:RadToolTip>
                </asp:Panel>
                <br />
                <asp:Label runat="server" ID="lblDescription" CssClass="mainBodySmall" /><br />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <b>Important
                    <%# region4.escWeb.SiteVariables.ObjectProvider.SessionNameCapitalized %>
                    Information:</b><br />
                <br />
                <asp:Label runat="server" ID="lblWebComments" CssClass="mainBody" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:PlaceHolder ID="plttess" runat="server" Visible="false">
                                    <br /><b>T-TESS/T-PESS</b>:<br /> <asp:Label runat="server" ID="lblTPESS" CssClass="mainBody" /><br /><br />
                </asp:PlaceHolder>

               
            </td>
        </tr>
        <tr>
            <td colspan="2" class="sessionSummary">
                <asp:Label runat="server" ID="lblRegistrationStatus" />
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="mainBody" id="contentsTable1" runat="server">
        <tr>
            <td>
                <b>
                    <%# region4.escWeb.SiteVariables.ObjectProvider.SessionNameCapitalized %>
                    ID:</b><br />
                <asp:Label runat="server" ID="lblSessionID" />
            </td>
            <td>
                <b>Credits Available: </b>
                <br />
                <asp:Label runat="server" ID="lblCredits" />
            </td>
            <td rowspan="3" align="right" valign="top">
                <escWorks:RecommendedEvents runat="server" ID="recommendedEvents" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlSeatsFilled" runat="server">
                <b>Seats Available:</b><br />
                <asp:Label runat="server" ID="lblSeatsFilled" />
                </asp:Panel>
            </td>
            <td>
                <b>Fee:</b><br />
                <asp:Label runat="server" ID="lblFee" />
            </td>
        </tr>
        <tr>
            <td>
                <b>Contact Person:</b><br />
                <asp:Label runat="server" ID="lblContactPerson" />
            </td>
            <td>
                <b>Instructor(s):</b><br />
                <asp:Label runat="server" ID="lblInstructors" />
            </td>
        </tr>
    </table>
    <asp:PlaceHolder runat="server" ID="pLocationPlaceHolder" />
</asp:Content>
