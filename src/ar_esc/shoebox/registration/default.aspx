<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="shoebox_registration_default"
    MasterPageFile="~/MasterPage.master" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content runat="server" ContentPlaceHolderID="mainBody" ID="content1"><a name="MainBody"></a>
    <span style="padding-right: 10px;"><button type="button" onclick="javascript:history.back()" class="formInput btn btn-ARESCblue btn-lg" role="button" style="width: 130px; font-size:small" ToolTip="Click here to go to previous page.">Previous</button></span>
    <br /><br />
    <style>
    .rtsSelected, .rtsSelected span
        {
           background:url(../Images/btnUpdate.jpg) no-repeat 0 100%  !important;
           background-color: #6C757D !important;
           text-align: center;
           color:white !important;
           
        }

  .RadTabStrip_Telerik li a.slected {
    background:url(../Images/btnUpdate.jpg) no-repeat 0 100%  !important;
           background-color: #6C757D !important;
           text-align: center;
           color:white;
  }

    </style>

    <script type="text/javascript" language="javascript">
        function OnClientRated(controlRating, args) {
            var toolTipControlId = controlRating.get_element().getAttribute("ToolTipControlId");
            var toolTipClientId = "ctl00_mainBody_regHistory_" + toolTipControlId;
            var tooltip = $find(toolTipClientId);
            tooltip.show();
        }

        var tabStrip;
        function onClientTabLoad(sender) {
            radTabStrip.focus();
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

<%--    <br />
    <br />--%>

    <script type="text/javascript" language="javascript">
        function OnTabSelected(sender, args) {
            var hidField = document.getElementById("<%=hiddenFieldTabValue.ClientID%>");
            hidField.value = args.get_tab().get_value();
        }

        var tabStrip;
        function onClientTabLoad(sender) {
            radTabStrip.focus();

        }

    </script>

<div style="margin-top: -3px;"><font style="color: white !important"> Hold down Shift and M key to bring into focus then navigate through arrow keys and hit enter.</font></div>
<div class="col-12 col-sm-10 col-lg-12" style="height: 100%; vertical-align: top;padding-left:0px;">
    <telerik:RadTabStrip ID="radTabStrip" AutoPostBack="true" runat="server" OnClientTabSelected="OnTabSelected"  SelectedIndex="0" RenderMode="Auto" TabIndex="0" OnClientLoad="onClientTabLoad">
                <KeyboardNavigationSettings CommandKey="Shift" FocusKey="M" />
        <Tabs>
            <telerik:RadTab runat="server" Text="Upcoming Events" Value="FutureEvents" Selected="true" TabIndex="0">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Past Events" Value="PastEvents" TabIndex="0">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="WaitingList" Value="WaitingList" TabIndex="0">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Online Event" Value="OnlineEvents" Visible="false" TabIndex="0">
                <Tabs>
                    <telerik:RadTab runat="server" Text="In Progress" Value="OnlineInProgress" Selected="true" TabIndex="0">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Complete" Value="OnlineComplete" TabIndex="0">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Incomplete" Value="OnlineIncomplete" TabIndex="0">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <asp:HiddenField ID="hiddenFieldTabValue" runat="server" Value="FutureEvents" />
    <escWorks:RegistrationHistory runat="server" ID="regHistory" />   
    </div>
    <br />
</asp:Content>
