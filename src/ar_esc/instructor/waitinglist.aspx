<%@ Page Language="C#" AutoEventWireup="true" CodeFile="waitinglist.aspx.cs" Inherits="instructor_waitinglist"
    MasterPageFile="~/masterpage.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="mainBody">
    <table cellspacing="2" cellpadding="4" width="100%">
        <tr>
            <td align="center" style="height: 59px">
                <table cellpadding="2" cellspacing="2" border="0">
                    <tr>
                        <td>
                            <img src="../lib/img/waitinglist.gif" />
                        </td>
                        <td class="FormInput" style="vertical-align: bottom; color: #343434;">
                            <b>Waiting List Manager</b>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gridWaitingList" runat="server" BackColor="White" BorderColor="#999999"
                    BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Font-Size="8pt"
                    Font-Color="#343434" AutoGenerateColumns="False" PageSize="5" RowStyle-HorizontalAlign="Left">
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black"></FooterStyle>
                    <Columns>
                        <asp:BoundField DataField="TimeStamp" HeaderText="Date/Time"></asp:BoundField>
                        <asp:BoundField DataField="Name" HeaderText="Name"></asp:BoundField>
                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <a href='mailto:<%# DataBinder.Eval(Container.DataItem,"Email") %>' class="PageLink">
                                    <%# DataBinder.Eval(Container.DataItem,"Email") %></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CheckBoxField ReadOnly="True" DataField="IsNotified" HeaderText="Notified?">
                        </asp:CheckBoxField>
                        <asp:CheckBoxField ReadOnly="True" DataField="Deleted" HeaderText="Deleted?">
                        </asp:CheckBoxField>
                        <asp:BoundField DataField="NotifiedTimeStamp" HeaderText="Notified Timestamp"></asp:BoundField>
                        <asp:TemplateField HeaderText="Registration Code">
                            <ItemTemplate>
                                <%# FormatRegistrationCode(DataBinder.Eval(Container.DataItem, "SessionID").ToString(), DataBinder.Eval(Container.DataItem, "Key").ToString(), DataBinder.Eval(Container.DataItem, "RegCode").ToString())%></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black"></RowStyle>
                    <EmptyDataTemplate>
                        Waiting List is empty for session
                        <%# this.SessionID %>.
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#008A8C" ForeColor="White" Font-Bold="True"></SelectedRowStyle>
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center"></PagerStyle>
                    <HeaderStyle BackColor="#000084" ForeColor="White" Font-Bold="True"></HeaderStyle>
                    <AlternatingRowStyle BackColor="Gainsboro"></AlternatingRowStyle>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <center>
                    <font size="1" color="red">
                        <asp:Label ID="lblViewMessage" runat="Server" /></font></center>
            </td>
        </tr>
    </table>
</asp:Content>
