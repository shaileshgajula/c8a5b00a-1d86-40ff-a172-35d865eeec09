<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TournamentDetails.ascx.cs"
    Inherits="StrongerOrg.Backoffice.UserControls.TournamentDetails" %>
<asp:DetailsView ID="DetailsView1" runat="server" DataKeyNames="Id" 
    DataSourceID="SqlDataSource1" AutoGenerateRows="False" 
    EnableModelValidation="True" >
    <Fields>
        
        <asp:BoundField DataField="TournamentName" HeaderText="TournamentName" 
            SortExpression="TournamentName" />
        <asp:BoundField DataField="Abstract" HeaderText="Abstract" SortExpression="Abstract" />
        <asp:BoundField DataField="Locations" HeaderText="Locations" SortExpression="Locations" />
        <asp:BoundField DataField="NumberOfPlayersLimit" HeaderText="NumberOfPlayersLimit"
            SortExpression="NumberOfPlayersLimit" />
        <asp:BoundField DataField="GameId" HeaderText="GameId" 
            SortExpression="GameId" />
        <asp:BoundField DataField="MatchingAlgo" HeaderText="MatchingAlgo" 
            SortExpression="MatchingAlgo" />
        <asp:BoundField DataField="TimeWindowStart" HeaderText="TimeWindowStart" 
            SortExpression="TimeWindowStart" />
        <asp:BoundField DataField="TimeWindowEnd" HeaderText="TimeWindowEnd" 
            SortExpression="TimeWindowEnd" />
        <asp:CheckBoxField DataField="IsOpenAllDay" HeaderText="IsOpenAllDay" 
            SortExpression="IsOpenAllDay" />
        <asp:BoundField DataField="FirstPrize" HeaderText="FirstPrize" 
            SortExpression="FirstPrize" />
        <asp:BoundField DataField="SecondPrize" HeaderText="SecondPrize" 
            SortExpression="SecondPrize" />
        <asp:BoundField DataField="ThirdPrize" HeaderText="ThirdPrize" 
            SortExpression="ThirdPrize" />
        
        <asp:BoundField DataField="StartDate" HeaderText="StartDate" 
            SortExpression="StartDate" />
        <asp:BoundField DataField="EmailTemplate" HeaderText="EmailTemplate" 
            SortExpression="EmailTemplate" />
        <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" 
            SortExpression="DateCreated" />
        <asp:CheckBoxField DataField="IsOpen" HeaderText="IsOpen" 
            SortExpression="IsOpen" />
    </Fields>
</asp:DetailsView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
    SelectCommand="SELECT * FROM [Tournaments] WHERE ([Id] = @Id)">
    <SelectParameters>
        <asp:QueryStringParameter Name="Id" QueryStringField="TournamentId" 
            Type="String" />
    </SelectParameters>
</asp:SqlDataSource>
