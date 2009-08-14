<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Backoffice/BackOffice.Master" CodeBehind="SiteMap.aspx.cs" Inherits="Tourna.SiteMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
        <telerik:RadTreeView ID="RadTreeView1" Runat="server" 
            DataSourceID="SiteMapDataSource1" Skin="Office2007">
        </telerik:RadTreeView>
</asp:Content>
    
