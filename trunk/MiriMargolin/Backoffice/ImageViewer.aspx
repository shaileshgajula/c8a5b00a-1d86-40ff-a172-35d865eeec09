<%@ Page Title="Image Display" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="ImageViewer.aspx.cs" Inherits="StrongerOrg.Backoffice.ImageViewer"  %>

<%@ Register Src="UserControls/ImageViewer.ascx" TagName="ImageViewer" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
        <tr>
            <td>
                <a href="EventGallery.aspx">View ALL</a> <img src="../Images/Icons/Seperator.gif" /> 
                <asp:LinkButton ID="lbDelete" runat="server" OnClick="lbDelete_Click">Delete Image</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td align="center" class="ThemeBorder">
                <uc1:ImageViewer ID="ImageViewer1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
