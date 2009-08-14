<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="Games2Organisation.aspx.cs" Inherits="Tourna.Backoffice.Games2Organisation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Games to Organisation</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                Allowed games for company
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
