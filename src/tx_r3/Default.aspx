<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"
    MasterPageFile="~/MasterPage.master" %>

<%@ Register TagPrefix="ucontrol" TagName="UploadFile" Src="~/lib/Controls/UploadFile.ascx" %>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="mainBody">
   
    <%-- <link href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.5.8/slick.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.5.8/slick-theme.min.css" rel="stylesheet" />--%>
      <link type="text/css" rel="stylesheet" href="~/lib/css/escWorksStyle.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.5.8/slick.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.ad-items').slick({
                slidesToShow: 1,
                slidesToScroll: 1,
                autoplay: true,
                autoplaySpeed: 3000
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
    <div style="float: right; width: 784px; margin-bottom: 5px;">
        <div id="searchbox">
            <asp:Panel ID="Panel1" DefaultButton="btnSearch" runat="server">
                <h2>
                    <label for="Text1"> Search by Session ID or Keyword </label>
                </h2>
                <input type="text" name="findSession" id="Text1" />
                <asp:Button runat="server" ID="btnSearch" OnClientClick="FindSession();return false;"
                    Text="submit" />
                <br />
            </asp:Panel>
        </div>
    </div>
    <div style="float: right; width: 784px; border: 1px solid #f0f0f0;">
        <table border="0" cellpadding="0" cellspacing="0" style="background-color: #f0f0f0;">
            <tr>
                <td width="70%">
                    <table border="0" cellpadding="16" cellspacing="0" width="550px">
                        <tr>
                            <td colspan="2">
                               <%-- <iframe frameborder="0" width="450" height="300" id="iFrameBanner" src="swf_files/TX_R3.html">
                                </iframe>--%>
                                <div class="ad-items" id="divAdItems" runat="server" style="width: 500px; height: 300px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" width="100%">
                                <table>
                                    <tr>
                                        <td valign="top" width="100%">
                                            <a href="about/contact.aspx" style="text-decoration: underline; color: #8eaa43;"><font
                                                size="3" color="#8eaa43"><b>Contact Us</b></font></a>
                                            <br />
                                            <span style="font-size: 9pt;">If you have any questions regarding upcoming sessions,
                                                please email or call the contact name listed for the session. For all other inquires
                                                or questions regarding this website, <a href="about/contact.aspx">please continue here</a>.</span>
                                            <br />
                                            <br />
                                            <span style="color: #8eaa43;">
                                                <h1>
                                                    Cancellation Policy</h1>
                                            </span>
                                            <br />
                                            <span  style="font-size: 10pt;">Cancellations must be completed online or sent to <a
                                                href="mailto:cancellations@esc3.net">cancellations@esc3.net</a> no later than 7
                                                calendar days prior to event for a refund. Phone cancellations are not accepted.
                                                To help expedite your request, please include the session number or event title and date. 
                                                Registrations are transferrable. A processing fee of 25% of the registration cost
                                                will be applied to the refund. Sessions with a fee of less than $35 will be charged
                                                the full session fee. No refunds for online courses, nonattendance, or late cancellations
                                                submitted one to six calendar days prior to the event. Participants will receive
                                                a full refund for events cancelled by Region 3.</span>
                                               <br />
                                               <br />
                                            <span style="font-size: 10pt;"><i> Thank you for choosing Region 3 ESC for your professional development needs.  
                                                Please plan to attend the training in its entirety and conduct yourself in a professional manner at all times. 
                                                We ask that during your time at Region 3 you do not bring children to the building. 
                                                We have the right to ask that you leave the session if you do not adhere to all rules.  Thank you.</i> </span>
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
                <td valign="top">
                    <br />
                    <escWorks:UpcomingEvents runat="server" ID="UpcomingEvents1" ItemsToDisplay="10" />
                </td>
            </tr>
        </table>
        <br />
    </div>
    <script type="text/javascript" src="lib/js/swfobject.js"> 
    </script>
</asp:Content>
