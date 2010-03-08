<%@ Page Title="Guest book" Language="C#" MasterPageFile="~/FrontSitePages/MiriMargolin/MiriMargolin.Master" AutoEventWireup="true" CodeBehind="GuestBook.aspx.cs" Inherits="StrongerOrg.FrontSitePages.MiriMargolin.GuestBook" Theme="MiriMargolin" %>
<%@ Register src="../../Backoffice/UserControls/Feedbacks.ascx" tagname="Feedbacks" tagprefix="uc1" %>
<%@ MasterType VirtualPath="~/FrontSitePages/MiriMargolin/MiriMargolin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:Feedbacks ID="Feedbacks1" runat="server" TextContentName="MiriMargolinGuestBook" IsEditMode="False" />
</asp:Content>
