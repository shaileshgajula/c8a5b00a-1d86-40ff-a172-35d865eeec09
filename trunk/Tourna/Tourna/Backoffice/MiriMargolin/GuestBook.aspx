<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true" CodeBehind="GuestBook.aspx.cs" Inherits="StrongerOrg.Backoffice.MiriMargolin.GuestBook" %>
<%@ Register src="../UserControls/Feedbacks.ascx" tagname="Feedbacks" tagprefix="uc1" %>
<%@ MasterType VirtualPath="~/Backoffice/BackOffice.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Feedbacks ID="Feedbacks1" runat="server" TextContentName="MiriMargolinGuestBook" IsEditMode="True" />
</asp:Content>
