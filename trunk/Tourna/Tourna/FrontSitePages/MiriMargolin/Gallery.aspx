<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSitePages/MiriMargolin/MiriMargolin.Master" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="StrongerOrg.FrontSitePages.MiriMargolin.Gallery" Theme="MiriMargolin" %>
<%@ Register src="../../Backoffice/UserControls/GalleryViewer.ascx" tagname="GalleryViewer" tagprefix="uc1" %>
<%@ MasterType VirtualPath="~/FrontSitePages/MiriMargolin/MiriMargolin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:GalleryViewer ID="GalleryViewer1" runat="server"  />
    
</asp:Content>
