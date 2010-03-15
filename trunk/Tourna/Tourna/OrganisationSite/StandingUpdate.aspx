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
            border: 3px solid black;
            font-size: 18px;
            background-color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; text-align: center">
        <tr>
            <td colspan="3">
                Click on the winner
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnPlayerA" runat="server" Width="150" Height="150" CssClass="player"
                    Text="Pini Usha" />
            </td>
            <td>
                vs.
            </td>
            <td>
            <asp:Button ID="btnPlayerB" runat="server" Width="150" Height="150" CssClass="player"
                    Text="Daniel Usha" />    
            </td>
        </tr>
    </table>
    Game details
    <table class="style2">
        <tr>
            <td colspan="4">
                <asp:Label ID="lblTournamentName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td rowspan="2">
                Pic A
            </td>
            <td>
                <asp:Label ID="lblPlayerA" runat="server"></asp:Label>
            </td>
            <td rowspan="2">
                Pic B
            </td>
            <td>
                <asp:Label ID="lblPlayerB" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDescriptionA" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblDescriptionB" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Score
            </td>
            <td>
                <telerik:RadNumericTextBox ID="rntbScoreA" runat="server" Culture="English (United States)"
                    DataType="System.Int32" ShowSpinButtons="true" MaxValue="30" MinValue="0" EmptyMessage="Enter the score"
                    Width="125px">
                    <NumberFormat DecimalDigits="0" />
                </telerik:RadNumericTextBox>
            </td>
            <td>
                Score
            </td>
            <td>
                <telerik:RadNumericTextBox ID="rntbScoreB" runat="server" Culture="English (United States)"
                    DataType="System.Int32" ShowSpinButtons="true" MaxValue="30" MinValue="0" EmptyMessage="Enter the score"
                    Width="125px">
                    <NumberFormat DecimalDigits="0" />
                </telerik:RadNumericTextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                I don&#39;t remember the score but i do remember<asp:RadioButtonList ID="rblPlayers"
                    runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                </asp:RadioButtonList>
                won.
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" /><br />
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                <asp:HyperLink ID="hlContactModerator" runat="server" Visible="False">Moderator</asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Content>
