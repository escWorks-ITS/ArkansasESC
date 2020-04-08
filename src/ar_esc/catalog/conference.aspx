<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="conference.aspx.cs" Inherits="catalog_conference" Title="Untitled Page" ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" Runat="Server">
<asp:Label runat="server" ID="txtTitle" CssClass="heading" />
<br />
<asp:Label runat="server" ID="txtDescription" Font-Italic="true" />
<br />
<escWorks:ConferenceSelection runat="server" ID="sessionDisplay" />
</asp:Content>

