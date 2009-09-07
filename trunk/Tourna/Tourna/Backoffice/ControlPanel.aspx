<%@ Page Title="Control Panel" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="ControlPanel.aspx.cs" Inherits="StrongerOrg.Backoffice.ControlPanel" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:GridView ID="OrgDataGrid" runat="server" AutoGenerateColumns="False" 
        DataSourceID="OrganisationSource" AllowSorting="True" DataKeyNames="Id" >
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" 
                ReadOnly="True"  />
            <asp:BoundField DataField="WebSite" HeaderText="WebSite" 
                SortExpression="WebSite" ReadOnly="True" />
            <asp:CheckBoxField DataField="Active" HeaderText="Active" 
                SortExpression="Active" ReadOnly="True" />
        </Columns>
        <EmptyDataTemplate>
            No Organization found.
        </EmptyDataTemplate>
    </asp:GridView>
      <asp:LinqDataSource ID="OrganisationSource" runat="server" 
        ContextTypeName="StrongerOrg.Backoffice.DataLayer.TournaDataContext" Select="new (Name, WebSite, Active, Players, Id)" 
        TableName="Organisations">
    </asp:LinqDataSource>
    <br />            
    <asp:GridView ID="TouranmentGrid" runat="server" AutoGenerateColumns="False" 
        DataSourceID="TournamentSource" DataKeyNames="Id">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="TournamentName" HeaderText="TournamentName" 
                SortExpression="TournamentName" />
            <asp:BoundField DataField="Count" HeaderText="Active Players" ReadOnly="True" 
                SortExpression="Id" />
        </Columns>
    </asp:GridView>
    <asp:LinqDataSource ID="TournamentSource" runat="server" 
        ContextTypeName="StrongerOrg.Backoffice.DataLayer.TournaDataContext" 
        TableName="Tournaments" 
        Where="OrganisationId == ((@Id == null)? Guid.Empty : Guid(@Id))" 
        onselecting="TournamentSource_Selecting" >
        <WhereParameters>
            <asp:ControlParameter ControlID="OrgDataGrid" DbType="Guid" 
                Name="Id" PropertyName="SelectedValue" DefaultValue="" />
        </WhereParameters>
    </asp:LinqDataSource>
    
    <br />
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
        DataKeyNames="Id" DataSourceID="TourneyDetails" Height="50px" 
        Width="125px" >
        <Fields>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" 
                SortExpression="Id" />
            <asp:BoundField DataField="OrganisationId" HeaderText="OrganisationId" 
                SortExpression="OrganisationId" />
            <asp:BoundField DataField="TournamentName" HeaderText="TournamentName" 
                SortExpression="TournamentName" />
            <asp:BoundField DataField="Abstract" HeaderText="Abstract" 
                SortExpression="Abstract" />
            <asp:BoundField DataField="Locations" HeaderText="Locations" 
                SortExpression="Locations" />
            <asp:BoundField DataField="NumberOfPlayersLimit" 
                HeaderText="NumberOfPlayersLimit" SortExpression="NumberOfPlayersLimit" />
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
            <asp:CheckBoxField DataField="IsApproved" HeaderText="IsApproved" 
                SortExpression="IsApproved" />
            <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" 
                SortExpression="DateCreated" />
        </Fields>
    </asp:DetailsView>
    <br />
    <asp:LinqDataSource ID="TourneyDetails" runat="server" 
        ContextTypeName="StrongerOrg.Backoffice.DataLayer.TournaDataContext" 
        EnableUpdate="true"
        TableName="Tournaments" Where="Id == ((@Id == null)? Guid.Empty : Guid(@Id))">
        <WhereParameters>
            <asp:ControlParameter ControlID="TouranmentGrid" DbType="Guid" Name="Id" 
                PropertyName="SelectedValue" />
        </WhereParameters>
    </asp:LinqDataSource>
    <br />
    <table >
    <tr>
        <td>
            <asp:Menu ID="navMenu"  runat="server" Orientation="Vertical" 
                BorderStyle="Dotted" BorderWidth="1px" 
                onmenuitemclick="navMenu_MenuItemClick" >
                <StaticSelectedStyle BackColor="#66CCFF" BorderStyle="Dotted" BorderWidth="1px" 
                    Font-Underline="True" ForeColor="Black" />
                <Items>
                    <asp:MenuItem  Text="Show Players" Value="0"></asp:MenuItem>
                    <asp:MenuItem  Value="1" Text="Show Pairs"></asp:MenuItem>
                    <asp:MenuItem  Text=" Schedule Games" Value="2"></asp:MenuItem>
                </Items>
            </asp:Menu>
        </td>
        <td>
            
            <asp:MultiView ID="PageView" runat="server">
                <asp:View ID="PlayersView" runat="server" onactivate="PlayersView_Activate">
                    <asp:GridView ID="playersGrid" runat="server">
                    </asp:GridView>
                </asp:View>
                <asp:View ID="PairView" runat="server" onactivate="PairView_Activate">
                    <asp:GridView ID="gvPairs" runat="server">
                        <EmptyDataTemplate>
                            No players were assigned to the tournament
                        </EmptyDataTemplate>
                    </asp:GridView>
                </asp:View>
                <asp:View ID="ScheduleView" runat="server" onactivate="ScheduleView_Activate">
                    <asp:PlaceHolder ID="schedulesPlaceHolder" runat="server">
                    </asp:PlaceHolder>        
                </asp:View>
            </asp:MultiView>
            
        </td>
    </tr>
    </table>
    
    <asp:HyperLink ID="hplPlayerCharts" runat="server" NavigateUrl="~/Backoffice/PlayersChart.aspx">Players Chart</asp:HyperLink>
    
</asp:Content>
