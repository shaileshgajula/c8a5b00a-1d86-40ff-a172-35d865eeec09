<%@ Page Title="Show Case" Language="C#" MasterPageFile="~/FrontSitePages/MiriMargolin/MiriMargolin.Master"
    AutoEventWireup="true" CodeBehind="ShowCase.aspx.cs" Inherits="StrongerOrg.FrontSitePages.MiriMargolin.ShowCase"
    Theme="MiriMargolin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" OnMenuItemClick="Menu1_MenuItemClick"
        Width="250">
        <StaticMenuItemStyle HorizontalPadding="10" />
        <StaticSelectedStyle CssClass="SelectedRowStyle" />
        <Items>
            <asp:MenuItem Text="Houses 1" Value="0" Selected="true" SeparatorImageUrl="~/Images/Icons/Seperator.gif">
            </asp:MenuItem>
            <asp:MenuItem Text="Houses 2" Value="1" Selected="false" SeparatorImageUrl="~/Images/Icons/Seperator.gif">
            </asp:MenuItem>
            <asp:MenuItem Text="Buildings/Offices" Value="2" Selected="false"></asp:MenuItem>
        </Items>
    </asp:Menu>
    <br />
    <asp:MultiView ID="mvShowCase" runat="server" ActiveViewIndex="0">
        <asp:View runat="server" ID="Viwe1">
            <table border="0" cellpadding="2" cellspacing="2" align="center">
                <tr>
                    <td>
                        <a href="/FrontSitePages/MiriMargolin/Gallery.aspx?AlbumId=19"><img src="../../Images/MiriMargolin/1266497180.jpg" width="350" height="234" border="0" alt="Abstract" title="Abstract" /></a>
                    </td>
                    <td>
                        <a href="/FrontSitePages/MiriMargolin/ImageViewer.aspx?ImgId=57"><img src="../../Images/MiriMargolin/1266872378.jpg" width="350" height="234"  border="0" alt="She & He" title="She & He"  /></a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="/FrontSitePages/MiriMargolin/Gallery.aspx?AlbumId=20"><img src="../../Images/MiriMargolin/1266497201.jpg"  border="0" alt="Figures" title="Figures" /></a>
                    </td>
                    <td>
                        <a href="/FrontSitePages/MiriMargolin/ImageViewer.aspx?ImgId=43"><img src="../../Images/MiriMargolin/1266497243.jpg"  border="0" alt="Shabi" title="Shabi" /></a>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View runat="server" ID="View2">
            <table border="0" cellpadding="2" cellspacing="2" align="center">
                <tr>
                    <td>
                        <a href="/FrontSitePages/MiriMargolin/ImageViewer.aspx?ImgId=47"><img src="../../Images/MiriMargolin/1266683082.jpg"  border="0" title="Ballerina" alt="Ballerina" /></a>
                    </td>
                    <td>
                        <a href="/FrontSitePages/MiriMargolin/ImageViewer.aspx?ImgId=50"><img src="../../Images/MiriMargolin/1266683159.jpg"  border="0" title="Yoga" alt="Yoga" /></a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="/FrontSitePages/MiriMargolin/ImageViewer.aspx?ImgId=45"><img src="../../Images/MiriMargolin/1266683187.jpg"  border="0" title="" alt=""/></a>
                    </td>
                    <td>
                        <a href="/FrontSitePages/MiriMargolin/ImageViewer.aspx?ImgId=47"><img src="../../Images/MiriMargolin/1266683512.jpg" border="0" title="" alt="" /></a>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View runat="server" ID="View3">
            <table border="0" cellpadding="2" cellspacing="2" align="center">
                <tr>
                    <td>
                        <a href="/FrontSitePages/MiriMargolin/ImageViewer.aspx?ImgId=97"><img src="../../Images/MiriMargolin/SabaBoaz.jpg" title="Saba Boaz"  border="0" alt="Saba Boaz" /></a>
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
