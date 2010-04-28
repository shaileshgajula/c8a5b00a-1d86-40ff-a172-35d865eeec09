<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextContent.ascx.cs" Inherits="StrongerOrg.Backoffice.UserControls.TextContent" %>


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
