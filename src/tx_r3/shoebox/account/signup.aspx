<%@ Page Language="C#" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="shoebox_account_signup"
    MasterPageFile="~/MasterPage.master" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content runat="server" ContentPlaceHolderID="mainBody">
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
            
            if (m_Text.indexOf("Other") > -1 || valueControl.value.indexOf("6272") > -1)
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
                    div.style.display = "block";
                else
                    div.style.display = "none";
            }
        }

        function openSpecial() {
            var div = document.getElementById("divSpecialAcc");
                div.style.display = "block";
        }

    </script>
    <asp:Panel runat="server" ID="pFirst">
        <asp:Label ID="lbErrorMessage" CssClass="error" runat="server"></asp:Label>
        <table width="75%" class="mainBody">
            <tr>
                <td colspan="3">
                    <asp:Label ID="PrimaryEmailLabel"
                        text="<strong>* Primary Email:</strong>"
                        AssociatedControlID="txtPrimaryEmail"
                        runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:TextBox ID="txtPrimaryEmail" runat="server" Width="278px" CssClass="formInput" />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPrimaryEmail"
                        CssClass="error" Display="Dynamic" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True">Primary Email is required</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:Label ID="SecondaryEmailLabel"
                        text="<strong>Secondary Email:</strong>"
                        AssociatedControlID="txtSecondaryEmail"
                        runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:TextBox ID="txtSecondaryEmail" runat="server" Width="276px" CssClass="formInput" />
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                     <asp:Label ID="SalutationLabel"
                        text="<strong>Salutation</strong>"
                        AssociatedControlID="ddlSalutation"
                        runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:DropDownList ID="ddlSalutation" runat="server" CssClass="formInput">
                    </asp:DropDownList>
                    <br />
                </td>
            </tr>
            <tr>
                <td style="width: 158px" valign="top">
                     <asp:Label ID="LastNameLabel"
                        text="<strong>* Last Name:</strong>"
                        AssociatedControlID="txtLastName"
                        runat="server"></asp:Label>
                </td>
                <td valign="top">
                    <asp:Label ID="FirstNameLabel"
                        text="<strong>* First Name: </strong>"
                        AssociatedControlID="txtFirstName"
                        runat="server"></asp:Label>
                </td>
                <td valign="top">
                    <asp:Label ID="MiddleNameLabel"
                        text="<strong>Middle Name:</strong>"
                        AssociatedControlID="txtMiddleName"
                        runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 158px" valign="top">
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="formInput" /><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName"
                        CssClass="error" ErrorMessage="Last Name is required"></asp:RequiredFieldValidator>
                </td>
                <td valign="top">
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="formInput" /><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFirstName"
                        CssClass="error" ErrorMessage="First Name is required"></asp:RequiredFieldValidator>
                </td>
                <td style="height: 45px" valign="top">
                    <asp:TextBox ID="txtMiddleName" runat="server" CssClass="formInput" />
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                     <asp:Label ID="HomeAddressLabel"
                        text="<strong>* Home Address:</strong>"
                        AssociatedControlID="txtHomeAddress"
                        runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:TextBox ID="txtHomeAddress" runat="server" Width="250px" CssClass="formInput" />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtHomeAddress"
                        CssClass="error" ErrorMessage="Home Address is required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 158px" valign="top">
                     <asp:Label ID="CityLabel"
                        text="<strong>* City:</strong>"
                        AssociatedControlID="txtCity"
                        runat="server"></asp:Label>
                </td>
                <td colspan="1" valign="top">
                    <asp:Label ID="StateLabel"
                            text="*&nbsp;<strong>State: (Two chars for state abbreviation,i.e TX)"
                            AssociatedControlID="ddState"
                            runat="server"></asp:Label>
                </td>
                <td colspan="1" valign="top">
                    <asp:Label ID="ZipLabel"
                        text="<strong>* Zip:</strong>"
                        AssociatedControlID="txtZip"
                    runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 158px; height: 45px;" valign="top">
                    <asp:TextBox ID="txtCity" runat="server" CssClass="formInput" /><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCity"
                        CssClass="error" ErrorMessage="City is required"></asp:RequiredFieldValidator>
                </td>
                <td colspan="1" style="height: 45px; width: 200px" valign="top">
                    <asp:DropDownList ID="ddState" runat="server" CssClass="formInput">
                    </asp:DropDownList>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddState"
                        CssClass="error" ErrorMessage="State is required"></asp:RequiredFieldValidator>
                </td>
                <td colspan="1" style="height: 45px" valign="top">
                    <asp:TextBox ID="txtZip" runat="server" CssClass="formInput" /><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtZip"
                        CssClass="error" ErrorMessage="Zip is required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 158px" valign="top">
                    <asp:Label ID="HomePhoneLabel"
                        text="<strong>* Home Phone:</strong>"
                        AssociatedControlId="txtHomePhone"
                        runat="server"></asp:Label>
                </td>
                <td colspan="1" valign="top">
                     <asp:Label ID="WorkPhoneLabel"
                        text="<strong>Work Phone:</strong>"
                        AssociatedControlID="txtWorkPhone"
                        runat="server"></asp:Label>
                </td>
                <td colspan="1" valign="top">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 158px; height: 45px" valign="top">
                    <asp:TextBox ID="txtHomePhone" runat="server" CssClass="formInput" /><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtHomePhone"
                        CssClass="error" ErrorMessage="Home Phone is required"></asp:RequiredFieldValidator>
                </td>
                <td colspan="1" style="height: 45px" valign="top">
                    <asp:TextBox ID="txtWorkPhone" runat="server" CssClass="formInput" /><br />
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtWorkPhone"
                        CssClass="error" ErrorMessage="Work Phone is required"></asp:RequiredFieldValidator>--%>
                </td>
                <td colspan="1" style="height: 45px" valign="top">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <strong><asp:Label ID="OrganizationLabel"
                        text=<%# region4.escWeb.SiteVariables.ObjectProvider.OrganizationNameCapitalized %>
                        AssociatedControlID="ddlRegion"
                        runat="server"></asp:Label></strong>
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
                    <strong><asp:Label ID="DistrictLabel"
                        text=<%# region4.escWeb.SiteVariables.ObjectProvider.SiteNameCapitalized %>
                        AssociatedControlID="ddlDistrict"
                        runat="server"></asp:Label></strong>
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="formInput" />
                    <br />
                    <cc1:CascadingDropDown ID="CascadingDropDown2" runat="server" TargetControlID="ddlDistrict"
                        ParentControlID="ddlRegion" PromptText="Please select a district..." ServicePath="~/services/locationservice.asmx"
                        ServiceMethod="GetDistrictsForRegion" Category="Site" />
                    <%--<asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="RangeValidator"></asp:RangeValidator>--%>
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <strong><asp:Label ID="SchoolLabel"
                        text=<%# region4.escWeb.SiteVariables.ObjectProvider.SchoolNameCapitalized %>
                        AssociatedControlID="ddlSchool"
                        runat="server"></asp:Label></strong>
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:DropDownList ID="ddlSchool" runat="server" CssClass="formInput" />
                    <br />
                    <cc1:CascadingDropDown ID="CascadingDropDown3" runat="server" TargetControlID="ddlSchool"
                        ParentControlID="ddlDistrict" PromptText="Please select a school..." ServicePath="~/services/locationservice.asmx"
                        ServiceMethod="GetSchoolsFromDistricts" Category="Room" />
                    <%--<asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="RangeValidator"></asp:RangeValidator>--%>
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <br /><asp:Label ID="SpecialNeedsLabel"
                        text="<strong>Special Accommodation (<i>Select and click add</i>):</strong>"
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
                                            <input type="hidden" id="specialneed" runat="server" />
                                            <asp:Label ID="SpecialNeedsListBoxLabel"
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
                        <asp:Label ID="SpecialNeedCommentsLabel"
                            text="<strong>Other Special Accommodation Comments:</strong>"
                            AssociatedControlID="txtSpecialNeedComments"
                            runat="server"></asp:Label><br />
                        <asp:TextBox ID="txtSpecialNeedComments" runat="server" Width="400px"></asp:TextBox><br /><br />
                    </div>
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
                    <cc1:CascadingDropDown ID="CascadingDropDown4" runat="server" TargetControlID="ddlPosition"
                        ParentControlID="ddlSchool" PromptText="Please select a Position..." ServicePath="~/services/locationservice.asmx"
                        ServiceMethod="GePositionsFromSchool" Category="Room" />
                    <%--<asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="RangeValidator"></asp:RangeValidator>--%>
                </td>
            </tr>
            <tr>
                <%--  <td colspan="3" valign="top">
            <strong>Grade Level:</strong>
            </td>
            </tr>--%>
                <%--<tr>
            <td colspan="3" valign="top">
            <asp:DropDownList runat="server" ID="ddlGradeLevel" CssClass="formInput" />
            </td>
            </tr>--%>
                <tr>
                    <td colspan="3" valign="top">
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 158px" valign="top">
                         <asp:Label ID="PasswordLabel"
                        text="<strong>Password:</strong>"
                        AssociatedControlID="txtPassword"
                        runat="server"></asp:Label>
                    </td>
                    <td colspan="1" valign="top">
                        <asp:Label ID="ConfirmPasswordLabel"
                        text="<strong>Confirm Password:</strong>"
                        AssociatedControlID="txtConfirmPassword"
                        runat="server"></asp:Label>
                    </td>
                    <td colspan="1" valign="top">
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 158px; height: 45px;" valign="top">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="formInput" /><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Password is required"
                            ControlToValidate="txtPassword" CssClass="error"></asp:RequiredFieldValidator>
                    </td>
                    <td colspan="1" style="height: 45px" valign="top">
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="formInput" /><br />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" CssClass="error" ErrorMessage="Password must match"
                            ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"></asp:CompareValidator>
                    </td>
                    <td colspan="1" style="height: 45px" valign="top">
                    </td>
                </tr>
        </table>
        <br />
        <br />
        <asp:Button runat="server" ID="btnSubmit" Text="Save Record" />
    </asp:Panel>
    <asp:Panel runat="server" ID="pSuccess" Visible="false">
        Your account has been created. <a href="~/default.aspx" runat="server" class="link">
            Please click here to continue</a>
    </asp:Panel>
</asp:Content>
