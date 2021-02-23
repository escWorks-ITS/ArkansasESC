<%@ Page Language="C#" AutoEventWireup="true" CodeFile="signin.aspx.cs" Inherits="security_signin" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="mainBody"><a name="MainBody"></a>
    <span style="padding-right: 10px;"><button type="button" onclick="javascript:history.back()" class="formInput btn btn-ARESCblue btn-lg" role="button" style="width: 130px; font-size:small" ToolTip="Click here to go to previous page.">Previous</button></span>
    <br /><br />
    <div class="row" style="margin-left:3px;">
    <div class="col-xs-12 col-sm-6" style="background-color: #F0F0F0; padding: 20px 5px 20px 5px;">
        <h2 style="padding-left:13px;">Account Sign-In</h2><br />
        <span style="padding-left:13px;">Sign in to your account</span><br /><br />
        
        <div class="form-group col-xs-12 col-sm-11">  
     
              <div class="input-group">
            <div class="input-group-prepend">
                <div class="input-group-text">
                    <div class="btn btn-R19Grey glyphicon glyphicon-user">
                    </div>
                </div>
            </div>
            <label for = "ctl00_mainBody_txtUserName"><span style="display:none">UserName</span></label>
            <asp:TextBox ID="txtUserName" CssClass="smallFont" style="height: 32px; width: 80%; font-family: Arial; color:black; margin: 0px;" class="form-control" placeholder="E-mail Address" runat="server" />
        </div> 


      </div>

    <div class="form-group col-xs-12 col-sm-11"> 


        <div class="input-group">
            <div class="input-group-prepend">
                <div class="input-group-text">
                    <div class="btn btn-R19Grey glyphicon glyphicon-lock">
                    </div>
                </div>
            </div>
            <label for = "ctl00_mainBody_txtPassword"><span style="display:none">password</span></label>
            <asp:TextBox ID="txtPassword" CssClass="smallFont" style="height: 32px; width: 80%; font-family: Arial; color:black; margin: 0px;" class="form-control" placeholder="Password" TextMode="Password" runat="server" />
        </div> 


      </div>
      <div class="form-group col-xs-12 col-sm-11">
          <br />
        <div class="form-group col-xs-12 col-sm-6">
            <asp:Button Cssclass="formInput btn btn-ARESCblue btn-lg" runat="server" ID="btnSubmit" Text="Login" OnClick="btnSubmit_Click" style="font-size:small" Width="130px" /></div>
            <br /><br />&nbsp;&nbsp;&nbsp;&nbsp;<a style="color:#292568" href="../shoebox/account/password.aspx?mode=forgot">Forgot Password?</a>
    </div>
  </div>
 
 


    <div class="col-xs-12 col-sm-6" style="background-color: #003399; padding: 20px 5px 20px 5px;">
        <h2 style="padding-left:13px; color: white;">Create an Account</h2><br /><br />
        <div style="padding-left:13px; color: white; font-family: Arial;">To create a new <strong>Professional Development</strong> account please click the "<strong>Create Account</strong>" button.</div>
        <br /><br /><br /><br />
                        <%--<span style="padding-right: 10px;"><button type="button" onclick="javascript:history.back()" class="formInput btn btn-ARESCblue btn-lg" role="button" style="width: 130px; font-size:small" ToolTip="Click here to go to previous page.">Previous</button></span>--%>

        <%--<asp:Button Cssclass="btn btn-secondary btn-lg btn-block" runat="server" ID="Button2" Text="Forgotten your password" style="font-size:medium" PostBackUrl="../shoebox/account/password.aspx?mode=forgot" />--%>
        <div style="padding-left:18px;">
            <div class="form-group col-xs-12 col-sm-6"><asp:Button class="formInput btn btn-ARESCgrey btn-lg" runat="server" ID="btnNewAccount" Text="Create Account" style="font-size:small;" PostBackUrl="~/shoebox/account/signup.aspx?ReturnUrl=/default.aspx"  />
        </div>
    </div>


</div>


 </div>


    



    <br /><br />

    <asp:Label runat="server" ID="lblMessage" CssClass="error" />
</asp:Content>
<%--<asp:Content runat="server" ID="content1" ContentPlaceHolderID="mainBody">
    <div>
    
    <h1 class="heading">Account Sign-in</h1><br />
   
   <table border=0>
   <tr><td style="width: 144px"> 
       <asp:Label ID="EmailAddressLabel"
text=" E-mail Address:"
AssociatedControlID="txtUserName"
runat="server"></asp:Label>
      </td><td> <asp:TextBox runat="server" 
           ID="txtUserName" Width="220px" /></td></tr>
   <tr><td style="width: 144px">
       <asp:Label ID="PasswordLabel"
text="Password:"
AssociatedControlID="txtPassword"
runat="server"></asp:Label>
        </td><td> <asp:TextBox runat="server" 
           ID="txtPassword" TextMode="Password" Width="220px" /></td></tr>
   </table>
    
    <br />
    <asp:Label runat="server" ID="lblMessage" CssClass="error" />
    <a id="A1" href="~/shoebox/account/signup.aspx" runat="server" class="link">Click here to create a new account</a>
   <br />
   If you have <b><i>forgotten your password</i></b>, <a href="../shoebox/account/password.aspx?mode=forgot" class="link">
							click here</a>.
        <br />
    <br />
    <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" />
    </div>
</asp:Content>--%>