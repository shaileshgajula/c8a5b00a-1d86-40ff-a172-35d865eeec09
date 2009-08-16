<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tourna.Default"
    MasterPageFile="~/FrontSite.Master" %>

<%@ MasterType VirtualPath="~/FrontSite.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Home page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table class="style2" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 20%; background-color:#f7f7f6">
                    &nbsp;
                </td>
                <td style="width: 60%">
                    <table>
                        <tr>
                            <td>
                                <img src="../Images/LadyWithLaptop.jpg" alt="Lady with laptop" id="lady" />
                            </td>
                            <td>
                                <img src="../Images/B2BGames.gif" alt="b2b games" id="b2bgames" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 20%; background-color:#f7f7f6">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
