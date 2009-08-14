<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="Rules.aspx.cs" Inherits="Tourna.Backoffice.Rules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadEditor ID="reRules" runat="server" Skin="Black" SkinID="" EditModes="All"
        EnableResize="False" ToolsFile="~/App_Data/RadEditor/BasicTools.xml">
        <Content>
        </Content>
    </telerik:RadEditor>
<asp:LinkButton ID="lbSave" runat="server" onclick="lbSave_Click">Save</asp:LinkButton>
</asp:Content>
