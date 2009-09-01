<%@ Page Title="Organisations" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="Organisations.aspx.cs" Inherits="StrongerOrg.Backoffice.Organisations"
    Debug="true" %>
<%@ MasterType VirtualPath="~/Backoffice/BackOffice.Master" %>
<%@ Register src="UserControls/OrganisationInfo.ascx" tagname="OrganisationInfo" tagprefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
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
    <uc1:OrganisationInfo ID="OrganisationInfo1" runat="server" />
</asp:Content>
