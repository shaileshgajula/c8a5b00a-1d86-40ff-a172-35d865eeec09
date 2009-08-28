<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="Games.aspx.cs" Inherits="StrongerOrg.Backoffice.Games" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Games</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblTitle" runat="server" Text="Games" CssClass="GrayTitle"></asp:Label>
<br/><br/>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="GamesSqlDataSource"
        ShowFooter="True" DataKeyNames="Id" >
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="GameDescription" HeaderText="GameDescription" SortExpression="GameDescription" />
            <asp:BoundField DataField="ConsoleName" HeaderText="ConsoleName" SortExpression="ConsoleName" />
            <asp:BoundField DataField="GameType" HeaderText="Game Type" SortExpression="GameType" />
            <asp:CheckBoxField DataField="IsOnline" HeaderText="IsOnline" />
            <asp:BoundField DataField="NumberOfCompetitors" HeaderText="# Competitors" SortExpression="NumberOfCompetitors" />
            <asp:CheckBoxField DataField="Active" HeaderText="Active" SortExpression="Active" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="GamesSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        SelectCommand="SELECT [Title], [GameDescription], [ConsoleName], [Active], [Id], [GameType], [NumberOfCompetitors], [IsOnline] FROM [Games] ORDER BY [Title]"
        DeleteCommand="DELETE FROM [Games] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Games] ([Title], [GameDescription], [ConsoleName], [Active],[GameType], [NumberOfCompetitors], [IsOnline]) VALUES (@Title, @GameDescription, @ConsoleName, @Active, @GameType, @NumberOfCompetitors, @IsOnline)"
        UpdateCommand="UPDATE [Games] SET [Title] = @Title, [GameDescription] = @GameDescription, [ConsoleName] = @ConsoleName, [Active] = @Active, GameType=@GameType, NumberOfCompetitors=@NumberOfCompetitors, IsOnline = @IsOnline  WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="GameDescription" Type="String" />
            <asp:Parameter Name="ConsoleName" Type="String" />
            <asp:Parameter Name="Active" Type="Boolean" />
            <asp:Parameter Name="Id" Type="Int32" />
            <asp:Parameter Name="GameType" Type="String" />
            <asp:Parameter Name="NumberOfCompetitors" Type="Int32" />
            <asp:Parameter Name="IsOnline" Type="Boolean" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="GameDescription" Type="String" />
            <asp:Parameter Name="ConsoleName" Type="String" />
            <asp:Parameter Name="Active" Type="Boolean" />
            <asp:Parameter Name="GameType" Type="String" />
            <asp:Parameter Name="NumberOfCompetitors" Type="Int32" />
            <asp:Parameter Name="IsOnline" Type="Boolean" />
        </InsertParameters>
    </asp:SqlDataSource>
    <br />
    <br />
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="Id"
        DataSourceID="GamesSqlDataSource" DefaultMode="Insert" 
        HeaderText="Insert new Game" GridLines="None" Width="50%" 
        AlternatingRowStyle-CssClass="AlternatingRow" 
        HeaderStyle-CssClass="HeaderStyle" oniteminserting="DetailsView1_ItemInserting">
        <Fields>
            <asp:TemplateField HeaderText="Title">
                <InsertItemTemplate>
                    <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("Title") %>' Width="250"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator"
                        ControlToValidate="txtTitle"></asp:RequiredFieldValidator>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="GameDescription" HeaderText="Game Description" SortExpression="GameDescription"
                ControlStyle-Width="250" />
            <asp:BoundField DataField="ConsoleName" HeaderText="Console Type" SortExpression="ConsoleName"
                ControlStyle-Width="250" />
            <asp:CheckBoxField DataField="Active" HeaderText="Active" SortExpression="Active" />
            <asp:BoundField DataField="GameType" HeaderText="Game Type" SortExpression="GameType" />
            <asp:BoundField DataField="NumberOfCompetitors" HeaderText="Number Of Competitors"
                SortExpression="NumberOfCompetitors" />
            <asp:CheckBoxField DataField="IsOnline" HeaderText="IsOnline" SortExpression="IsOnline" />
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True"
                SortExpression="Id" />
            <asp:TemplateField HeaderText="Game Image/Logo">
                <InsertItemTemplate>
                    <asp:FileUpload ID="fuGameImage" runat="server" FileName='<%# Bind("FileName") %>' /> Not implemented
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowInsertButton="True" ItemStyle-HorizontalAlign="Right" />
        </Fields>
    </asp:DetailsView>
</asp:Content>
