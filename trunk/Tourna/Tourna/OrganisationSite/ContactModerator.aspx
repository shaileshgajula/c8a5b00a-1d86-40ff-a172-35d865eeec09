<%@ Page Title="" Language="C#" MasterPageFile="~/OrganisationSite/OrgSite.Master" 
    AutoEventWireup="true" CodeBehind="ContactModerator.aspx.cs" Inherits="StrongerOrg.OrganisationSite.ContactModerator" Theme="OrganisationSite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td colspan="2">
                Contact Moderator</td>
        </tr>
        <tr>
            <td>
                Your Name</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Subject</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Your Email</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Message</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:LinkButton ID="lbSend" runat="server" onclick="lbSend_Click">Send</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
