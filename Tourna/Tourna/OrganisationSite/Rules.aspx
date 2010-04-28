<%@ Page Title="" Language="C#" MasterPageFile="~/OrganisationSite/OrgSite.Master" AutoEventWireup="true" 
CodeBehind="Rules.aspx.cs" Inherits="StrongerOrg.OrganisationSite.Rules" Theme="OrganisationSite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Rules</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <ul class="lavaLampBottomStyle" id="M1">
        <li></li>
        <li><a href="ContactModerator.aspx?orgId=<%= Request.QueryString["OrgId"].ToString()%>">Contact Moderator</a></li>
        <li class="current"><a href="Rules.aspx?orgId=<%= Request.QueryString["OrgId"].ToString() %>" >Rules</a></li>
        <li><a href="EventGallery.aspx?orgId=<%= Request.QueryString["OrgId"].ToString() %>">Event Gallery</a></li>
        <li><a href="Leagues.aspx?orgId=<%= Request.QueryString["OrgId"].ToString() %>">Tournaments</a></li>
    </ul>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div runat="server" id="divRules"></div>
</asp:Content>
