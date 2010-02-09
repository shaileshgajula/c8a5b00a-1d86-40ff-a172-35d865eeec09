<%@ Page Title="Event Gallery" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master"
    AutoEventWireup="true" CodeBehind="EventGallery.aspx.cs" Inherits="StrongerOrg.Backoffice.EventGallery" %>

<%@ Register Src="UserControls/GalleryUploader.ascx" TagName="GalleryUploader" TagPrefix="uc1" %>

<%@ Register src="UserControls/Albums.ascx" tagname="Albums" tagprefix="uc2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border=0 width="100%" style="height:100%">
        <tr>
            <td align="center">
                
                <uc2:Albums ID="Albums1" runat="server" BaseNavigationUrl="~/BackOffice" />
                
            </td>
        </tr>
        <tr>
            <td align="center">
                <uc1:GalleryUploader ID="GalleryUploader1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
