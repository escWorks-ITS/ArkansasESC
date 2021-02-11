<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="contact.aspx.cs" Inherits="about_contact" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="Server"><a name="MainBody"></a>
    <span style="padding-right: 10px;"><button type="button" onclick="javascript:history.back()" class="formInput btn btn-ARESCBlue btn-lg" role="button" style="width: 130px; font-size:small" ToolTip="Click here to go to previous page.">Previous</button></span>
    <br /><br />
    <asp:Panel runat="server" ID="pStep1">
<%--        <strong><asp:Label ID="RegionLabel"
text="Region"
AssociatedControlID="Cooperatives"
runat="server"></asp:Label></strong><br />
        <asp:DropDownList ID="Cooperatives" runat="Server" AutoPostBack="true" CssClass="formInput">
        </asp:DropDownList>
        <br />
        <br />--%>

<div class="container">

  <div class="row">
        <div class="form-group col-xs-12 col-sm-6" >  
        <asp:Label ID="RegionLabel"
                  Text ="Region: <br/>"
                  AssociatedControlID="Cooperatives"
                  CssClass="smallFont"
                  runat="server">
       </asp:Label>
       <asp:DropDownList 
           ID="Cooperatives" CssClass="form-control smallFont" style="height: 35px;" runat="server" />        
    </div>
  </div>
    <br />
  <div class="row">
        <div class="form-group col-xs-12 col-sm-6" >  
        <asp:Label ID="categorylabel"
                  Text ="Category: <br/>"
                  AssociatedControlID="ddlCategory"
                  CssClass="smallFont"
                  runat="server">
       </asp:Label>
       <asp:DropDownList 
           ID="ddlCategory" CssClass="form-control smallFont" style="height: 35px;" runat="server" />
           
    </div>
  </div>

    <div class="row">
       <div class="form-group col-xs-12 col-sm-12">  
        <asp:Label ID="CommentsLabel" class="textwidth"
                  Text ="Enter your comments in the space provided below: <br/> "
                  AssociatedControlID="txtComments"
            CssClass="smallFont"
                  runat="server">
       </asp:Label>
       
       <asp:TextBox 
           ID="txtComments" CssClass="form-control smallFont" TextMode="MultiLine"
            Height="99px" runat="server"/>
           
        </div>
     </div>

        <div class="textwidth smallFont"><b>Please provide some information about yourself:</b></div>
        <br />

    <div class="row" style="padding-left: 15px;">
      <div class="form-group col-xs-12 col-sm-6">      
            <asp:Label ID="NameLabel"
                  Text ="Name:"
                  AssociatedControlID="txtName"
                  CssClass="smallFont"
                  runat="server">
            </asp:Label>
            <asp:TextBox  
           ID="txtName" CssClass="form-control smallFont" runat="server" />
           
        </div>
    </div>

    <div class="row" style="padding-left: 15px;">
        <div class="form-group col-xs-12 col-sm-6">  
        <asp:Label ID="EmailLabel"
                  Text ="E-mail:"
                  AssociatedControlID="txtEmail"
                  CssClass="smallFont"
                  runat="server">
       </asp:Label>
       <asp:TextBox  
           ID="txtEmail" CssClass="form-control smallFont" runat="server"/>      
      </div>
    </div>

    <div class="row" style="padding-left: 15px;">
        <div class="form-group col-xs-12 col-sm-6"> 
        <asp:Label ID="PhoneLabel"
                  Text ="Telephone:"
                  AssociatedControlID="txtPhone"
                  CssClass="smallFont"
                  runat="server">
       </asp:Label>
       <asp:TextBox  
           ID="txtPhone" CssClass="form-control smallFont" runat="server" />
           
      </div>
    </div>
  </div>
        <br />
        <asp:CheckBox runat="server" ID="chkASAP" CssClass="textwidth smallFont" Text="Please contact me as soon as possible regarding this matter." />
        <br />
        <br />
        <label for = "g-recaptcha-response"><span style="display:none">Recaptcha</span></label>
        <div class="g-recaptcha" data-sitekey="6LeRZBETAAAAAKN3XmAIQW4yM6xh0icj4W6SOvsv" id="g-recaptcha" title="g-recaptcha" style="width:100%">
        </div>
        <br />
        <br />
        <asp:Label runat="server" ID="lblError" CssClass="error smallFont" /><br />
        <br />
        <asp:Button runat="server" ID="btnSubmit" Text="Submit Comments" CssClass="formInput btn btn-ARESCBlue btn-lg" Style="width: 150px; font-size:small" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="formInput btn btn-ARESCGrey btn-lg" Style="width: 150px; font-size:small" />
    </asp:Panel>
    <asp:Panel runat="server" ID="pStep2">
        <span class="smallFont">Thank you for your comments</span><br />
        <br />
        <a href="~/default.aspx" runat="server" class="link smallFont">Click here to continue</a>
    </asp:Panel>

<%--        <b><asp:Label ID="CategoryLabel"
text="Category"
AssociatedControlID="ddlCategory"
runat="server"></asp:Label></b><br />
        <asp:DropDownList runat="server" ID="ddlCategory" CssClass="formInput" />
        <br />
        <br />
        <b><asp:Label ID="CommentsLabel"
text="Enter your comments in the space provided below:"
AssociatedControlID="txtComments"
runat="server"></asp:Label></b>
        <br />
        <asp:TextBox runat="server" ID="txtComments" CssClass="formInput" TextMode="MultiLine"
            Height="99px" Width="282px" />
        <br />
        <br />
        <b>Please provide some information about yourself:</b><br />
        <br />
        <b><asp:Label ID="NameLabel"
text="Name:&nbsp;"
AssociatedControlID="txtName"
runat="server"></asp:Label> </b>
        <asp:TextBox runat="server" ID="txtName" CssClass="formInput" />
        <br />
        <br />
        <b><asp:Label ID="EmailLabel"
text="E-mail:&nbsp;"
AssociatedControlID="txtEmail"
runat="server"></asp:Label> </b>
        <asp:TextBox runat="server" ID="txtEmail" CssClass="formInput" />
        <br />
        <br />
        <b><asp:Label ID="TelephoneLabel"
text="Telephone:&nbsp;"
AssociatedControlID="txtPhone"
runat="server"></asp:Label> </b>
        <asp:TextBox runat="server" ID="txtPhone" CssClass="formInput" />
        <br />
        <br />
        <asp:CheckBox runat="server" ID="chkASAP" Text="Please contact me as soon as possible regarding this matter." />
        <br />
        <br />
        <div class="g-recaptcha" data-sitekey="6LeRZBETAAAAAKN3XmAIQW4yM6xh0icj4W6SOvsv">
        </div>
        <br />
        <br />
        <asp:Label runat="server" ID="lblError" CssClass="error" /><br />
        <br />
        <asp:Button runat="server" ID="btnSubmit" Text="Submit Comments" />
        <asp:Button runat="server" ID="btnCancel" Text="Cancel" />
    </asp:Panel>
    <asp:Panel runat="server" ID="pStep2">
        Thank you for your comments<br />
        <br />
        <a href="~/default.aspx" runat="server" class="link">Click here to continue</a>
    </asp:Panel>--%>
</asp:Content>
