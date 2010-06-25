<%@ Page Title="" Language="C#" MasterPageFile="~/OrganisationSite/OrgSite.Master"
    AutoEventWireup="true" CodeBehind="Schedules.aspx.cs" Inherits="StrongerOrg.OrganisationSite.Schedules"
    Theme="OrganisationSite" %>

<%@ Register Src="~/Backoffice/UserControls/Feedbacks.ascx" TagName="Feedbacks" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Schedules</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="0" align="right" style="width: 100%">
        <tr>
            <td style="font-size: 22px; color: #E74194; font-weight: bold"> 
                <asp:Label ID="lblTournamentTitle" runat="server" Text=""></asp:Label>
            </td>
            <td style="width: 150px; text-align: right">
                <a href="Leagues.aspx?orgId=<%= Request.QueryString["OrgId"].ToString() %>">
                    <img src="../Images/Icons/listIcon.jpeg" alt="Tournaments list" title="Tournaments list" border="0" style="vertical-align: top;" /> Tournaments
                    list</a>
            </td>
            <td style="width: 5px; text-align: right">
                <img src="../Images/Icons/Seperator.gif" />
            </td>
            <td style="width: 120px; text-align: center">
                <a href="BracketsView.aspx?OrgId=<%= Request.QueryString["OrgId"].ToString() %>&TournamentId=<%= Request.QueryString["TournamentId"].ToString() %>"
                    >
                    <img src="../Images/Icons/BracketsIcon.gif" alt="Brackets view" title="Brackets view" border="0" style="vertical-align: top;" /> Brackets View</a>
            </td>
            <td style="width: 5px; text-align: right">
                <img src="../Images/Icons/Seperator.gif" />
            </td>
            <td style="width: 60px; text-align: right">
                <a href="PrintTournament.aspx?TournamentId=<%= Request.QueryString["TournamentId"].ToString() %>"
                    target="_blank">
                    <img src="../Images/Icons/PrinterIcon.gif" alt="Print" title="Print" border="0" style="vertical-align: top;" />
                    Print</a>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
        EnableModelValidation="True" Style="width: 100%" RowStyle-HorizontalAlign="Center"
        GridLines="None" OnRowDataBound="GridView1_RowDataBound" 
        >
        <Columns>
            <asp:BoundField DataField="MatchupId" HeaderText="Id" />
            <asp:BoundField DataField="Round" HeaderText="Round" />
                    <asp:HyperLinkField HeaderText="Name" DataTextField="PlayerA" DataNavigateUrlFormatString="~/Backoffice/TeamPlayers.aspx?TeamId={0}"
                DataNavigateUrlFields="PlayerAId" />
            <asp:TemplateField>
                <ItemTemplate>
                    vs.
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Competitor" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="playerText">
                <ItemTemplate>
                    <%# Eval("PlayerB")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Next Match Id">
                <ItemTemplate>
                    <%# Eval("NextMatchId").ToString() == "0" ? "Final Game" : Eval("NextMatchId") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Start" HeaderText="Start" SortExpression="Start" DataFormatString="{0:f}"
                ItemStyle-HorizontalAlign="Left" />
            <asp:TemplateField>
                <HeaderTemplate>
                    Winner
                </HeaderTemplate>
                <ItemTemplate>
                    <strong>
                        <%# Eval("WinnerName")%></strong>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <div id="Div1" class="ui-widget" runat="server">
                <div class="ui-state-highlight ui-corner-all" style="margin-top: 20px; padding: 0 .7em;">
                    <p>
                        <span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span>
                        <strong>Alert:</strong> No mathchups yet!!
                    </p>
                </div>
            </div>
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetTournamentMatchups" TypeName="StrongerOrg.Backoffice.Entities.TournamentMatchupManager">
        <SelectParameters>
            <asp:QueryStringParameter DbType="Guid" Name="tournamentId" QueryStringField="TournamentId" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <br />
    <br />
    <br />
    <asp:DetailsView ID="dvGameDetails" runat="server" AutoGenerateRows="false" DataSourceID="SqlDataSource1"
        OnDataBinding="dvGameDetails_DataBinding" OnDataBound="dvGameDetails_DataBound">
        <HeaderTemplate>
            <strong>Tournament details</strong>
        </HeaderTemplate>
        <Fields>
            <asp:BoundField DataField="TournamentName" HeaderText="Tournament Name:" HeaderStyle-Font-Bold="true" />
            <asp:BoundField DataField="ConsoleName" HeaderText="Category:" HeaderStyle-Font-Bold="true" />
            <asp:BoundField DataField="StartDate" HeaderText="Start:" DataFormatString="{0:f}"
                HeaderStyle-Font-Bold="true" />
            <asp:BoundField DataField="Title" HeaderText="Title:" HeaderStyle-Font-Bold="true" />
            <asp:BoundField DataField="RegisteredPlayers" HeaderText="Registered Competitor:" HeaderStyle-Font-Bold="true" />
            <asp:BoundField DataField="Mode" HeaderText="Mode:" HeaderStyle-Font-Bold="true" />
        </Fields>
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        SelectCommand="TournamentsGet" SelectCommandType="StoredProcedure" CancelSelectOnNullParameter="False">
        <SelectParameters>
            <asp:QueryStringParameter Name="OrganisationId" QueryStringField="OrgId" Type="String" />
            <asp:QueryStringParameter DbType="String" Name="TournamentId" QueryStringField="TournamentId" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <div style="background-color: #afafae; color: White; width: 100%" class="GrayTitleNormal">
        Talkbacks, leave your comments</div>
    <br />
    <uc1:Feedbacks ID="Feedbacks1" runat="server" TextContentName="Feedbacks" IsEditMode="False" />
</asp:Content>
