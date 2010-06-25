<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FakeUsers.ascx.cs" Inherits="StrongerOrg.Backoffice.UserControls.FakeUsers" %>
<script type="text/javascript">
    $(function () {
        $('.CheckAll').click(function () {
            $(':checkbox').attr('checked', true);
            return false;
        });
        $('#<%= this.btnCleanPlayers.ClientID %>').click(function () { return confirm('Are you sure you want to delete all tournament players, matchups and scores'); })
        $('.UnCheckAll').click(function () {
            $(':checkbox').attr('checked', false);
            return false;
        });
        $('#format').buttonset();
        if ($(".Alert1").text() == "")
            $("div.ui-widget").hide();
        else {
            $("div.ui-widget").show();
        }
    });
</script>
<table border="0" cellpadding="10" cellspacing="0">
    <tr>
        <td>
            <div id="format" align="right">
                <asp:Button runat="server" ID="btnMatchUpPlayers" Text="Matchup Players" OnClick="btnMatchUpPlayers_Click" />
                <asp:Button ID="btnCleanPlayers" runat="server" Text="Remove tournaments Players..."
                    OnClick="btnCleanPlayers_Click" />
                <asp:Button ID="btnClearMatchups" runat="server" Text="Remove matchups" OnClick="btnClearMatchups_Click" />
                <asp:Button ID="btnRemovePlayers2Tournaments" runat="server" Text="Remove Players 2 Tournaments" OnClick="btnRemovePlayers2Tournaments_Click" />
                <asp:Button ID="btnNotifyPlayers" runat="server" Text="Notify players" OnClick="btnNotifyPlayers_Click" />
            </div>
        </td>
        <td>
            <div id="Div1" class="ui-widget" runat="server">
                <div class="ui-state-highlight ui-corner-all" style="margin-top: 0px; padding: 0 .7em;
                    height: 40px">
                    <span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em; margin-top: 5px">
                    </span>
                    <asp:Label ID="lblMsg" runat="server" Text="" CssClass="Alert1"></asp:Label>
                </div>
            </div>
        </td>
    </tr>
</table>
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
    <tr>
        <td>
            Select <b>Fake Users</b>: <a class="CheckAll" href="#">All</a>, <a class="UnCheckAll"
                href="#">None</a>
        </td>
   
        <td style="text-align:right">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lbBindToTournament_Click">Register to tournament</asp:LinkButton></div>
        </td>
    </tr>
</table>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
    DataSourceID="SqlDataSource1" EnableModelValidation="True" OnRowCreated="GridView1_RowCreated">
    <Columns>
        <asp:TemplateField>
            <ItemStyle Width="20px" />
            <HeaderTemplate>
                #</HeaderTemplate>
            <ItemTemplate>
                <%= i++ %>.
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemStyle HorizontalAlign="Center" />
            <ItemTemplate>
                <asp:CheckBox ID="cbItem" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
        <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center">
            <ItemStyle HorizontalAlign="Center" />
            <ItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Icons/trash.gif"
                    CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete')" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<br />
<div class="ThemeBorder" style="width: 100%; text-align: right">
    <asp:LinkButton ID="lbBindToTournament" runat="server" OnClick="lbBindToTournament_Click">Register to tournament</asp:LinkButton></div>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
    DeleteCommand="DELETE FROM [FakeUsers] WHERE [Id] = @Id" InsertCommand="INSERT INTO [FakeUsers] ([Name], [Email]) VALUES (@Name, @Email)"
    SelectCommand="SELECT * FROM [FakeUsers]" UpdateCommand="UPDATE [FakeUsers] SET [Name] = @Name, [Email] = @Email WHERE [Id] = @Id">
    <DeleteParameters>
        <asp:Parameter Name="Id" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="Name" Type="String" />
        <asp:Parameter Name="Email" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="Name" Type="String" />
        <asp:Parameter Name="Email" Type="String" />
        <asp:Parameter Name="Id" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>
