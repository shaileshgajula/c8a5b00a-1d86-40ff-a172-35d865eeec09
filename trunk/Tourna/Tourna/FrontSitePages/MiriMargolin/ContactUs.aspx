<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/FrontSitePages/MiriMargolin/MiriMargolin.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="StrongerOrg.FrontSitePages.MiriMargolin.ContactUs" Theme="MiriMargolin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="width:70%">
        <tr>
            <td>
                Name</td>
            <td align="right">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                Phone or Email</td>
            <td align="right">
                <asp:TextBox ID="txtPhoneOrEmail" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="vertical-align:top">
                Message</td>
            <td align="right">
                <asp:TextBox ID="txtMessage" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
           
            <td colspan="2" align="right">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                <asp:LinkButton ID="lbSend" runat="server" onclick="lbSend_Click">Send</asp:LinkButton></td>
        </tr>
    </table>

</asp:Content>
