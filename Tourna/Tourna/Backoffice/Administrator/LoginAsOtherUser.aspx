<%@ Page Title="Control Panel" Language="C#" AutoEventWireup="true" CodeBehind="LoginAsOtherUser.aspx.cs" Inherits="StrongerOrg.Backoffice.Administrator.LoginAsOtherUser" 
MasterPageFile="~/Backoffice/BackOffice.Master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table border="0" cellpadding="2" cellspacing="0">
            <tr>
                <td align="right">
                    <asp:Label ID="AdminUserNameLabel" runat="server" AssociatedControlID="AdminUserName">An <b>Admin</b> User Name:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="AdminUserName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="AdminUserNameRequired" runat="server" 
                        ControlToValidate="AdminUserName" ErrorMessage="The Admin User Name is required." 
                        ToolTip="The Admin User Name is required." ValidationGroup="LogInAs">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="AdminPasswordLabel" runat="server" AssociatedControlID="AdminPassword">The <b>Admin</b> Password:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="AdminPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="AdminPasswordRequired" runat="server" 
                        ControlToValidate="AdminPassword" ErrorMessage="The Admin Password is required." 
                        ToolTip="The Admin Password is required." ValidationGroup="LogInAs">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="LogInAsUserNameLabel" runat="server" AssociatedControlID="LogInAsUserName">Log In As User Name:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="LogInAsUserName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="LogInAsUserNameRequired" runat="server" 
                        ControlToValidate="LogInAsUserName" ErrorMessage="Log In As User Name is required." 
                        ToolTip="Log In As User Name is required." ValidationGroup="LogInAs">*</asp:RequiredFieldValidator>
                </td>
            </tr>                                
            <tr>
                <td align="center" colspan="2" style="color:Red;">
                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2">
                    <asp:LinkButton ID="LoginButton" runat="server" CommandName="Login"  
                        ValidationGroup="LogInAs" onclick="LoginButton_Click" >Log In</asp:LinkButton>
                        
                </td>
            </tr>
        </table>
</asp:Content>