<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="lib_collaboration_default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en-us" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Share a Page</title>
    <script src='https://www.google.com/recaptcha/api.js' type="text/javascript" async defer></script>
    <meta name="viewport" content="width=device-width, initial-scale=1">

      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxc
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
        <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>

<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" 
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <link href="../../Content/screen1004.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/screen768.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/screen480.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/screen320.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript">
    function Page_OnInit() {
        resizeTo(350, 650);
    }
</script>
<body onload="Page_OnInit();">
    <br />
    <span style="padding-right: 10px;"><button type="button" onclick="window.close();" class="formInput btn btn-ARESCblue btn-lg" role="button" style="width: 130px; font-size:small" ToolTip="Click here to go to previous page.">Previous</button></span>
    <br /><br />
    <div style="padding-left: 10px">
    <form id="form1" runat="server">

    <div class="container-fluid">      
    <div class="row">
    <div class="col-12 col-sm-3">
        <img src="../../lib/standard/img/trans.gif" border="0" height="1" alt="Transparent Gif" />     
    </div>  
        
    <div class="row"> 
        <div class="col-12 col-sm-3">
            <img src="../../lib/standard/img/trans.gif" border="0" height="4" alt="Transparent Gif" />     
        </div>   
    </div>


        <%--<div>
            <table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
                <tr>
                    <td colspan="2" height="1" bgcolor="#191970">
                        <img src="../../lib/standard/img/trans.gif" border="0" height="1" alt="Transparent Gif" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="4" bgcolor="#ffffff">
                        <img src="../../lib/standard/img/trans.gif" border="0" height="4" alt="Transparent Gif" />
                    </td>
                </tr>--%>

        <div class="row"> 
            <div class="col-12 col-sm-3">
                <div style="background-color:#ffffff">&nbsp;<img src="../../lib/standard/img/share.gif" width="32" height="32" alt="" border="0"
                        align="middle" /> 
                </div>
            <%--</div>--%>   
            <%--<div class="col-12 col-sm-12">--%>
                <div style="background-color:#ffffff">
                        <span style="color: #191970; font-weight: bold; font-size: 14pt;">Collaboration: Share
                        a page</span><br />
                        <span style="font-size: 12pt;">Share a resource with a colleague or friend.</span>
                </div> 
            </div>
        </div>

                <%--<tr>
                    <td bgcolor="#ffffff">&nbsp;<img src="../../lib/standard/img/share.gif" width="32" height="32" alt="" border="0"
                        align="absmiddle" />
                    </td>
                    <td bgcolor="#ffffff">
                        <span style="color: #191970; font-weight: bold; font-size: 12pt;">Collaboration: Share
                        a page</span><br>
                        <span style="font-size: 8pt;">Share a resource with a colleague or friend.</span>
                    </td>
                </tr>--%>

        <div class="row"> 
            <div class="col-12 col-sm-3">
                <div style="background-color:#ffffff">
                    <img src="../../lib/standard/img/trans.gif" border="0" height="4" alt="Transparent Gif" />
                </div>
            </div>   
        </div>
        <div class="row"> 
            <div class="col-12 col-sm-3">
                <div style="background-color:#191970">
                    <img src="../../lib/standard/img/trans.gif" border="0" height="1" alt="Transparent Gif" />
                </div> 
            </div>   
        </div>

                <%--<tr>
                    <td colspan="2" height="4" bgcolor="#ffffff">
                        <img src="../../lib/standard/img/trans.gif" border="0" height="4" alt="Transparent Gif" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="1" bgcolor="#191970">
                        <img src="../../lib/standard/img/trans.gif" border="0" height="1" alt="Transparent Gif" />
                    </td>
                </tr>--%>

        <div class="row"> 
            <div class="col-12 col-sm-3">
                <div class="FormInput">You are sharing the following resource:<br />
                </div> 
            </div>   
        </div>
        <div class="row"> 
            <div class="col-12 col-sm-3">
                <span style="color:#0066ff" onclick="window.close();"><u><i>Session Detail</i></u></span>
                <%--<a href="../../catalog/session.aspx?session_id=<%= sessionId %>">Session Detail</a>--%>
                <%--<a href="../../catalog/session.aspx?session_id=0">Session Detail</a>--%>
                <asp:Label ID="ResourceSource" runat="server" Font-Size="9pt" Font-Italic="True" Visible="False"></asp:Label>
            </div> 
        </div>

                <%--<tr>
                    <td colspan="2" height="100%" valign="top">
                        <table border="0" width="100%">
                            <tr>
                                <td class="FormInput">You are sharing the following resource:<br />
                                    <asp:Label ID="ResourceSource" runat="server" Font-Size="9pt" Font-Italic="True"></asp:Label>--%>
                                    <br />
                                    <br />

        <div class="row"> 
            <div class="col-12 col-sm-3">
                
                <asp:Label ID="RecipeintLabel"
                                        text="Friend or Colleagues Email:"
                                        AssociatedControlID="ResourceRecipient"
                                        runat="server"></asp:Label>                                  
									<asp:RequiredFieldValidator ID="Require_EmailText" runat="Server" ControlToValidate="ResourceRecipient" ErrorMessage="Email is missing.<br>" CssClass="RequiredText" Style="color: darkred"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="Validate_EmailText" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="The email address is not in an acceptable format. (user@domain.com)<br>" Display="Dynamic" ControlToValidate="ResourceRecipient" CssClass="RequiredText"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="ResourceRecipient" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                                    <asp:PlaceHolder ID="pSenderInfo" runat="server">
                                    </div>   
        </div>
        <br />

                                    <%--<asp:Label ID="RecipientEmailLabel"
