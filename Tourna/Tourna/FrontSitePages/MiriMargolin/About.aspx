<%@ Page Title="About Miri" Language="C#" MasterPageFile="~/FrontSitePages/MiriMargolin/MiriMargolin.Master"
    AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="StrongerOrg.FrontSitePages.MiriMargolin.About"
    Theme="MiriMargolin" %>

<%@ MasterType VirtualPath="~/FrontSitePages/MiriMargolin/MiriMargolin.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Width="100%">
        <img src="../../Images/Staff/MiriMargolinSelf.jpg" alt="Miri Margolin at her home"
            align="left" style="padding: 15px" />
        <asp:Label ID="lblAbout" runat="server" Text="Label"></asp:Label>
    </asp:Panel>
    <div style="text-align: right; width: 100%">
    <asp:LinkButton ID="lbShowAddNew" runat="server" OnClientClick="return false">
        <asp:Image ID="Image1" runat="server" />&nbsp
        <asp:Label ID="lblFeedbackHeader" runat="server" Text="Read More"></asp:Label></asp:LinkButton>
        </div>
    <ajax:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" Collapsed="true"
        CollapsedSize="380" ExpandControlID="lbShowAddNew" CollapseControlID="lbShowAddNew"
        AutoCollapse="False" AutoExpand="false" TextLabelID="lblFeedbackHeader" ExpandedImage="~/Images/Icons/collapse.jpg"
        CollapsedImage="~/Images/Icons/expand.jpg" TargetControlID="Panel1" ExpandDirection="Vertical"
        ImageControlID="Image1">
    </ajax:CollapsiblePanelExtender>
    <p><strong>Miri Margolin's interview</strong></p>
    <div style="text-align: center; width: 100%">
        <object width="425" height="344">
            <param name="movie" value="http://www.youtube.com/v/LS1-OjvkSQM&hl=en_US&fs=1&rel=0&color1=0x234900&color2=0x4e9e00">
            </param>
            <param name="allowFullScreen" value="true"></param>
            <param name="allowscriptaccess" value="always"></param>
            <embed src="http://www.youtube.com/v/LS1-OjvkSQM&hl=en_US&fs=1&rel=0&color1=0x234900&color2=0x4e9e00"
                type="application/x-shockwave-flash" allowscriptaccess="always" allowfullscreen="true"
                width="320" height="265"></embed></object>
    </div>
</asp:Content>
