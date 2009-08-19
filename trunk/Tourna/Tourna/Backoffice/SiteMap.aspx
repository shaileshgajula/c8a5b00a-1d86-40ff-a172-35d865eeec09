<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Backoffice/BackOffice.Master"
    CodeBehind="SiteMap.aspx.cs" Inherits="StrongerOrg.SiteMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Site map</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblTitle" runat="server" Text="Site map" CssClass="GrayTitle"></asp:Label>
    <br />
    <br />
    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
    <telerik:RadTreeView ID="RadTreeView1" runat="server" DataSourceID="SiteMapDataSource1"
        Skin="Office2007">
    </telerik:RadTreeView>
</asp:Content>