text="Friend or Colleagues Email:"
AssociatedControlID="ResourceRecipient"
runat="server"></asp:Label>
                                <asp:RequiredFieldValidator ID="Require_EmailText" runat="Server" ControlToValidate="ResourceRecipient"
                                    ErrorMessage="Email is missing.<br>" CssClass="RequiredText"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="Validate_EmailText" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ErrorMessage="The email address is not in an acceptable format. (user@domain.com)<br>"
                                        Display="Dynamic" ControlToValidate="ResourceRecipient" CssClass="RequiredText"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="ResourceRecipient" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                                    <asp:PlaceHolder ID="pSenderInfo" runat="server">
                                        <br />--%>

<div class="row"> 
            <div class="col-12 col-sm-3">
                <asp:Label ID="SenderNameLabel"
                                            text="Your Name:"
                                            AssociatedControlID="ResourceSender"
                                            runat="server"></asp:Label><br />
                                        
            <asp:TextBox ID="ResourceSender" runat="server" CssClass="TextBox" Style="width: 100%"></asp:TextBox>
    </div> 
</div> 
<br />

                                        <%--<asp:Label ID="SenderNameLabel"
text="Your name:"
AssociatedControlID="ResourceSender"
runat="server"></asp:Label><br />
                                        <asp:TextBox ID="ResourceSender" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                                        <br />--%>

        <div class="row"> 
            <div class="col-12 col-sm-3">
                                    <asp:Label ID="YourEmailLabel"
            text="Your E-mail:"
            AssociatedControlID="ResourceSenderEmail"
            runat="server"></asp:Label>
                                    <asp:RequiredFieldValidator ID="Require_EmailText2" runat="Server" ControlToValidate="ResourceSenderEmail"
                                        ErrorMessage="Email is missing.<br>" CssClass="RequiredText" Style="color: darkred"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="Validate_EmailText2" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ErrorMessage="The email address is not in an acceptable format. (user@domain.com)<br>" 
                                        Display="Dynamic" ControlToValidate="ResourceSenderEmail" CssClass="RequiredText" Style="color: darkred"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="ResourceSenderEmail" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                                </asp:PlaceHolder>
    </div>
    </div>                                

        <br />
    <div class="row"> 
            <div class="col-12 col-sm-3">
                <asp:Label ID="MessageLabel"
                                        text="Short Message:"
                                        AssociatedControlID="ResourceMessage"
                                        runat="server"></asp:Label><br />

                                    <asp:TextBox ID="ResourceMessage" runat="server" CssClass="TextBox" TextMode="MultiLine"
                                        Rows="10" Columns="40" Height="60px" Style="width: 100%"></asp:TextBox>
        </div> 
    </div> 

                                       <%--<asp:Label ID="SenderEmailLabel"
text="Your E-mail:"
AssociatedControlID="ResourceSenderEmail"
runat="server"></asp:Label> 
                                    <asp:RequiredFieldValidator ID="Require_EmailText2" runat="Server" ControlToValidate="ResourceSenderEmail"
                                        ErrorMessage="Email is missing.<br>" CssClass="RequiredText"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="Validate_EmailText2" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ErrorMessage="The email address is not in an acceptable format. (user@domain.com)<br>"
                                            Display="Dynamic" ControlToValidate="ResourceSenderEmail" CssClass="RequiredText"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="ResourceSenderEmail" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                                    </asp:PlaceHolder>
                                    <br />
                                    <asp:Label ID="MessageLabel"
text="Short Message:"
AssociatedControlID="ResourceMessage"
runat="server"></asp:Label><br />
                                    <asp:TextBox ID="ResourceMessage" runat="server" CssClass="TextBox" TextMode="MultiLine"
                                        Rows="7" Columns="35" Width="100%" Height="60px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>--%>

<br />
        <div>
            <label for = "g-recaptcha-response"><span style="display:none">Recaptcha</span></label>
        <div class="g-recaptcha" data-sitekey="6LeRZBETAAAAAKN3XmAIQW4yM6xh0icj4W6SOvsv">
        </div>
        <br />
        <br />
    </div>
    <div class="row"> 
        <div class="col-12 col-sm-3">
            <asp:Label runat="server" CssClass="error" ID="lblError" />
        <br />
                <asp:Button runat="server" ID="btnSend" Text="Send" CssClass="formInput btn btn-ARESCblue btn-sm" style="width: 140px; font-size:small" />
            &nbsp;&nbsp;
            <input type="button" value="Cancel" class="formInput btn btn-ARESCgrey btn-sm" style="width: 140px; font-size:small;" onclick="self.close();" />
        </div>
    </div>
