<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="confirmuserprofile.aspx.cs" Inherits="catalog_register_confirmuserprofile"
    EnableEventValidation="false" Title="Confirm User Profile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="Server">
    <script type="text/javascript" language="javascript">
        function AddMultiSelect(dropdown, listbox, hiddenValue, msg) {

            var ddControl = document.getElementById(dropdown);
            var lbControl = document.getElementById(listbox);
            var valueControl = document.getElementById(hiddenValue);

            if (ddControl.selectedIndex < 1) {
                alert(msg);
                return;
            }

            var m_Text = ddControl[ddControl.selectedIndex].text;
            var m_Value = ddControl[ddControl.selectedIndex].value;

            if (m_Value.length == 0) {
                alert(msg);
                return;
            }

            var option = new Option(m_Text);
            if (valueControl.value.indexOf(m_Value) == -1) {
                if (valueControl.value.length > 0)
                    valueControl.value = valueControl.value + ',' + m_Value;
                else
                    valueControl.value = m_Value;
            }
            else {
                alert("You already added " + m_Text)
                return;
            }

            lbControl[lbControl.length] = option;
            // ddControl[ddControl.selectedIndex] = null;

            ddControl.selectedIndex = 0;

            var div = document.getElementById("divSpecialAcc");

            if (m_Text.indexOf("Other") > -1 || valueControl.value.indexOf("6268") > -1)
                div.style.display = "block";
            else
                div.style.display = "none";
        }

        function OnRemoveMulti(lbControl, dropdown, textbox) {
            var ddControl = document.getElementById(dropdown);
            var tbControl = document.getElementById(textbox);
            var lbControl = document.getElementById(lbControl);

            if (lbControl.length > 0 && lbControl.selectedIndex >= 0) {
                var m_Text = lbControl[lbControl.selectedIndex].text;
                var m_Value = lbControl[lbControl.selectedIndex].value;

                //var option = new Option(m_Text, m_Value);
                //ddControl[ddControl.length] = option;
                lbControl[lbControl.selectedIndex] = null;

                var text = '';
                for (var n = 0; n < lbControl.length; n++) {
                    if (n == 0)
                        text = lbControl[n].value;
                    else
                        text = text + ',' + lbControl[n].value;
                }
                tbControl.value = text;

                var div = document.getElementById("divSpecialAcc");

                if (m_Text.indexOf("Other") > -1)
                    div.style.display = "none";
                else
                    div.style.display = "block";
            }
        }

        function openSpecial() {
            var div = document.getElementById("divSpecialAcc");
            div.style.display = "block";
        }

    </script>
    <br />
    <br />
    <asp:Label runat="server" ID="lblErrorMessage" CssClass="error" />
    <br />
    <asp:Label ID="labelPleaseVerify" runat="server"><strong><big>Please help us verify your information to ensure you receive proper credit for your professional development. 
        </big></strong></asp:Label><br />
    <br />
    <br />
    <table width="75%" class="mainBody">
        <tr>
            <td colspan="3" valign="top">
              
                   <strong> <asp:Label ID="OrganizationLabel"
                       text=<%# region4.escWeb.SiteVariables.ObjectProvider.OrganizationNameCapitalized %>
                AssociatedControlID="ddlRegion"
                runat="server"></asp:Label></strong>(Select Region 3 ESC if you do not know your <%# region4.escWeb.SiteVariables.ObjectProvider.OrganizationNameCapitalized %>.)
            </td>
        </tr>
        <tr>
            <td colspan="3" valign="top">
                <asp:DropDownList ID="ddlRegion" runat="server" CssClass="formInput" />
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlRegion"
                    CssClass="error" ErrorMessage="Region is a required field"></asp:RequiredFieldValidator>
                <cc1:CascadingDropDown ID="CascadingDropDown1" runat="server" TargetControlID="ddlRegion"
                    Category="Org" PromptText="Please select a region..." ServicePath="~/services/locationservice.asmx"
                    ServiceMethod="GetRegions" />
            </td>
        </tr>
        <tr>
            <td colspan="3" valign="top">
                <strong><asp:Label ID="SiteLabel"
                    text=<%# region4.escWeb.SiteVariables.ObjectProvider.SiteNameCapitalized %>
                    AssociatedControlID="ddlDistrict"
                    runat="server"></asp:Label>
                </strong>(Select Other Organizations if you do not know your <%# region4.escWeb.SiteVariables.ObjectProvider.SiteNameCapitalized %>.)
            </td>
        </tr>
        <tr>
            <td colspan="3" valign="top">
                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="formInput" />
                <br />
                <br />
                <cc1:CascadingDropDown ID="CascadingDropDown2" runat="server" TargetControlID="ddlDistrict"
                    ParentControlID="ddlRegion" PromptText="Please select a district..." ServicePath="~/services/locationservice.asmx"
                    ServiceMethod="GetDistrictsForRegion" Category="Site" />
            </td>
        </tr>
        <tr>
            <td colspan="3" valign="top">
                <strong><asp:Label ID="SchoolLabel"
                    text=<%# region4.escWeb.SiteVariables.ObjectProvider.SchoolNameCapitalized %>
                    AssociatedControlID="ddlSchool"
                    runat="server"></asp:Label>
                </strong>(Select Other Organizations if you do not know your <%# region4.escWeb.SiteVariables.ObjectProvider.SchoolNameCapitalized %>.)
            </td>
        </tr>
        <tr>
            <td colspan="3" valign="top">
                <asp:DropDownList ID="ddlSchool" runat="server" CssClass="formInput" />
                <br />
                <br />
                <cc1:CascadingDropDown ID="CascadingDropDown3" runat="server" TargetControlID="ddlSchool"
                    ParentControlID="ddlDistrict" PromptText="Please select a campus..." ServicePath="~/services/locationservice.asmx"
                    ServiceMethod="GetSchoolsFromDistricts" Category="Room" />
            </td>
        </tr>
        <tr>
            <td colspan="3" valign="top">
                <asp:Label ID="PositionLabel"
                    text="<strong>Position:</strong>"
                    AssociatedControlID="ddlPosition"
                    runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3" valign="top">
                <asp:DropDownList ID="ddlPosition" runat="server" CssClass="formInput">
                </asp:DropDownList>
                <br />
            </td>
        </tr>
                    <tr>
                <td colspan="3" valign="top">
                    <br />
                    <asp:Label ID="SpecialAccommodationLabel"
                        text="<strong>Special Accommodation(<i>Select and click add</i>):</strong>"
                        AssociatedControlID="ddlSpecialNeedList"
                        runat="server"></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td style="height: 45px" valign="top" colspan="3">
                    <table border="0" cellpadding="3" cellspacing="0">
					                <tr>
						                <td>
						                   <asp:DropDownList ID="ddlSpecialNeedList" runat="server" Width="300px" OnPreRender="ddlSpecialNeedList_PreRender" name="ddlSpecialNeedList"></asp:DropDownList>
						                </td>
						                <td>
							                &nbsp;&nbsp;<input type="button" id="SpecialNeedAdd" name="SpecialNeedAdd" width="60px" value="Add" onclick="AddMultiSelect('ctl00_mainBody_ddlSpecialNeedList', 'ctl00_mainBody_lbSpecialNeed', 'ctl00_mainBody_specialneed', 'No Special Need has been selected.');" /><input type="button" name="btnDeleteSpecialNeed" id="btnDeleteSpecialNeed" value="Del." onclick="    OnRemoveMulti('ctl00_mainBody_lbSpecialNeed', 'ctl00_mainBody_ddlSpecialNeedList', 'ctl00_mainBody_specialneed');"/>
						                </td>
					                </tr>
					                <tr>
						                <td colspan="2">
							                <asp:ListBox ID="lbSpecialNeed" runat="server" Width="300px" Height="50"></asp:ListBox>
                                            <input type="hidden" id="specialneed" runat="server" /><asp:Label ID="SpecialNeedListBoxLabel"
                                                text="<font color=#ffffff>Selected Items</font>"
                                                AssociatedControlID="lbSpecialNeed"
                                                runat="server"></asp:Label><br />
							                <%--<span style="font-family:Arial;font-size:7pt;color:#909090;">Double-click on the row to remove.</span>--%>
				
						                </td>
					                </tr>
                                    
				                 </table>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div id="divSpecialAcc" name="divSpecialAcc" style="display:none">
                        <asp:Label ID="OtherAccomLabel"
                            text="<strong>Other Special Accommodation Comments:</strong>"
                            AssociatedControlID="txtSpecialNeedComments"
                            runat="server"></asp:Label><br />
                        <asp:TextBox ID="txtSpecialNeedComments" runat="server" Width="400px"></asp:TextBox><br /><br />
                    </div>
                </td>
            </tr>
        <tr>
            <td colspan="3" valign="top">
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="3" valign="top">
                <asp:CheckBox runat="server" ID="checkboxCertify" AutoPostBack="True" Text="I certifiy the above information to be accurate"
                    OnCheckedChanged="OnCheckedChanged" />
            </td>
        </tr>
        <tr>
            <td colspan="3" valign="top">
                <br />
                <br />
            </td>
        </tr>
    </table>
    <asp:Button runat="server" ID="btnSaveUserProfile" Text="Continue" OnClick="btnSaveUserProfileClick"
        Visible="false" />
</asp:Content>
