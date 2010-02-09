<%@ Page Title="Control Panel" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master"
    AutoEventWireup="true" CodeBehind="ControlPanel.aspx.cs" Inherits="StrongerOrg.Backoffice.ControlPanel" %>
<%@ MasterType VirtualPath="~/Backoffice/BackOffice.Master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:LinqDataSource ID="TournamentSource" runat="server" ContextTypeName="StrongerOrg.Backoffice.DataLayer.TournaDataContext"
        TableName="Tournaments" Select="new (TournamentName, Id)" OnSelecting="TournamentSource_Selecting">
    </asp:LinqDataSource>
    <br />
    <br />
    <br />
    <table style="border: thin dotted #0099FF; width: 100%">
        <tr>
            <td style="text-align: right">
                Select Tournament:
                <asp:DropDownList ID="drpDownTournamentList" runat="server" DataSourceID="TournamentSource"
                    DataTextField="TournamentName" DataValueField="Id" AutoPostBack="True" 
                    ondatabound="drpDownTournamentList_DataBound" 
                    onselectedindexchanged="drpDownTournamentList_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Menu ID="navMenu" runat="server" Orientation="Horizontal" BorderStyle="Dotted"
                    BorderWidth="1px" OnMenuItemClick="navMenu_MenuItemClick" Width="100%">
                    <StaticSelectedStyle BackColor="#F4F4F4" />
                    <Items>
                        <asp:MenuItem Text="Show Players" Value="0"></asp:MenuItem>
                        <asp:MenuItem Value="1" Text="Show Pairs"></asp:MenuItem>
                        <asp:MenuItem Text=" Scheduled Games" Value="2"></asp:MenuItem>
                    </Items>
                </asp:Menu>
            </td>
        </tr>
        <tr>
            <td>
                <asp:MultiView ID="PageView" runat="server" ActiveViewIndex="0">
                    <asp:View ID="PlayersView" runat="server">
                        Add <asp:TextBox ID="txtNumPlayer" runat="server" Height="21px" Width="36px" />
                        players <asp:LinkButton ID="lbtnAddPlayers" runat="server" Text="Add" 
                            OnClick="lbtnAddPlayers_Click" />
                        <br />
                        <table style="width: 100%">
                            <tr>
                                <td style="text-align: right">
                                    Number of Players:
                                    <asp:Label ID="lblNumOfPlayers" Text="0" Font-Bold="true" runat="server" />
                                    <asp:LinkButton ID="lbtnPlayersExport" Text="Export" runat="server" OnClick="lbtnPlayersExport_Click" />
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="playersGrid" runat="server">
                                        <EmptyDataTemplate>
                                            No players were assigned to the tournament
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="PairView" runat="server">
                        <table>
                            <tr>
                                <td>
                                    Player Matching:
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpPairAlgo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpPairAlgo_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Pairing:
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpPairing" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpPairing_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblMultiGame" Text="Number of Games:" runat="server" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMultiGame" runat="server" Text="1" Height="21px" 
                                        Width="36px" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="lbtnPairUp" runat="server" Text="Pair" 
                                        OnClick="lbtnPairUp_Click" />
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%">
                            <tr>
                                <td style="text-align: right">
                                    Number of Games:
                                    <asp:Label ID="lblNumActiveGames" runat="server" Font-Bold="true" />
                                    <asp:LinkButton ID="lBtnSave" Text="Save" runat="server" 
                                        onclick="lBtnSave_Click"  />
                                    <asp:LinkButton ID="lbtnPairsExport" Text="Export" runat="server" OnClick="lbtnPairsExport_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="pairGrid" runat="server">
                                        <EmptyDataTemplate>
                                            No players were assigned to the tournament
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="ScheduleView" runat="server">
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Menu ID="schedMenu" runat="server" Width="100%" Orientation="Horizontal" OnMenuItemClick="schedMenu_MenuItemClick">
                                        <StaticSelectedStyle BackColor="#F4F4F4" />
                                        <Items>
                                            <asp:MenuItem Text="Calendar View" Value="0"></asp:MenuItem>
                                            <asp:MenuItem Text="Grid View" Value="1"></asp:MenuItem>
                                        </Items>
                                    </asp:Menu>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lbtnForceReschedule" runat="server" Text="Run scheduler" 
                                        onclick="lbtnForceReschedule_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:MultiView ID="scheduleMultiView" runat="server" ActiveViewIndex="0">
                                        <asp:View runat="server" ID="schedCalendarView">
                                            <asp:PlaceHolder ID="schedulesPlaceHolder" runat="server"></asp:PlaceHolder>
                                        </asp:View>
                                        <asp:View runat="server" ID="schedGridView">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="text-align:right">
                                                        <asp:LinkButton ID="lbtnExportSchedules" Text="Export" runat="server" onclick="lbtnExportSchedules_Click"
                                                         />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="schedDatesGrid" runat="server">
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                    </asp:MultiView>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
    <asp:HyperLink ID="hplPlayerCharts" runat="server" NavigateUrl="~/Backoffice/PlayersChart.aspx">Players Chart</asp:HyperLink>
</asp:Content>
