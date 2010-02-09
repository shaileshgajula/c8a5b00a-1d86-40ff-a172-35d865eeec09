<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GalleryViewer.ascx.cs"
    Inherits="StrongerOrg.Backoffice.UserControls.GalleryViewer" %>
<asp:Label ID="lblAlbumTitle" Width="100%" runat="server" Text="" Style="border-bottom-style: double;
    border-bottom-width: 3px; border-bottom-color: #ADADAD; width: 100%"></asp:Label>
<asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" RepeatColumns="5"
    RepeatLayout="Table">
    <ItemStyle VerticalAlign="Top" CssClass="GrayTextLight" HorizontalAlign="Center" />
    <ItemTemplate>
        <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl='<%# @"~\OrganisationGalleryImages\ThumbNail\"+Eval("FileName") %>'
            NavigateUrl='<%# BuildNavigationUrl(Eval("Id")) %>' BorderWidth="1" BorderColor="#CCCCCC"
            Style="margin: 10px">   
        </asp:HyperLink><br />
        <%# Eval("ImageCaption") %>
    </ItemTemplate>
</asp:DataList><asp:Label ID="lblMsg" Visible="false" runat="server" Text="Label">No images have been uploaded</asp:Label>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
    SelectCommand="SELECT [Id],[ImageCaption], [FileName] FROM [ImageGallery] WHERE ([OrganisationId] = @OrganisationId) and 
    (AlbumId=COALESCE(@AlbumId,AlbumId)) order by albumId, ImageOrder desc" OnSelected="SqlDataSource1_Selected"
    CancelSelectOnNullParameter="false">
    <SelectParameters>
        <asp:ControlParameter ControlID="lblOrganisationId" Name="OrganisationId" Type="String" />
        <asp:QueryStringParameter Name="AlbumId" QueryStringField="AlbumId" Type="String"
            ConvertEmptyStringToNull="true" />
    </SelectParameters>
</asp:SqlDataSource>
