<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="WhoIsOnline.aspx.cs" Inherits="Tourna.Backoffice.WhoIsOnline" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Who Is Online</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td class="GrayTitle">
                Who is Online?
            </td>
        </tr>
        <tr>
            <td class="GrayTextLight">
                There are currently
                <asp:Label ID="NumOnline" runat="server"></asp:Label>
                users logged on right now!
            </td>
        </tr>
    </table>
    <asp:GridView ID="CurrentUserActivityGrid" runat="server" AutoGenerateColumns="False"
        DataSourceID="CurrentActivityDataSource" GridLines="None" Width="95%" AlternatingRowStyle-CssClass="AlternatingRow"
        HeaderStyle-CssClass="HeaderStyle">
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="User" SortExpression="UserName" />
            <asp:BoundField DataField="Action" HeaderText="Action" SortExpression="Action" />
            <asp:TemplateField HeaderText="When" SortExpression="MinutesSinceAction">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("MinutesSinceAction") %>'></asp:Label>
                    minutes ago...
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
        </Columns>
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="CurrentActivityDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        SelectCommand="sproc_GetUsersCurrentActivity" SelectCommandType="StoredProcedure"
        OnSelecting="CurrentActivityDataSource_Selecting">
        <SelectParameters>
            <asp:Parameter Name="ApplicationName" Type="String" />
            <asp:Parameter Name="MinutesSinceLastInActive" Type="Int32" />
            <asp:Parameter Name="CurrentTimeUtc" Type="DateTime" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <br />
    <table style="width:50%">
        <tr>
            <td class="GrayTitle">
                User List
            </td>
        </tr>
        <tr>
            <td class="GrayTextLight">
                Here is a list of the user accounts in the system.
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" GridLines="None" AllowPaging="True" AutoGenerateColumns="False"
                    DataSourceID="allUsersDataSource" EmptyDataText="There are no users in the system..."
                    AlternatingRowStyle-CssClass="AlternatingRow" HeaderStyle-CssClass="HeaderStyle"  Width="100%">
                    <Columns>
                        <asp:BoundField DataField="UserName" HeaderText="UserName" ReadOnly="True" SortExpression="UserName" />
                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Email", "mailto:{0}") %>'
                                    Text='<%# Eval("Email") %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CreationDate" HeaderText="Created On" ReadOnly="True"
                            SortExpression="CreationDate" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="LastLoginDate" HeaderText="Last Login" SortExpression="LastLoginDate" DataFormatString="{0:d}" />
                    </Columns>
                    <EmptyDataRowStyle Font-Italic="True" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="allUsersDataSource" runat="server" SelectMethod="GetAllUsers"
        TypeName="System.Web.Security.Membership"></asp:ObjectDataSource>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
