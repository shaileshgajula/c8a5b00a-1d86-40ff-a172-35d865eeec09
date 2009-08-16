<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.Master" AutoEventWireup="true"
    CodeBehind="Products.aspx.cs" Inherits="Tourna.FrontSitePages.Products" %>

<%@ MasterType VirtualPath="~/FrontSite.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Products</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td style="padding: 15px">
                <img src="../Images/ProductsTitle.gif" />
            </td>
        </tr>
    </table>
</asp:Content>
