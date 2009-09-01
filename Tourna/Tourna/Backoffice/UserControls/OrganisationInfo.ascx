<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrganisationInfo.ascx.cs"
    Inherits="StrongerOrg.Backoffice.UserControls.OrganisationInfo" %>
<asp:DetailsView ID="DetailsView1" runat="server" DataSourceID="SqlDataSource2" GridLines="None"
    Width="100%" AutoGenerateRows="False" HeaderStyle-BackColor="#afafae" HeaderStyle-ForeColor="White"
    HeaderText="Organisation Details" OnItemUpdated="DetailsView1_ItemUpdated" OnItemDeleted="DetailsView1_ItemDeleted"
    OnItemInserted="DetailsView1_ItemInserted" OnItemInserting="DetailsView1_ItemInserting"
    OnItemUpdating="DetailsView1_ItemUpdating">
    <Fields>
        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
        <asp:BoundField DataField="WebSite" HeaderText="Web Site" SortExpression="WebSite" />
        <asp:BoundField DataField="ShippingAddress" HeaderText="Shipping Address" />
        <asp:BoundField DataField="BillingAddress" HeaderText="Billing Address" />
        <asp:CheckBoxField DataField="Active" HeaderText="Active" />
        <asp:CheckBoxField DataField="EmailReminders" HeaderText="Email Reminders" />
        <asp:TemplateField>
            <HeaderTemplate>
                Culture Info
            </HeaderTemplate>
            <ItemTemplate>
                <%#Eval("CultureInfoName") %>
            </ItemTemplate>
            <InsertItemTemplate>
                <asp:DropDownList ID="ddlCountries" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="en-US">English - USA</asp:ListItem>
                    <asp:ListItem Value="he-IL">Hebrew -  Israel</asp:ListItem>
                    <asp:ListItem Value="uk-UA">Ukraine - Ukraine</asp:ListItem>
                </asp:DropDownList>
            </InsertItemTemplate>
            <EditItemTemplate>
                <%#Eval("CultureInfoName") %>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderStyle VerticalAlign="Top" />
            <HeaderTemplate>
                Organisation Logo</HeaderTemplate>
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl='<%# SetCompanyLogo(Eval("CompanyLogo")) %>'
                    GenerateEmptyAlternateText="true" />
            </ItemTemplate>
            <InsertItemTemplate>
                <asp:FileUpload ID="fuCompanyLogo" runat="server" FileName='<%# Bind("FileName") %>' />
            </InsertItemTemplate>
            <EditItemTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl='<%# UpdateOrgLogo(Eval("CompanyLogo")) %>'
                    Visible="true" />
                <asp:LinkButton ID="lbRemove" runat="server" OnClick="lbRemove_Click">Remove</asp:LinkButton>
                <asp:FileUpload ID="fuCompanyLogo" runat="server" FileName='<%# Bind("FileName") %>'
                    Visible="false" />
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ShowHeader="false" InsertVisible="False">
            <ItemTemplate>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Backoffice/OrganisationPlayers.aspx">Players</asp:HyperLink>
                |
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Backoffice/Schedules.aspx"
                    ToolTip="Schedules for all tournaments">Schedules</asp:HyperLink>
                |
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Backoffice/Standings.aspx">Standings</asp:HyperLink>
                |
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Backoffice/ManageUsers.aspx">Manage Users</asp:HyperLink>
                |
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Backoffice/Games2Organisation.aspx">Games</asp:HyperLink>
                |
                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Backoffice/Tournaments.aspx">Tournaments</asp:HyperLink>
                |
                <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl='<%# Eval("Id", "~/OrganisationSite/Default.aspx?OrgId={0}")%>'
                    Target="_blank">Site</asp:HyperLink>
                |
                <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl='~/Backoffice/Holidays.aspx'>Holidays</asp:HyperLink>
                |
                <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl='~/Backoffice/RegistrationFormBuilder.aspx'>Registration Form</asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ShowHeader="false" InsertVisible="true" ItemStyle-HorizontalAlign="Right">
            <ItemStyle CssClass="ThemeBorder" />
            <ItemTemplate>
                <asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit">Edit</asp:LinkButton>
                <asp:LoginView ID="LoginView2" runat="server">
                    <RoleGroups>
                        <asp:RoleGroup Roles="Administrator">
                            <ContentTemplate>
                                <asp:LinkButton ID="lbNew" runat="server" CommandName="New">New</asp:LinkButton>
                                <asp:LinkButton ID="lbDelete" runat="server" OnClientClick="return confirm('Are you certain you want to delete this organisation?')"
                    CommandName="Delete">Delete</asp:LinkButton>
                            </ContentTemplate>
                        </asp:RoleGroup>
                    </RoleGroups>
                </asp:LoginView>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:LinkButton ID="LinkButton22" runat="server" CommandName="Update" >Update</asp:LinkButton>
                <asp:LinkButton ID="LinkButton42" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
            </EditItemTemplate>
            <InsertItemTemplate>
                <asp:LinkButton ID="LinkButton23" runat="server" CommandName="Insert" >Insert</asp:LinkButton>
                <asp:LinkButton ID="LinkButton43" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
            </InsertItemTemplate>
            <ItemStyle HorizontalAlign="Right"></ItemStyle>
        </asp:TemplateField>
    </Fields>
    <EmptyDataTemplate>
        <asp:LinkButton ID="LinkButton31" runat="server" CommandName="New">New Organisation</asp:LinkButton>
    </EmptyDataTemplate>
</asp:DetailsView>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
    SelectCommand="GetOrganisations" SelectCommandType="StoredProcedure" InsertCommand="OrganisationInsert"
    InsertCommandType="StoredProcedure" DeleteCommand="Delete from Organisation WHERE (Id = @Id)"
    UpdateCommand="OragnisationUpdate" UpdateCommandType="StoredProcedure">
    <SelectParameters>
        <asp:ControlParameter ControlID="lblOrganisationId" Name="Id" Type="String" />
    </SelectParameters>
    <UpdateParameters>
        <asp:Parameter Name="Name" DbType="String" />
        <asp:Parameter Name="ShippingAddress" DbType="String" />
        <asp:Parameter Name="BillingAddress" DbType="String" />
        <asp:Parameter Name="WebSite" DbType="String" />
        <asp:Parameter Name="Active" DbType="String" />
        <asp:Parameter Name="FileName" ConvertEmptyStringToNull="true" />
        <asp:Parameter Name="EmailReminders" ConvertEmptyStringToNull="true" />
        <asp:ControlParameter ControlID="lblOrganisationId" Name="Id" Type="String" />
    </UpdateParameters>
    <InsertParameters>
        <asp:Parameter Name="Name" />
        <asp:Parameter Name="ShippingAddress" />
        <asp:Parameter Name="BillingAddress" />
        <asp:Parameter Name="Active" Type="Boolean" />
        <asp:Parameter Name="FileName" />
        <asp:Parameter Name="WebSite" />
        <asp:Parameter Name="EmailReminders" />
    </InsertParameters>
    <DeleteParameters>
        <asp:ControlParameter ControlID="lblOrganisationId" Name="Id" Type="String" />
    </DeleteParameters>
</asp:SqlDataSource>