</div>
</div>

<%--                <tr>
                    <td>
                        <div class="g-recaptcha" data-sitekey="6LeRZBETAAAAAKN3XmAIQW4yM6xh0icj4W6SOvsv">
                        </div>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" bgcolor="#191970" align="right">
                        <table border="0" width="100%">
                            <tr>
                                <td align="right">
                                    <asp:Label runat="server" CssClass="error" ID="lblError" />
                                    <asp:Button runat="server" ID="btnSend" Text="Send" CssClass="forminput" />
                                    <input type="button" value="Cancel" style="width: 100px;" class="button" onclick="self.close();" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>--%>
    </form>
    </div>

<%--    <form id="form1" runat="server">
        <div>
            <table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
                <tr>
                    <td colspan="2" height="1" bgcolor="#191970">
                        <img src="/global/img/trans.gif" border="0" height="1" alt="Transparent Gif"></td>
                </tr>
                <tr>
                    <td colspan="2" height="4" bgcolor="#ffffff">
                        <img src="/global/img/trans.gif" border="0" height="4" alt="Transparent Gif"></td>
                </tr>
                <tr>
                    <td bgcolor="#ffffff">&nbsp;<img src="/global/img/ico/32/share.gif" width="32" height="32" alt="" border="0" align="absmiddle"></td>
                    <td bgcolor="#ffffff"><span style="color: #191970; font-weight: bold; font-size: 12pt;">Collaboration: Share a page</span><br>
                        <span style="font-size: 8pt;">Share a resource with a colleague or friend.</span></td>
                </tr>
                <tr>
                    <td colspan="2" height="4" bgcolor="#ffffff">
                        <img src="/global/img/trans.gif" border="0" height="4" alt="Transparent Gif"></td>
                </tr>
                <tr>
                    <td colspan="2" height="1" bgcolor="#191970">
                        <img src="/global/img/trans.gif" border="0" height="1" alt="Transparent Gif"></td>
                </tr>
                <tr>
                    <td colspan="2" height="100%" valign="top">
                        <table border="0" width="100%">
                            <tr>
                                <td class="FormInput">You are sharing the following resource:<br>
                                    <asp:Label ID="ResourceSource" runat="server" Font-Size="9pt" Font-Italic="True"></asp:Label>
                                    <br>
                                    <br>
                                    <asp:Label ID="RecipientEmailLabel"
text="Friend or Colleagues Email:"
AssociatedControlID="ResourceRecipient"
runat="server"></asp:Label>
									<asp:RequiredFieldValidator ID="Require_EmailText" runat="Server" ControlToValidate="ResourceRecipient" ErrorMessage="Email is missing.<br>" CssClass="RequiredText"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="Validate_EmailText" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="The email address is not in an acceptable format. (user@domain.com)<br>" Display="Dynamic" ControlToValidate="ResourceRecipient" CssClass="RequiredText"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="ResourceRecipient" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                                    <asp:PlaceHolder ID="pSenderInfo" runat="server">
                                        <br>
                                        <asp:Label ID="SenderNameLabel"
text="Your name:"
AssociatedControlID="ResourceSender"
runat="server"></asp:Label><br>
                                        <asp:TextBox ID="ResourceSender" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                                        <br>
                                        <asp:Label ID="SenderEmailLabel"
text="Your E-mail:"
AssociatedControlID="ResourceSenderEmail"
runat="server"></asp:Label>
									<asp:RequiredFieldValidator ID="Require_EmailText2" runat="Server" ControlToValidate="ResourceSenderEmail" ErrorMessage="Email is missing.<br>" CssClass="RequiredText"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="Validate_EmailText2" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="The email address is not in an acceptable format. (user@domain.com)<br>" Display="Dynamic" ControlToValidate="ResourceSenderEmail" CssClass="RequiredText"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="ResourceSenderEmail" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                                    </asp:PlaceHolder>
                                    <br>
                                    <asp:Label ID="MessageLabel"
text="Short Message:"
AssociatedControlID="ResourceMessage"
runat="server"></asp:Label><br>
                                    <asp:TextBox ID="ResourceMessage" runat="server" CssClass="TextBox" TextMode="MultiLine" Rows="7" Columns="35" Width="100%" Height="60px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="g-recaptcha" data-sitekey="6LeRZBETAAAAAKN3XmAIQW4yM6xh0icj4W6SOvsv">
                        </div>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <table border="0" width="100%">
                            <tr>
                                <td align="right">
                                    <asp:Label runat="server" CssClass="error" ID="lblError" />
                                    <asp:Button runat="server" ID="btnSend" Text="Send" CssClass="forminput" />
                                    <input type="button" value="Cancel" style="width: 100px;" class="button" onclick="self.close();">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>--%>
</body>
</html>
