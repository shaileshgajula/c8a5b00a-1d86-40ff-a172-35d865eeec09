﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Albums.ascx.cs" Inherits="StrongerOrg.Backoffice.UserControls.Albums" %>
 <asp:DataList ID="dlAlbums" runat="server" DataSourceID="SqlDataSource1" OnItemDataBound="dlAlbums_ItemDataBound" Width="100%" 
    RepeatColumns="2" CellPadding="5" CellSpacing=5>
        <ItemTemplate>
            <table style="width:100%">
                <tr>
                    <td  style="border-bottom-style:double;border-bottom-width:3px;border-bottom-color:#ADADAD">
                        <asp:HyperLink ID="hlSeeMore" runat="server" NavigateUrl='<%#BuildNavigateUrl (Eval("Id"), "Gallery.aspx?AlbumId={0}") %>'><%# Eval("Title") %></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DataList ID="dlAlbumPreview" runat="server" DataKeyField="Id" DataSourceID="SqlDataSourceAlbumPreview"
                            RepeatColumns="3">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# BuildNavigateUrl (Eval("Id"), "ImageViewer.aspx?ImgId={0}") %>' ImageUrl='<%# Eval("FileName", "~/OrganisationGalleryImages/ThumbNail/{0}") %>' BorderColor="#eeeeee" BorderWidth="1px" Style="margin: 5px;"></asp:HyperLink>
                                
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                    
                </tr>
            </table>
            <asp:SqlDataSource ID="SqlDataSourceAlbumPreview" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
                SelectCommand="SELECT top 3  [FileName], [Id] FROM [ImageGallery] WHERE ([AlbumId] = @AlbumId) order by ImageOrder desc">
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