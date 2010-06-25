<%@ Page Title="" Language="C#" MasterPageFile="~/OrganisationSite/OrgSite.Master"
    AutoEventWireup="true" CodeBehind="BracketsView.aspx.cs" Inherits="StrongerOrg.OrganisationSite.BracketsView"
    Theme="OrganisationSite" %>

<%@ Register Src="../Backoffice/UserControls/BracketsDisplay.ascx" TagName="BracketsDisplay"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <ul class="lavaLampBottomStyle" id="M1">
        <li></li>
        <li><a href="ContactModerator.aspx?orgId=<%= Request.QueryString["OrgId"].ToString()%>">
            Contact Moderator</a></li>
        <li><a href="Rules.aspx?orgId=<%= Request.QueryString["OrgId"].ToString() %>">Rules</a></li>
        <li><a href="EventGallery.aspx?orgId=<%= Request.QueryString["OrgId"].ToString() %>">
            Event Gallery</a></li>
        <li class="current"><a href="Leagues.aspx?orgId=<%= Request.QueryString["OrgId"].ToString() %>">
            Tournaments</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="0" align="right" style="width: 100%">
        <tr>
            <td style="font-size: 22px; color: #E74194; font-weight: bold">
                <asp:Label ID="lblTournamentTitle" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="width: 150px; text-align: right">
                <a href="Leagues.aspx?orgId=<%= Request.QueryString["OrgId"].ToString() %>">
                    <img src="../Images/Icons/listIcon.jpeg" alt="Tournaments list" title="Tournaments list"
                        border="0" style="vertical-align: top;" />
                    Tournament list</a>
            </td>
            <td style="width: 5px; text-align: right">
                <img src="../Images/Icons/Seperator.gif" />
            </td>
            <td style="width: 90px; text-align: center">
                <a href="Schedules.aspx?OrgId=<%= Request.QueryString["OrgId"].ToString() %>&TournamentId=<%= Request.QueryString["TournamentId"].ToString() %>">
                    <img src="../Images/Icons/grid_icon.gif" alt="Grid View" title="Grid View" border="0"
                        style="vertical-align: top;" />
                    Grid View</a>
            </td>
            <td style="width: 5px; text-align: right">
                <img src="../Images/Icons/Seperator.gif" />
            </td>
            <td style="width: 60px; text-align: right">
                <a href="PrintBrackets.aspx?TournamentId=<%= Request.QueryString["TournamentId"].ToString() %>"
                    target="_blank">
                    <img src="../Images/Icons/PrinterIcon.gif" alt="Print" title="Print" border="0" style="vertical-align: top;" />
                    Print</a>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <uc1:BracketsDisplay ID="BracketsDisplay1" runat="server" />
</asp:Content>
