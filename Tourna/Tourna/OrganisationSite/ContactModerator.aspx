<%@ Page Title="" Language="C#" MasterPageFile="~/OrganisationSite/OrgSite.Master" 
    AutoEventWireup="true" CodeBehind="ContactModerator.aspx.cs" Inherits="StrongerOrg.OrganisationSite.ContactModerator" Theme="OrganisationSite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table >
        <tr>
            <td colspan="3" style="height:50px;vertical-align:top" class="H1Title">
                Contact Moderator</td>
        </tr>
        <tr>
        <td rowspan="5" style="width:10px"></td>
            <td style="width:140px">
                Your Name</td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Subject</td>
            <td>
                <asp:TextBox ID="txtSubject" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Your Email</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="vertical-align:top">
                Message</td>
            <td>
                <asp:TextBox ID="txtMessage" runat="server" Height="109px" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="right">
                <asp:LinkButton ID="lbSend" runat="server" onclick="lbSend_Click">Send</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
