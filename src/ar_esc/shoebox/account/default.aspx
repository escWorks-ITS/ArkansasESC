<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="shoebox_account_default"
    EnableEventValidation="false" MasterPageFile="~/MasterPage.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content runat="server" ContentPlaceHolderID="mainBody"><a name="MainBody"></a>
    <span style="padding-right: 10px;"><button type="button" onclick="javascript:history.back()" class="formInput btn btn-ARESCBlue btn-lg" role="button" style="width: 130px; font-size:small" ToolTip="Click here to go to previous page.">Previous</button></span>
    <br /><br />
    <asp:Panel runat="server" ID="pFirst">
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
                    <a class="link" runat="server" href="~/shoebox/account/email.aspx">Change primary email
                        address...</a>
                    <br />
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="OnChangePassword">Change password</asp:LinkButton>                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPrimaryEmail"
                        CssClass="error" Display="Dynamic" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True">Primary Email is required</asp:RequiredFieldValidator>
                </td>
            </tr>--%>

<div class="row">
    <div class="col-xs-12 col-sm-8">
        <asp:Label ID="UserNameLabel"
        text="<strong>Primary Email:</strong>"
        AssociatedControlID="txtPrimaryEmail"
        CssClass="smallFont" style="color: #292568;"
        runat="server"></asp:Label>
        <asp:TextBox ID="txtPrimaryEmail" runat="server" CssClass="form-control smallFont" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPrimaryEmail"
                        CssClass="error smallFont" Display="Dynamic" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True">Primary Email is required</asp:RequiredFieldValidator>
        
    </div>       
</div>
        <br />

        <button type="button" class="btn btn-ARESCBlue btn-lg" onclick="location.href='../account/email.aspx'">Change Primary Email</button>  
<%--    <button type="button" class="btn btn-info btn-lg"" onclick="location.href='../account/password.aspx/OnChangePassword()'">Change Password</button>--%>
<asp:LinkButton ID="btnChangePassword" runat="server" OnClick="OnChangePassword"><button type="button" class="btn btn-ARESCBlue btn-lg">Change Password</button></asp:LinkButton>
<br /><br />

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

<div class="row">
    <div class="col-xs-12 col-sm-8">
        <asp:Label ID="SecondaryEmailLabel"
        text="<strong>Secondary Email:</strong>"
        AssociatedControlID="txtSecondaryEmail"
        CssClass="smallFont"
        runat="server"></asp:Label>
        <asp:TextBox ID="txtSecondaryEmail" CssClass="form-control smallFont" runat="server" /><br />        
     </div>       
  </div>

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
<%--            <tr>
                <td style="width: 158px" valign="top">
                    <strong><asp:Label ID="LastNameLabel"
text="Last Name:"
AssociatedControlID="txtLastName"
runat="server"></asp:Label></strong>
                </td>
                <td valign="top">
                    <strong><asp:Label ID="FirstNameLabel"
text="First Name:"
AssociatedControlID="txtFirstName"
runat="server"></asp:Label> </strong>
                </td>
                <td valign="top">
                    <strong><asp:Label ID="MiddleNameLabel"
text="Middle Name:"
AssociatedControlID="txtMiddleName"
runat="server"></asp:Label></strong>
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
            </tr>--%>

