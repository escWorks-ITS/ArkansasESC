<%@ Page Language="C#" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="shoebox_account_signup"
    MasterPageFile="~/MasterPage.master" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content runat="server" ContentPlaceHolderID="mainBody"><a name="MainBody"></a>
    <span style="padding-right: 10px;"><button type="button" onclick="javascript:history.back()" class="formInput btn btn-ARESCBlue btn-lg" role="button" style="width: 130px; font-size:small" ToolTip="Click here to go to previous page.">Previous</button></span>
    <br /><br />
    <asp:Panel runat="server" ID="pFirst">
        <asp:Label ID="lbErrorMessage" CssClass="error smallFont" runat="server"></asp:Label>
        <%--<asp:Label ID="lbErrorMessage" CssClass="error" runat="server"></asp:Label>--%>

            <div class="row">
                <div class="col-xs-12 col-sm-8">
                   <font color="black">*&nbsp;</font><asp:Label ID="PrimaryEmailLabel" Text="<strong>Primary Email: </strong>" AssociatedControlID="txtPrimaryEmail" CssClass="smallFont" runat="server">
            
                    </asp:Label><asp:TextBox ID="txtPrimaryEmail" CssClass="form-control smallFont" aria-required="true" runat="server" Style="height: 28px;" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPrimaryEmail"
                        CssClass="error smallFont" Display="Dynamic" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" ForeColor="#A80000">Primary Email is required</asp:RequiredFieldValidator>
                    <br />
                </div>
            </div>

        <%--<table width="75%" class="mainBody">
            <tr>
                <td colspan="3">
                    <strong><asp:Label ID="PrimaryEmailLabel"
text="Primary Email:"
AssociatedControlID="txtPrimaryEmail"
runat="server"></asp:Label></strong>
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:TextBox ID="txtPrimaryEmail" runat="server" Width="278px" CssClass="formInput" />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPrimaryEmail"
                        CssClass="error" Display="Dynamic" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True">Primary Email is required</asp:RequiredFieldValidator>
                </td>
            </tr>--%>

            <div class="row">
                <div class="col-xs-12 col-sm-8">
                    <asp:Label ID="SecondaryEmailLabel" Text="<strong>Secondary Email: </strong>" AssociatedControlID="txtSecondaryEmail" CssClass="smallFont" runat="server"> 
                                
                    </asp:Label><asp:TextBox ID="txtSecondaryEmail" CssClass="form-control smallFont" runat="server" Style="height: 28px;" />
                    <br />
                </div>
            </div>

            <%--<tr>
                <td colspan="3" valign="top">
                    <strong><asp:Label ID="SecondaryEmailLabel"
text="Secondary Email:"
AssociatedControlID="txtSecondaryEmail"
runat="server"></asp:Label></strong>
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:TextBox ID="txtSecondaryEmail" runat="server" Width="276px" CssClass="formInput" />
                </td>
            </tr>--%>
            <%--            <tr>
                <td colspan="3" valign="top">
                    <strong>Salutation</strong></td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:DropDownList ID="ddlSalutation" runat="server" CssClass="formInput">
                    </asp:DropDownList><br />
                </td>
            </tr>--%>

            <div class="row">
                <div class="col-xs-12 col-sm-4">
                   <font color="black">*&nbsp;</font>
                    <asp:Label ID="FirstNameLabel"
                        Text="<strong>First Name: </strong>"
                        AssociatedControlID="txtFirstName"
                        CssClass="smallFont"
                        runat="server"></asp:Label>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control smallFont" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFirstName"
                        CssClass="error smallFont" ErrorMessage="First Name is required" ForeColor="#A80000"></asp:RequiredFieldValidator>
                </div>
                <div class="col-xs-12 col-sm-4">
                    <font color="black">*&nbsp;</font>
                    <asp:Label ID="LastNameLabel"
                        Text="<strong>Last Name:</strong>"
                        AssociatedControlID="txtLastName"
                        CssClass="smallFont"
                        runat="server"></asp:Label>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control smallFont" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName"
                        CssClass="error smallFont" ErrorMessage="Last Name is required" ForeColor="#A80000"></asp:RequiredFieldValidator>
                </div>
                <div class="col-xs-12 col-sm-4">
                    <asp:Label ID="MiddleNameLabel"
                        Text="<strong>Middle Name:</strong>"
                        AssociatedControlID="txtMiddleName"
                        CssClass="smallFont"
                        runat="server"></asp:Label>
                    <asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control smallFont" /><br />
                </div>
            </div>

            <%--<tr>
                <td valign="top">
                    <strong><asp:Label ID="FirstNameLabel"
