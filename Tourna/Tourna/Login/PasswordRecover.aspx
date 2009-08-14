<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordRecover.aspx.cs" Inherits="Tourna.Login.PasswordRecover" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                    </telerik:RadScriptManager>
    <div>
        
        <table class="style1">
            <tr>
                <td colspan="2">
                    Enter your User Name to receive your password.</td>
            </tr>
            <tr>
                <td class="style2">
                    E-Mail</td>
                <td>
                    <telerik:RadTextBox ID="txtEmail" Runat="server">
                    </telerik:RadTextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtEmail" ErrorMessage="Email is not valid" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    
                    <asp:Button ID="btnSend" runat="server" onclick="btnSend_Click" Text="Button" />
                </td>
            </tr>
            <tr>
                <td class="style2" colspan="2">
                    <asp:Label ID="txtMessage" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
