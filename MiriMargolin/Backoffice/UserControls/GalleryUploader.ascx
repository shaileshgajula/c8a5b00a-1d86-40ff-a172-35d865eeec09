<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GalleryUploader.ascx.cs"
    Inherits="StrongerOrg.Backoffice.UserControls.GalleryUploader" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<fieldset style="width: 80%;">
    <legend>Upload Image</legend>
    <table>
        <tr>
            <td>
                Select image
            </td>
            <td>
                <asp:FileUpload ID="fuImage" runat="server" Width="200px" />
            </td>
        </tr>
        <tr>
            <td>
                Image caption(Optional)
            </td>
            <td>
                <asp:TextBox ID="txtCaption" runat="server" Width="220px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top">
                Image story(Optional)
            </td>
            <td>
                <asp:TextBox ID="tbStory" runat="server" Width="220px" Rows="3" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Sizes and dimentions(Optional)
            </td>
            <td>
                <asp:TextBox ID="txtSizes" runat="server" Width="220px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Album(Optional)
            </td>
            <td>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
                    SelectCommand="SELECT [Id], [Title], [Description], [AlbumCover] FROM [Albums] WHERE ([OrganisationId] = @OrganisationId) ORDER BY [Title]"
                    OnSelected="SqlDataSource1_Selected">
                    <SelectParameters>
                        <asp:CookieParameter CookieName="OrganisationId" Name="OrganisationId" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1"
                    DataTextField="Title" DataValueField="Id" Width="225">
                    <asp:ListItem Text="No Albums" Value="-1" />
                </asp:DropDownList>
                <ajax:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="lnkPopup"
                    PopupControlID="panEdit" BackgroundCssClass="modalBackground" CancelControlID="btnCancel"
                    PopupDragHandleControlID="panEdit">
                </ajax:ModalPopupExtender>
                <asp:Panel ID="panEdit" runat="server" Width="550px" CssClass="ModalWindow">
                    <table width="100%">
                        <tr>
                            <td class="GrayTitle" colspan="2">
                                Add new album
                            </td>
                        </tr>
                        <tr>
                            <td class="formtext" align="left">
                                Album Name:
                            </td>
                            <td align="right">
                                <asp:TextBox ID="txtAlbumName" runat="server" width="200px">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:LinkButton ID="btnAdd" runat="server" onclick="btnAdd_Click">Add</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td class="GrayTitle" colspan="2">
                                Current albums (check the ones you want to delete)
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" height="10">
                                <asp:CheckBoxList ID="cblAlbums" runat="server" DataSourceID="SqlDataSource1" DataTextField="Title"
                                    DataValueField="Id" RepeatColumns="5" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                                <asp:Label ID="lblNoAlbumsFound" runat="server" Text="No Albums Found" Visible="False">
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:LinkButton ID="btnDelete" runat="server" onclick="btnDelete_Click">Delete</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: right; height: 40px">
                                <asp:LinkButton ID="btnCancel" runat="server">Cancel</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <a id="lnkPopup" runat="server" href="#" style="font-style: italic">Manage Albums...</a>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right; height: 40px">
                <asp:LinkButton ID="lbUpload" runat="server" OnClick="lbUpload_Click">Upload</asp:LinkButton>
            </td>
        </tr>
    </table>
</fieldset>