text="First Name:"
AssociatedControlID="txtFirstName"
runat="server"></asp:Label> </strong>
                </td>
                <td style="width: 158px" valign="top">
                    <strong><asp:Label ID="LastNameLabel"
text="Last Name:"
AssociatedControlID="txtLastName"
runat="server"></asp:Label></strong>
                </td>
                <td valign="top">
                    <strong><asp:Label ID="MiddleNameLabel"
text="Middle Name:"
AssociatedControlID="txtMiddleName"
runat="server"></asp:Label></strong>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="formInput" /><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFirstName"
                        CssClass="error" ErrorMessage="First Name is required"></asp:RequiredFieldValidator>
                </td>
                <td style="width: 158px" valign="top">
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="formInput" /><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName"
                        CssClass="error" ErrorMessage="Last Name is required"></asp:RequiredFieldValidator>
                </td>
                <td style="height: 45px" valign="top">
                    <asp:TextBox ID="txtMiddleName" runat="server" CssClass="formInput" />
                </td>
            </tr>--%>

            <div class="row">
                <div class="col-xs-12 col-sm-12">
                    <font color="black">*&nbsp;</font><asp:Label ID="HomeAddressLabel"
                        Text="<strong>Home Address:</strong>"
                        AssociatedControlID="txtHomeAddress"
                        CssClass="smallFont"
                        runat="server"></asp:Label>
                    <asp:TextBox ID="txtHomeAddress" runat="server" CssClass="form-control smallFont" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtHomeAddress"
                        CssClass="error" ErrorMessage="Home Address is required" ForeColor="#A80000"></asp:RequiredFieldValidator>
                </div>
            </div>

<%--            <tr>
                <td colspan="3" valign="top">
                    <strong><asp:Label ID="HomeAddressLabel"
text="Home Address:"
AssociatedControlID="txtHomeAddress"
runat="server"></asp:Label></strong>
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:TextBox ID="txtHomeAddress" runat="server" Width="250px" CssClass="formInput" />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtHomeAddress"
                        CssClass="error" ErrorMessage="Home Address is required"></asp:RequiredFieldValidator>
                </td>
            </tr>--%>

        <div class="row">
                <div class="col-xs-12 col-sm-4">
                    <font color="black">*&nbsp;</font>
                    <asp:Label ID="CityLabel"
                        Text="<strong>City:</strong>"
                        AssociatedControlID="txtCity"
                        CssClass="smallFont"
                        runat="server"></asp:Label>
                    <asp:TextBox ID="txtCity" runat="server" CssClass="form-control smallFont" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCity"
                        CssClass="error" ErrorMessage="City is required" ForeColor="#A80000"></asp:RequiredFieldValidator>
                </div>
                <div class="col-xs-12 col-sm-4">
                    <font color="black">*&nbsp;</font>
                    <asp:Label ID="StateLabel"
                        Text="<strong>State: </strong>"
                        AssociatedControlID="ddState"
                        CssClass="smallFont"
                        runat="server"></asp:Label>
                    <asp:DropDownList ID="ddState" runat="server" CssClass="form-control smallFont" Height="32"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddState"
                        CssClass="error" ErrorMessage="State is required" ForeColor="#A80000"></asp:RequiredFieldValidator>
                </div>
                <div class="col-xs-12 col-sm-4">
                       <font color="black">*&nbsp;</font>
                        <asp:Label ID="ZipLabel"
                            Text="<strong>Zip:</strong>"
                            AssociatedControlID="txtZip"
                            CssClass="smallFont"
                            runat="server"></asp:Label>
                        <asp:TextBox ID="txtZip" runat="server" CssClass="form-control smallFont" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtZip"
                            CssClass="error" ErrorMessage="Zip is required" ForeColor="#A80000"></asp:RequiredFieldValidator>
                    </div>
                </div>

<%--            <tr>
                <td style="width: 158px" valign="top">
                    <strong><asp:Label ID="CityLabel"
text="City:"
AssociatedControlID="txtCity"
runat="server"></asp:Label></strong>
                </td>
               <td colspan="1" valign="top">
                    <strong><asp:Label ID="StateLabel"
text="* State: (Two chars for state abbrev,i.e AR)"
AssociatedControlID="ddState"
runat="server"></asp:Label></strong></td>
                <td colspan="1" valign="top">
                    <strong><asp:Label ID="ZipLabel"
