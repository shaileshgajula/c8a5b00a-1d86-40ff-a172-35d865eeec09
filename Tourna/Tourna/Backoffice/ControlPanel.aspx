<%@ Page Title="Control Panel" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master"
    AutoEventWireup="true" CodeBehind="ControlPanel.aspx.cs" Inherits="StrongerOrg.Backoffice.ControlPanel" %>

<%@ MasterType VirtualPath="~/Backoffice/BackOffice.Master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#format').buttonset();
        });
    </script>
    <div id="format" align="left">
        <a href="https://spreadsheets.google.com/ccc?key=0AnH0jDGOn2Z1dHFaQzFZaDBvYXZzWEdUejg3NjJteGc&hl=en"
            target="_blank">Open user spread sheet...</a> 
            <a href="playersChart.aspx">Competitors Chart</a>
        <asp:Button ID="btnImport" runat="server" Text="Import fake users from spread sheet"
            OnClick="btnImport_Click" />
    </div>
    <br />
    <br />
    Fake users(shared with all clients)
    <asp:GridView ID="GVcsv" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        DataSourceID="SqlDataSource1">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <%= (++i).ToString() + "." %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
        </Columns>
        <EmptyDataTemplate>
            <div id="Div1" class="ui-widget" runat="server">
                <div class="ui-state-highlight ui-corner-all" style="margin-top: 20px; padding: 0 .7em;">
                    <p>
                        <span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span>
                        <strong>Alert:</strong> No fake users have been found
                    </p>
                </div>
            </div>
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        SelectCommand="SELECT [Name], [Email], [Id] FROM [FakeUsers] ORDER BY [Name]">
    </asp:SqlDataSource>
</asp:Content>
