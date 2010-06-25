<%@ Page Title="Competitors" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master"
    AutoEventWireup="true" CodeBehind="OrganisationPlayers.aspx.cs" Inherits="StrongerOrg.Backoffice.OrganisationPlayers" %>

<%@ MasterType VirtualPath="~/Backoffice/BackOffice.Master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblTitle" runat="server" Text="" CssClass="GrayTitle"></asp:Label>
    <asp:Image ID="imgCompetitorMode" runat="server" Style="padding: 5px; vertical-align: middle" /><asp:HyperLink
        ID="hlTournamentTitle" runat="server"></asp:HyperLink>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="Id" DataSourceID="SqlDataSource1" PageSize="20" OnRowCreated="GridView1_RowCreated">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <%# i++ %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="true" HeaderText="Edit" />
            <asp:HyperLinkField HeaderText="Name" DataTextField="Name" DataNavigateUrlFormatString="~/Backoffice/TeamPlayers.aspx?TeamId={0}"
                DataNavigateUrlFields="Id" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="CreateDate" HeaderText="CreateDate"  ReadOnly="True" DataFormatString="{0:f}" />
            <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center">
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Icons/trash.gif"
                        CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete')" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <div id="Div1" class="ui-widget" runat="server">
                <div class="ui-state-highlight ui-corner-all" style="margin-top: 20px; padding: 0 .7em;">
                    <p>
                        <span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span>
                        <strong>Alert:</strong> No Competitor found.
                    </p>
                </div>
            </div>
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        DeleteCommand="DELETE FROM [Players] WHERE [Id] = @Id;Delete from Players2Tournaments where playerId=@Id"
        InsertCommand="INSERT INTO [Players] ([Name], [Email], [CompetitorType], [Department], [Id]) VALUES (@Name, @Email, @CompetitorType, @Department, @Id)"
        SelectCommand="PlayersGet" SelectCommandType="StoredProcedure" CancelSelectOnNullParameter="false"
        UpdateCommand="UPDATE [Players] SET [Name] = @Name, [Email] = @Email, [CompetitorType] = @CompetitorType, [Department] = @Department WHERE [Id] = @Id">
        <SelectParameters>
            <asp:CookieParameter Name="OrganisationId" CookieName="OrganisationId" Type="String" />
            <asp:QueryStringParameter Name="TournamentId" ConvertEmptyStringToNull="true" QueryStringField="TournamentId"
                Direction="Input" DbType="String" />
            <asp:QueryStringParameter Name="CompetitorType" ConvertEmptyStringToNull="true" QueryStringField="Mode"
                Direction="Input" DbType="String" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Object" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="CompetitorType" Type="String" />
            <asp:Parameter Name="Department" Type="String" />
            <asp:Parameter Name="Id" Type="Object" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="CompetitorType" Type="String" />
            <asp:Parameter Name="Department" Type="String" />
            <asp:Parameter Name="Id" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>
