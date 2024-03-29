﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageViewer.ascx.cs"
    Inherits="StrongerOrg.Backoffice.UserControls.ImageViewer" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<script type="text/javascript">
    function pageLoad() {
        $addHandler(document, 'keydown', onKeypress);
    }

    function onKeypress(args) {
        if (args.keyCode == Sys.UI.Key.esc) {
            var mdl = $find('imgAssociatedModal');
            var md2 = $find('AddAssociatedImageModal');
            mdl.hide();
            md2.hide();
        }
    }
</script>
<table border="0" cellpadding="0" cellspacing="4" style="width: 100%">
    <tr>
        <td align="center">
            <asp:HyperLink ID="hlPrevious" runat="server"><img src="../../Images/Icons/Previous.gif" border="0" alt="Previous image" /></asp:HyperLink>
            <asp:HyperLink ID="hlNext" runat="server"><img src="../../Images/Icons/next.gif" border="0" alt="Next Image"/></asp:HyperLink>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td valign="top" align="center" rowspan="2">
            <asp:Image ID="imgBigDisplay" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="border: 1px solid #CCCCCC; vertical-align: top">
            <table width="300" border="0">
                <tr>
                    <td class="GrayTitleNormal" colspan="2">
                        Item Ticket
                    </td>
                </tr>
                <tr>
                    <td class="GrayTextLight" valign="top">
                        Caption:
                    </td>
                    <td class="GrayTitleNormal">
                        <asp:Label ID="lblImgCaption" runat="server" Text=""></asp:Label>
                        <asp:TextBox ID="txtImgCaption" runat="server" Visible="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="GrayTextLight">
                        Album:
                    </td>
                    <td style="font-style: italic">
                        <asp:HyperLink ID="hlAlbum" runat="server" NavigateUrl='<%#Eval("id", "Gallery.aspx?AlbumId={0}") %>'
                            Text='<%#Eval("Title") %>'></asp:HyperLink>
                        <asp:DropDownList ID="ddlAlbums" runat="server" Visible="false" DataSourceID="SqlDataSource2"
                            DataTextField="Title" DataValueField="Id" Width="225">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
                            SelectCommand="SELECT [Id], [Title], [Description], [AlbumCover] FROM [Albums] WHERE ([OrganisationId] = @OrganisationId) ORDER BY [Title]"
                            OnSelected="SqlDataSource1_Selected">
                            <SelectParameters>
                                <asp:CookieParameter CookieName="OrganisationId" Name="OrganisationId" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="GrayTextLight" valign="top">
                        Story:
                    </td>
                    <td class="GrayTitleNormal">
                        <asp:Label ID="lblStory" runat="server" Text=""></asp:Label>
                        <asp:TextBox ID="tbStory" runat="server" Width="220px" Rows="3" TextMode="MultiLine"
                            Visible="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="GrayTextLight">
                        Sizes:
                    </td>
                    <td class="GrayTitleNormal">
                        <asp:Label ID="lblSizes" runat="server" Text=""></asp:Label>
                        <asp:TextBox ID="txtSizes" runat="server" Visible="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="GrayTextLight">
                        <asp:Label runat="server" ID="lblPrice" Text="Price" Visible="false"></asp:Label>
                    </td>
                    <td class="GrayTitleNormal">
                        <asp:TextBox ID="txtPrice" runat="server" Visible="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="GrayTextLight">
                        <asp:Label ID="lblImageOrder" runat="server" Text="Image Order" Visible="false"></asp:Label>
                    </td>
                    <td class="GrayTitleNormal">
                        <asp:DropDownList ID="ddlImageOrder" runat="server" Visible="false">
                            <asp:ListItem Text="Not important" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <asp:LinkButton ID="lbUpdateTicket" runat="server" Visible="false" OnClick="lbUpdateTicket_Click">Update</asp:LinkButton>
                    </td>
                </tr>
            </table>
            <table border="0" width="100%">
                <tr>
                    <td class="GrayTitleNormal" colspan="2">
                        Various angles
                    </td>
                </tr>
                <tr>
                    <td class="GrayTextLight" colspan="2">
                        <ajax:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pnlImageDisplay"
                            TargetControlID="hiddenTargetControlForModalPopup" CancelControlID="btnCancelAssociatedImage"
                            BackgroundCssClass="modalBackground" BehaviorID="imgAssociatedModal">
                        </ajax:ModalPopupExtender>
                        <asp:Panel ID="pnlImageDisplay" runat="server" CssClass="ModalWindow">
                            <table>
                                <tr>
                                    <td colspan="3" align="center">
                                        <asp:Image ID="imgAssiciatedFullSizeImage" runat="server" AlternateText="Associated Image" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Caption:
                                        <asp:Label ID="lblAssociatedCaption" runat="server" Text=""></asp:Label>
                                        <asp:TextBox ID="txtCaption" runat="server"></asp:TextBox>
                                        <asp:LinkButton ID="btnUpdateAssociatedImage" runat="server" OnClick="btnUpdateAssociatedImage_Click">Update</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="btnDeleteAssociatedImage" runat="server" OnClick="btnDeleteAssociatedImage_Click">Delete</asp:LinkButton>
                                    </td>
                                    <td align="right">
                                        <asp:LinkButton ID="btnCancelAssociatedImage" runat="server">Close</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
                        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" RepeatColumns="3">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibAssociatedImage" runat="server" OnCommand="ibAssociatedImage_Command"
                                    ImageUrl='<%# @"~\OrganisationGalleryImages\ThumbNail\"+Eval("FileName") %>'
                                    Style="margin: 5px;" BorderWidth="1" BorderColor="#CCCCCC" CommandArgument='<%# BuildCommandArgument(Eval("Id"), Eval("FileName"), Eval("Caption")) %>'
                                    alt='<%#Eval("Caption") %>' />
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
                            SelectCommand="SELECT [Id], [FileName], [Caption] FROM [AssociatedImages] WHERE ([ParentImageId] = @ParentImageId)"
                            OnSelected="SqlDataSource1_Selected">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="ParentImageId" QueryStringField="ImgId" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:Label ID="lblNoAssociatedImagesFound" runat="server" Text="" Visible="false"
                            CssClass="GrayTextLight">No Associated items have been found</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <ajax:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="lnkPopupAdd"
                            PopupControlID="panEdit" BackgroundCssClass="modalBackground" CancelControlID="btnCancel"
                            PopupDragHandleControlID="panEdit" BehaviorID="AddAssociatedImageModal">
                        </ajax:ModalPopupExtender>
                        <asp:Panel ID="panEdit" runat="server" Height="120px" Width="450px" CssClass="ModalWindow">
                            <table width="100%">
                                <tr>
                                    <td class="GrayTitle" colspan="2">
                                        Add associated image
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formtext" align="left">
                                        Select Image:
                                    </td>
                                    <td align="right">
                                        <asp:FileUpload runat="server" ID="fuAssociatedImage" Width="223px"></asp:FileUpload>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formtext" align="left">
                                        Image caption:
                                    </td>
                                    <td align="right">
                                        <asp:TextBox runat="server" ID="txtAssociatedImgCaption" Width="220px">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="right">
                                        <asp:LinkButton ID="btnAddAssociatedImage" runat="server" OnClick="btnAddAssociatedImage_Click">Add</asp:LinkButton>
                                        &nbsp;&nbsp;
                                        <asp:LinkButton ID="btnCancel" runat="server">Cancel</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:HyperLink ID="lnkPopupAdd" runat="server" Style="font-style: italic" NavigateUrl="#">Add...</asp:HyperLink>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td style="border: 1px solid #74b741">
            <b>Limited Edition.</b><br>
            Click
            <asp:HyperLink ID="hlCheckAvailability" runat="server">here</asp:HyperLink>
            to check availability and price.
        </td>
    </tr>
</table>