text="Zip:"
AssociatedControlID="txtZip"
runat="server"></asp:Label></strong>
                </td>
            </tr>
            <tr>
                <td style="width: 158px; height: 45px;" valign="top">
                    <asp:TextBox ID="txtCity" runat="server" CssClass="formInput" /><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCity"
                        CssClass="error" ErrorMessage="City is required"></asp:RequiredFieldValidator>
                </td>
                 <td colspan="1" style="height: 45px" valign="top">
                    
                    <asp:DropDownList ID="ddState" runat="server" CssClass="formInput"></asp:DropDownList><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddState"
                        CssClass="error" ErrorMessage="State is required"></asp:RequiredFieldValidator></td>
                <td colspan="1" style="height: 45px" valign="top">
                    <asp:TextBox ID="txtZip" runat="server" CssClass="formInput" /><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtZip"
                        CssClass="error" ErrorMessage="Zip is required"></asp:RequiredFieldValidator>
                </td>
            </tr>--%>

            <div class="row">
                <div class="col-xs-12 col-sm-4">
                    <font color="black">*&nbsp;</font>
                    <asp:Label ID="HomePhoneLabel"
                        Text="<strong>Home Phone:</strong>"
                        AssociatedControlID="txtHomePhone"
                        CssClass="smallFont"
                        runat="server"></asp:Label>
                    <asp:TextBox ID="txtHomePhone" runat="server" CssClass="form-control smallFont" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtHomePhone"
                        CssClass="error smallFont" ErrorMessage="Home Phone is required" ForeColor="#A80000"></asp:RequiredFieldValidator>
                </div>
                <div class="col-xs-12 col-sm-4">
                    <font color="black">*&nbsp;</font><asp:Label ID="WorkPhoneLabel"
                        Text="<strong>Work Phone:</strong>"
                        AssociatedControlID="txtWorkPhone"
                        CssClass="smallFont"
                        runat="server"></asp:Label>
                    <asp:TextBox ID="txtWorkPhone" runat="server" CssClass="form-control smallFont" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtWorkPhone"
                        CssClass="error" ErrorMessage="Work Phone is required" ForeColor="#A80000"></asp:RequiredFieldValidator>
                </div>
                <div class="col-xs-12 col-sm-4">
                    <font color="black">&nbsp;</font>
                    <asp:Label ID="EmployeeNoLabel"
                    text="<strong>Employee No.</strong>"
                    AssociatedControlID="txtEmployeeNo"
                    CssClass="smallFont"
                    runat="server"></asp:Label>
                    <asp:TextBox ID="txtEmployeeNo" runat="server" CssClass="form-control smallFont" />
<%--        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtWorkPhone"
                        CssClass="error smallFont" ErrorMessage="Work Phone is required" ForeColor="#A80000"></asp:RequiredFieldValidator>--%>
                 </div>
            </div>

<%--            <tr>
                <td style="width: 158px" valign="top">
                    <strong><asp:Label ID="HomePhoneLabel"
text="Home Phone:"
AssociatedControlID="txtHomePhone"
runat="server"></asp:Label></strong>
                </td>
                <td colspan="1" valign="top">
                    <strong><asp:Label ID="WorkPhoneLabel"
text="Work Phone:"
AssociatedControlID="txtWorkPhone"
runat="server"></asp:Label></strong>
                </td>
                <td colspan="1" valign="top">
                    <strong><asp:Label ID="EmployeeNoLabel"
text="Employee No."
AssociatedControlID="txtEmployeeNo"
runat="server"></asp:Label></strong>
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtWorkPhone"
                        CssClass="error" ErrorMessage="Work Phone is required"></asp:RequiredFieldValidator>
                </td>
                <td colspan="1" style="height: 45px" valign="top">
                    <asp:TextBox ID="txtEmployeeNo" runat="server" CssClass="formInput" /><br />
                </td>
            </tr>--%>

            <div class="row">
                <div class="col-xs-12 col-sm-8">
                        <font color="black">*&nbsp;</font><strong><asp:Label ID="RegionLabel"
                            text=<%# region4.escWeb.SiteVariables.ObjectProvider.OrganizationNameCapitalized %> 
                            AssociatedControlID="ddlRegion"
                            CssClass="smallFont"
                            runat="server"></asp:Label>:&nbsp;</strong>
        <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control smallFont" Height="32">
        </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlRegion"
                        CssClass="error" ErrorMessage="Region is a required field" ForeColor="#A80000"></asp:RequiredFieldValidator>
                    <cc1:CascadingDropDown ID="CascadingDropDown1" runat="server" TargetControlID="ddlRegion" Category="Org" PromptText="Choose your service coop/school group." ServicePath="~/services/locationservice.asmx" ServiceMethod="GetRegions" />
                </div>
            </div>

