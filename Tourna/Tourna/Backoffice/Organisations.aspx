<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="Organisations.aspx.cs" Inherits="StrongerOrg.Backoffice.Organisations"
    Debug="true" %>

<%@ MasterType VirtualPath="~/Backoffice/BackOffice.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Organisations</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblTitle" runat="server" Text="Organisation list" CssClass="GrayTitle"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="false"
        DataKeyNames="Id,Name" DataSourceID="SqlDataSource1" OnSelectedIndexChanging="GridView1_SelectedIndexChanging"
        OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="WebSite" HeaderText="Web Site" SortExpression="WebSite" />
            <asp:CheckBoxField DataField="Active" HeaderText="Active" SortExpression="Active" />
        </Columns>
        <EmptyDataTemplate>
            No Records found
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        SelectCommand="GetOrganisations" SelectCommandType="StoredProcedure" CancelSelectOnNullParameter="False"
        DeleteCommand="DELETE FROM [Organisation] WHERE [Id] = @Id" InsertCommand="INSERT INTO Organisation(Name, ContactPerson, ShippingAddress, BillingAddress, WebSite) VALUES (@Name, @ContactPerson, @ShippingAddress, @BillingAddress, @WebSite)">
        <SelectParameters>
            <asp:QueryStringParameter Name="Id" QueryStringField="OrgId" Type="String" ConvertEmptyStringToNull="true" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="Id" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Name" />
            <asp:Parameter Name="ContactPerson" />
            <asp:Parameter Name="ShippingAddress" />
            <asp:Parameter Name="BillingAddress" />
            <asp:Parameter Name="WebSite" />
        </InsertParameters>
    </asp:SqlDataSource>
    <br />
    <br />
    <asp:DetailsView ID="DetailsView1" runat="server" DataSourceID="SqlDataSource2" GridLines="None"
        Width="80%" AutoGenerateRows="False" HeaderStyle-BackColor="#afafae" HeaderStyle-ForeColor="White"
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
                    Country
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
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    Company Logo</HeaderTemplate>
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
                    <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl='~/Backoffice/Holidays.aspx'
                        Target="_blank">Holidays</asp:HyperLink>
                    |
                    <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl='~/Backoffice/RegistrationFormBuilder.aspx'
                        Target="_blank">Registration Form</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="false" InsertVisible="true" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Are you certain you want to delete this company?')"
                        CommandName="Delete">Delete</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton21" runat="server" CommandName="Edit">Edit</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton31" runat="server" CommandName="New">New</asp:LinkButton>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton22" runat="server" CommandName="Update">Update</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton42" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:LinkButton ID="LinkButton23" runat="server" CommandName="Insert">Insert</asp:LinkButton>
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
        SelectCommand="GetOrganisations" SelectCommandType="StoredProcedure" InsertCommand="INSERT INTO Organisation(Name, ShippingAddress, BillingAddress, Active, WebSite, CompanyLogo, EmailReminders, CultureInfoName) VALUES (@Name, @ShippingAddress, @BillingAddress, @Active, @WebSite, @FileName, @EmailReminders, @CultureInfoName)"
        DeleteCommand="Delete from Organisation WHERE (Id = @Id)" UpdateCommand="OragnisationUpdate"
        UpdateCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="Id" PropertyName="SelectedValue"
                Type="Empty" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" DbType="String" />
            <asp:Parameter Name="ShippingAddress" DbType="String" />
            <asp:Parameter Name="BillingAddress" DbType="String" />
            <asp:Parameter Name="WebSite" DbType="String" />
            <asp:Parameter Name="Active" DbType="String" />
            <asp:Parameter Name="FileName" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="EmailReminders" ConvertEmptyStringToNull="true" />
            <asp:ControlParameter ControlID="GridView1" Name="Id" PropertyName="SelectedValue"
                Type="Empty" />
            <asp:Parameter Name="CultureInfoName" Type="String" ConvertEmptyStringToNull="true" />
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
            <asp:ControlParameter ControlID="GridView1" Name="Id" PropertyName="SelectedValue"
                Type="Empty" />
        </DeleteParameters>
    </asp:SqlDataSource>
    <br />
</asp:Content>
