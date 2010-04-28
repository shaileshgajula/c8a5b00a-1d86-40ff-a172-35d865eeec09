<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StrongerOrg.Backoffice.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>StrongerOrg [LogIn]</title>
    
    <link type="text/css" href="scripts/css/redmond/jquery-ui-1.8.custom.css" rel="stylesheet" />	
		<script type="text/javascript" src="scripts/js/jquery-1.4.2.min.js"></script>
		<script type="text/javascript" src="scripts/js/jquery-ui-1.8.custom.min.js"></script>
        <script type="text/javascript">
            $(function () {
                $('.date').button();

            });
            </script>
</head>
<body>
    <form id="form1" runat="server">
  
    <table style="width:100%;height:350px">
        <tr>
            <td align="center">
                <asp:Login ID="Login1" runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderPadding="4"
                    BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em"
                    ForeColor="#333333" Height="187px" PasswordRecoveryText="Recover your password"
                    PasswordRecoveryUrl="~/Login/PasswordRecover.aspx" RememberMeSet="True" TitleText="StrngerOrg [Log In]"
                    Width="473px" DestinationPageUrl="~/Backoffice/Organisations.aspx" 
                    OnLoggedIn="Login1_LoggedIn">
                    <TextBoxStyle Font-Size="0.8em" />
                    <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px"
                        Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
                    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                    <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                </asp:Login>
                
               <%-- <asp:Button CssClass="date" Text="hello wolrd" Height="80" Width="180" 
                    ID="btnTest" runat="server" onclick="btnTest_Click" />--%>
            </td>
        </tr>
    </table>
   
    </form>
</body>
</html>
