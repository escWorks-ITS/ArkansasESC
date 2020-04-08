<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="shoebox_registration_default"
    MasterPageFile="~/MasterPage.master" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content runat="server" ContentPlaceHolderID="mainBody" ID="content1">
    <script type="text/javascript" language="javascript">
        function OnClientRated(controlRating, args) {
            var toolTipControlId = controlRating.get_element().getAttribute("ToolTipControlId");
            var toolTipClientId = "ctl00_mainBody_regHistory_" + toolTipControlId;
            var tooltip = $find(toolTipClientId);
            tooltip.show();
        }

        function CloseCurrentToolTip() {
            var tooltip = Telerik.Web.UI.RadToolTip.getCurrent();
            if (tooltip) {
                tooltip.hide();
            }
        }

        function OnClientPostComment(buttonControl) {
            var attendee_pk = buttonControl.getAttribute("attendee_pk");

            var RatingID = buttonControl.getAttribute("RatingID");
            var RatingClientID = "ctl00_mainBody_regHistory_" + RatingID;
            var RatingControl = $find(RatingClientID);

            var CommentsID = buttonControl.getAttribute("CommentsID");
            var CommentsClientID = "ctl00_mainBody_regHistory_" + CommentsID;
            var commentsControl = document.getElementById(CommentsClientID);

            var LabelCommentsID = buttonControl.getAttribute("LabelCommentsID");
            var LabelCommentsClientID = "ctl00_mainBody_regHistory_" + LabelCommentsID;
            var LabelCommentsControl = document.getElementById(LabelCommentsClientID);
            LabelCommentsControl.innerHTML = commentsControl.value;

            PageMethods.PostComment(attendee_pk, RatingControl.get_value(), commentsControl.value, null);

            CloseCurrentToolTip();            
        }
            
    </script>

    <br />
    <br />

    <script type="text/javascript" language="javascript">
        function OnTabSelected(sender, args) {
            var hidField = document.getElementById("<%=hiddenFieldTabValue.ClientID%>");
            hidField.value = args.get_tab().get_value();
        }
    </script>

    <telerik:RadTabStrip ID="radTabStrip" AutoPostBack="true" runat="server" OnClientTabSelected="OnTabSelected">
        <Tabs>
            <telerik:RadTab runat="server" Text="Upcoming Events" Value="FutureEvents" Selected="true">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Past Events" Value="PastEvents">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="WaitingList" Value="WaitingList">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Online Event" Value="OnlineEvents" Visible="false">
                <Tabs>
                    <telerik:RadTab runat="server" Text="In Progress" Value="OnlineInProgress" Selected="true">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Complete" Value="OnlineComplete">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Incomplete" Value="OnlineIncomplete">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <asp:HiddenField ID="hiddenFieldTabValue" runat="server" Value="FutureEvents" />
    <escWorks:RegistrationHistory runat="server" ID="regHistory" />    
</asp:Content>
