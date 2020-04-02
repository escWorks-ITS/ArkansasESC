<%@ Page Language="C#" MasterPageFile="~/MasterPageDummy.master" AutoEventWireup="true"
    CodeFile="SevenDayOutlook.aspx.cs" Inherits="catalog_SevenDayOutlook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="Server">
    <br />
    <table width="100%" style="border-collapse: collapse;">
        <tr>
            <td>
                <escWorks:SevenDayOutlook runat="server" ID="IdSevenDayOutlook" ItemsToDisplay="10" />
            </td>
        </tr>
    </table>
</asp:Content>
