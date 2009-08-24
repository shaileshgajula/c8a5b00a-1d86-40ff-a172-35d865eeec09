<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.Master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="StrongerOrg.FrontSitePages.About" %>

<%@ MasterType VirtualPath="~/FrontSite.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>About us</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
        <tr>
            <td style="padding: 15px">
                <img src="../Images/aboutus.gif" />
            </td>
        </tr>
        <tr>
            <td class="GrayTextNormal" style="padding: 15px">
                The idea that became StrongerOrg was born during numerous gripe sessions between
                a group of interface experts and web application coders (that’s us). We all needed
                a good web-based task management application, but none of us could find one that
                really did the job.<br>
                Between us we’ve used every web-based task and project management available, and
                either the interface was unnecessarily complicated or the application was too limited
                and didn’t enable us to connect with all of the communications tools we relied on
                to do our jobs. We wanted a fully-featured, social networking aware task management
                application with a user interface that made sense, something we didn’t have to devote
                a couple of hours to learning to use. We wanted to be able to get a clear overview
                of the status of any project, anytime and from any place. We needed to be able to
                collaborate effortlessly. We wanted to be able to update project information in
                many different ways : via email, online, desktop, mobile, IM... and we needed to
                be able to share information in real time with all our team members, no matter how
                computer-savvy they are … or aren’t.<br>
                We couldn’t find that perfect application, so we decided to build it. StrongerOrg
                will evolve regularly; we have a lot of great new features in development.
                <br>
                And we’d love to know what features you’d find useful -- please send your comments
                to you have any feedback, feel free to shoot us an email at contact@StrongerOrg.com.
                StrongerOrg is headquartered in New York City.
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
