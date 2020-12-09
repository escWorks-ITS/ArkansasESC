    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"
    MasterPageFile="~/MasterPage.master" %>

<%@ Register TagPrefix="ucontrol" TagName="UploadFile" Src="~/lib/Controls/UploadFile.ascx" %>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="mainBody"><a name="MainBody"></a>

    <%--<link href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.5.8/slick.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.5.8/slick-theme.min.css" rel="stylesheet" />--%>
     <link type="text/css" rel="stylesheet" href="lib/css/escWorksStyle.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.5.8/slick.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.ad-items').slick({
                slidesToShow: 1,
                slidesToScroll: 1,
                autoplay: true,
                autoplaySpeed: 4000
            });
        });
    </script>

    <script language="javascript" type="text/javascript">
        if (typeof String.prototype.trim != 'function') { // detect native implementation
            String.prototype.trim = function () {
                return this.replace(/^\s+/, '').replace(/\s+$/, '');
            };
        }

        function FindSession() {
            var mSession = document.aspnetForm.findSession.value.trim();

            if (mSession.length < 1) {
                alert("Please type " + '<%# region4.escWeb.SiteVariables.ObjectProvider.SessionName %>' + " ID or Keyword");
                document.aspnetForm.findSession.focus();
                return;
            }
            if (isNaN(mSession))
                top.location.href = "search.aspx?SearchCriteria=" + mSession;
            else
                top.location.href = "./catalog/session.aspx?session_id=" + mSession;
        }
    </script>
    <br />

<%--    <div class="row">
        <div class="col-xs-12 col-lg-12 sidenav">
            <div id="pageheader" style="background-color: <%# sloganBackgroundColor %> !important;">
                <span id="headerFont">Welcome to Professional Development Online Registration</span>                 
            </div>
        </div>
    </div>--%>

<%--    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color:<%# logoSpaceColor %>">
        <tr>
            <td width="70%" height="1px" valign="top" style="background-color:<%# sloganBackgroundColor %>;">
                <table border="0" cellpadding="12" cellspacing="0" style="height:1px">
                    <tr>
                        <td colspan="2" style="background-color: <%# sloganBackgroundColor %>;">
                            <font size="4" color="<%# sloganFontColor %>"><b><%# textLine1 %>
                                <br />
                            </b></font><font color="<%# sloganFontColor %>" size="4"><b><%# textLine2 %></b></font>
                        </td>
                    </tr>
                </table>
               </td>
        </tr>
    </table>--%>


<%--<div id="searchbox">--%>
        <asp:Panel ID="Panel1" DefaultButton="btnSearch" runat="server">
<div class="container">

    <div class="row">
        <div class="col-xs-12 col-lg-12 sidenav">
            <div id="pageheader" style="background-color: <%# sloganBackgroundColor %> !important;">
                <span id="headerFont">Welcome to Professional Development Online Registration</span>                 
            </div>
        </div>
    </div>
<div id="searchBox2" style="border: 1px solid black;">
<div class="row">
    <div class="col-xs-12 col-sm-12">
        <span id="searchText" style="font-weight: bold; font-size: 1.3em; padding-left: 20px;"><label for="findSession">Search by Session ID or Keyword</label></span>     
    </div>
</div>
    <div class="row">
        <div class="col-xs-1 col-sm-8">
            <input type="text" name="findSession" id="findSession" class="form-control fullWidth smallFont" style="height:32px; margin-left: 20px !important;"/>
        </div>   
        <div class="col-xs-2 col-sm-3">
            <div style="padding-left: 20px;"><asp:Button runat="server" ID="btnSearch" OnClientClick="FindSession();return false;" Text="Search" CssClass="formInput btn btn-ARESCblue btn-lg" Style="width: 110px; font-size:small; background-color: #0275d8; color: white;" /></div>
        </div>       
    </div>
    <br />
</div>
</div>
</asp:Panel>
<%--</div>--%>
    <br />
