<%@ Page Title="" Language="C#" MasterPageFile="~/OrganisationSite/OrgSite.Master"
    AutoEventWireup="true" CodeBehind="RescheduleRequest.aspx.cs" Inherits="StrongerOrg.OrganisationSite.RescheduleRequest" Theme="OrganisationSite" %>

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
        <li><a href="Leagues.aspx?orgId=<%= Request.QueryString["OrgId"].ToString() %>">Tournaments</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hfPlayerName" runat="server" />
    <table border="0" cellpadding="5" style="-moz-border-radius: 15px; -webkit-border-radius: 10px;
        border-radius: 10px; width: 600px; border: 1px solid #ADA6FF; background-color: White;height:100px"
        align="center">
        <tr>
            <td colspan="2" class="H1Title">
                Reschedule Request
            </td>
        </tr>
         <tr>
            <td>
                Tournament name:
            </td>
            <td>
                <asp:Label ID="lblTournamentName" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Match up:
            </td>
            <td>
                <asp:Label ID="lblMatchup" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Date:
            </td>
            <td>
                <asp:Label ID="lblMatchupDate" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Reason
            </td>
            <td>
                <asp:DropDownList ID="ddlReason" runat="server">
                    <asp:ListItem Text="Not in that day" Value="Not in that day" />
                    <asp:ListItem Text="Can not participate in that hour" Value="Can not participate in that hour" />
                    <asp:ListItem Text="Do not feel like playing" Value="Do not feel like playing" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Comment
            </td>
            <td>
                <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:LinkButton ID="lbSend" runat="server" onclick="lbSend_Click">Send</asp:LinkButton>
            </td>
        </tr>
    </table>
    
    
    <div id="divMessage" class="ui-widget" runat="server" visible="false">
        <div class="ui-state-highlight ui-corner-all" style="margin-top: 20px; padding: 0 .7em;">
            <p>
                <span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span>
                <strong>Alert:</strong>
                A message has been sent to modorator and it is to his considoration to reschedule your mathup.
            </p>
        </div>
    </div>
</asp:Content>
