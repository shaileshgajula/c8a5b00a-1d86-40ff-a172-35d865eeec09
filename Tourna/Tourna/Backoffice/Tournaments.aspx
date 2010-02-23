<%@ Page Title="Tournaments" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master"
    AutoEventWireup="true" CodeBehind="Tournaments.aspx.cs" Inherits="StrongerOrg.Backoffice.Tournaments" %>
<%@ MasterType VirtualPath="~/Backoffice/BackOffice.Master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Backoffice/TournamentBuilder.aspx">Compose a new tournament</asp:HyperLink><br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id, TournamentName"
        DataSourceID="SqlDataSource1" 
        >
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Tournament.aspx?TournamentId={0}"
                DataTextField="Id" DataTextFormatString="Manage" HeaderText="" />
            <asp:BoundField DataField="TournamentName" HeaderText="Tournament Name" ReadOnly="True"
                SortExpression="TournamentName" />
            <asp:BoundField DataField="StartDate" HeaderText="Start Date" SortExpression="StartDate"
                DataFormatString="{0:d}" />
            <asp:BoundField DataField="Title" HeaderText="Game Title" SortExpression="Title" />
            <asp:BoundField DataField="NumberOfPlayersLimit" HeaderText="Limit" SortExpression="NumberOfPlayersLimit" />
            <asp:BoundField DataField="IsOpen" HeaderText="Open"/>
            <asp:HyperLinkField DataNavigateUrlFields="Id,TournamentName" DataNavigateUrlFormatString="OrganisationPlayers.aspx?TournamentId={0}&TournamentName={1}"
                DataTextField="RegisteredPlayers" HeaderText="Registered" />
            <asp:CommandField HeaderText="Del" ShowDeleteButton="True" DeleteText="Del" />
        </Columns>
        <EmptyDataTemplate>
            No Data Found
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
