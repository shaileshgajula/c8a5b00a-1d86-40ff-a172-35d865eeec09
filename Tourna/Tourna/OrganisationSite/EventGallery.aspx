<%@ Page Title="" Language="C#" MasterPageFile="~/OrganisationSite/OrgSite.Master" AutoEventWireup="true" CodeBehind="EventGallery.aspx.cs" Inherits="StrongerOrg.OrganisationSite.EventGallery" Theme="OrganisationSite" %>
<%@ Register src="../Backoffice/UserControls/GalleryViewer.ascx" tagname="GalleryViewer" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <ul class="lavaLampBottomStyle" id="M1">
        <li></li>
        <li><a href="ContactModerator.aspx?orgId=<%= Request.QueryString["OrgId"].ToString()%>">Contact Moderator</a></li>
        <li ><a href="Rules.aspx?orgId=<%= Request.QueryString["OrgId"].ToString() %>" >Rules</a></li>
        <li class="current"><a href="EventGallery.aspx?orgId=<%= Request.QueryString["OrgId"].ToString() %>">Event Gallery</a></li>
        <li ><a href="Leagues.aspx?orgId=<%= Request.QueryString["OrgId"].ToString() %>">Tournaments</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblOrganisationId" runat="server" Visible="False"></asp:Label>
    <uc1:GalleryViewer ID="GalleryViewer1" runat="server"  />
</asp:Content>
