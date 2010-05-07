<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.Master" AutoEventWireup="true" CodeBehind="FreeTrial.aspx.cs" Inherits="StrongerOrg.FrontSitePages.FreeTrial" %>
<%@ Register src="~/FrontSitePages/UserContorls/FeeTrailForm.ascx" tagname="FeeTrailForm" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:FeeTrailForm ID="FeeTrailForm1" runat="server" />
</asp:Content>
