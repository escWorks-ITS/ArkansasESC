<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="session.aspx.cs" Inherits="catalog_session" Title="Untitled Page" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="Server"><a name="MainBody"></a>

    <script language="javascript" type="text/javascript">

        function OnClientOpenView() {
            var tooltip = $find("<%=radToolTipReviews.ClientID %>");
            tooltip.show();
        }

        function CloseToolTip() {
            var tooltip = Telerik.Web.UI.RadToolTip.getCurrent();
            if (tooltip) {
                tooltip.hide();
            }
        }
    </script>

    <asp:Label runat="server" ID="lblErrorMessage" CssClass="error" />
    <br />

    <div id="noSessionDetails" style="background-color: #FFFFFF; padding: 10px 5px 10px 5px;" >
        <div style="width: 100%; border-collapse: collapse;" runat="server" id="contentsTable" class="mainBody">
    </div>
    <div class="container">
           <div class="row">
            <div class="form-group col-xs-12 col-sm-12"> 
                <div>
                    <div>
                    <span style="padding-right: 10px;"><button type="button" onclick="javascript:history.back()" class="formInput btn btn-ARESCblue btn-lg" role="button" style="width: 130px; font-size:small" ToolTip="Click here to go to previous page.">Previous</button></span>
                    <button type="button" onclick="window.location.href='<%#ResolveUrl("~/search.aspx") %>'" class="formInput btn btn-ARESCblue btn-lg" role="button" style="width: 130px; font-size:small" ToolTip="Click here for new search.">New Search</button>    
                    </div>
                    <div style="clear: both;"></div>
                    </div>
                </div>
             </div>

        <div class="row">
            <div class="form-group col-xs-12 col-sm-12"> 
                <div>
                    <div>
                    <span ><asp:Button runat="server" ID="btnRegister" Cssclass="formInput btn btn-ARESCblue btn-lg" AlternateText="Register" Text="Register" Style="width: 130px; font-size:small; margin-right: 10px !important;" ToolTip="Click here to register." /></span>
                    <span ><asp:Button runat="server" ID="btnGroupRegister" Cssclass="formInput btn btn-ARESCblue btn-lg" AlternateText="Group Register" Text="Group Register" Style="width: 130px; font-size:small; margin-right: 10px !important;" ToolTip="Click here to group register." /></span>
                    <span ><asp:Button runat="server" ID="btnWaitingList" Cssclass="formInput btn btn-ARESCblue btn-lg" AlternateText="Waiting List" Text="Waiting List" Style="width: 130px; font-size:small; margin-right: 10px !important;" ToolTip="Click here to wait list." /></span>
                    <span ><asp:Button runat="server" ID="btnRemoveFromCart" Cssclass="formInput btn btn-ARESCblue btn-lg" AlternateText="Remove" Text="Remove From Cart" Style="width: 130px; font-size:small; margin-right: 10px !important;" ToolTip="Click here to remove from cart.." OnClientClick="localStorage.setItem('itemCount', parseInt(localStorage.getItem('itemCount') - 1));"/></span>

                    <span style="float:left; display:inline-block"><button type="button" id="btnShare" class="formInput btn btn-ARESCblue btn-lg" style="margin-right: 10px !important; width: 130px; font-size:small; color: white" onclick="window.open('<%#ResolveUrl("~/lib/collaboration/default.aspx") %>?url=<%# server %>catalog/session.aspx?session_id=<%=lblSessionID.Text %>&title=Session%20Detail&session_id=<%=lblSessionID.Text %>')" role="button">Share</button></span>
                    </div><br /><br />
                     <h2><asp:Label runat="server" ID="lblTitle" style="font-size:18px;" /></h2><br />
                
                    <div style="clear: both;"></div>
                    <asp:Panel runat="server" ID="panelRating" Visible="false" >                  
                    <telerik:RadRating ID="radRatingSession" runat="server" ItemCount="5" SelectionMode="Continuous"
                        Precision="Exact" ReadOnly="true" Skin="Default">
                    </telerik:RadRating>
                    <asp:LinkButton ID="btnOpenReview" CssClass="link btn btn-success btn-md btn-block" OnClientClick="OnClientOpenView();return false;"
                        runat="server"></asp:LinkButton>
                    <telerik:RadToolTip ID="radToolTipReviews" runat="server" ShowEvent="FromCode" HideEvent="FromCode"
                        TargetControlID="btnOpenReview" RelativeTo="Element" Skin="Default" Position="MiddleLeft"
                        OffsetX="-15" Animation="Slide">
                        <asp:Panel ID="panelDetailedReviews" runat="server">
                        </asp:Panel>
                        <asp:Button ID="btnCloseReview" class="btn btn-danger btn-md btn-block" OnClientClick="CloseToolTip();return false;" runat="server" Text="Close" />
                    </telerik:RadToolTip>
                </asp:Panel>
                <br />
              
                <asp:Label runat="server" ID="lblDescription" CssClass="mainBodyBig" /><br /><br />
                <asp:Label runat="server" ID="lblSuccessFactor" CssClass="mainBodyBig" />
                  
                </div>
            </div>
         </div>
    </div>
