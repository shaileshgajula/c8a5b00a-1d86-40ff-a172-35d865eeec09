<%@ Page Title="About Miri" Language="C#" MasterPageFile="~/FrontSitePages/MiriMargolin/MiriMargolin.Master"
    AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="StrongerOrg.FrontSitePages.MiriMargolin.About"
    Theme="MiriMargolin" %>

<%@ MasterType VirtualPath="~/FrontSitePages/MiriMargolin/MiriMargolin.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="-moz-border-radius: 15px;
                    -webkit-border-radius: 10px; border-radius: 10px; height: 100px; width: 350px;
                    border: 2px solid #74b741; background-color: White; padding: 10px" align="left">
                    <tr>
                        <td>
                            <strong>Come to see Savta and the sculptures at her house on Thursday April 15th at
                                6:00PM contact us for more details</strong>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="-moz-border-radius: 15px;
                    -webkit-border-radius: 10px; border-radius: 10px; height: 100px; width: 350px;
                    border: 2px solid #74b741; background-color: White; padding: 10px" align="center">
                    <tr>
                        <td>
                            <strong>Full Name</strong>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ErrorMessage="*" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                           <strong>Email</strong>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="*" ControlToValidate="txtEmail" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*"
                                ControlToValidate="txtEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                            </asp:RegularExpressionValidator>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: right">
                            <asp:Label ID="lblMsg" runat="server" Text="" Font-Italic="true"></asp:Label>
                            <asp:LinkButton ID="lbNotify" runat="server" OnClick="lbNotify_Click" PostBackUrl="http://www.mirimargolin.com/FrontSitePages/MiriMargolin/About.aspx">Notify me about new events</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server" Width="100%">
        <img src="../../Images/Staff/MiriMargolinSelf.jpg" alt="Miri Margolin at her home"
            align="left" style="padding: 15px" />
        <asp:Label ID="lblAbout" runat="server" Text="Label"></asp:Label>
    </asp:Panel>
    <div style="text-align: right; width: 100%">
        <asp:LinkButton ID="lbShowAddNew" runat="server" OnClientClick="return false">
            <asp:Image ID="Image1" runat="server" />&nbsp
            <asp:Label ID="lblFeedbackHeader" runat="server" Text="Read More"></asp:Label></asp:LinkButton>
    </div>
    <ajax:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" Collapsed="true"
        CollapsedSize="380" ExpandControlID="lbShowAddNew" CollapseControlID="lbShowAddNew"
        AutoCollapse="False" AutoExpand="false" TextLabelID="lblFeedbackHeader" ExpandedImage="~/Images/Icons/collapse.jpg"
        CollapsedImage="~/Images/Icons/expand.jpg" TargetControlID="Panel1" ExpandDirection="Vertical"
        ImageControlID="Image1">
    </ajax:CollapsiblePanelExtender>
    <p>
        <strong>Miri Margolin's interview</strong></p>
    <div style="text-align: center; width: 100%">
        <object width="425" height="344">
            <param name="movie" value="http://www.youtube.com/v/LS1-OjvkSQM&hl=en_US&fs=1&rel=0&color1=0x234900&color2=0x4e9e00">
            </param>
            <param name="allowFullScreen" value="true"></param>
            <param name="allowscriptaccess" value="always"></param>
            <embed src="http://www.youtube.com/v/LS1-OjvkSQM&hl=en_US&fs=1&rel=0&color1=0x234900&color2=0x4e9e00"
                type="application/x-shockwave-flash" allowscriptaccess="always" allowfullscreen="true"
                width="320" height="265"></embed></object>
    </div>
</asp:Content>
