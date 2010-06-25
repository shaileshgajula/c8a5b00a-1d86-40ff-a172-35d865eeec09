<%@ Page Title="" Language="C#" MasterPageFile="~/OrganisationSite/OrgSite.Master"
    AutoEventWireup="true" CodeBehind="StandingUpdate.aspx.cs" Inherits="StrongerOrg.OrganisationSite.StandingUpdate"
    Theme="OrganisationSite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Update Game Score</title>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.player').button();

            if ($(".Alert1").text() == "")
                $("div.ui-widget").hide();
            else {
                $("div.ui-widget").show();
            }

        });
        
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
     <ul class="lavaLampBottomStyle" id="M1">
        <li></li>
        <li><a href="ContactModerator.aspx?orgId=<%= Request.QueryString["OrgId"].ToString()%>">
            Contact Moderator</a></li>
        <li><a href="Rules.aspx?orgId=<%= Request.QueryString["OrgId"].ToString() %>">Rules</a></li>
        <li><a href="EventGallery.aspx?orgId=<%= Request.QueryString["OrgId"].ToString() %>">
            Event Gallery</a></li>
        <li ><a href="Leagues.aspx?orgId=<%= Request.QueryString["OrgId"].ToString() %>">
            Tournaments</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 80%; text-align: center"
        align="center">
        <tr>
            <td colspan="3" style="font-size: 22px; color: #E74194; font-weight: bold;height:50px">
                <asp:Label ID="lblClickOnWinner" runat="server" Text="">Click on the winner</asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnPlayerA" runat="server" Width="200" Height="150" CssClass="player"
                    Text="" OnClick="btnPlayer_Click" Style="cursor: pointer;" />
            </td>
            <td>
                vs.
            </td>
            <td>
                <asp:Button ID="btnPlayerB" runat="server" Width="200" Height="150" CssClass="player"
                    Text="" OnClick="btnPlayer_Click" Style="cursor: pointer;" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <div class="ui-widget" runat="server">
        <div class="ui-state-highlight ui-corner-all" style="margin-top: 20px; padding: 0 .7em;">
            <p>
                <span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span>
                <strong>Alert:</strong>
                <asp:Label ID="lblUpdateMessage" runat="server" Text="" CssClass="Alert1"></asp:Label>
            </p>
        </div>
    </div>
    <br />
    <br />
    <asp:Panel ID="pnlGameDetails" runat="server">
        <asp:DetailsView ID="dvGameDetails" runat="server" AutoGenerateRows="false">
            <HeaderTemplate>
                Game details</HeaderTemplate>
            <Fields>
                <asp:BoundField DataField="TournamentName" HeaderText="Tournament Name:" HeaderStyle-Font-Bold="true" />
                <asp:BoundField DataField="Round" HeaderText="Round:" HeaderStyle-Font-Bold="true" />
                <asp:BoundField DataField="Start" HeaderText="Start:" DataFormatString="{0:f}" HeaderStyle-Font-Bold="true" />
            </Fields>
        </asp:DetailsView>
    </asp:Panel>
</asp:Content>