<div>
        <div class="row">
            <div class="form-group col-xs-12 col-sm-12"> 
                <div style="padding-left: 13px;">
                <h3><span style="font-size:18px;" >Important
                    <%# region4.escWeb.SiteVariables.ObjectProvider.SessionNameCapitalized %>
                    Information:</span></h3>
             
                <br />
                <div>
                    <asp:Label runat="server" ID="lblWebComments" CssClass="leftIndent mainBodyBig" />
                </div>
           
             </div>
           
               <div class="row">
        <div class="form-group col-xs-12 col-sm-12"> 
            
        <div class="sessionSummary">
           
                <div style="padding-left: 13px;">
                <asp:Label Cssclass="leftIndent" runat="server" ID="lblRegistrationStatus" />
                </div>
        </div>
        <br />

        </div>
    </div>
            </div>
</div>

        <div id="contentsTable1" runat="server">
        <div class="mainBody">
    <div class="row">
       <div class="form-group col-xs-12 col-sm-6 mainBodySmall">  

                <div style="padding-left: 13px;" class="mainBodyBig">
                <b>
                    <%# region4.escWeb.SiteVariables.ObjectProvider.SessionNameCapitalized %>
                    ID:</b><br />
                <asp:Label runat="server" class="mainBodyBig" ID="lblSessionID" />
                    </div>
        </div>
        <div class="form-group col-xs-12 col-sm-6 mainBodySmall">  
                <div style="padding-left: 13px;" class="mainBodyBig">
                <b>Credits Available: </b>
                <br />
                <asp:Label runat="server" ID="lblCredits" Cssclass="mainBodyBig" />
                    </div>
        </div>
      </div>


        <div class="row">
       <div class="form-group col-xs-12 col-sm-6 mainBodySmall">  

                <div style="padding-left: 13px;" class="mainBodyBig">
                <b>Seats Filled:</b><br />
                <asp:Label runat="server" ID="lblSeatsFilled" class="mainBodyBig" />
                    </div>
        </div>
        <div class="form-group col-xs-12 col-sm-6 mainBodySmall">  
                <div style="padding-left: 13px;" class="mainBodyBig">
                <b>Fee:</b><br />
                <asp:Label runat="server" ID="lblFee" class="mainBodyBig" />
                    </div>
        </div>
      </div>

           
        <div class="row">
       <div class="form-group col-xs-12 col-sm-6 mainBodySmall">  

                <div style="padding-left: 13px;" class="mainBodyBig">
                <b>Contact Person:</b><br />
                <asp:Label runat="server" ID="lblContactPerson" class="mainBodyBig" />
                    </div>
        </div>
        <div class="form-group col-xs-12 col-sm-6 mainBodySmall" class="mainBodyBig">  
                <div style="padding-left: 13px;">
                <b>Instructor(s):</b><br />
                <asp:Label runat="server" ID="lblInstructors" class="mainBodyBig" />
                </div>
        </div> 
        
    </div>

    <div class="row">
       <div class="form-group col-xs-12 col-sm-6 mainBodySmall">  

                <div style="padding-left: 13px;">
                <b><asp:Label runat="server" ID="lblAudience" CssClass="mainBody mainBodyBig" Text="Audiences:" /></b>&nbsp;<br />
                <asp:Label runat="server" ID="lblAudiences" CssClass="mainBodyBig" />
                    </div>
        </div>
        <div class="form-group col-xs-12 col-sm-6 mainBodySmall">  
                &nbsp;
        </div> 
        
    </div>

   <div class="form-group col-xs-12 col-sm-12 mainBodySmall">
            <asp:PlaceHolder runat="server" ID="pLocationPlaceHolder" />
   </div>
                
    <div class="row">
        <div class="form-group col-xs-12 col-sm-12 mainBodySmall">  
            <div>
                <escWorks:RecommendedEvents runat="server" ID="recommendedEvents" />
            </div>
        </div>
    </div>          