<%--            <tr>
                <td colspan="3" valign="top">
                    <strong><asp:Label ID="OrganizationLabel"
text=<%# region4.escWeb.SiteVariables.ObjectProvider.OrganizationNameCapitalized %>
AssociatedControlID="ddlRegion"
runat="server"></asp:Label>
                        :</strong>
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:DropDownList ID="ddlRegion" runat="server" CssClass="formInput" />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlRegion"
                        CssClass="error" ErrorMessage="Region is a required field"></asp:RequiredFieldValidator>
                    <cc1:CascadingDropDown ID="CascadingDropDown1" runat="server" TargetControlID="ddlRegion"
                        Category="Org" PromptText="Choose your service coop/school group." ServicePath="~/services/locationservice.asmx"
                        ServiceMethod="GetRegions" />
                </td>
            </tr>--%>

            <div class="row">
                <div class="col-xs-12 col-sm-8">
                    <font color="black">*&nbsp;</font><strong>
                        <asp:Label ID="DistrictLabel"
                             text=<%# region4.escWeb.SiteVariables.ObjectProvider.SiteNameCapitalized %>
                            AssociatedControlID="ddlDistrict"
                            CssClass="smallFont"
                            runat="server"></asp:Label>:&nbsp;</strong>
        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control smallFont" Height="32">
        </asp:DropDownList>
                    <cc1:CascadingDropDown ID="CascadingDropDown2" runat="server" TargetControlID="ddlDistrict" ParentControlID="ddlRegion" PromptText="Please select a district..." ServicePath="~/services/locationservice.asmx" ServiceMethod="GetDistrictsForRegion" Category="Site" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlDistrict"
                        CssClass="error" ErrorMessage="District is a required field" InitialValue="" ForeColor="#A80000"></asp:RequiredFieldValidator>
                </div>
            </div>

<%--            <tr>
                <td colspan="3" valign="top">
                    <strong><asp:Label ID="SiteLabel"
text=<%# region4.escWeb.SiteVariables.ObjectProvider.SiteNameCapitalized %>
AssociatedControlID="ddlDistrict"
runat="server"></asp:Label>
                        :</strong>
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="formInput" />
                    <br />
                    <cc1:CascadingDropDown ID="CascadingDropDown2" runat="server" TargetControlID="ddlDistrict"
                        ParentControlID="ddlRegion" PromptText="Please select a district..." ServicePath="~/services/locationservice.asmx"
                        ServiceMethod="GetDistrictsForRegion" Category="Site" />
                    <%--<asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="RangeValidator"></asp:RangeValidator>
                </td>
            </tr>--%>

        <div class="row">
            <div class="col-xs-12 col-sm-8">
           <font color="black">*&nbsp;</font><strong>
                        <asp:Label ID="SchoolLabel"
                            text=<%# region4.escWeb.SiteVariables.ObjectProvider.SchoolNameCapitalized %>
                            AssociatedControlID="ddlSchool"
                            runat="server"></asp:Label>
                            :</strong> 
            <asp:DropDownList ID="ddlSchool" runat="server" CssClass="form-control smallFont form-input" Height="32" /><br />
                    <cc1:CascadingDropDown ID="CascadingDropDown3" runat="server" TargetControlID="ddlSchool" ParentControlID="ddlDistrict" PromptText="Please select a school..." ServicePath="~/services/locationservice.asmx" ServiceMethod="GetSchoolsFromDistricts" Category="Room" />
<%--                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddlSchool"
                        CssClass="error" ErrorMessage="Campus is a required field" InitialValue="" ForeColor="#A80000"></asp:RequiredFieldValidator>--%>
            </div>
        </div>

            <%--<tr>
                <td colspan="3" valign="top">
                    <strong><asp:Label ID="SchoolLabel"