<div class="row">
    <div class="col-xs-12 col-sm-4">
        <font color="black">*&nbsp;</font>
        <asp:Label ID="FirstNameLabel"
        text="<strong>First Name: </strong>"
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
        text="<strong>Last Name:</strong>"
        AssociatedControlID="txtLastName"
        CssClass="smallFont"
        runat="server"></asp:Label>
        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control smallFont" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName"
        CssClass="error smallFont" ErrorMessage="Last Name is required" ForeColor="#A80000"></asp:RequiredFieldValidator>
    </div>



    <div class="col-xs-12 col-sm-4">
        <asp:Label ID="MiddleNameLabel"
        text="<strong>Middle Name:</strong>"
        AssociatedControlID="txtMiddleName"
        CssClass="smallFont"
        runat="server"></asp:Label>
        <asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control smallFont" /><br />
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
    <div class="col-xs-12 col-sm-12">
         <font color="black">*&nbsp;</font>
        <asp:Label ID="HomeAddressLabel"
        text="<strong>Home Address:</strong>"
        AssociatedControlID="txtHomeAddress"
        CssClass="smallFont"
        runat="server"></asp:Label>
        <asp:TextBox ID="txtHomeAddress" runat="server" CssClass="form-control smallFont" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtHomeAddress"
                        CssClass="error smallFont" ErrorMessage="Home Address is required" ForeColor="#A80000"></asp:RequiredFieldValidator>
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
text="* State:(Two chars for state abbreviation,i.e AR)"
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
        <asp:Label ID="CityLabel"
        text="<strong>City:</strong>"
        AssociatedControlID="txtCity"
        CssClass="smallFont"
        runat="server"></asp:Label>       
       <asp:TextBox ID="txtCity" runat="server" CssClass="form-control smallFont" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCity"
                        CssClass="error smallFont" ErrorMessage="City is required" ForeColor="#A80000"></asp:RequiredFieldValidator>
    </div>
    <div class="col-xs-12 col-sm-4">
        <font color="black">*&nbsp;</font>
        <asp:Label ID="StateLabel"
        text="<strong>State: (2 letter Abbrev)</strong>"
        AssociatedControlID="ddState"
        CssClass="smallFont"
        runat="server"></asp:Label>                         
        <asp:DropDownList ID="ddState" runat="server" CssClass="form-control smallFont" style="height: 30px"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddState"
                        CssClass="error smallFont" ErrorMessage="State is required" ForeColor="#A80000"></asp:RequiredFieldValidator>
    </div>
    <div class="col-xs-12 col-sm-4">
        <font color="black">*&nbsp;</font>
        <asp:Label ID="ZipLabel"
        text="<strong>Zip:</strong>"
        AssociatedControlID="txtZip"
        CssClass="smallFont"
        runat="server"></asp:Label>
        <asp:TextBox ID="txtZip" runat="server" CssClass="form-control smallFont" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtZip"
                        CssClass="error smallFont" ErrorMessage="Zip is required" ForeColor="#A80000"></asp:RequiredFieldValidator>
    </div>
  </div>


<%--            <tr>
                <td style="width: 158px" valign="top">
                    <strong><asp:Label ID="HomePHoneLabel"
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
    <div class="col-xs-12 col-sm-4">
        <font color="black">*&nbsp;</font>
        <asp:Label ID="HomePhoneLabel"
        text="<strong>Home Phone:</strong>"
        AssociatedControlID="txtHomePhone"
        CssClass="smallFont"
        runat="server"></asp:Label>
        <asp:TextBox ID="txtHomePhone" runat="server" CssClass="form-control smallFont" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtHomePhone"
                        CssClass="error smallFont" ErrorMessage="Home Phone is required" ForeColor="#A80000"></asp:RequiredFieldValidator>
    </div>
    <div class="col-xs-12 col-sm-4">
        <font color="black">*&nbsp;</font>
        <asp:Label ID="WorkPhoneLabel"
        text="<strong>Work Phone:</strong>"
        AssociatedControlID="txtWorkPhone"
        CssClass="smallFont"
        runat="server"></asp:Label>
        <asp:TextBox ID="txtWorkPhone" runat="server" CssClass="form-control smallFont" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtWorkPhone"
                        CssClass="error smallFont" ErrorMessage="Work Phone is required" ForeColor="#A80000"></asp:RequiredFieldValidator>
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
                        Category="Org" PromptText="Please select a region..." ServicePath="~/services/locationservice.asmx"
                        ServiceMethod="GetRegions" />
                </td>
            </tr>--%>

         <div class="row">
    <div class="col-xs-12 col-sm-10">
         <font color="black">*&nbsp;</font>
        <strong><asp:Label ID="RegionLabel"
        text=<%# region4.escWeb.SiteVariables.ObjectProvider.OrganizationNameCapitalized %>
        AssociatedControlID="ddlRegion"
        CssClass="smallFont"
        runat="server"></asp:Label>
                        </strong>
        <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control smallFont" Height="33px" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlRegion"
            CssClass="error smallFont" ErrorMessage="Region is a required field" ForeColor="#A80000"></asp:RequiredFieldValidator>
        <cc1:CascadingDropDown ID="CascadingDropDown1" runat="server" TargetControlID="ddlRegion" Category="Org" PromptText="Please select a region..." ServicePath="~/services/locationservice.asmx" ServiceMethod="GetRegions" />
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
    <div class="col-xs-12 col-sm-10">
        <font color="black">*&nbsp;</font>
        <strong><asp:Label ID="DistrictLabel"
        text=<%# region4.escWeb.SiteVariables.ObjectProvider.SiteNameCapitalized %>
        AssociatedControlID="ddlDistrict"
        CssClass="smallFont"
        runat="server"></asp:Label>
                        </strong>
        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control smallFont" Height="33px" /><br />
        <cc1:CascadingDropDown ID="CascadingDropDown2" runat="server" TargetControlID="ddlDistrict" ParentControlID="ddlRegion" PromptText="Please select a district..." ServicePath="~/services/locationservice.asmx" ServiceMethod="GetDistrictsForRegion" Category="Site" />
    </div>
  </div> 

