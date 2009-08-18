<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="Tournaments.aspx.cs" Inherits="Tourna.Backoffice.Tournaments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Tournaments</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Label ID="lblTitle" runat="server" Text="Tournaments" CssClass="GrayTitle"></asp:Label>
<br/><br/>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        DataSourceID="SqlDataSource1" GridLines="None" Width="100%" AlternatingRowStyle-CssClass="AlternatingRow" HeaderStyle-CssClass="HeaderStyle">
        <Columns>
            <asp:BoundField DataField="TournamentName" HeaderText="TournamentName" ReadOnly="True"
                SortExpression="TournamentName" />
            <asp:BoundField DataField="StartDate" HeaderText="StartDate" SortExpression="StartDate" DataFormatString="{0:d}" />
            <asp:BoundField DataField="Title" HeaderText="Game Title" SortExpression="Title" />
            <asp:BoundField DataField="NumberOfPlayersLimit" HeaderText="Players Limit" SortExpression="NumberOfPlayersLimit" />
            <asp:HyperLinkField DataNavigateUrlFields="Id,TournamentName" DataNavigateUrlFormatString="OrganisationPlayers.aspx?TournamentId={0}&TournamentName={1}"
                DataTextField="RegisteredPlayers" HeaderText="Tournament Players" />
            <asp:HyperLinkField Text="Edit" />
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Backoffice/Schedules.aspx?TournamentId={0}"
                HeaderImageUrl="~/Images/Icons/scheduler.gif" HeaderText="Scheduales" Text="Scheduale" />
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Backoffice/Standings.aspx?TournamentId={0}"
                HeaderText="Standings" Text="Standing" />
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Backoffice/InvitToTournament.aspx?TournamentId={0}"
                HeaderText="Invite" Text="Invite" />
            <asp:CommandField HeaderText="Del" ShowDeleteButton="True" DeleteText="Del" />
        </Columns>
        <EmptyDataTemplate>
            No Data Found
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        DeleteCommand="DELETE FROM [Tournaments] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Tournaments] ([Id], [TournamentName], [Abstract]) VALUES (@Id, @TournamentName, @Abstract)"
        SelectCommand="TournamentsGet" UpdateCommand="UPDATE [Tournaments] SET [TournamentName] = @TournamentName, [Abstract] = @Abstract WHERE [Id] = @Id"
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ProfileParameter Name="OrganisationId" PropertyName="OrganisationId" Type="String" />
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
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Backoffice/TournamentBuilder.aspx">Compose a new tournament</asp:HyperLink>
</asp:Content>
