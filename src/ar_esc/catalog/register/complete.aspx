<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="complete.aspx.cs" Inherits="catalog_register_complete" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" Runat="Server"><a name="MainBody"></a>
    <span style="padding-right: 10px;"><button type="button" onclick="javascript:history.back()" class="formInput btn btn-ARESCblue btn-lg" role="button" style="width: 130px; font-size:small" ToolTip="Click here to go to previous page.">Previous</button></span>
    <br /><br />
<div class="container-fluid">
    <div class="row">
        <div class="col-12 col-sm-12">
            <span style="font-size:16px;"><b>Thank you for your registration</b></span>
        </div>
    </div>
<%--<h1 class="heading">Thank you for your registration</h1>--%>
<br />
    <div class="row">
        <div class="col-12 col-sm-12">
            <span style="font-size:14px;">You have been registered for:</span>
        </div>
    </div>
    <br />
<%--You have been registered for:--%>
    <div class="row">
        <div class="col-xs-12 col-sm-12">
            <table role="presentation" runat="server" id="registrationTable" />
        </div>
    </div>
<%--<table runat="server" id="registrationTable" />--%>
<br />

    <div style="padding-left: 12px;">
    <div class="row">
        <div class="col-12 col-sm-12" style="padding-left : 0">
            <span style="font-size:14px;">You may visit your </span><a href="~/shoebox/registration/default.aspx" runat="server" class="link smallFont">Registration History</a><span style="font-size:14px;"> to print a confirmation page for each <%# Resources.Names.Session %> for which you are registered.</span>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-12 col-sm-12" style="padding-left : 0">
            <asp:Panel runat="server" ID="panelPaymentVoucher">
                <span style="font-size:14px;">If you are paying by PO, TR or ISR please include the payment voucher with your payment.  You can download the payment voucher by clicking <a runat="server" id="aVoucher" style="color: #0000FF;">here</a></span>
            </asp:Panel>
        </div>
    </div>
    </div>

<%--You may visit your <a href="~/shoebox/registration/default.aspx" runat="server" class="link">Registration History</a> to print a confirmation page for each <%# Resources.Names.Session %> for which you are registered.
<br /><br />
<asp:Panel runat="server" ID="panelPaymentVoucher">
If you are paying by check, money order, or purchase order please include the payment voucher with your payment.  You can download the payment voucher by clicking <a runat="server" id="aVoucher">here</a>
</asp:Panel>--%>

</asp:Content>

