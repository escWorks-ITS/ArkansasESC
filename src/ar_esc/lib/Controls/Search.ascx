<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search.ascx.cs" Inherits="Search" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    .RadGrid A:hover
    {
        color: black;
    }
</style>

<label for="formLabel" style="display: none;">formLabel</label>

 <div class="container">
        <div class="row" style="width:90%">
            <div id="searchCriteriaDesktop"> 

                        <div class="row">
                            <div class="col-12 col-sm-12" style="padding-left: 30px !important;">
                                <%--<span style="padding-right: 10px;"><button type="button" onclick="javascript:history.back()" class="formInput btn btn-R10Blue btn-lg" role="button" style="width: 130px; font-size:small" ToolTip="Click here to go to previous page.">Previous</button></span>
                                <br /><br />--%>
                                <label id="searchLabel" for="search"><span style="color: black !important;"><b>Search: </b></span></label>
                                
                                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control fullWidth smallFont" aria-labelledby="searchLabel"/>&nbsp;&nbsp;
                            </div>
                        </div>
                <asp:PlaceHolder ID="plESC" runat="server">
                        <div class="row">
<%--                            <div class="col-6 col-sm-6">
                                <div style="padding-left: 15px !important;">
                                    <asp:Button id="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" class="formInput btn btn-R10Blue btn-lg" style="width: 140px; height:30px; font-size:small" />
                                </div>
                            </div>--%>
                            <div class="col-12 col-sm-12" style="padding-left: 30px !important;">
                            <%--<asp:PlaceHolder ID="plESC" runat="server">--%>
                            <asp:Label ID="Labelorg" style="color: black !important;" text="<b>Co-op:&nbsp;&nbsp;</b>"
                                AssociatedControlID="ddOrganizationId"
                                runat="server"></asp:Label>
                        <asp:DropDownList ID="ddOrganizationId" runat="Server" Width="100%" CssClass="form-control fullWidth smallFont">
                        </asp:DropDownList>
                        <%--</asp:PlaceHolder>--%>
                                </div>
                        </div>
                        <div class="row">
                            <div class="col-12 col-sm-12" style="padding-left: 15px !important;">
                                <div class="col-12 col-sm-3">
                                    <asp:CheckBox ID="chkFree" runat="server" Text="&nbsp;&nbsp;Free" style="color: black !important;" Font-Size="X-Small" />
                                </div>
                                <div class="col-12 col-sm-3">
                                    <asp:CheckBox ID="chkWeekend" runat="server" Text="&nbsp;&nbsp;Weekend" style="color: black !important;" Font-Size="X-Small" />
                                </div>
                            </div>
                        </div>
                </asp:PlaceHolder>
                        <div class="row">
                            <br /><br />
                            <div class="col-6 col-sm-6">
                                <div style="padding-left: 15px !important;">
                                    <asp:Button id="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" class="formInput btn btn-ARESCblue btn-lg" style="width: 140px; height:30px; font-size:small" />
                                </div>
                            </div>

                            <div class="col-3 col-sm-4">
                                <asp:Button id="btnReset" Text="Reset" runat="server" OnClick="btnReset_Click" class="formInput btn btn-ARESCgrey btn-lg" style="width: 140px; height:30px; font-size:small" />
                            </div>
                        </div>



     
                          </div>
        </div>
    </div>

<div id="searchGridDeskTop">
 <br />
 <telerik:RadGrid ID="grdSearch" Label="Page Size" runat="server" AllowSorting="true" AutoGenerateColumns="false"
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
                        <telerik:GridBoundColumn DataField="EventTypeDisplay" UniqueName="EventTypeDisplay" HeaderText="Type"
                            AllowSorting="true" ShowSortIcon="true" AllowFiltering="false" Groupable="false"
                            Reorderable="true" Visible="true">
                            <HeaderStyle Width="14%" Font-Size="Small" />
                        </telerik:GridBoundColumn>
                        <telerik:GridHyperLinkColumn DataNavigateUrlFields="URL" DataTextField="SearchResult" UniqueName="SearchResult"
                            HeaderText="SearchResult" DataNavigateUrlFormatString="{0}" Visible="false">
                            <HeaderStyle Width="6%" Font-Size="Small" />
                        </telerik:GridHyperLinkColumn>
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
   
</div>

<div id="searchGridMobile">
     <br />
            <telerik:RadGrid ID="grdSearchMobile" Label="Page Size" runat="server" AllowSorting="false" AutoGenerateColumns="false"
                Skin="Outlook" CellPadding="0" Width="100%" GridLines="None" AllowPaging="false"
                PagerStyle-Position="TopAndBottom" BorderStyle="Solid" BorderColor="#0066FF" RenderMode="Auto">
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

                    <telerik:GridBoundColumn DataField="SearchResult" UniqueName="SearchResult" HeaderText="SearchResult"
                        AllowSorting="true" ShowSortIcon="true" AllowFiltering="false" Groupable="false"
                        Reorderable="false" Visible="true">
                        <HeaderStyle Width="3%" Font-Size="Small" />
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
            <asp:Label ID="Label1" runat="server" Visible="false" ForeColor="Red"></asp:Label>
         </div>

<%--<table role="presentation" width="100%">
    <tr>
        <td>
            <table role="presentation" width="90%">
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
                    </td>--%>


<%--                    <td>
                        <asp:CheckBox ID="chkFree" runat="server" Text="Free" Font-Size="X-Small" Width="20%" />
                        <asp:CheckBox ID="chkWeekend" runat="server" Text="Weekend" Font-Size="X-Small" Width="30%" />
                    </td>
                </tr>--%>
                
<%--            </table>
        </td>
    </tr>--%>



<%--    <tr>
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
</table>--%>
