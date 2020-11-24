<%@ Page Language="C#" AutoEventWireup="true" CodeFile="personal.aspx.cs" Inherits="shoebox_transcripts_personal"
    MasterPageFile="~/MasterPage.master" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content runat="server" ContentPlaceHolderID="mainBody"><a name="MainBody"></a>
    <span style="padding-right: 10px;"><button type="button" onclick="javascript:history.back()" class="formInput btn btn-ARESCblue btn-lg" role="button" style="width: 130px; font-size:small" ToolTip="Click here to go to previous page.">Previous</button></span>
    <br /><br />

<script type="text/javascript">
function CheckForOther(ddlControl)
	{
		if(ddlControl[ddlControl.selectedIndex].value == "0")
		{
			//
			// They need the option to enter the credit
			// name for the report.
			document.aspnetForm['<%# txtCreditName.UniqueID %>'].disabled = false;
		}
		else
		{
			//
			// A valid credit name already exists
			document.aspnetForm['<%# txtCreditName.UniqueID %>'].disabled = true;
			document.aspnetForm['<%# txtCreditName.UniqueID %>'].value = "";
		}
	}
	
	function RemoveCredit(creditID)
	{
	if(confirm("Are you sure you want to remove this credit?"))
	{
	    document.aspnetForm['<%# hiddenField.UniqueID %>'].value = creditID;
	    document.forms[0].submit();
	}
	}
</script>
<div class="row">
            <div class="col-xs-12 col-sm-1">
        <asp:Label ID="TitleLabel"
                  Text ="Title:<br/> "
                  AssociatedControlID="txtTitle"
                  runat="server"></asp:Label>
    </div> 
    <div class="col-xs-12 col-sm-5">
        <asp:TextBox ID="txtTitle" Width="260px" height="28px" CssClass="forminput" runat="server"/>
    </div>    
    <div class="col-xs-12 col-sm-1">
        <asp:Label ID="DateLabel"
                  Text ="Date:<br/> "
                  AssociatedControlID="txtDate"
                  runat="server"></asp:Label>
         
    </div> 
    <div class="col-xs-12 col-sm-5" style="z-index:1;">
        <%--<asp:TextBox  
           ID="txtDate" Width="188px" CssClass="forminput" runat="server" />&nbsp;<asp:ImageButton
                    runat="server" alt="Calendar Button" ID="btnCalendar1" ImageUrl="~/lib/img/buttons/calendar.png" />--%>
        <asp:TextBox runat="server" ID="txtDate" width="188px" height="28px" CssClass="forminput" />&nbsp;<asp:ImageButton
                    runat="server" ID="btnCalendar1" alt="Credit Date Calendar Button" ImageUrl="~/lib/img/buttons/calendar.png" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                    PopupButtonID="btnCalendar1" />
    </div>    
</div>
<%--    <table style="border-collapse: collapse; border: solid 1px gray; vertical-align: top;" align="center">
        <tr>
            <td colspan="2" valign="top">
                <asp:Label ID="TitleLabel"
text="Title:"
AssociatedControlID="txtTitle"
runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="DateLabel"
text="Date:"
AssociatedControlID="txtDate"
runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" valign="bottom">
                <asp:TextBox runat="server" ID="txtTitle" CssClass="forminput" Width="290px" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtDate" CssClass="forminput" />&nbsp;<asp:ImageButton
                    runat="server" ID="btnCalendar1" alt="Calendar Button" ImageUrl="~/lib/img/buttons/calendar.png" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                    PopupButtonID="btnCalendar1" />
            </td>
        </tr>--%>
    
<div class="row">
    <div class="col-xs-12 col-sm-3">
        <asp:Label ID="CreditTypeLabel"
                  Text ="Credit Type: <br/>"
                  AssociatedControlID="ddlCreditType"
                  runat="server"></asp:Label>
    </div> 
    <div class="col-xs-12 col-sm-3">
        <asp:DropDownList  
           ID="ddlCreditType" runat="server" CssClass="form-control fullWidth mediumFont" style="height: 32px" OnChange="CheckForOther(this);"/>
    </div>    
</div>

<div class="row">
    <div class="col-xs-12 col-sm-3">
        <asp:Label ID="CreditNameLabel"
                  Text ="***Credit Name: <br/> "
                  AssociatedControlID="txtCreditName"
                  runat="server"></asp:Label>
    </div> 
    <div class="col-xs-12 col-sm-3">
                <asp:TextBox  
           ID="txtCreditName" runat="server" CssClass="form-control fullWidth mediumFont" />
    </div>    
</div>

<div class="row">
    <div class="col-xs-12 col-sm-3">
            <asp:Label ID="CreditEarnedLabel"
                  Text ="Credit Earned: <br/> "
                  AssociatedControlID="txtCreditEarned"
                  runat="server"></asp:Label>
    </div> 
    <div class="col-xs-12 col-sm-3">
                <asp:TextBox  
           ID="txtCreditEarned" runat="server" CssClass="form-control fullWidth mediumFont"/>
    </div>    
</div>

        <%--<tr>
            <td>
                <asp:Label ID="CreditTypeLabel"
