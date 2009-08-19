<%@ Page Title="" Language="C#" MasterPageFile="~/OrganisationSite/OrgSite.Master"
    AutoEventWireup="true" CodeBehind="StandingUpdate.aspx.cs" Inherits="StrongerOrg.OrganisationSite.StandingUpdate" Theme="OrganisationSite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Update Game Score</title>
<style type="text/css">
    .style2
    {
        width: 100%;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="style2">
    <tr>
        <td colspan="4">
            <asp:Label ID="lblTournamentName" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td rowspan="2">
            Pic A</td>
        <td>
            <asp:Label ID="lblPlayerA" runat="server"></asp:Label>
        </td>
        <td rowspan="2">
            Pic B</td>
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
            Score</td>
        <td>
            <telerik:RadNumericTextBox ID="rntbScoreA" Runat="server" 
                Culture="English (United States)" DataType="System.Int32" ShowSpinButtons="true" MaxValue="3" MinValue="0" EmptyMessage="Enter the score"
                Width="125px">
                <NumberFormat DecimalDigits="0" />
            </telerik:RadNumericTextBox>
        </td>
        <td>
            Score</td>
        <td>
            <telerik:RadNumericTextBox ID="rntbScoreB" Runat="server" 
                Culture="English (United States)" DataType="System.Int32" ShowSpinButtons="true" MaxValue="3" MinValue="0" EmptyMessage="Enter the score" 
                Width="125px">
                <NumberFormat DecimalDigits="0" />
            </telerik:RadNumericTextBox>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            I don&#39;t remember the score but i do remember<asp:RadioButtonList 
                ID="rblPlayers" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
            </asp:RadioButtonList> won.</td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                onclick="btnUpdate_Click" /><br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <asp:HyperLink ID="hlContactModerator" runat="server" Visible="False">Moderator</asp:HyperLink>
        </td>
    </tr>
</table>

</asp:Content>
