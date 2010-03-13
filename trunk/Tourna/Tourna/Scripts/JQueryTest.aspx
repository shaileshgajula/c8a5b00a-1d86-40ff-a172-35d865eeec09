<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JQueryTest.aspx.cs" Inherits="StrongerOrg.Scripts.JQueryTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" media="screen" rel="stylesheet" href="colorbox.css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>
    <script type="text/javascript" src="colorbox/jquery.colorbox.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".example8").colorbox({ width: "50%", inline: true, href: "#inline_example1" });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <a href="content/ohoopee1.jpg" rel="example8" title="abc">Click here</a></p> <a class='example8'
        href="#">Inline HTML</a></p>
    <!-- This contains the hidden content for inline calls -->
    <div style='display: none'>
        <div id='inline_example1' style='padding: 10px; background: #fff;'>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton><asp:TextBox
                ID="TextBox1" runat="server"></asp:TextBox>
        </div>
    </div>
    </form>
</body>
</html>
