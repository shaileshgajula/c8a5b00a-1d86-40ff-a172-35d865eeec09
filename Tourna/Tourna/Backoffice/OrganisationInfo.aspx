<%@ Page Title="Organisation Info" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master"
    AutoEventWireup="true" CodeBehind="OrganisationInfo.aspx.cs" Inherits="StrongerOrg.Backoffice.OrganisationInfo" %>
<%@ MasterType VirtualPath="~/Backoffice/BackOffice.Master" %>
<%@ Register Src="UserControls/OrganisationInfo.ascx" TagName="OrganisationInfo"
    TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:OrganisationInfo ID="OrganisationInfo1" runat="server" />
</asp:Content>
