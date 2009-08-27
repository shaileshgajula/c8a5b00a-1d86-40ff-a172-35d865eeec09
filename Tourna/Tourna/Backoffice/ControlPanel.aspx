<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="ControlPanel.aspx.cs" Inherits="StrongerOrg.Backoffice.ControlPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Control Panel</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:GridView ID="OrgDataGrid" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="false"
        DataKeyNames="Id,Name" DataSourceID="OrganizationDataSource" >
        <Columns>
            <asp:CommandField ShowSelectButton="True" SelectText="Select" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"  />
            <asp:BoundField DataField="WebSite" HeaderText="Web Site" SortExpression="WebSite" />
            <asp:CheckBoxField DataField="Active" HeaderText="Active" SortExpression="Active" />
        </Columns>
        <EmptyDataTemplate>
            No Organization found.
        </EmptyDataTemplate>
    </asp:GridView>
      <asp:SqlDataSource ID="OrganizationDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        SelectCommand="GetOrganisations" SelectCommandType="StoredProcedure" CancelSelectOnNullParameter="False">
        <SelectParameters>
            <asp:QueryStringParameter Name="Id" QueryStringField="OrgId" Type="String" ConvertEmptyStringToNull="true" />
        </SelectParameters>
      </asp:SqlDataSource>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource3">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="TournamentName" HeaderText="TournamentName" 
                SortExpression="TournamentName" />
            <asp:BoundField DataField="NumberOfPlayersLimit" 
                HeaderText="NumberOfPlayersLimit" SortExpression="NumberOfPlayersLimit" />
            <asp:BoundField DataField="StartDate" HeaderText="StartDate" 
                SortExpression="StartDate" />
            <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" 
                SortExpression="DateCreated" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>" 
        SelectCommand="SELECT [TournamentName], [NumberOfPlayersLimit], [StartDate], [DateCreated] FROM [Tournaments] WHERE ([OrganisationId] = @OrganisationId)">
        <SelectParameters>
            <asp:ControlParameter ControlID="OrgDataGrid" Name="OrganisationId" 
                PropertyName="SelectedValue" Type="Object" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
        DataKeyNames="Id" DataSourceID="SqlDataSource4" Height="50px" Width="125px">
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
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
        ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>" 
        SelectCommand="SELECT * FROM [Tournaments]"></asp:SqlDataSource>
    <br />
    
    <!--table class="style1">
        <tr>
            <td>
                Select
            </td>
            <td>
                <asp:DropDownList ID="ddlOrganisations" runat="server" DataSourceID="SqlDataSource1"
                    DataTextField="Name" DataValueField="Id" AutoPostBack="True">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
                    SelectCommand="GetOrganisations" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td>
                Organisations
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Select Tournament
            </td>
            <td>
                <asp:DropDownList ID="ddlTournament" runat="server" DataSourceID="SqlDataSource2"
                    DataTextField="TournamentName" DataValueField="Id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
                    SelectCommand="TournamentsGet" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlOrganisations" DbType="String" Name="OrganisationId"
                            PropertyName="SelectedValue" ConvertEmptyStringToNull="true" DefaultValue="a484d7d5-9195-4241-805e-03f50382c0a2" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:LinkButton ID="lblDeletePlayers" runat="server" OnClick="lblDeletePlayers_Click"
                    OnClientClick="return confirm('Are you certain you want to delete all tournament players?')"
                    ToolTip="Delete all users in tournament">Delete</asp:LinkButton>
                <br />
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Show pairs</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                Create
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" Width="50px">32</asp:TextBox>
            </td>
            <td>
                Players
            </td>
            <td>
                <asp:LinkButton ID="lblCreatePlayers" runat="server" OnClick="LinkButton3_Click"
                    ToolTip="Create Players">Create</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Backoffice/PlayersChart.aspx">Players Chart For All Companies</asp:HyperLink>
            </td>
            <td colspan="3">
                <asp:Label ID="lblMsg" runat="server" CssClass="title"></asp:Label>
            </td>
        </tr>
    </table-->
    
    <asp:GridView ID="gvPairs" runat="server">
        <EmptyDataTemplate>
            No players were assigned to the tournament</EmptyDataTemplate>
    </asp:GridView>
    <table>
    <tr>
        <td>
            <asp:LinkButton ID="lbShowPairs" runat="server" OnClick="LinkButton1_Click">Show pairs</asp:LinkButton>
        </td>
        <td>
            <asp:LinkButton ID="lbScheduleGames" runat="server" 
            onclick="lbScheduleGames_Click">Schedule games</asp:LinkButton>
        </td>
        <td>
            <asp:HyperLink ID="hplPlayerCharts" runat="server" NavigateUrl="~/Backoffice/PlayersChart.aspx">Players Chart</asp:HyperLink>
        </td>
    </tr>
    </table>
    <br />
    <asp:PlaceHolder ID="schedulesPlaceHolder" runat="server">
    </asp:PlaceHolder>
</asp:Content>
