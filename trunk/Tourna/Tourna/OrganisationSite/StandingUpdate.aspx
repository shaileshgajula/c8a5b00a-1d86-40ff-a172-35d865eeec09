<%@ Page Title="" Language="C#" MasterPageFile="~/OrganisationSite/OrgSite.Master"
    AutoEventWireup="true" CodeBehind="StandingUpdate.aspx.cs" Inherits="StrongerOrg.OrganisationSite.StandingUpdate"
    Theme="OrganisationSite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Update Game Score</title>
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        
        .player:hover
        {
            background-color: #cafde0;
            cursor: pointer;
        }
        .player
        {
            border: 2px solid black;
            font-size: 18px;
            background-color: white;
        }
        .playerSelected
        {
            border: 3px solid Orange;
            font-size: 18px;
            background-color: white;
            color:Black;
        }
        .playerNotSelected
        {
            border: 2px solid gray;
            font-size: 18px;
            background-color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 80%; text-align: center" align="center">
        <tr>
            <td colspan="3">
                Click on the winner
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnPlayerA" runat="server" Width="150" Height="150" CssClass="player"
                    Text="" OnClick="btnPlayer_Click" />
            </td>
            <td>
                vs.
            </td>
            <td>
                <asp:Button ID="btnPlayerB" runat="server" Width="150" Height="150" CssClass="player"
                    Text="" OnClick="btnPlayer_Click" />
            </td>
        </tr>
         <tr>
            <td colspan="3" style="height:70px">
                <asp:Label ID="lblUpdateMessage" runat="server" Text="" CssClass="AlertText"></asp:Label>
            </td>
        </tr>
    </table>
   <br /><br /><br />
    <asp:Panel ID="pnlGameDetails" runat="server">
        <asp:DetailsView ID="dvGameDetails" runat="server"  AutoGenerateRows="false"  >
        <HeaderTemplate>Game details</HeaderTemplate>
        
        <Fields>
            <asp:BoundField DataField="TournamentName" HeaderText="Tournament Name:" HeaderStyle-Font-Bold="true" />
            <asp:BoundField DataField="Round" HeaderText="Round:" HeaderStyle-Font-Bold="true" />
            <asp:BoundField DataField="Start" HeaderText="Start:" DataFormatString="{0:f}" HeaderStyle-Font-Bold="true" />
        </Fields>
    </asp:DetailsView>
    </asp:Panel>
    
</asp:Content>
