<%@ Page Language="C#" AutoEventWireup="true" CodeFile="email.aspx.cs" Inherits="shoebox_account_email" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ContentPlaceHolderID="mainBody"><a name="MainBody"></a>
        <span style="padding-right: 10px;"><button type="button" onclick="javascript:history.back()" class="formInput btn btn-ARESCBlue btn-lg" role="button" style="width: 130px; font-size:small" ToolTip="Click here to go to previous page.">Previous</button></span>
    <br /><br />
<asp:Panel runat="server" ID="pStep1">
<div class="row">
    <div class="col-xs-12 col-sm-12">
    <span style="font-size:small">If your email address needs to be changed provide your old email address and password to specify a new email address.</span>
</div>
</div>
<br />
    <div class="row">
        <div class="col-xs-12 col-sm-6">
            <asp:Label ID="CurrentEmailLabel"
            text="Current Email Address:"
            AssociatedControlID="txtEmailAddress"
            runat="server"></asp:Label><br />
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12 col-sm-6">
            <asp:TextBox runat="server" ID="txtEmailAddress"
                    CssClass="mediumFont fullWidth" style="height: 28px" />
        </div>
    </div>
<br />
    <div class="row">
        <div class="col-xs-12 col-sm-6">
            <asp:Label ID="NewEmail1Label"
                text="New Email Address:"
                AssociatedControlID="txtNewEmail"
                runat="server"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12 col-sm-6">
            <asp:TextBox runat="server" ID="txtNewEmail" CssClass="mediumFont fullWidth" height="28px" />
        </div>
    </div>
<br />
<div class="row">
    <div class="col-xs-12 col-sm-6">
        <asp:Label ID="ConfirmNewEmailLabel"
        text="Confirm Email Address:"
        AssociatedControlID="txtNewEmail2"
        runat="server"></asp:Label>
    </div>
</div>
<div class="row">
    <div class="col-xs-12 col-sm-6">
        <asp:TextBox runat="server" ID="txtNewEmail2" CssClass="mediumFont fullWidth" height="28px" />
    </div>
</div>
<br />
<asp:Label runat="server" id="lblError" CssClass="error" />
<div class="row">
    <div class="col-xs-12 col-sm-2">
        <asp:Button Cssclass="formInput btn btn-ARESCBlue btn-lg" runat="server" ID="btnSubmit" Text="Submit" 
            Style="width: 170px; font-size:small" ToolTip="Click here to submit." />
    </div>
</div>
</asp:Panel>
<asp:Panel runat="server" ID="pStep2" Visible="false">
You have successfully saved the changes to your account!<br /><a id="A1" href="~/default.aspx" runat="server" class="link">Please click here to continue</a>
</asp:Panel>
</asp:Content>

