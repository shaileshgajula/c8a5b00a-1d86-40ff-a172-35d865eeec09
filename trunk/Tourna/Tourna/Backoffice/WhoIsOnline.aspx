<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="WhoIsOnline.aspx.cs" Inherits="Tourna.Backoffice.WhoIsOnline" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Who Is Online</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Who is Online?</h2>
    <p>There are currently
    <asp:Label ID="NumOnline" runat="server"></asp:Label>
    users logged on right now!
    </p>
    <asp:GridView ID="CurrentUserActivityGrid" runat="server" AutoGenerateColumns="False"
        CellPadding="4" DataSourceID="CurrentActivityDataSource" ForeColor="#333333"
        GridLines="None" Width="95%">
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
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
        SelectCommand="sproc_GetUsersCurrentActivity" 
    SelectCommandType="StoredProcedure" 
    onselecting="CurrentActivityDataSource_Selecting">
        <SelectParameters>
            <asp:Parameter Name="ApplicationName" Type="String" />
            <asp:Parameter Name="MinutesSinceLastInActive" Type="Int32" />
            <asp:Parameter Name="CurrentTimeUtc" Type="DateTime" />
        </SelectParameters>
    </asp:SqlDataSource>
    
    <h2>
        User List</h2>
    <p>
        Here is a list of the user accounts in the system.</p>
    <p>
        <asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84"
            BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Font-Names="Verdana" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="allUsersDataSource" EmptyDataText="There are no users in the system..." Font-Italic="False">
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="UserName" ReadOnly="True" SortExpression="UserName" />
                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Email", "mailto:{0}") %>'
                            Text='<%# Eval("Email") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CreationDate" HeaderText="Created On" ReadOnly="True"
                    SortExpression="CreationDate" />
                <asp:BoundField DataField="LastLoginDate" HeaderText="Last Login" SortExpression="LastLoginDate" />
            </Columns>
            <EmptyDataRowStyle Font-Italic="True" />
        </asp:GridView>
        <asp:ObjectDataSource ID="allUsersDataSource" runat="server" SelectMethod="GetAllUsers" TypeName="System.Web.Security.Membership"></asp:ObjectDataSource>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
