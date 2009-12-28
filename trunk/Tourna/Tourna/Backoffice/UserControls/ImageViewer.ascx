<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageViewer.ascx.cs"
    Inherits="StrongerOrg.Backoffice.UserControls.ImageViewer" %>
<table>
    <tr>
        <td align="center">
            <asp:HyperLink ID="hlPrevious" runat="server"><img src="../../Images/Icons/Previous.png" border="0" alt="Previous image" /></asp:HyperLink>
        </td>
        <td>
            <asp:Image ID="imgBigDisplay" runat="server" />
        </td>
        <td>
            <asp:HyperLink ID="hlNext" runat="server"><img src="../../Images/Icons/next.png" border="0" /></asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="3">
            <asp:Label ID="lblImgCaption" runat="server" Text=""></asp:Label>
        </td>
    </tr>
</table>
