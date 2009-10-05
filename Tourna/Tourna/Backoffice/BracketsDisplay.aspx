<%@ Page Title="Brackets Display" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master"
    AutoEventWireup="true" CodeBehind="BracketsDisplay.aspx.cs" Inherits="StrongerOrg.Backoffice.BracketsDisplay" %>

<%@ Register Assembly="TourneyLogic.Web.UI.BracketControl.v2" Namespace="TourneyLogic.Web.UI.WebControls"
    TagPrefix="tl" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:LinkButton ID="LinkButton2" runat="server">LinkButton</asp:LinkButton>
    <br />
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Switch to edit mode</asp:LinkButton>
    <br />
    <br />
    
    <tl:bracket id="brackets" runat="server" readonly="True" roundwidth="130" font-bold="False"
        font-italic="False" font-names="Arial" font-size="Small" forecolor="Blue" incorrectpickappearance-forecolor="Red"
        incorrectpickappearance-font-strikeout="True" correctpickappearance-forecolor="0, 192, 0"
        correctpickappearance-font-bold="True" 
        roundtextappearance-forecolor="Gray" initialmatchupheight="50" 
        ChampionshipText="Champion" DataCompetitorIdField="" DataCompetitorNameField="PlayerAName" 
        DataCompetitorNavigateUrlField="" DataCompetitorSeedNumberField="" 
        DataSourceID="SqlDataSource1" 
        InvalidResultsFoundMessage="The entered picks appear to be invalid. This is usaully caused by JavaScript being disabled. Please verify that the picks are valid and resubmit." 
        DataMember="DefaultView" Width="426px"></tl:bracket>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>" 
        SelectCommand="StandingsGet" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="TournamentId" 
                QueryStringField="TournamentId" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>