<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search.ascx.cs" Inherits="Search" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    .RadGrid A:hover
    {
        color: black;
    }
</style>
<table width="100%">
    <tr>
        <td>
            <table width="90%">
                <tr>
                    <td>
                        <asp:Label ID="SearchLabel"
text="Search:"
AssociatedControlID="txtSearch"
runat="server"></asp:Label>
                        <telerik:RadTextBox ID="txtSearch" runat="server" Width="100%">
                        </telerik:RadTextBox>
                    </td>
                    <td>
                        <telerik:RadButton ID="btnSearch" runat="server" Text="Search" CausesValidation="false"
                            OnClick="btnSearch_Click">
                        </telerik:RadButton>
                        <telerik:RadButton ID="btnReset" runat="server" Text="Reset" CausesValidation="false"
                            OnClick="btnReset_Click">
                        </telerik:RadButton>
                    </td>
                </tr>
                <asp:PlaceHolder ID="plESC" runat="server">
                <tr>
                    <td>
                        <asp:Label ID="Labelorg" text="Co-op:"
AssociatedControlID="ddOrganizationId"
runat="server"></asp:Label>
                        <asp:DropDownList ID="ddOrganizationId" runat="Server" Width="80%">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:CheckBox ID="chkFree" runat="server" Text="Free" Font-Size="X-Small" Width="20%" />
                        <asp:CheckBox ID="chkWeekend" runat="server" Text="Weekend" Font-Size="X-Small" Width="30%" />
                    </td>
                </tr>
                </asp:PlaceHolder>
            </table>
        </td>
    </tr>
    <tr>
        <td>
             <telerik:RadGrid ID="grdSearch" runat="server" AllowSorting="true" AutoGenerateColumns="false"
                Skin="Outlook" CellPadding="0" Width="100%" GridLines="None" AllowPaging="True"
                PagerStyle-Position="TopAndBottom" BorderStyle="Solid" BorderColor="#0066FF">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <AlternatingItemStyle BackColor="#CFDDF3" />
             <PagerStyle ChangePageSizeButtonToolTip="Change Page Size" 
                    ChangePageSizeComboBoxTableSummary="The table which holds the composite controls for the ChangePageSize RadComboBox control."
                    ChangePageSizeComboBoxToolTip="Change Page Size"
                    ChangePageSizeTextBoxToolTip="Change Page Size" GoToPageButtonToolTip="Go To Page"
                    GoToPageTextBoxToolTip="Go To Page" />
                <MasterTableView Width="100%" DataKeyNames="ID" Font-Size="X-Small" AllowMultiColumnSorting="false">
                    <SortExpressions>
                        <telerik:GridSortExpression FieldName="StartDate" SortOrder="Ascending" />
                    </SortExpressions>
                    <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridHyperLinkColumn DataNavigateUrlFields="URL" DataTextField="ID" UniqueName="ID"
                            HeaderText="ID" DataNavigateUrlFormatString="{0}">
                            <HeaderStyle Width="6%" Font-Size="Small" />
                        </telerik:GridHyperLinkColumn>
                        <telerik:GridBoundColumn DataField="StartDate" DataFormatString="{0:d}" UniqueName="StartDate"
                            HeaderText="Start Date" AllowSorting="true" ShowSortIcon="true" AllowFiltering="false"
                            Groupable="false" Reorderable="false" Visible="true">
                            <HeaderStyle Width="10%" Font-Size="Small" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Title" UniqueName="Title" HeaderText="Title"
                            AllowSorting="true" ShowSortIcon="true" AllowFiltering="false" Groupable="false"
                            Reorderable="false" Visible="true">
                            <HeaderStyle Width="30%" Font-Size="Small" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="DescriptionDisplay" UniqueName="DescriptionDisplay"
                            HeaderText="Description" AllowSorting="false" AllowFiltering="false" Groupable="false"
                            Reorderable="false" Visible="true">
                            <HeaderStyle Width="40%" Font-Size="Small" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EventTypeDisplay" UniqueName="EventTypeDisplay"
                            HeaderText="Type" AllowSorting="true" ShowSortIcon="true" AllowFiltering="false"
                            Groupable="false" Reorderable="true" Visible="true">
                            <HeaderStyle Width="14%" Font-Size="Small" />
                        </telerik:GridBoundColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                        </EditColumn>
                    </EditFormSettings>
                </MasterTableView>
                <FilterMenu EnableImageSprites="False">
                </FilterMenu>
            </telerik:RadGrid>
            <asp:Label ID="lbError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
        </td>
    </tr>
</table>
