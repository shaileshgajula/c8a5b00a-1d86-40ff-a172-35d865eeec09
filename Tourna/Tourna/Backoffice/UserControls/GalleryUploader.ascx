<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GalleryUploader.ascx.cs"
    Inherits="StrongerOrg.Backoffice.UserControls.GalleryUploader" %>
<fieldset style="width: 80%">
    <legend>Upload Images</legend>
    <table>
        <tr>
            <td>
                Select Image
            </td>
            <td>
                <asp:FileUpload ID="fuImage" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Image caption(Optional)
            </td>
            <td>
                <asp:TextBox ID="txtCaption" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">
                <asp:LinkButton ID="lbUpload" runat="server" OnClick="lbUpload_Click">Upload</asp:LinkButton>
            </td>
        </tr>
    </table>
</fieldset>
