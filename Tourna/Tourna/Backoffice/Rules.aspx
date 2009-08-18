<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="Rules.aspx.cs" Inherits="Tourna.Backoffice.Rules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Tournament rules</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblTitle" runat="server" Text="Tournament rules" CssClass="GrayTitle"></asp:Label>
    <br />
    <br />
    <table>
        <tr>
            <td>
                <telerik:RadEditor ID="reRules" runat="server" Skin="Black" SkinID="" EditModes="All"
                    EnableResize="False" ToolsFile="~/App_Data/RadEditor/BasicTools.xml">
                    <Content>
                    </Content>
                </telerik:RadEditor>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:LinkButton ID="lbSave" runat="server" OnClick="lbSave_Click">Save</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
