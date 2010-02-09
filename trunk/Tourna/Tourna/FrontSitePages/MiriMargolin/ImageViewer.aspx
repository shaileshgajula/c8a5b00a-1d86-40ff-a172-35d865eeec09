<%@ Page Title="Image display" Language="C#" MasterPageFile="~/FrontSitePages/MiriMargolin/MiriMargolin.Master" AutoEventWireup="true" CodeBehind="ImageViewer.aspx.cs" Inherits="StrongerOrg.FrontSitePages.MiriMargolin.ImageDisplay" 
Theme="MiriMargolin" %>
<%@ Register src="../../Backoffice/UserControls/ImageViewer.ascx" tagname="ImageViewer" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        
    <uc1:ImageViewer ID="ImageViewer1" runat="server" ImageFolder ="~/FrontSitePages/MiriMargolin/ImageViewer.aspx?ImgId={0}" IsEditMode="false" />

</asp:Content>