</div>
            </div>
 </div>
</div>
    <br />
    <br />

    <asp:Panel runat="server" ID="panelOnDemand" Visible="false">
        <i>This course is part of a series. Upon registering for this class, any other courses in the series will be added to your cart, and fees will be adjusted accordingly.
        </i>
    </asp:Panel>
<%--    <table style="width: 100%; border-collapse: collapse;" runat="server" id="contentsTable"
        class="mainBody">
        <tr valign="top">
            <td>
                <img runat="server" src="~/lib/img/buttons/previous.png" alt="Previous" onclick="javascript:history.back();" />
                <a runat="server" href="~/search.aspx">
                    <img runat="server" src="~/lib/img/buttons/newsearch.png" alt="New Search" border="0" /></a>
            </td>
            <td rowspan="2" valign="middle">
                <asp:ImageButton runat="server" ID="btnRegister" AlternateText="Register" />
                <asp:ImageButton runat="server" ID="btnGroupRegister" AlternateText="Group Regsiter" />
                <asp:ImageButton runat="server" ID="btnWaitingList" AlternateText="Waiting List" />
                <asp:ImageButton runat="server" ID="btnRemoveFromCart" AlternateText="Remove" />
                <br />
                <%# base.SharePageButton %>
                <br />
                <br />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="lblTitle" CssClass="mainBodyBold" /><br />
                <asp:Panel runat="server" ID="panelRating" Visible="false">
                    <telerik:RadRating ID="radRatingSession" runat="server" ItemCount="5" SelectionMode="Continuous"
                        Precision="Exact" ReadOnly="true" Skin="Default">
                    </telerik:RadRating>
                    <asp:LinkButton ID="btnOpenReview" CssClass="link" OnClientClick="OnClientOpenView();return false;"
                        runat="server"></asp:LinkButton>
                    <telerik:RadToolTip ID="radToolTipReviews" runat="server" ShowEvent="FromCode" HideEvent="FromCode"
                        TargetControlID="btnOpenReview" RelativeTo="Element" Skin="Default" Position="MiddleLeft"
                        OffsetX="-15" Animation="Slide">
                        <asp:Panel ID="panelDetailedReviews" runat="server">
                        </asp:Panel>
                        <asp:Button ID="btnCloseReview" OnClientClick="CloseToolTip();return false;" runat="server" Text="Close" />
                    </telerik:RadToolTip>
                </asp:Panel>
                <br />
                <asp:Label runat="server" ID="lblDescription" CssClass="mainBodySmall" /><br />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <b>Important
                    <%# region4.escWeb.SiteVariables.ObjectProvider.SessionNameCapitalized %>
                    Information:</b><br />
                <br />
                <asp:Label runat="server" ID="lblWebComments" CssClass="mainBody" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="sessionSummary">
                <asp:Label runat="server" ID="lblRegistrationStatus" />
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="mainBody" id="contentsTable1" runat="server">
        <tr>
            <td>
                <b>
                    <%# region4.escWeb.SiteVariables.ObjectProvider.SessionNameCapitalized %>
                    ID:</b><br />
                <asp:Label runat="server" ID="lblSessionID" />
            </td>
            <td>
                <b>Credits Available: </b>
                <br />
                <asp:Label runat="server" ID="lblCredits" />
            </td>
            <td rowspan="3" align="right" valign="top">
                <escWorks:RecommendedEvents runat="server" ID="recommendedEvents" />
            </td>
        </tr>
        <tr>
            <td>
                <b>Seats Filled:</b><br />
                <asp:Label runat="server" ID="lblSeatsFilledlblSeatsFilled" />
            </td>
            <td>
                <b>Fee:</b><br />
                <asp:Label runat="server" ID="lblFee" />
            </td>
        </tr>
        <tr>
            <td>
                <b>Contact Person:</b><br />
                <asp:Label runat="server" ID="lblContactPerson" />
            </td>
            <td>
                <b>Instructor(s):</b><br />
                <asp:Label runat="server" ID="lblInstructors" />
            </td>
        </tr>
          <tr>
            <td colspan="2">
                <b><asp:Label runat="server" ID="lblAudience" CssClass="mainBody" Text="Audiences:" /></b>&nbsp;
                <asp:Label runat="server" ID="lblAudiences" />
            </td>
            </tr>
    </table>
    <asp:PlaceHolder runat="server" ID="pLocationPlaceHolder" />--%>
</asp:Content>
