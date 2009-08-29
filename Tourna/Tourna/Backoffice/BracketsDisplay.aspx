<%@ Page Title="Brackets Display" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="BracketsDisplay.aspx.cs" Inherits="StrongerOrg.Backoffice.BracketsDisplay" %>

<%@ Register Assembly="TourneyLogic.Web.UI.BracketControl.v2" Namespace="TourneyLogic.Web.UI.WebControls"
    TagPrefix="tl" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Switch to edit mode</asp:LinkButton>
    <br />
    <br />
    <tl:Bracket ID="Bracket1" runat="server" ReadOnly="true" RoundWidth="130" Font-Bold="False"
        Font-Italic="False" Font-Names="Arial" Font-Size="Small" ForeColor="Blue" IncorrectPickAppearance-ForeColor="Red"
        IncorrectPickAppearance-Font-Strikeout="True" CorrectPickAppearance-ForeColor="0, 192, 0"
        CorrectPickAppearance-Font-Bold="True" 
        RoundTextAppearance-ForeColor="Gray" InitialMatchupHeight="50" ><Competitors>
<tl:BracketCompetitor ID="BracketCompetitor3" CompetitorName="Pini"></tl:BracketCompetitor>
<tl:BracketCompetitor ID="BracketCompetitor4" CompetitorName="Inbar"></tl:BracketCompetitor>
<tl:BracketCompetitor ID="BracketCompetitor5" CompetitorName="Stan"></tl:BracketCompetitor>
<tl:BracketCompetitor ID="BracketCompetitor6" CompetitorName="Dave"></tl:BracketCompetitor>
<tl:BracketCompetitor ID="BracketCompetitor7" CompetitorName="John"></tl:BracketCompetitor>
<tl:BracketCompetitor ID="BracketCompetitor8" CompetitorName="Jasson"></tl:BracketCompetitor>
<tl:BracketCompetitor ID="BracketCompetitor9" CompetitorName="Patrick"></tl:BracketCompetitor>
<tl:BracketCompetitor ID="BracketCompetitor10" CompetitorName="Christina"></tl:BracketCompetitor>
</Competitors>
    



</tl:Bracket>
</asp:Content>
