<%@ Page Title="Tournament rules" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="Rules.aspx.cs" Inherits="StrongerOrg.Backoffice.Rules" %>
<%@ MasterType VirtualPath="~/Backoffice/BackOffice.Master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
