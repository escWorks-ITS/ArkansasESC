<%@ Page Language="C#" MasterPageFile="~/MasterPageDummy.master" AutoEventWireup="true"
    CodeFile="OnlineSession.aspx.cs" Inherits="catalog_OnlineSession" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="Server">
    <br />
    <table width="100%" style="border-collapse: collapse;">
        <tr>
            <td>
                <escWorks:OnlineSessions runat="server" ID="IdOnlineSessions" ItemsToDisplay="10" />
            </td>
        </tr>
    </table>
</asp:Content>
