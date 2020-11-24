<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cancel.aspx.cs" Inherits="shoebox_registration_cancel" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ContentPlaceHolderID="mainBody"><a name="MainBody"></a>
    <span style="padding-right: 10px;"><button type="button" onclick="javascript:history.back()" class="formInput btn btn-ARESCblue btn-lg" role="button" style="width: 130px; font-size:small" ToolTip="Click here to go to previous page.">Previous</button></span>
    <br /><br />

<asp:Panel runat="server" ID="pCancelDetails" Visible="true">

<div class="container">
  <div class="row">
    <div class="form-group col-xs-12 col-sm-12" >  
        <span style="font-size: 14px;">This is the registration cancellation page.  Please read the message below before continuing.</span>
    </div>
  </div>

<%--<br /><br />
This is the registration cancellation page.  Please read the message below before continuing.
<br />
<br />--%>

<div class="row">
    <div class="form-group col-xs-12 col-sm-12" >  
        <span style="font-size: 14px;">You are currently registered for:</span>
    </div>
</div>

<%--You are currently registered for:
<br /><br />--%>
<div style="width: 99%; background-color: #f5f5f5; border: solid 1px gray">
<%--<div style="width: 75%; background-color: #f5f5f5; border: solid 1px gray">--%>
<asp:Label runat="server" ID="lblTitle" cssClass="mainBodyBold" />
<br />
<asp:Label runat="server" ID="lblDescription" cssClass="mainBodySmall" />
<br />
<b><%# region4.escWeb.SiteVariables.ObjectProvider.SessionNameCapitalized %> ID:</b> <asp:Label runat="server" ID="lblSessionID" />
<br />
<b>Fee:</b> <asp:Label runat="server" ID="lblFee" />
<br />
<b>Start Date: </b><asp:Label runat="server" ID="lblStartDate" />
<br />
<b>Location:</b> <asp:Label runat="server" ID="lblLocation" />
<br />
<br />

</div>
<br /><br />

<div class="row">
    <div class="form-group col-xs-12 col-sm-12" > 
        <span style="font-size: 14px;">By clicking on 'Cancel Registration', you will be removed from the <%# region4.escWeb.SiteVariables.ObjectProvider.SessionName %> listed above. 
        Depending on your payment status and the number of days before this <%# region4.escWeb.SiteVariables.ObjectProvider.SessionName %>, you maybe eligible for a refund.
        For more information please contact Registration Services.</span>
    </div>
</div>

<%--By clicking on 'Cancel Registration', you will be removed from the <%# region4.escWeb.SiteVariables.ObjectProvider.SessionName %> listed above. 
Depending on your payment status and the number of days before this <%# region4.escWeb.SiteVariables.ObjectProvider.SessionName %>, you maybe eligible for a refund.
For more information please contact Registration Services.--%>
<br />
<%--<br />--%>

<div class="row">
        <div class="col-xs-12 col-sm-4">

            <asp:Button runat="server" ID="btnSubmit" Text="Cancel Registration" CssClass="btn btn-ARESCblue btn-lg" Style="width: 160px; font-size:small" ToolTip="Click here to cancel registration." />
            <%--<asp:Button runat="server" ID="btnSubmit" Text="Cancel Registration" CssClass="formInput" />--%> 

        </div>
        <div class="col-xs-12 col-sm-4"></div>
        <div class="col-xs-12 col-sm-4">  
            <input type="button" onclick="javascript: history.back()" title="Click here to go to previous page" value="Previous Page" class="btn btn-ARESCgrey btn-lg" style="width: 160px; font-size:small" />              
         </div> 
    </div>
</div>

<%--<asp:Button runat="server" ID="btnSubmit" Text="Cancel Registration" 
        CssClass="formInput" /> <input type="button" 
        onclick="javascript:history.back()" title="Previous Page" value="Previous Page" 
        class="formInput" />--%>
</asp:Panel>

<asp:Panel runat="server" ID="pUnavailable" Visible="false">
The cancellation period for this session has passed.
<br />
<a class="link" onclick="javascript:history.back()">Click here</a> to return to the previous page.
</asp:Panel>

<asp:Panel runat="server" ID="pSuccess" Visible="false">
<br /><br />
<span style="font-size: 14px;"><b>You have been successfully removed from:</b></span>
<%--You have been successfully removed from:--%>
<br /><br />
<span style="font-size: 14px;"><b>Title: </b> <asp:Label runat="server" ID="lblTitle2" /></span>
<%--<b>Title: </b> <asp:Label runat="server" ID="lblTitle2" />--%>
<br />
<span style="font-size: 14px;"><b><%# region4.escWeb.SiteVariables.ObjectProvider.SessionNameCapitalized %> ID:</b> <asp:Label runat="server" ID="lblSessionId2" /></span>
<%--<b><%# region4.escWeb.SiteVariables.ObjectProvider.SessionNameCapitalized %> ID:</b> <asp:Label runat="server" ID="lblSessionId2" />--%>
<br />
<span style="font-size: 14px;"><b>Start Date:</b> <asp:Label runat="server" ID="lblStartDate2" /></span>
<%--<b>Start Date:</b> <asp:Label runat="server" ID="lblStartDate2" />--%>
<br />
<span style="font-size: 14px;"><b>Location: </b> <asp:Label runat="server" ID="lblLocation2" /></span>
<%--<b>Location: </b> <asp:Label runat="server" ID="lblLocation2" />--%>
<br />
<br />
<div class="row">
        <div class="col-xs-12 col-sm-3">
            <button type="button" onclick="window.location.href='<%#ResolveUrl("~/shoebox/registration/default.aspx") %> '" class="formInput btn btn-ARESCblue btn-lg" style="width: 140px; font-size:small" >Next</button>
        </div>
        <div class="col-xs-12 col-sm-9"></div>
</div>
<%--<a id="A1" runat="server" href="~/shoebox/registration/default.aspx"><img id="Img1" runat="server" style="border: none;" src="~/lib/img/buttons/next.png" alt="Return to Registration Summary" /></a>--%>
<br />
</asp:Panel>

<asp:Panel runat="server" ID="pError" Visible="false">
An error occurred while processing your request.
<br /><br />
<a class="link" onclick="javascript:history.back()">Click here</a> to return to the previous page.
</asp:Panel>

</asp:Content>
