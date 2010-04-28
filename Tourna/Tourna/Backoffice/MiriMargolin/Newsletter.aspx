<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true" CodeBehind="Newsletter.aspx.cs" Inherits="StrongerOrg.Backoffice.MiriMargolin.Newsletter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1" EnableModelValidation="True" DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="FullName" HeaderText="Full Name" 
                SortExpression="FullName" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:StrongerOrgConnectionString %>" 
        DeleteCommand="DELETE FROM [Newsletter] WHERE [Id] = @Id" 
        InsertCommand="INSERT INTO [Newsletter] ([FullName], [Email]) VALUES (@FullName, @Email)" 
        SelectCommand="SELECT [FullName], [Email], [Id] FROM [Newsletter]" 
        UpdateCommand="UPDATE [Newsletter] SET [FullName] = @FullName, [Email] = @Email WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="FullName" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="FullName" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
