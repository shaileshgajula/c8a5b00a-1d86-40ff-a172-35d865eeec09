<%@ Page Title="Gallery (Albums)" Language="C#" MasterPageFile="~/FrontSitePages/MiriMargolin/MiriMargolin.Master"
    AutoEventWireup="true" CodeBehind="Albums.aspx.cs" Inherits="StrongerOrg.FrontSitePages.MiriMargolin.Albums"
    Theme="MiriMargolin" %>

<%@ Register src="../../Backoffice/UserControls/Albums.ascx" tagname="Albums" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:Albums ID="Albums1" runat="server" BaseNavigationUrl="~/FrontSitePages/MiriMargolin" />
    
</asp:Content>
