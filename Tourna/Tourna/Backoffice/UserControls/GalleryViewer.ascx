<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GalleryViewer.ascx.cs"
    Inherits="StrongerOrg.Backoffice.UserControls.GalleryViewer" %>
<asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" RepeatColumns="5"
    RepeatLayout="Table">
    <ItemTemplate>
        <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl='<%# @"~\OrganisationGalleryImages\ThumbNail\"+Eval("FileName") %>'
            NavigateUrl='<%# BuildNavigationUrl(Eval("Id")) %>' Style="margin: 15px;" BorderWidth="1" BorderColor="#CCCCCC">   
        </asp:HyperLink>
    </ItemTemplate>
</asp:DataList><asp:Label ID="lblMsg" Visible="false" runat="server" Text="Label">No images have been uploaded</asp:Label>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
    SelectCommand="SELECT [Id],[ImageCaption], [FileName] FROM [ImageGallery] WHERE ([OrganisationId] = @OrganisationId)"
    OnSelected="SqlDataSource1_Selected">
    <SelectParameters>
        <asp:ControlParameter ControlID="lblOrganisationId" Name="OrganisationId" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>
