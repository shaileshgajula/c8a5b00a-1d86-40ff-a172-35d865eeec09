<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true" CodeBehind="BracketsView.aspx.cs" Inherits="StrongerOrg.Backoffice.BracketsView" %>
<%@ Register Assembly="TourneyLogic.Web.UI.BracketControl.v2" Namespace="TourneyLogic.Web.UI.WebControls"
    TagPrefix="tl"  %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:LinkButton ID="lbSwitchToEdit" runat="server" 
        onclick="lbSwitchToEdit_Click">Switch to edit mode</asp:LinkButton>
   <br />
   
    <tl:Bracket ID="Bracket1" runat="server" DataSourceID="SqlDataSource1" DataCompetitorNameField="PlayerAName"></tl:Bracket>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>" 
        SelectCommand="StandingsGet" SelectCommandType="StoredProcedure" 
        onselecting="SqlDataSource1_Selecting">
        <SelectParameters>
            <asp:QueryStringParameter Name="TournamentId" 
                QueryStringField="TournamentId" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    
    <br />
</asp:Content>
