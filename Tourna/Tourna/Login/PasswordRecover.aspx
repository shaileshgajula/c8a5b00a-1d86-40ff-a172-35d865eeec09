<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordRecover.aspx.cs"
    Inherits="StrongerOrg.Login.PasswordRecover" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Password recover</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .RedText
        {
            color:Red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <table style="width: 100%; height: 350px">
        <tr>
            <td align="center">
                <table cellspacing="0" cellpadding="4" border="0" id="Login1" style="background-color: #EFF3FB;
                    border-color: #B5C7DE; border-width: 1px; border-style: Solid; border-collapse: collapse;">
                    <tr>
                        <td>
                            <table cellpadding="0" border="0" style="color: #333333; font-family: Verdana; font-size: 0.8em;
                                height: 107px; width: 473px;">
                                <tr>
                                    <td align="center" colspan="2" style="color: White; background-color: #507CD1; font-size: 0.9em;
                                        font-weight: bold;">
                                        Enter your E-Mail to receive your password.
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <label for="Login1_UserName">
                                            E-Mail:</label>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="txtEmail" runat="server" Width="150">
                                        </telerik:RadTextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                            ErrorMessage="Email is not valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Label ID="lblMsg" runat="server" Text="" CssClass="RedText" ></asp:Label> 
                                     <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="Send" Style="color: #284E98;
                                            background-color: White; border-color: #507CD1; border-width: 1px; border-style: Solid;
                                            font-family: Verdana; font-size: 0.8em;   " />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
