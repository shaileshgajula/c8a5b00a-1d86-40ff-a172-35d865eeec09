﻿<%@ Page Title="Organisation Info" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="OrganisationInfo.aspx.cs" Inherits="StrongerOrg.Backoffice.OrganisationInfo"  %>
<%@ Register src="UserControls/OrganisationInfo.ascx" tagname="OrganisationInfo" tagprefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <uc1:OrganisationInfo ID="OrganisationInfo1" runat="server" />

    
</asp:Content>