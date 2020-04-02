<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentID.aspx.cs" Inherits="Barcode_PaymentID" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en-us" xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <table align="center" border="0" >
     <tr valign="top">
     <td width="1068px">
     <table style="margin-left: auto;background-color:White;margin-right: auto; margin-top: 20px; border-collapse: collapse; height: 500px; border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid;">
        <tr>
            <td colspan="2" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; padding-top: 0px; background-color: #abaaaa;">
            <a  href="http://www.esc3.net/" style="display:block;">
            <img src="<%# Request.ApplicationPath %>/tx_r3/lib/standard/img/R3Banner.jpg"  alt="ESC 3" width="100%" style="background-color: #35638f; style="border:none;"  /></a>
            </td>
        </tr>
        <tr><td colspan="2"><br /></td></tr>
        <tr><td colspan="2" style="padding:10px;">
        <a  href="http://www.escweb.net/tx_r3/" style="display:block;"><font size="5px">Home</font></a>
 </td></tr>
       <tr><td colspan="2" style="padding:10px">
 
<asp:Panel runat ="server" ID="Psignin" >
    
    <h1 class="heading">Attendee Payments </h1><br />
   
   <table border=0>
   <tr><td>
   <asp:Label ID="lbl1" 
       Text="Please enter the Payment ID's in the below given text area and click the submit button"
       AssociatedControlID="txtpaymentid"
       runat="server"></asp:Label>
   </td></tr>
   <tr><td><br /></td></tr>
   <tr><td>   
    <asp:TextBox ID="txtpaymentid" runat="server" TextMode="MultiLine" Columns ="50" Rows ="25" wrap="false" />
     </td></tr>
  </table>   
    <br />
    <br />
    <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" />

</asp:Panel>    
 
    <asp:Panel runat="server" ID="pSuccess" Visible="false">
       <b> All the attendee payments are marked Invoiced!<br /></b>
       <a id="A1" href="~/default.aspx" runat="server" class="link">Please click here to continue</a>
    </asp:Panel>
    </td></tr>
       
       
        <tr>
                        <td colspan="3" style="background-color: #a10108;">
                            <div style="padding: 5px;" align="center">
                                <font color="#ffffff">1905 Leary Lane Victoria, TX 77901<br />Phone: 361.573.0731</font></div>
                        </td>
                    </tr>

    </table>

    <br />

    </td></tr>
    </table>
    </form>
</body>
</html>
