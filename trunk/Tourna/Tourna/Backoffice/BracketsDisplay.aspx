<%@ Page Title="Brackets Display" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master"
    AutoEventWireup="true" CodeBehind="BracketsDisplay.aspx.cs" Inherits="StrongerOrg.Backoffice.BracketsDisplay" %>

<%@ Register Assembly="TourneyLogic.Web.UI.BracketControl.v2" Namespace="TourneyLogic.Web.UI.WebControls"
    TagPrefix="tl" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click1">LinkButton</asp:LinkButton>
    <br />
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Switch to edit mode</asp:LinkButton>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
   
    <br />
    <%--<tl:Bracket ID="brackets" runat="server" readonly="True" RoundWidth="130" Font-Bold="False"
        Font-Italic="False" Font-Names="Arial" Font-Size="Small" ForeColor="Blue" incorrectpickappearance-forecolor="Red"
        incorrectpickappearance-font-strikeout="True" correctpickappearance-forecolor="0, 192, 0"
        correctpickappearance-font-bold="True" roundtextappearance-forecolor="Gray" InitialMatchupHeight="50"
        ChampionshipText="Champion" DataCompetitorIdField="Id" DataCompetitorNameField="Name"
        DataCompetitorNavigateUrlField="" DataCompetitorSeedNumberField=""
        DataSourceID="SqlDataSource1"
        InvalidResultsFoundMessage="The entered picks appear to be invalid. This is usaully caused by JavaScript being disabled. Please verify that the picks are valid and resubmit."
        DataMember="DefaultView" Width="426px"></tl:Bracket>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        SelectCommand="PlayersGet" SelectCommandType="StoredProcedure" CancelSelectOnNullParameter="false">
        <SelectParameters>
            <asp:CookieParameter CookieName="OrganisationId" Name="OrganisationId" Type="String" />
            <asp:QueryStringParameter Name="TournamentId" QueryStringField="TournamentId" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>--%>
    <tl:Bracket ID="BracketTest" runat="server" DisplayMode="ViewMode" Width="100" MatchupTextStyle-BorderWidth="5">

    </tl:Bracket>
</asp:Content>