<%--    <div style="float: right; width: 784px; margin-bottom: 5px;">
        <div id="searchbox">
            <asp:Panel ID="Panel1" DefaultButton="btnSearch" runat="server">
             <label for="Text1" style="font-weight: bold; font-size: 1.3em;">Search by Session # or Keyword&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label><input type="text" name="findSession" id="Text1" />
                
                <asp:Button runat="server" ID="btnSearch" OnClientClick="FindSession();return false;"
                    Text="submit" />
                <br />
            </asp:Panel>
        </div>
    </div>--%>

            <div class="container" style="border: 1px solid black; margin-left: -30px !important; width:102%">
            <div class="row" style="background-color: #ebebeb;">
                <div class="col-sm-12 col-lg-8 text-left">
                    <label id="slick-slide00"><span style="display:none">Aria</span></label> 
                    <label id="slick-slide01"><span style="display:none">Aria</span></label> 
                    <label id="slick-slide02"><span style="display:none">Aria</span></label> 
                    <label id="slick-slide03"><span style="display:none">Aria</span></label> 
 
                    <div class="ad-items" id="divAdItems" runat="server" style="width: 500px; height: 300px">
                    </div>
<%--                        <a href="about/contact.aspx" style="text-decoration: none; color: #000000;"><font size="3" color="#cb2027"><b>CONTACT US</b></font></a>
                        <br /> --%>
                    <a href="about/contact.aspx" style="text-decoration: underline; color: #C80032;"><font
                                                size="3" color="#C80032"><b>Contact Us</b></font></a>

                    <%--<a href="about/contact.aspx" style="text-decoration: underline; color: #C80032;"><font size="3" color="#C80032"><b>Registration Services</b></font></a>--%>
                    <br />
                    <span style="font-size: 9pt;">Contact us if you have questions regarding upcoming
                                                <%# region4.escWeb.SiteVariables.ObjectProvider.SessionPluralName %>
                                                or questions about this website.</span>
                    <%--<span style="font-size: 11pt;">For assistance please contact our Staff Development department at (936) 435-8295
                                                 or send an email to <a style="color: #11347D;" href="mailto:kcook@esc6.net">kcook@esc6.net</a>.  For Driver Education assistance please call (936) 435-8321.</span>--%>


                    <br />
                         <div>
                                <ucontrol:UploadFile ID="UploadFile1" runat="server" />
                        </div>                   
                    </div>


                <div class="col-sm-12 col-lg-4" style="float:right; border-left: 0 1px 1px 1px solid black; background-color:<%# upcomingBackgroundColor %>;">
                            <div><h3 style="line-height:1.6;">
                                <br />
                            <escWorks:UpcomingEvents runat="server" ID="UpcomingEvents1" ItemsToDisplay="9" />
                            </h3></div>

                    </div>

<%--    <div style="float: right; width: 784px; border: 1px solid #999;">
        <table border="0" cellpadding="0" cellspacing="0"  width="100%" style="background-color:<%# flashBackgroundColor %>"><%-- style="background-color: #e5e5e5;">
            <tr>
                <td valign="top" width="70%">
                    <table border="0" cellpadding="16" cellspacing="0" width="550px">
                        <tr>
                            <td colspan="2">
                                 
                                 <div class="ad-items" id="divAdItems" runat="server" style="width: 500px; height: 362px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" width="100%">
                                <table>
                                    <tr>
                                        <td valign="top" width="100%">
                                            <a href="about/contact.aspx" style="text-decoration: underline; color: #C80032;"><font
                                                size="3" color="#C80032"><b>Contact Us</b></font></a>
                                            <br />
                                            <span style="font-size: 9pt;">Contact us if you have questions regarding upcoming
                                                <%# region4.escWeb.SiteVariables.ObjectProvider.SessionPluralName %>
                                                or questions about this website.</span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <ucontrol:UploadFile ID="UploadFile1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="30%"  style ="background-color:<%# upcomingBackgroundColor %>;" valign="top">
                    <br />
                    <escWorks:UpcomingEvents runat="server" ID="UpcomingEvents1" ItemsToDisplay="9" />
                </td>
            </tr>
        </table>
        <br />
    </div>--%>
                        </div>
            </div>


    <br />
    <script type="text/javascript" src="lib/js/swfobject.js"> 
    </script>
</asp:Content>

