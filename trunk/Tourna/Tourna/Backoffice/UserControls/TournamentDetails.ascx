<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TournamentDetails.ascx.cs"
    Inherits="StrongerOrg.Backoffice.UserControls.TournamentDetails" %>
<asp:DetailsView ID="DetailsView1" runat="server" DataKeyNames="Id" DataSourceID="SqlDataSource1">
    <Fields>
        <asp:BoundField DataField="TournamentName" HeaderText="TournamentName" SortExpression="TournamentName" HeaderStyle-Width="200px"  />
        <asp:BoundField DataField="Abstract" HeaderText="Abstract" SortExpression="Abstract" />
        <asp:BoundField DataField="Locations" HeaderText="Locations" SortExpression="Locations" />
        <asp:BoundField DataField="NumberOfPlayersLimit" HeaderText="NumberOfPlayersLimit"
            SortExpression="NumberOfPlayersLimit" />
        <asp:BoundField DataField="GameId" HeaderText="GameId" SortExpression="GameId" />
        <asp:BoundField DataField="MatchingAlgo" HeaderText="MatchingAlgo" SortExpression="MatchingAlgo" />
        <asp:BoundField DataField="TimeWindowStart" HeaderText="TimeWindowStart" SortExpression="TimeWindowStart" />
        <asp:BoundField DataField="TimeWindowEnd" HeaderText="TimeWindowEnd" SortExpression="TimeWindowEnd" />
        <asp:CheckBoxField DataField="IsOpenAllDay" HeaderText="IsOpenAllDay" SortExpression="IsOpenAllDay" />
        <asp:BoundField DataField="FirstPrize" HeaderText="FirstPrize" SortExpression="FirstPrize" />
        <asp:BoundField DataField="SecondPrize" HeaderText="SecondPrize" SortExpression="SecondPrize" />
        <asp:BoundField DataField="ThirdPrize" HeaderText="ThirdPrize" SortExpression="Third Prize" />
        <asp:BoundField DataField="StartDate" HeaderText="StartDate" SortExpression="Start Date" />
        <asp:TemplateField HeaderStyle-VerticalAlign="Top">
            <HeaderTemplate>
                Email Invitation [<asp:HyperLink ID="hlEditEmailInvitation" NavigateUrl='<%# Eval("Id", "~/Backoffice/InvitToTournament.aspx?TournamentId={0}" ) %>' runat="server">Edit</asp:HyperLink>]
                </HeaderTemplate>
            <ItemTemplate>
                <%#Eval("EmailTemplate")%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated" />
    </Fields>
</asp:DetailsView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
    SelectCommand="SELECT * FROM [Tournaments] WHERE ([Id] = @Id)">
    <SelectParameters>
        <asp:ControlParameter ControlID="GridView1" Name="Id" PropertyName="SelectedValue"
            Type="Object" />
    </SelectParameters>
</asp:SqlDataSource>
