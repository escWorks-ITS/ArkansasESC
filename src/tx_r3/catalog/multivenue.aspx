<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="multivenue.aspx.cs" Inherits="catalog_multivenue"  Title="Multi-Venue Events"%>

<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="Server">
    <script type="text/javascript">

        function showDiv(divShow, divHide, showDivID) {
            var show = document.getElementById(divShow);
            var hide = document.getElementById(divHide);
            showDivID.style.display = 'block';
            show.style.display = 'none';
            hide.style.display = 'block';
        }

        function hideDiv(divShow, divHide, hideDiv) {
            var show = document.getElementById(divShow);
            var hide = document.getElementById(divHide);
            hideDiv.style.display = 'none';
            show.style.display = 'block';
            hide.style.display = 'none';
        }

    </script>
    <asp:Label runat="server" ID="txtTitle" CssClass="heading" />
    <br />
    <asp:Label runat="server" ID="txtDescription" Font-Italic="true" />
    <br />
    <escWorks:MultiVenueSessions runat="server" ID="sessionDisplay" CollapseBreakoutByDefault="true" ShowText="Show Details" HideText="Hide Details" ShowTextColor="#2b3990;"/>
</asp:Content>
