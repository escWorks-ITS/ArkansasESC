<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"
    MasterPageFile="~/MasterPage.master" %>

<%@ Register TagPrefix="ucontrol" TagName="UploadFile" Src="~/lib/Controls/UploadFile.ascx" %>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="mainBody">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.5.8/slick.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.5.8/slick-theme.min.css" rel="stylesheet" />
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
    <div id="pageheader">
        <h1><span class="pageheadertxt">Welcome to Professional Development Online Registration</span></h1>
    </div>
    <div style="float: right; width: 786px; margin-bottom: 5px;">
        <div id="searchbox" style="background-color:#ffffff; border-color:#dbdbe2">
            <asp:Panel ID="Panel1" DefaultButton="btnSearch" runat="server">
                <h2><label for="Text1">Search by Session # or Keyword&nbsp;&nbsp;</label></h2><input type="text" name="findSession" id="Text1" />
                
                <asp:Button runat="server" ID="btnSearch" OnClientClick="FindSession();return false;"
                    Text="submit" />
                <br />
            </asp:Panel>
        </div>
    </div>
    <div style="float: right; width: 784px; border: 1px solid #dbdbe2;">
        <table border="0" cellpadding="0" cellspacing="0" style="background-color: #ffffff;">
            <tr>
                <td width="70%">
                    <table border="0" cellpadding="16" cellspacing="0" width="550px">
                        <tr>
                            <td colspan="2">
                                <div class="ad-items" id="divAdItems" runat="server" style="width: 450px; height: 300px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" width="100%">
                                <table>
                                    <tr>
                                           <a href="about/contact.aspx" style="text-decoration: underline; color: #000000;"><font
                                                size="3" color="#292568"><b>Welcome to Click & Learn, Education Service Center —</b></font></a>
                                            <br /> 

                                                <span style="font-size: 9pt;"> Region 19's web-based professional development registration and management center.  Through Click & Learn, you will be able to browse and register for professional development events, access your professional development records, complete evaluations and print certificates.  If you experience difficulty logging in, please contact the Events Management office at (915) 780-5055.
                                                    </span>
                                        <p></p>
                                        <td valign="top" width="100%">
                                            <a href="about/contact.aspx" style="text-decoration: underline; color: #000000;"><font
                                                size="3" color="#292568"><b>Registration Services</b></font></a>
                                            <br />
                                            <span style="font-size: 9pt;">If you are experiencing errors, having difficulties finding an event, or have registered with more than one email address, please call (915) 780-5055 or send an email to <a href="mailto:eventsmanagement@esc19.net">eventsmanagement@esc19.net</a>. </span>
                                        <p></p>
                                                 <a href="about/contact.aspx" style="text-decoration: underline; color: #000000;"><font
                                                size="3" color="#292568"><b>Cancellation Policy</b></font></a>
                                            <br />
                                            <span style="font-size: 9pt;">Cancellation requests will be considered on an individual basis and refunds are not guaranteed. Cancellation must be requested at least five business days prior to the workshop for a full refund. 
                                                No refunds are given for cancellations less than five business days prior to the workshop. Telephone requests for cancellations will not be accepted. 
                                                Districts/campuses are encouraged to substitute personnel if the person registered is unable to attend. 
                                                <p></p>
                                                Refund request must include your name, address, daytime phone number, the event number and session name. Please allow up to four weeks to process your refund. No refunds will be given on or after the first meeting date or for non-attendance.
                                                <p></p>
                                                Please email your cancellation request to <a href="mailto:eventsmanagement@esc19.net">eventsmanagement@esc19.net</a> or fax to (915) 780-5034. For additional questions and/or assistance please contact:  Events Management at (915) 780-5055.       
                                               </span>
                                             <br />
                                             <br />

                                             <font size ="3" color="#292568"><b><u>Photo/Media Release Disclaimer</b></u></font>
                                            <br />
                                            <span style="font-size: 9pt;">By registering you are consenting to the possibility of being photographed and/or recorded during this event for publications, news 
                                                                          releases, instructional materials, online and in other communications related to the mission of Education Service Center - Region 19 
                                                                          and/or the organizer of the session or event.  Upon registration and attendance, you acknowledge and agree to the terms contained in 
                                                                          the consent and release Education Service Center - Region 19 of any liability as related to any digital photography, video streaming, video 
                                                                          recordings, and/or print images published.
                                                <p></p>
                                                
                                               </span>


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
                    <h3>
                        <escWorks:UpcomingEvents runat="server" ID="UpcomingEvents1" ItemsToDisplay="10" />
                    </h3>
                </td>
            </tr>
        </table>
        <br />
    </div>
    <script type="text/javascript" src="lib/js/swfobject.js"> 
    </script>
</asp:Content>
