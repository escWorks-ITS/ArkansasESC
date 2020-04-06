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
     <td width="100%">
     <table style="margin-left: auto;background-color:White;margin-right: auto; margin-top: 20px; border-collapse: collapse; height: 500px; border:solid 1px #000;">
        <tr>
     <td colspan="3" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                            padding-top: 0px; background-color: #325e8e;">
                            <div>
                                <a title="esc19.NET" href="http://www.esc19.net">
                                    <img src="https://txr19.escworks.net/lib/standard/img/clicknlearn_banner.png" alt="escWorks" height="80px" width="1024px" style="background-color: #016699"; border:none;" /></a></div>
                        </td>
        </tr>
        <tr><td colspan="3"><br /></td></tr>
        <tr><td style="padding:10px;" colspan="3">
        <a  href="http://www.esc19.net" style="display:block;"><font size="5px">Home</font></a>
 </td></tr>
       <tr><td colspan="3" style="padding:10px">
 
<asp:Panel runat ="server" ID="Psignin" >
    
    <h1 class="heading">Attendee Payments </h1><br />
   
   <table border="0">
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
                      <td colspan="3" style="background-color: #dbdbe2;">
                            <div style="padding: 25px;" align="center">
                               <h4><font color="#292568">EDUCATION SERVICE CENTER-REGION 19 | 6611 Boeing Drive | El Paso TX 79925 | (915) 780-1919</font></h4><p></p><p></p></div>
                        </td>
                    </tr>

    </table>

    <br />

    </td></tr>
    </table>
    </form>
</body>
</html>
