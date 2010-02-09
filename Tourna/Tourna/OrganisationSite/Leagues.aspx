<%@ Page Title="" Language="C#" MasterPageFile="~/OrganisationSite/OrgSite.Master"
    AutoEventWireup="true" CodeBehind="Leagues.aspx.cs" Inherits="StrongerOrg.OrganisationSite.Leagues"
    Theme="OrganisationSite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" BorderWidth="0px"
        BorderStyle="Dashed" RepeatColumns="2" Width="100%">
        <ItemStyle BorderStyle="Dotted" BorderWidth="1px" />
        <ItemTemplate>
            <table border="0" cellpadding="3" cellspacing="3" style="vertical-align:top">
                <tr>
                    <td align="center" colspan="2" class="H1Title" >
                        <%#Eval("TournamentName")%>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
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
                        Players limit:
                    </td>
                    <td>
                        <%#Eval("NumberOfPlayersLimit")%>
                    </td>
                </tr>
                <tr>
                    <td>
                        Registered Players:
                    </td>
                    <td>
                        <%#Eval("RegisteredPlayers")%>
                    </td>
                </tr>
                <tr>
                    <td>
                        League status:
                    </td>
                    <td>
                        Not started yet
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# BuildNavigaionUrl ("Standings.aspx", Eval("Id").ToString()) %>'>Standings</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server"  NavigateUrl='<%# BuildNavigaionUrl ("Schedules.aspx", Eval("Id").ToString()) %>'>Schedules</asp:HyperLink>
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
