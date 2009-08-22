<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="ManageUsers.aspx.cs" Inherits="StrongerOrg.Backoffice.ManageUsers" %>

<%@ MasterType VirtualPath="~/Backoffice/BackOffice.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Manage users</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblTitle" runat="server" Text="Manage users" CssClass="GrayTitle"></asp:Label>
    <br />
    <br />
    <table cellpadding="2" cellspacing="2" style="width: 50%">
        <tr>
            <td class="HeaderStyle" colspan="2">
                Search for Users
            </td>
        </tr>
        <tr>
            <td>
                Search by:
                <asp:DropDownList ID="ddlSearchBy" runat="server">
                    <asp:ListItem>--SelectMethod--</asp:ListItem>
                    <asp:ListItem>User</asp:ListItem>
                    <asp:ListItem>Email</asp:ListItem>
                    <asp:ListItem Value="OrganisationName">Organisation Name</asp:ListItem>
                </asp:DropDownList>
                for:<asp:TextBox ID="txtSearchParam" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:LinkButton ID="lbFind" runat="server">Find</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="GrayTextLight" colspan="2">
                Wildcard characters * and ? are permitted.
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" AutoGenerateColumns="false"
        DataKeyNames="UserName" GridLines="None" Width="100%" AlternatingRowStyle-CssClass="AlternatingRow"
        HeaderStyle-CssClass="HeaderStyle">
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="UserName" ReadOnly="True" SortExpression="UserName" />
            <asp:BoundField DataField="Name" HeaderText="Organisation" SortExpression="Name" />
            <asp:BoundField DataField="RoleName" HeaderText="Role Name" SortExpression="RoleName" />
            <asp:BoundField DataField="LastActivityDate" HeaderText="Last Activity Date" SortExpression="LastActivityDate"
                DataFormatString="{0:d}" />
                <asp:BoundField DataField="Description" HeaderText="Role Description" SortExpression="Description" />
            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
        </Columns>
        <EmptyDataTemplate>
            No Records found
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetOrganisationUsers"
        TypeName="StrongerOrg.Backoffice.Entities.UsersManager" DeleteMethod="DeleteUser">
        <DeleteParameters>
            <asp:Parameter Name="UserName" Type="String" />
        </DeleteParameters>
        <SelectParameters>
            <asp:CookieParameter  Name="organisationId" CookieName="organisationId" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <%--<asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetOrganisationUsers"
        TypeName="StrongerOrg.Backoffice.Entities.UsersManager" DeleteMethod="DeleteUser">
        <DeleteParameters>
            <asp:Parameter Name="UserName" Type="String" />
        </DeleteParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="txtSearchParam" Name="searchKey" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="ddlSearchBy" Name="searchByKey" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>--%>
    <br />
    <table border="0" style="width: 50%" cellpadding="2" cellspacing="2">
        <tr>
            <td colspan="2" class="HeaderStyle">
                Sign Up for New Account to <%= Master.OrgBasicInfo.Name%>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtUserName">User Name:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtUserName"
                    ErrorMessage="User Name is required." ToolTip="User Name is required.">User Name is required</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="txtPassword">Password:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="password must be betwenn 6-12 chars" ValidationExpression="[\S\s]{6,12}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="txtEmail">E-mail:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="E-mail is required." ToolTip="E-mail is required." Display="Dynamic">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                    Display="Dynamic" ErrorMessage="Email is not valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server">Role:</asp:Label>
            </td>
            <td>
                <asp:LoginView ID="LoginView1" runat="server">
                    <RoleGroups>
                        <asp:RoleGroup Roles="Administrator">
                            <ContentTemplate>
                                <asp:RadioButtonList ID="rbRoles" runat="server">
                                    <asp:ListItem>Administrator</asp:ListItem>
                                    <asp:ListItem Selected="True">Moderator</asp:ListItem>
                                    <asp:ListItem>Accountants</asp:ListItem>
                                    <asp:ListItem Value="ContentManager">Content manager</asp:ListItem>
                                </asp:RadioButtonList>
                            </ContentTemplate>
                        </asp:RoleGroup>
                        <asp:RoleGroup Roles="Moderator">
                            <ContentTemplate>
                                <asp:RadioButtonList ID="rbRoles" runat="server">
                                    <asp:ListItem Selected="True">Moderator</asp:ListItem>
                                    <asp:ListItem>Accountants</asp:ListItem>
                                    <asp:ListItem Value="ContentManager">Content manager</asp:ListItem>
                                </asp:RadioButtonList>
                            </ContentTemplate>
                        </asp:RoleGroup>
                    </RoleGroups>
                </asp:LoginView>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <asp:LinkButton ID="lbCreateUser" runat="server" OnClick="btnCreateUser_Click">Create user</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="color: Red;">
                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
            </td>
        </tr>
    </table>
</asp:Content>
