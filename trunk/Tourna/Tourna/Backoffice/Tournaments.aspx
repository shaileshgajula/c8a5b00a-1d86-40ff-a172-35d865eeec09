<%@ Page Title="Tournaments" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master"
    AutoEventWireup="true" CodeBehind="Tournaments.aspx.cs" Inherits="StrongerOrg.Backoffice.Tournaments" %>

<%@ MasterType VirtualPath="~/Backoffice/BackOffice.Master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Backoffice/TournamentBuilder.aspx">+ Compose a new tournament</asp:HyperLink><br />
    &nbsp
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id, TournamentName"
        DataSourceID="SqlDataSource1" OnRowCreated="GridView1_RowCreated">
        <Columns>
            <asp:TemplateField HeaderText="Tournament Name">
                <ItemTemplate>
                    <asp:HyperLink ID="hlTournament" runat="server" NavigateUrl='<%# BuildNavigationLink(Eval("Mode"), Eval("Id")) %>'><%#Eval("TournamentName")%></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="LastRegistrationDate" HeaderText="Last Registration" DataFormatString="{0:D}" />
            <asp:BoundField DataField="StartDate" HeaderText="Start Date" SortExpression="StartDate"
                DataFormatString="{0:D}" />
            <asp:BoundField DataField="Title" HeaderText="Game Title" SortExpression="Title" />
            <asp:BoundField DataField="NumberOfPlayersLimit" HeaderText="Limit" SortExpression="NumberOfPlayersLimit" />
            <asp:HyperLinkField DataNavigateUrlFields="Id,TournamentName,Mode" DataNavigateUrlFormatString="OrganisationPlayers.aspx?TournamentId={0}&TournamentName={1}&Mode={2}"
                DataTextField="RegisteredPlayers" HeaderText="Registered" />
            <asp:TemplateField HeaderText="Mode" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <img src='<%# GetCompetitorType(Eval("Mode")) %>' />
                </ItemTemplate>
            </asp:TemplateField>
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
                        <strong>Alert:</strong> No tournaments have been found.
                    </p>
                </div>
            </div>
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        DeleteCommand="DELETE FROM [Tournaments] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Tournaments] ([Id], [TournamentName], [Abstract]) VALUES (@Id, @TournamentName, @Abstract)"
        SelectCommand="TournamentsGet" UpdateCommand="UPDATE [Tournaments] SET [TournamentName] = @TournamentName, [Abstract] = @Abstract WHERE [Id] = @Id"
        SelectCommandType="StoredProcedure" CancelSelectOnNullParameter="false">
        <SelectParameters>
            <asp:CookieParameter CookieName="OrganisationId" Name="OrganisationId" Type="String" />
            <asp:Parameter Name="TournamentId" Type="String" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Object" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="TournamentName" Type="String" />
            <asp:Parameter Name="Abstract" Type="String" />
            <asp:Parameter Name="Id" Type="Object" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="Id" Type="Object" />
            <asp:Parameter Name="TournamentName" Type="String" />
            <asp:Parameter Name="Abstract" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>
