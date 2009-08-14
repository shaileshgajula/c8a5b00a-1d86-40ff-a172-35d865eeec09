<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="ManageUsers.aspx.cs" Inherits="Tourna.Backoffice.ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 584px;
        }
        .style3
        {
        }
        .style4
        {
            width: 35px;
        }
    </style>
    <title>Manage users</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" class="style1">
        <tr>
            <td class="style3" colspan="2">
                Search for Users
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;
            </td>
            <td>
                Search by:
                <asp:DropDownList ID="ddlSearchBy" runat="server">
                    <asp:ListItem>--SelectMethod--</asp:ListItem>
                    <asp:ListItem>User</asp:ListItem>
                    <asp:ListItem>Email</asp:ListItem>
                    <asp:ListItem Value="OrganisationName">Organisation Name</asp:ListItem>
                </asp:DropDownList>
                for:<asp:TextBox ID="txtSearchParam" runat="server"></asp:TextBox>
                <asp:Button ID="btnFind" runat="server" Text="Find" OnClick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;
            </td>
            <td>
                Wildcard characters * and ? are permitted.
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;
            </td>
            <td>
                print a-z
            </td>
        </tr>
    </table>
    &nbsp;<asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1"
        AutoGenerateColumns="False" DataKeyNames="UserName">
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="UserName" ReadOnly="True" SortExpression="UserName" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="Comment" HeaderText="Comment" SortExpression="Comment" />
            <asp:CheckBoxField DataField="IsApproved" HeaderText="IsApproved" SortExpression="IsApproved" />
            <asp:CheckBoxField DataField="IsLockedOut" HeaderText="IsLockedOut" ReadOnly="True"
                SortExpression="IsLockedOut" />
            <asp:BoundField DataField="CreationDate" HeaderText="CreationDate" ReadOnly="True"
                SortExpression="CreationDate" />
            <asp:BoundField DataField="LastLoginDate" HeaderText="LastLoginDate" SortExpression="LastLoginDate" />
            <asp:CheckBoxField DataField="IsOnline" HeaderText="IsOnline" ReadOnly="True" SortExpression="IsOnline" />
            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
        </Columns>
        <EmptyDataTemplate>
            No Records found
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
        SelectMethod="FindUsers" TypeName="Tourna.Backoffice.Entities.ManageUsers" 
        DeleteMethod="DeleteUser">
        <DeleteParameters>
            <asp:Parameter Name="UserName" Type="String" />
        </DeleteParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="txtSearchParam" Name="searchKey" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="ddlSearchBy" Name="searchByKey" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <table border="0">
                            <tr>
                                <td align="center" colspan="2">
                                    Sign Up for Your New Account</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtUserName">User Name:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                        ControlToValidate="txtUserName" ErrorMessage="User Name is required." 
                                        ToolTip="User Name is required.">User Name is required</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="txtPassword">Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                        ControlToValidate="txtPassword" 
                                        ErrorMessage="password must be betwenn 6-12 chars" 
                                        ValidationExpression="[\S\s]{6,12}"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="txtEmail">E-mail:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
                                        ControlToValidate="txtEmail" ErrorMessage="E-mail is required." 
                                        ToolTip="E-mail is required." Display="Dynamic">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                        ControlToValidate="txtEmail" Display="Dynamic" 
                                        ErrorMessage="Email is not valid" 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" >Role:</asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rbRoles" runat="server">
                                        <asp:ListItem Selected="True">Modrator</asp:ListItem>
                                        <asp:ListItem>Accountants</asp:ListItem>
                                        <asp:ListItem>Administrator</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:Button ID="btnCreateUser" runat="server" Text="Button" 
                                        onclick="btnCreateUser_Click" /></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color:Red;">
                                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                        </table>
</asp:Content>
