<%@ Page Title="Games to Organisation" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="Games2Organisation.aspx.cs" Inherits="StrongerOrg.Backoffice.Games2Organisation" %>
<%@ MasterType VirtualPath="~/Backoffice/BackOffice.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td class="HeaderStyle">
                Allowed games for organisation
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:LinkButton ID="lbUpdate" runat="server" OnClick="Button1_Click">Update</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
