<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetUp.aspx.cs" Inherits="StrongerOrg.Login.SetUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="loginPanel" runat="server">
            <table class="style1">
                <tr>
                    <td>
                    Test Connection to db
                    </td>
                        <td>
                            <asp:LinkButton ID="lbOpenConnection" runat="server" Text="Open" 
                                onclick="lbOpenConnection_Click"></asp:LinkButton> 
                            <asp:Label ID="lblOpenConnectionResult" runat="server"></asp:Label>
                    </td>
                </tr>
                
                <tr>
                    <td colspan="2">
                        Setup page
                    </td>
                </tr>
                <tr>
                    <td>
                        User name
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        password
                    </td>
                    <td>
                        <asp:TextBox ID="txtPws" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:LinkButton ID="lbGo" runat="server" OnClick="lbGo_Click">Go</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
        <asp:Panel ID="SecurityPanel" runat="server" Visible="false">
            <table class="style1">
                <tr>
                    <td>
                        Roles
                    </td>
                    <td>
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                            <asp:ListItem>Administrator</asp:ListItem>
                            <asp:ListItem>Accountants</asp:ListItem>
                            <asp:ListItem>Modrator</asp:ListItem>
                            <asp:ListItem>ContentManager</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                    <td>
                        <asp:LinkButton ID="lbAdd" runat="server" OnClick="lbAdd_Click">Add selected roles</asp:LinkButton>
                        <br />
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Add pini to administrators</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
