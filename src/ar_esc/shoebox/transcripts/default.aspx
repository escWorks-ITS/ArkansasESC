<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="shoebox_transcripts_default"
    MasterPageFile="~/MasterPage.master" EnableEventValidation="false" %>

<asp:Content runat="server" ContentPlaceHolderID="mainBody"><a name="MainBody"></a>
    <span style="padding-right: 10px;"><button type="button" onclick="javascript:history.back()" class="formInput btn btn-ARESCblue btn-lg" role="button" style="width: 130px; font-size:small" ToolTip="Click here to go to previous page.">Previous</button></span>
    <br /><br />
    <table role="presentation" border="0" width="100%">
        <tr>
            <td>
                Transcripts allow you to track the amount of credit you have received from professional
                development
                <%# region4.escWeb.SiteVariables.ObjectProvider.SessionPluralName %>
                at
                <%# region4.escWeb.SiteVariables.customer_name %>. All of this data is aggregated
                into a printable format that can be used as proof of credit.
                <br />
                <br />
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="30" rowspan="8" nowrap>
                        </td>
                        <td width="300" valign="top">
                            <b>Official Record</b>
                            <br />
                            <span class="smallestFont" style="color: black !important">An official transcript cannot be altered. It contains
                                a record of the
                                <%# region4.escWeb.SiteVariables.ObjectProvider.SessionPluralName%>
                                that you have attended at
                                <%# region4.escWeb.SiteVariables.customer_name %>. </span>
                            <br />
                            <br />
                            <asp:PlaceHolder ID="pOfficial" runat="Server"><span class="smallestFont">Year of Record:</span><br>
<%--                                <asp:DropDownList ID="ddOfficialYear" runat="server" CssClass="DropDownList">
                                </asp:DropDownList>--%>
                                <asp:DropDownList ID="ddOfficialYear" runat="server" CssClass="form-control fullWidth smallFont" style="height: 28px">
                                </asp:DropDownList>
                                &nbsp;&nbsp;
                                <br /><asp:Button ID="btnOfficialTranscript" runat="Server" Text="Go" CssClass="formInput btn btn-ARESCblue btn-lg"
                                Style="width: 170px; font-size:small" ToolTip="Click here to go to official transcript."></asp:Button>
                                    <%--<asp:Button ID="btnOfficialTranscript" runat="Server" Text="Go" CssClass="Button"--%>
                                    <%--Style="width: 40px;"></asp:Button>--%>
                            </asp:PlaceHolder>
                            <asp:PlaceHolder ID="pOfficialFailure" runat="Server"><span class="smallestFont" style="color: #363636">
                                <i>There are not currently any credits on file for you. Therefore, your official transcript
                                    cannot be viewed at this time. </i></span></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr>
                        <td width="300" height="8">
                            <img src="/global/img/trans.gif" alt="" height="8" border="0" />
                        </td>
                    </tr>
                    <tr>
                        <td width="300" height="1" bgcolor="#cccccc" background="/global/img/dash_h.gif">
                            <img src="/global/img/trans.gif" alt="" height="1" border="0" />
                        </td>
                    </tr>
                    <tr>
                        <td width="300" height="8">
                            <img src="/global/img/trans.gif" alt="" height="8" border="0" />
                        </td>
                    </tr>
                    <tr>
                        <td width="300" valign="top">
                            <b>Personal Record</b>
                            <br>
                            <span class="smallestFont" style="color: black !important">A personal transcript can be altered. It contains a record
                                of
                                <%# region4.escWeb.SiteVariables.ObjectProvider.SessionPluralName%>
                                that you have attended at
                                <%# region4.escWeb.SiteVariables.customer_name %>
                                as well as events that you have entered. This transcript is managed online.
                            </span>
                            <br />
                            <br />
                            <asp:Button ID="btnPersonalTranscript" runat="Server" Text="Manage Personal Record" CssClass="formInput btn btn-ARESCblue btn-lg"
                                Style="width: 170px; font-size:small" ToolTip="Click here to manage your personal transcript.">
                            </asp:Button>
<%--                            <asp:Button ID="btnPersonalTranscript" runat="Server" Text="Manage Transcript" CssClass="formInput"
                                Style="width: 150px;" ToolTip="Click here to manage your personal transcript.">
                            </asp:Button>--%>
                        </td>
                    </tr>
                    <tr>
                        <td width="300" height="8">
                            <img src="/global/img/trans.gif" alt="" height="8" border="0" />
                        </td>
                    </tr>
                    <tr>
                        <td width="300" height="1" bgcolor="#cccccc" background="/global/img/dash_h.gif">
                            <img src="/global/img/trans.gif" alt="" height="1" border="0" />
                        </td>
                    </tr>
                </table>
                <table role="presentation" border="0" cellpadding="5" width="100%">
                    <tr>
                        <td width="65%">
                            <i>Portfolio uses Adobe Acrobat&nbsp;&reg; to produce your transcript. If you do not
                                have Adobe Acrobat Reader&nbsp;&reg; installed on your computer, you will need to
                                download a version (free of charge) from <a href="http://www.adobe.com/" target="_blank"
                                    class="PageLink">Adobe</a>. </i>
                        </td>
                        <td nowrap>
                            <a href="http://www.adobe.com/products/acrobat/readstep2.html" target="_blank">
                                <img src="../../lib/img/adobe.gif" border="0" alt="Click here to download the latest version of Adobe Acrobat Reader."
                                    align="left" hspace="12" /></a>
                            <br />
                            <a href="http://www.adobe.com/products/acrobat/readstep2.html" target="_blank" class="PageLink">
                                Click here to download<br />
                                Abobe Acrobat Reader &reg;.</a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
