<%@ Page Title="" Language="C#" MasterPageFile="~/OrganisationSite/OrgSite.Master"
    AutoEventWireup="true" CodeBehind="ImageViewer.aspx.cs" Inherits="StrongerOrg.OrganisationSite.ImageViewer"
    Theme="OrganisationSite" %>
<%@ Register Src="../Backoffice/UserControls/ImageViewer.ascx" TagName="ImageViewer"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%">
        <tr>
        <td>
            <asp:HyperLink ID="hlViewAll" runat="server" >View All</asp:HyperLink></td>
        </tr>
        <tr>
            <td align="center">
            <uc1:ImageViewer ID="ImageViewer1" runat="server"  />
            </td>
        </tr>
    </table>
    
</asp:Content>
