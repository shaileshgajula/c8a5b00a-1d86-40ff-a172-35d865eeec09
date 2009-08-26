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
    <table class="style1">
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
    </table>
    <asp:GridView ID="gvPairs" runat="server">
        <EmptyDataTemplate>
            No players were assigned to the tournament</EmptyDataTemplate>
            
    </asp:GridView>
    <asp:LinkButton ID="lbScheduleGames" runat="server" 
    onclick="lbScheduleGames_Click">Schedule games</asp:LinkButton>
    <br />
    <asp:PlaceHolder ID="schedulesPlaceHolder" runat="server">
    </asp:PlaceHolder>
</asp:Content>
