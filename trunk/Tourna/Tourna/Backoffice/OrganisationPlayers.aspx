﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="OrganisationPlayers.aspx.cs" Inherits="Tourna.Backoffice.OrganisationPlayers" %>
<%@ MasterType VirtualPath="~/Backoffice/BackOffice.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Organisation Players</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblTitle" runat="server" Text="" CssClass="GrayTitle"></asp:Label>
    <br /><br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="Id" DataSourceID="SqlDataSource1" GridLines="None" Width="80%" AlternatingRowStyle-CssClass="AlternatingRow" HeaderStyle-CssClass="HeaderStyle">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"  />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"  />
            <asp:BoundField DataField="NickName" HeaderText="Nick Name" SortExpression="NickName"  />
            <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department" />
        </Columns>
        <EmptyDataTemplate>
            No players found
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# BuildUrl() %>' Target="_blank">
            <br />
            Click here to create a new player[new window]</asp:HyperLink>
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        DeleteCommand="DELETE FROM [Players] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Players] ([Name], [Email], [NickName], [Department], [Id]) VALUES (@Name, @Email, @NickName, @Department, @Id)"
        SelectCommand="PlayersGet" SelectCommandType="StoredProcedure"
        CancelSelectOnNullParameter="false"       
        UpdateCommand="UPDATE [Players] SET [Name] = @Name, [Email] = @Email, [NickName] = @NickName, [Department] = @Department WHERE [Id] = @Id" >
        <SelectParameters>
            <asp:ProfileParameter Name="OrganisationId" PropertyName="OrganisationId" Type="String" />
            <asp:QueryStringParameter Name="TournamentId" ConvertEmptyStringToNull="true" 
                QueryStringField="TournamentId" Direction="Input" DbType="String" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Object" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="NickName" Type="String" />
            <asp:Parameter Name="Department" Type="String" />
            <asp:Parameter Name="Id" Type="Object" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="NickName" Type="String" />
            <asp:Parameter Name="Department" Type="String" />
            <asp:Parameter Name="Id" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>