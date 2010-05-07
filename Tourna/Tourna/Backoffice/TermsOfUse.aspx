<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true" CodeBehind="TermsOfUse.aspx.cs" Inherits="StrongerOrg.Backoffice.TermsOfUse" %>
<%@ Register src="~/Backoffice/UserControls/TermsOfUse.ascx" tagname="TermsOfUse" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:TermsOfUse ID="TermsOfUse1" runat="server" />

</asp:Content>
