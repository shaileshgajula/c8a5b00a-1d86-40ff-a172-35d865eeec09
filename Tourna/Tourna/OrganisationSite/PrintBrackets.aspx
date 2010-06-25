<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintBrackets.aspx.cs"
    Inherits="StrongerOrg.OrganisationSite.PrintBrackets" %>

<%@ Register Src="../Backoffice/UserControls/BracketsDisplay.ascx" TagName="BracketsDisplay"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 22px; color: #E74194; font-weight: bold;font-family:Arial">
        <asp:Label ID="lblTournamentTitle" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <uc1:BracketsDisplay ID="BracketsDisplay1" runat="server" />
    </div>
    <br />
    <br>
    <div style="border-top: 1px dotted #444444; text-align: center">
        www.strongerorg.com</div>
    </form>
</body>
</html>
