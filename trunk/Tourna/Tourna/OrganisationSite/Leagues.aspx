<%@ Page Title="Tournaments" Language="C#" MasterPageFile="~/OrganisationSite/OrgSite.Master"
    AutoEventWireup="true" CodeBehind="Leagues.aspx.cs" Inherits="StrongerOrg.OrganisationSite.Leagues"
    Theme="OrganisationSite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <ul class="lavaLampBottomStyle" id="M1">
        <li></li>
        <li><a href="ContactModerator.aspx?orgId=<%= Request.QueryString["OrgId"].ToString()%>">Contact Moderator</a></li>
        <li ><a href="Rules.aspx?orgId=<%= Request.QueryString["OrgId"].ToString() %>" >Rules</a></li>
        <li><a href="EventGallery.aspx?orgId=<%= Request.QueryString["OrgId"].ToString() %>">Event Gallery</a></li>
        <li class="current"><a href="Leagues.aspx?orgId=<%= Request.QueryString["OrgId"].ToString() %>">Tournaments</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" BorderWidth="0px"
         RepeatColumns="2"  HorizontalAlign="Center" CellPadding="0" CellSpacing="25" >
        <ItemStyle BorderStyle="Dotted" BorderWidth="1px" VerticalAlign="Top" />
        
        <ItemTemplate>
            <table border="0" cellpadding="3" cellspacing="3" style="vertical-align:top;height:100%" align="center">
                <tr>
                    <td align="center" colspan="2" class="H1Title" style="height:40px" >
                        <asp:HyperLink ID="HyperLink2" runat="server"  NavigateUrl='<%# BuildNavigaionUrl ("Schedules.aspx", Eval("Id").ToString()) %>'><%#Eval("TournamentName")%></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" style="height:150px">
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("GameImage", "~/Images/GamesImages/{0}")%>' />
                    </td>
                </tr>
                <tr>
                    <td>
                        Start date:
                    </td>
                    <td>
                        <%#Eval("StartDate")%>
                    </td>
                </tr>
                <tr>
                    <td>
                        Competitors limit:
                    </td>
                    <td>
                        <%#Eval("NumberOfPlayersLimit")%>
                    </td>
                </tr>
                <tr>
                    <td>
                        Registered competitors:
                    </td>
                    <td>
                        <%#Eval("RegisteredPlayers")%>
                    </td>
                </tr>
                <tr>
                    <td>
                        Status:
                    </td>
                    <td>
                        Not started yet
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        SelectCommand="TournamentsGet" SelectCommandType="StoredProcedure" OnSelected="SqlDataSource1_Selected"
        CancelSelectOnNullParameter="false">
        <SelectParameters>
            <asp:CookieParameter Name="OrganisationId" CookieName="OrganisationId" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
