<%@ Page Title="Gallery (Albums)" Language="C#" MasterPageFile="~/FrontSitePages/MiriMargolin/MiriMargolin.Master"
    AutoEventWireup="true" CodeBehind="Albums.aspx.cs" Inherits="StrongerOrg.FrontSitePages.MiriMargolin.Albums"
    Theme="MiriMargolin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="dlAlbums" runat="server" DataSourceID="SqlDataSource1" OnItemDataBound="dlAlbums_ItemDataBound">
        <ItemTemplate>
            <table>
                <tr>
                    <td class="GrayTitleNormal">
                        <%# Eval("Title") %>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DataList ID="dlAlbumPreview" runat="server" DataKeyField="Id" DataSourceID="SqlDataSourceAlbumPreview"
                            RepeatColumns="3">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("FileName", "~/OrganisationGalleryImages/ThumbNail/{0}") %>' />
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                    <td style="vertical-align: bottom">
                        <asp:HyperLink ID="hlSeeMore" runat="server" NavigateUrl='<%#Eval("Id", "~/FrontSitePages/MiriMargolin/Gallery.aspx?AlbumId={0}") %>'>See more ...</asp:HyperLink>
                    </td>
                </tr>
            </table>
            <asp:SqlDataSource ID="SqlDataSourceAlbumPreview" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
                SelectCommand="SELECT top 3  [FileName], [Id] FROM [ImageGallery] WHERE ([AlbumId] = @AlbumId) order by id">
                <SelectParameters>
                    <asp:Parameter Name="AlbumId" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        SelectCommand="SELECT [Id], [Title] FROM [Albums] WHERE ([OrganisationId] = @OrganisationId)">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblOrganisationId" Name="OrganisationId" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