text="Credit Type:"
AssociatedControlID="ddlCreditType"
runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="CreditNameLabel"
text="***Credit Name:"
AssociatedControlID="txtCreditName"
runat="server"></asp:Label></td>
            <td>
                <asp:Label ID="CreditEarnedLabel"
text="Credit Earned:"
AssociatedControlID="txtCreditEarned"
runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
        <td><asp:DropDownList runat="server" ID="ddlCreditType" CssClass="formInput"  OnChange="CheckForOther(this);"/></td>
        <td><asp:TextBox runat="server" ID="txtCreditName" CssClass="formInput" /></td>
        <td><asp:TextBox runat="server" ID="txtCreditEarned" CssClass="forminput" /></td>
        </tr>--%>

<span style="font-size: smaller; font-style: italic;">*** When the credit type 'Other' is selected, you have the option of entering a custom credit type. </span>
            <br />
            <asp:Label runat="server" id="lblError" CssClass="error" /><br />
        <asp:Button runat="server" ID="btnAddCredit" Text="Add Credit" Cssclass="formInput btn btn-ARESCblue btn-lg" style="width: 140px; height:30px; font-size:small" />

<%--        <tr>
        <td colspan="3">
        <span style="font-size: smaller; font-style: italic;">*** When the credit type 'Other' is selected, you have the option of entering a custom credit type. </span><br /><asp:Label runat="server" id="lblError" CssClass="error" /><br />
        <asp:Button runat="server" ID="btnAddCredit" Text="Add Credit" CssClass="formInput" /></td>
        </tr>
    </table>--%>
    <br /><br />

    <table role="presentation" style="border-collapse: collapse; border: solid 1px gray; width: 100%">
    <tr>
    <td> 

<asp:Label ID="StartDateLabel"
                  Text ="Start Date:  "
                  AssociatedControlID="txtStartDate"
                  runat="server">
       
       <asp:TextBox  
           ID="txtStartDate" runat="server" CssClass="formInput" />&nbsp;<asp:ImageButton
                    runat="server" ID="btnCalendar2" AlternateText="Calendar Button Start Date" ImageUrl="~/lib/img/buttons/calendar.png" />
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtStartDate"
                    PopupButtonID="btnCalendar2" />
           </asp:Label>    
         <asp:Label ID="EndDateLabel"
                  Text ="End Date: "
                  AssociatedControlID="txtEndDate"
                  runat="server">
       
       <asp:TextBox  
           ID="txtEndDate" runat="server" CssClass="formInput" />&nbsp;<asp:ImageButton
                    runat="server" ID="btnCalendar3" Alt="Calendar Button End Date" ImageUrl="~/lib/img/buttons/calendar.png" />
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtEndDate"
                    PopupButtonID="btnCalendar3" />
           </asp:Label>
                    &nbsp;<asp:Button runat="server" ID="btnGo" Text="Go" Cssclass="formInput btn btn-ARESCblue btn-lg" style="width: 50px; height:30px; font-size:small" /> &nbsp;
                    <asp:Button runat="server" ID="btnPrint" Text="Print" Cssclass="formInput btn btn-ARESCblue btn-lg" style="width: 50px; height:30px; font-size:small" />&nbsp;
                    <br /><asp:CheckBox 
            runat="server" ID="chkIncludeOffical" Text="Include Official Credits" /></td>
    </tr>
    <tr><td><asp:PlaceHolder runat="server" ID="pTableResults" /></td></tr>
    </table> 

<%--    <table style="border-collapse: collapse; border: solid 1px gray; width: 100%">
    <tr>
    <td> 
        
        <asp:Label ID="StartDatelabel"
        text="Start Date &nbsp;"
        AssociatedControlID="txtStartDate"
        runat="server"></asp:Label><asp:TextBox runat="server" ID="txtStartDate" CssClass="formInput" />&nbsp;<asp:ImageButton
                    runat="server" ID="btnCalendar2" alt="Start Date Calendar Button" ImageUrl="~/lib/img/buttons/calendar.png" />
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtStartDate"
                    PopupButtonID="btnCalendar2" /> - <asp:Label ID="EndDateLabel"
                        text="End Date:&nbsp;"
                        AssociatedControlID="txtEndDate"
                        runat="server"></asp:Label><asp:TextBox runat="server" ID="txtEndDate" CssClass="formInput" />&nbsp;<asp:ImageButton
                    runat="server" ID="btnCalendar3" alt="End Date Calendar Button" ImageUrl="~/lib/img/buttons/calendar.png" />
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtEndDate"
                    PopupButtonID="btnCalendar3" />&nbsp;<asp:Button runat="server" ID="btnGo" Text="Go" CssClass="formInput" /> &nbsp;
                    <asp:Button runat="server" ID="btnPrint" Text="Print" CssClass="formInput" />&nbsp;<asp:CheckBox 
            runat="server" ID="chkIncludeOffical" Text="Include Official Credits" /></td>
    </tr>
    <tr><td><asp:PlaceHolder runat="server" ID="pTableResults" /></td></tr>
    </table>--%>
    
    <asp:HiddenField runat="server" id="hiddenField" />
</asp:Content>
