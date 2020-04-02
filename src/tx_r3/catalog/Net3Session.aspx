<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="Net3Session.aspx.cs" Inherits="catalog_Net3Session"
    Title="Net3 Session" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlRegion">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pRegion3ViewingLocation" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="pTechnicalContact" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="pConnectionInformation" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="lbErrorMessage" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlDistrict">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pTechnicalContact" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="pConnectionInformation" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="lbErrorMessage" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSubmit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lbErrorMessage" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <br />
    ** Please Note All Connections Are Contingent On ESCs' Bridge Capacity and Availability
    **<br />
    * Required
    <asp:Panel runat="server" ID="pRequestorInformation">
        <table width="95%" border="0" cellspacing="2" cellpadding="0">
            <tr>
                <td>
                    <br />
                    <br />
                    <strong>Requester Information</strong>
                    <br />
                    Person completing the registration, either for yourself or on behalf of a teacher
                    at your district.
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>Requester Name:</strong><asp:Label ID="labelRequesterName" ForeColor="Red"
                        Font-Bold="true" Text="*" Visible="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtRequesterName" runat="server" Width="180px" CssClass="formInput" />
                    <br />
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRequesterName"
                        CssClass="error" ErrorMessage="Requester Name is required"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>Requester Email:</strong><asp:Label ID="label1" ForeColor="Red" Font-Bold="true"
                        Text="*" Visible="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtRequesterEmail" runat="server" Width="180px" CssClass="formInput" />
                    <br />
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRequesterEmail"
                        CssClass="error" ErrorMessage="RequiredFieldValidator">Requester Email is required</asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>Requester Phone:</strong><asp:Label ID="label2" ForeColor="Red" Font-Bold="true"
                        Text="*" Visible="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtRequesterPhone" runat="server" Width="180px" CssClass="formInput" />
                    <br />
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtRequesterPhone"
                        CssClass="error" ErrorMessage="Requester Phone is required"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>Position:</strong>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtRequesterPosition" runat="server" Width="180px" CssClass="formInput" />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel runat="server" ID="pTeacherInformation">
        <table width="95%" border="0" cellspacing="2" cellpadding="0">
            <tr>
                <td>
                    <br />
                    <br />
                    <strong>Teacher Information</strong>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>Teacher Name:</strong><asp:Label ID="label3" ForeColor="Red" Font-Bold="true"
                        Text="*" Visible="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTeacherName" runat="server" Width="180px" CssClass="formInput" />
                    <br />
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTeacherName"
                        CssClass="error" ErrorMessage="Teacher Name is required"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>Teacher Email:</strong><asp:Label ID="label4" ForeColor="Red" Font-Bold="true"
                        Text="*" Visible="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTeacherEmail" runat="server" Width="180px" CssClass="formInput" />
                    <br />
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTeacherEmail"
                        CssClass="error" ErrorMessage="RequiredFieldValidator">Teacher Email is required</asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>Teacher Phone:</strong><asp:Label ID="label5" ForeColor="Red" Font-Bold="true"
                        Text="*" Visible="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTeacherPhone" runat="server" Width="180px" CssClass="formInput" />
                    <br />
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTeacherPhone"
                        CssClass="error" ErrorMessage="Teacher Phone is required"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>District Name:</strong><asp:Label ID="label6" ForeColor="Red" Font-Bold="true"
                        Text="*" Visible="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTeacherDistrictName" runat="server" Width="180px" CssClass="formInput" />
                    <br />
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTeacherDistrictName"
                        CssClass="error" ErrorMessage="District Name is required"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>Campus Name:</strong><asp:Label ID="label7" ForeColor="Red" Font-Bold="true"
                        Text="*" Visible="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTeacherCampusName" runat="server" Width="180px" CssClass="formInput" />
                    <br />
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtTeacherCampusName"
                        CssClass="error" ErrorMessage="Campus Name is required"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <asp:PlaceHolder runat="server" ID="placeHolderTotalNumberStudents">
                <tr>
                    <td valign="top">
                        <strong>Total Number of Students Viewing Program:</strong></strong><asp:Label ID="label8"
                            ForeColor="Red" Font-Bold="true" Text="*" Visible="true" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtTotalNumberStudents" runat="server" Width="180px" CssClass="formInput" />
                        <br />
                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtTotalNumberStudents"
                            CssClass="error" ErrorMessage="Total Number of Students Viewing Program is required"></asp:RequiredFieldValidator>
                        <br />
                    </td>
                </tr>
            </asp:PlaceHolder>
            <tr>
                <td valign="top">
                    <strong>City:</strong><asp:Label ID="label9" ForeColor="Red" Font-Bold="true" Text="*"
                        Visible="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTeacherCity" runat="server" Width="180px" CssClass="formInput" />
                    <br />
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtTeacherCity"
                        CssClass="error" ErrorMessage="City is required"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>State:</strong><asp:Label ID="label10" ForeColor="Red" Font-Bold="true" Text="*"
                        Visible="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTeacherState" runat="server" Width="180px" CssClass="formInput" />
                    <br />
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtTeacherState"
                        CssClass="error" ErrorMessage="State is required"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>Zip Code:</strong><asp:Label ID="label11" ForeColor="Red" Font-Bold="true"
                        Text="*" Visible="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTeacherZipCode" runat="server" Width="180px" CssClass="formInput" />
                    <br />
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtTeacherZipCode"
                        CssClass="error" ErrorMessage="Zip Code is required"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>Country:</strong><asp:Label ID="label12" ForeColor="Red" Font-Bold="true"
                        Text="*" Visible="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTeacherCountry" runat="server" Width="180px" CssClass="formInput" />
                    <br />
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtTeacherCountry"
                        CssClass="error" ErrorMessage="Country is required"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel runat="server" ID="pAdditionalTeacher">
        <table width="95%" border="0" cellspacing="2" cellpadding="0">
            <tr>
                <td>
                    <br />
                    <br />
                    <strong>Additional Teachers Attending Same Event.</strong>
                    <br />
                    If more than one teacher is attending the same event, same time, at same location
                    - please add contact information (name and email).
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>Teacher 2 Name:</strong>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTeacher2Name" runat="server" Width="180px" CssClass="formInput" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>Teacher 2 Email:</strong>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTeacher2Email" runat="server" Width="180px" CssClass="formInput" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>Teacher 3 Name:</strong>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTeacher3Name" runat="server" Width="180px" CssClass="formInput" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>Teacher 3 Email:</strong>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTeacher3Email" runat="server" Width="180px" CssClass="formInput" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>Teacher 4 Name:</strong>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTeacher4Name" runat="server" Width="180px" CssClass="formInput" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>Teacher 4 Email:</strong>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTeacher4Email" runat="server" Width="180px" CssClass="formInput" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>Teacher 5 Name:</strong>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTeacher5Name" runat="server" Width="180px" CssClass="formInput" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>Teacher 5 Email:</strong>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTeacher5Email" runat="server" Width="180px" CssClass="formInput" />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel runat="server" ID="pInteraction">
        <table width="95%" border="0" cellspacing="2" cellpadding="0">
            <tr>
                <td>
                    <br />
                    <br />
                    <strong>Interaction</strong>
                    <br />
                    Most sites will be View Only. If you would like to be an interactive site - please
                    submit no more than 3 questions you would like to ask presenter. Email notifications
                    will be sent to selected sites.
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>Question 1:</strong>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtInteractionQuestion1" runat="server" Width="500px" TextMode="MultiLine"
                        Rows="5" CssClass="formInput" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>Question 2:</strong>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtInteractionQuestion2" runat="server" Width="500px" TextMode="MultiLine"
                        Rows="5" CssClass="formInput" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>Question 3:</strong>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtInteractionQuestion3" runat="server" Width="500px" TextMode="MultiLine"
                        Rows="5" CssClass="formInput" />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel runat="server" ID="pTexasViewingLocation" Visible="false">
        <table width="95%" border="0" cellspacing="2" cellpadding="0">
            <tr>
                <td>
                    <strong>Texas Viewing Locations</strong>
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <br />
                    <strong>Indicate which Regional Education Service Center (ESC) you receive videoconferencing
                        services from:</strong>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlRegion" runat="server" CssClass="formInput" AutoPostBack="True"
                        OnSelectedIndexChanged="RegionalEscChanged" />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="pRegion3ViewingLocation" Visible="false">
            <table width="95%" border="0" cellspacing="2" cellpadding="0">
                <tr>
                    <td valign="top">
                        <br />
                        <strong>If you are located in Region 3, indicate your viewing site.</strong>
                        <br />
                        Listed Below are NET3 Member sites.
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="formInput" AutoPostBack="True"
                            OnSelectedIndexChanged="ViewingSiteChanged" />
                        &nbsp;<asp:RequiredFieldValidator ID="RFVViewingSite" runat="server" ControlToValidate="ddlDistrict"
                            CssClass="error" ErrorMessage="Viewing site is required"></asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <br />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>
    <asp:Panel runat="server" ID="pTechnicalContact" Visible="false">
        <table width="95%" border="0" cellspacing="2" cellpadding="0">
            <tr>
                <td>
                    <strong>Technical Contact </strong>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>Technical Contact Name:</strong><asp:Label ID="labelTechnicalContactName"
                        ForeColor="Red" Font-Bold="true" Text="*" Visible="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTechnicalContactName" runat="server" Width="180px" CssClass="formInput" />
                    <br />
                    &nbsp;<asp:RequiredFieldValidator ID="RFVTechnicalContactName" runat="server" ControlToValidate="txtTechnicalContactName"
                        CssClass="error" Enabled="true" ErrorMessage="Technical Contact Name is required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>Technical Contact Email:</strong>
                    <asp:Label ID="labelTechnicalContactEmail" ForeColor="Red" Font-Bold="true" Text="*"
                        Visible="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTechnicalContactEmail" runat="server" Width="180px" CssClass="formInput" /><br />
                    &nbsp;<asp:RequiredFieldValidator ID="RFVTechnicalContactEmail" runat="server" ControlToValidate="txtTechnicalContactEmail"
                        CssClass="error" Enabled="true" ErrorMessage="Technical Contact Email is required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <strong>Technical Contact Phone:</strong>
                    <asp:Label ID="labelTechnicalContactPhone" ForeColor="Red" Font-Bold="true" Text="*"
                        Visible="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTechnicalContactPhone" runat="server" Width="180px" CssClass="formInput" />
                    <br />
                    &nbsp;<asp:RequiredFieldValidator ID="RFVTechnicalContactPhone" runat="server" ControlToValidate="txtTechnicalContactPhone"
                        CssClass="error" Enabled="true" ErrorMessage="Technical Contact Phone is required"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel runat="server" ID="pConnectionInformation" Visible="false">
        <table width="95%" border="0" cellspacing="2" cellpadding="0">
            <tr>
                <td>
                    <strong>Connection Information</strong>
                    <br />
                    IP information needed ONLY if connecting from outside of Texas or you do not receive
                    videoconferencing services from an Education Service Center (ESC) in Texas.
                    <br />
                    <br />
                </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="pConnectionInfoIPNumber">
            <table width="95%" border="0" cellspacing="2" cellpadding="0">
                <tr>
                    <td valign="top">
                        <strong>IP Number (H.323):</strong>
                        <asp:Label ID="labelConnectionInfoIPNumber" ForeColor="Red" Font-Bold="true" Text="*"
                            Visible="true" runat="server" />
                        <br />
                        Provide IP if located outside of Texas. If you don't know this information, please
                        check with your technical contact.
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtConnectionInfoIPNumber" runat="server" Width="180px" CssClass="formInput" />
                        <br />
                        &nbsp;<asp:RequiredFieldValidator ID="RFVConnectionInfoIPNumber" runat="server" ControlToValidate="txtConnectionInfoIPNumber"
                            CssClass="error" Enabled="true" ErrorMessage="IP Number (H.323) is required"></asp:RequiredFieldValidator>
                        <br />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="pConnectionInfoSystemType">
            <table width="95%" border="0" cellspacing="2" cellpadding="0">
                <tr>
                    <td valign="top">
                        <strong>System Type</strong>
                        <asp:Label ID="labelConnectionInfoSystemType" ForeColor="Red" Font-Bold="true" Text="*"
                            Visible="false" runat="server" />
                        <br />
                        What type of videoconferencing equipment do you have? ie: Polycom, Cisco/Tandberg,
                        Lifesize, Desktop (Zoom/Jabber/Blue Jeans/Polycom RealPresence), iPad (Polycom RealPresence
                        Mobile).
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtConnectionInfoSystemType" runat="server" Width="180px" CssClass="formInput" />
                        <br />
                        <br />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="pConnectionInfoBridgeInfo">
            <table width="95%" border="0" cellspacing="2" cellpadding="0">
                <tr>
                    <td valign="top">
                        <strong>Bridge Information</strong>
                        <br />
                        If you have a bridging service, please provide contact information.
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtConnectionInfoBridgeInfo" runat="server" Width="180px" CssClass="formInput" />
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <strong>Connection Comments</strong>
                        <br />
                        Comments helpful to establish your connection.
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtConnectionInfoConnectionComments" runat="server" Width="180px"
                            CssClass="formInput" />
                        <br />
                        <br />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>
    <asp:Label ID="lbErrorMessage" runat="server" CssClass="error"></asp:Label>
    <br />
    <br />
    <img src="../lib/img/Net3Programming.jpg" alt="ESC 3" width="98%" style="background-color: #35638f;
        border: none;" />
    <br />
    <br />
    <asp:Button runat="server" ID="btnSubmit" Text="Add to Cart" />
</asp:Content>
