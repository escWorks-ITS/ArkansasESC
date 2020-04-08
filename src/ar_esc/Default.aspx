    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"
    MasterPageFile="~/MasterPage.master" %>

<%@ Register TagPrefix="ucontrol" TagName="UploadFile" Src="~/lib/Controls/UploadFile.ascx" %>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="mainBody">

    <link href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.5.8/slick.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.5.8/slick-theme.min.css" rel="stylesheet" />
    <%-- <link type="text/css" rel="stylesheet" href="lib/css/escWorksStyle.css" />--%>
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
   <%-- <div id="pageheader">
        <span class="pageheadertxt">Welcome to Professional Development Online Registration</span>
    </div>--%>

    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color:<%# logoSpaceColor %>">
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
    </table>


    <div style="float: right; width: 784px; margin-bottom: 5px;">
        <div id="searchbox">
            <asp:Panel ID="Panel1" DefaultButton="btnSearch" runat="server">
             <label for="Text1" style="font-weight: bold; font-size: 1.3em;">Search by Session # or Keyword&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label><input type="text" name="findSession" id="Text1" />
                
                <asp:Button runat="server" ID="btnSearch" OnClientClick="FindSession();return false;"
                    Text="submit" />
                <br />
            </asp:Panel>
        </div>
    </div>
    <div style="float: right; width: 784px; border: 1px solid #999;">
        <table border="0" cellpadding="0" cellspacing="0"  width="100%" style="background-color:<%# flashBackgroundColor %>"><%-- style="background-color: #e5e5e5;">--%>
            <tr>
                <td valign="top" width="70%">
                    <table border="0" cellpadding="16" cellspacing="0" width="550px">
                        <tr>
                            <td colspan="2"> <%----valign="top">--%>
                                 
                                <%--<iframe frameborder="0" width="450" height="300" id="iFrameBanner" src="swf_files/advertisement.html">
                                </iframe>--%>
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
    </div>
    <script type="text/javascript" src="lib/js/swfobject.js"> 
    </script>
</asp:Content>

