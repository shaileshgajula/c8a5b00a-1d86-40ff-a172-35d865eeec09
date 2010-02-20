<%@ Page Title="Show Case" Language="C#" MasterPageFile="~/FrontSitePages/MiriMargolin/MiriMargolin.Master"
    AutoEventWireup="true" CodeBehind="ShowCase.aspx.cs" Inherits="StrongerOrg.FrontSitePages.MiriMargolin.ShowCase"
    Theme="MiriMargolin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" OnMenuItemClick="Menu1_MenuItemClick" Width="250">
        <StaticSelectedStyle Font-Underline="true" />
        <StaticMenuItemStyle HorizontalPadding="10" Font-Italic="true" />
        <Items>
            <asp:MenuItem Text="Houses(1)" Value="0" Selected="true" SeparatorImageUrl="~/Images/Icons/Seperator.gif">
            </asp:MenuItem>
            <asp:MenuItem Text="Houses(2)" Value="1" Selected="false" SeparatorImageUrl="~/Images/Icons/Seperator.gif">
            </asp:MenuItem>
            <asp:MenuItem Text="Others" Value="2" Selected="false"></asp:MenuItem>
        </Items>
    </asp:Menu>
    <br />
    <asp:MultiView ID="mvShowCase" runat="server" ActiveViewIndex="0">
        <asp:View runat="server" ID="Viwe1">
            <table border="0" cellpadding="2" cellspacing="2" align="center">
                <tr>
                    <td>
                        <img src="../../Images/MiriMargolin/1266497108.jpg" title="here we need to enter the name of the statue we see" />
                    </td>
                    <td>
                        <img src="../../Images/MiriMargolin/1266497180.jpg" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <img src="../../Images/MiriMargolin/1266497201.jpg" />
                    </td>
                    <td>
                        <img src="../../Images/MiriMargolin/1266497243.jpg" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View runat="server" ID="View2">
            <table border="0" cellpadding="2" cellspacing="2" align="center">
                <tr>
                    
                    <td>
                    <img src="../../Images/MiriMargolin/1266683082.jpg" title="here we need to enter the name of the statue we see" />
                    </td>
                    <td>
                        <img src="../../Images/MiriMargolin/1266683159.jpg" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <img src="../../Images/MiriMargolin/1266683187.jpg" />
                    </td>
                    <td>
                        <img src="../../Images/MiriMargolin/1266683512.jpg" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View runat="server" ID="View3">
        <table border="0" cellpadding="2" cellspacing="2" align="center">
                <tr>
                    <td>
                        <img src="../../Images/MiriMargolin/1266597646.jpg" />
                    </td>
                    <td>
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        
                    </td>
                    <td>
                       
                    </td>
                </tr>
            </table>
            
        </asp:View>
    </asp:MultiView>
</asp:Content>