<%--            <tr>
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
        <strong><asp:Label ID="SchoolLabel"
        text=<%# region4.escWeb.SiteVariables.ObjectProvider.SchoolNameCapitalized %>
        AssociatedControlID="ddlSchool"
        CssClass="smallFont"
        runat="server"></asp:Label> </strong>
       
        <asp:DropDownList ID="ddlSchool" runat="server" CssClass="form-control smallFont" Height="33px" /><br />
                    <cc1:CascadingDropDown ID="CascadingDropDown3" runat="server" TargetControlID="ddlSchool" ParentControlID="ddlDistrict" PromptText="Please select a school..." ServicePath="~/services/locationservice.asmx" ServiceMethod="GetSchoolsFromDistricts" Category="Room" />
    </div>
  </div>

<%--            <tr>
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
    <div class="col-xs-12 col-sm-10">
     <font color="white">*&nbsp;</font>
        <asp:Label ID="AccomodationsLabel"
        text="<strong>:</strong>"
        AssociatedControlID="ddlAccommodation"
        CssClass="smallFont"
        runat="server">Special Accommodations:</asp:Label>

       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlPosition"
            CssClass="error smallFont" ErrorMessage="Position is a required field" ForeColor="#A80000"></asp:RequiredFieldValidator>--%>
         <%--<cc1:CascadingDropDown ID="CascadingDropDown4" runat="server" TargetControlID="ddlPosition" ParentControlID="ddlSchool" PromptText="Please select a Position..." ServicePath="~/services/locationservice.asmx" ServiceMethod="GePositionsFromSchool"  Category="Room"/>--%>
        <asp:DropDownList ID="ddlAccommodation" runat="server" CssClass="form-control smallFont" Height="33px" OnPreRender="ddlAccommodation_OnLoad"/><br />
    </div>
  </div>

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
            </tr>
        </table>--%>
        <asp:Label ID="lbErrorMessage" runat="server"></asp:Label>
        <%--<asp:Button runat="server" ID="btnSubmit" Text="Save Record" />--%>
        <asp:Button ID="btnSubmit" runat="Server" Text="Save Record" CssClass="formInput btn btn-ARESCBlue btn-lg"
            Style="width: 150px; font-size:small" ToolTip="Click here to save record.">
        </asp:Button>
    </asp:Panel>
    <asp:Panel runat="server" ID="pSuccess" Visible="false">
        You have successfully saved the changes to your account!<br />
        </b><a href="~/default.aspx" runat="server" class="link">Please click here to continue</a>
    </asp:Panel>
</asp:Content>
