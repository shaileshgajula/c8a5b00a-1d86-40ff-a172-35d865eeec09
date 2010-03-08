<%@ Page Title="About Miri" Language="C#" MasterPageFile="~/FrontSitePages/MiriMargolin/MiriMargolin.Master" AutoEventWireup="true" 
CodeBehind="About.aspx.cs" Inherits="StrongerOrg.FrontSitePages.MiriMargolin.About" Theme="MiriMargolin"  %>
<%@ MasterType VirtualPath="~/FrontSitePages/MiriMargolin/MiriMargolin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" >
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<img src="../../Images/Staff/MiriMargolinSelf.jpg" alt="Miri Margolin at her home" align="left" style="padding:15px"/>
    <asp:Label ID="lblAbout" runat="server" Text="Label"></asp:Label>

</asp:Content>
