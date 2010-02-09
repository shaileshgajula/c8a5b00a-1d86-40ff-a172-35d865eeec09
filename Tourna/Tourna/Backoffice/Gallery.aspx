<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="StrongerOrg.Backoffice.Gallery" %>
<%@ Register src="UserControls/GalleryViewer.ascx" tagname="GalleryViewer" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:GalleryViewer ID="GalleryViewer1" runat="server" ImageViewerUrl="~\BackOffice\ImageViewer.aspx?ImgId=" />
</asp:Content>
