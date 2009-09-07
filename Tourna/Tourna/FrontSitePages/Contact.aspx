<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.Master" AutoEventWireup="true"
    CodeBehind="Contact.aspx.cs" Inherits="StrongerOrg.FrontSitePages.Contact" %>

<%@ MasterType VirtualPath="~/FrontSite.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Contact</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td style="padding: 15px">
                <img src="../Images/ContactTitle.gif" />
            </td>
        </tr>
    </table>
    <table style="width: 80%; padding: 10px;margin-left: auto;margin-right: auto;height:110px" border="0" >
        <tr>
        <td rowspan="4" style="text-align:left;vertical-align:top;border-right-color:#CCCCCC;border-right-style:solid;border-right-width:1px" class="GrayTextNormal">
            <Div class="GrayTitle"> Main Office</Div>
            792 Columbus Ave.<br>
            New York City, NY, 10025<br>
            Sales:<br>
            <a href="mailto:sales@strongerorg.com?subject=StrongerOrg sales">sales@strongerorg.com</a><br />
            Phone: +1 646-255-5026 <br/>
            Fax: +1 646-123-4567
        </td>
            <td style="vertical-align: top;text-align:right">
                <telerik:RadTextBox runat="server" Columns="40" EmptyMessage="-- Your Name --" ID="txtName"
                    Width="220px">
                    <EnabledStyle BorderColor="#66CCFF" BorderStyle="Solid" />
                                    <EmptyMessageStyle ForeColor="#66CCFF" />
                </telerik:RadTextBox>
            </td>
            <td rowspan="4" style="text-align:right;">
                <telerik:RadTextBox runat="server" EmptyMessage="-- Your Message  --" ID="txtMessages"
                    Width="350px" Height="130px" TextMode="MultiLine">
                    <EnabledStyle BorderColor="#66CCFF" BorderStyle="Solid" />
                                    <EmptyMessageStyle ForeColor="#66CCFF" />
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:right;">
                <telerik:RadTextBox runat="server" Columns="40" EmptyMessage="-- Company --" ID="txtCompany"
                    Width="220px">
                    <EnabledStyle BorderColor="#66CCFF" BorderStyle="Solid" />
                                    <EmptyMessageStyle ForeColor="#66CCFF" />
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: bottom;text-align:right;">
                <telerik:RadTextBox runat="server" Columns="40" EmptyMessage="-- Email --" ID="txtEmail"
                    Width="220px">
                    <EnabledStyle BorderColor="#66CCFF" BorderStyle="Solid" />
                                    <EmptyMessageStyle ForeColor="#66CCFF" />
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: bottom;text-align:right;">
                <telerik:RadComboBox ID="RadComboBox1" runat="server" Width="225px" >
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Text="Sales" Value="Sales" />
                        <telerik:RadComboBoxItem runat="server" Text="Support" Value="Support" />
                        <telerik:RadComboBoxItem runat="server" Text="General" Value="General" />
                    </Items>
                    <HeaderTemplate>Select Subject</HeaderTemplate>
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: right;height:80px">
                <asp:ImageButton ID="ibSend" runat="server" ImageUrl="~/Images/SendBtn.gif" OnClick="ibSend_Click" />
                <asp:ImageButton ID="ibClear" runat="server" ImageUrl="~/Images/ClearBtn.gif" OnClick="ibClear_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