text=<%# region4.escWeb.SiteVariables.ObjectProvider.SchoolNameCapitalized %>
AssociatedControlID="ddlSchool"
runat="server"></asp:Label>
                        :</strong>
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:DropDownList ID="ddlSchool" runat="server" CssClass="formInput" />
                    <br />
                    <cc1:CascadingDropDown ID="CascadingDropDown3" runat="server" TargetControlID="ddlSchool"
                        ParentControlID="ddlDistrict" PromptText="Please select a school..." ServicePath="~/services/locationservice.asmx"
                        ServiceMethod="GetSchoolsFromDistricts" Category="Room" />
                    <%--<asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="RangeValidator"></asp:RangeValidator>
                </td>
            </tr>--%>

          <div class="row">
    <div class="col-xs-12 col-sm-10">
     <font color="black">*&nbsp;</font>
        <asp:Label ID="PositionLabel"
        text="<strong>Position:</strong>"
        AssociatedControlID="ddlPosition"
        CssClass="smallFont"
        runat="server"></asp:Label>

       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlPosition"
            CssClass="error smallFont" ErrorMessage="Position is a required field" ForeColor="#A80000"></asp:RequiredFieldValidator>--%>
         <%--<cc1:CascadingDropDown ID="CascadingDropDown4" runat="server" TargetControlID="ddlPosition" ParentControlID="ddlSchool" PromptText="Please select a Position..." ServicePath="~/services/locationservice.asmx" ServiceMethod="GePositionsFromSchool"  Category="Room"/>--%>
        <asp:DropDownList ID="ddlPosition" runat="server" CssClass="form-control smallFont" Height="33px" /><br />
    </div>
  </div>

            <%--<tr>
                <td colspan="3" valign="top">
                    <strong><asp:Label ID="PositionLabel"
text="Position:"
AssociatedControlID="ddlPosition"
runat="server"></asp:Label></strong>
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:DropDownList ID="ddlPosition" runat="server" CssClass="formInput">
                    </asp:DropDownList>
                    <br />
                    <%--<asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="RangeValidator"></asp:RangeValidator>
                </td>
            </tr>--%>
            <%--            <tr>
                <td colspan="3" valign="top">
                    <strong>Grade Level:</strong>
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:DropDownList runat="server" ID="ddlGradeLevel" CssClass="formInput" />
                </td>
            </tr>--%>
<%--            <tr>
                <td colspan="3" valign="top">
                </td>
            </tr>--%>

<div class="row">
    <div class="col-xs-12 col-sm-6">
        <font color="black">*&nbsp;</font><asp:Label ID="PasswordLabel"
        text="<strong>Password:</strong>"
        AssociatedControlID="txtPassword"
        CssClass="smallFont"
        runat="server"></asp:Label>

        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control smallFont" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Password is required" ForeColor="#A80000" ControlToValidate="txtPassword" CssClass="error"></asp:RequiredFieldValidator>
    </div>

    <div class="col-xs-12 col-sm-6">
       <font color="black">*&nbsp;</font><asp:Label ID="ConfirmPasswordLabel"
        text="<strong>Confirm Password:</strong>"
        AssociatedControlID="txtConfirmPassword"
        CssClass="smallFont"
        runat="server"></asp:Label>

        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control smallFont" />
        <asp:CompareValidator ID="CompareValidator1" runat="server" CssClass="error smallFont"
        ErrorMessage="Password must match" ForeColor="#A80000" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"></asp:CompareValidator>
    </div> 

</div>

            <%--<tr>
                <td colspan="1" style="width: 158px" valign="top">
                    <strong><asp:Label ID="PasswordLabel"
text="Password:"
AssociatedControlID="txtPassword"
runat="server"></asp:Label></strong>
                </td>
                <td colspan="1" valign="top">
                    <strong><asp:Label ID="ConfirmPasswordLabel"
text="Confirm Password:"
AssociatedControlID="txtConfirmPassword"
runat="server"></asp:Label></strong>
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
        </table>--%>

<div class="row">
    <div class="col-xs-12 col-sm-4">

        <asp:Button ID="btnSubmit" runat="Server" Text="Save Record" CssClass="formInput btn btn-ARESCBlue btn-lg"
        Style="width: 170px; font-size:small" ToolTip="Click here to save record.">
        </asp:Button><br /><br />
    </div>
 </div>
        <%--<asp:Button runat="server" ID="btnSubmit" Text="Save Record" />--%>
    </asp:Panel>
    <asp:Panel runat="server" ID="pSuccess" Visible="false">
        Your account has been created. <a href="~/default.aspx" runat="server" class="link">
            Please click here to continue</a>
    </asp:Panel>
</asp:Content>
