<%@ Page Title="F.A.Q" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master"
    AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="StrongerOrg.Backoffice.Administrator.FAQ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <EmptyDataTemplate>
            No Faq found</EmptyDataTemplate>
        <Columns>
            <asp:BoundField DataField="Caption" HeaderText="Caption" SortExpression="Caption" />
            <asp:BoundField DataField="Content" HeaderText="Content" SortExpression="Content" />
            <asp:CommandField ShowDeleteButton="True" />
            <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        DeleteCommand="DELETE FROM [TextContent] WHERE [Id] = @Id" InsertCommand="INSERT INTO [TextContent] ([ContentType], [Caption], [Content], [OrganisationId]) VALUES (@ContentType, @Caption, @Content, @OrganisationId)"
        SelectCommand="SELECT [Id], [ContentType], [Caption], [Content], [OrganisationId] FROM [TextContent] WHERE (([OrganisationId] = @OrganisationId) AND ([ContentType] = @ContentType))"
        UpdateCommand="UPDATE [TextContent] SET [ContentType] = @ContentType, [Caption] = @Caption, [Content] = @Content WHERE [Id] = @Id">
        <SelectParameters>
            <asp:CookieParameter CookieName="OrganisationId" Name="OrganisationId" Type="String" />
            <asp:Parameter DefaultValue="FAQ" Name="ContentType" Type="String" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="ContentType" Type="String" DefaultValue="FAQ" />
            <asp:Parameter Name="Caption" Type="String" />
            <asp:Parameter Name="Content" Type="String" />
            <asp:Parameter Name="OrganisationId" Type="String" />
            <asp:Parameter Name="SelectedId" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="ContentType" Type="String" DefaultValue="FAQ" />
            <asp:Parameter Name="Caption" Type="String" />
            <asp:Parameter Name="Content" Type="String" />
            <asp:CookieParameter CookieName="OrganisationId" Name="OrganisationId" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
    <br />
    <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource2" OnItemUpdated="FormView1_ItemUpdated"
        OnItemInserted="FormView1_ItemInserted" DataKeyNames="Id">
        <EditItemTemplate>
            <table cellpadding="4">
                <tr>
                    <td colspan="2" class="GrayTitleNormal">
                        Update FAQ
                    </td>
                </tr>
                <tr>
                    <td>
                        Caption:
                    </td>
                    <td>
                        <asp:TextBox ID="CaptionTextBox" runat="server" Text='<%# Bind("Caption") %>' Width="450px" />
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top">
                        Content:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Content") %>' TextMode="MultiLine"
                            Rows="20" Height="100px" Width="450px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: right">
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                            Text="Update" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                            CommandName="Cancel" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </EditItemTemplate>
        <InsertItemTemplate>
            <table cellpadding="4">
                <tr>
                    <td colspan="2" class="GrayTitleNormal">
                        Insert new FAQ
                    </td>
                </tr>
                <tr>
                    <td>
                        Caption:
                    </td>
                    <td>
                        <asp:TextBox ID="CaptionTextBox" runat="server" Text='<%# Bind("Caption") %>' Width="450px" />
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top">
                        Content:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Content") %>' TextMode="MultiLine"
                            Rows="20" Height="100px" Width="450px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: right">
                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                            Text="Insert" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                            CommandName="Cancel" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </InsertItemTemplate>
        <ItemTemplate>
            <asp:LinkButton ID="lbNewFAQ" runat="server" OnClick="lbNewFAQ_Click">Compose new FAQ</asp:LinkButton>
        </ItemTemplate>
        <EmptyDataTemplate>
            <asp:LinkButton ID="lbNewFAQ" runat="server" OnClick="lbNewFAQ_Click">Compose new FAQ</asp:LinkButton>
        </EmptyDataTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" CancelSelectOnNullParameter="false"
        ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>" InsertCommand="INSERT INTO [TextContent] ([ContentType], [Caption], [Content], [OrganisationId]) VALUES (@ContentType, @Caption, @Content, @OrganisationId)"
        SelectCommand="SELECT [Id], [ContentType], [Caption], [Content] FROM [TextContent] WHERE Id=@Id"
        UpdateCommand="UPDATE [TextContent] SET [ContentType] = @ContentType, [Caption] = @Caption, [Content] = @Content WHERE [Id] = @Id">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="Id" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="ContentType" Type="String" DefaultValue="FAQ" />
            <asp:Parameter Name="Caption" Type="String" />
            <asp:Parameter Name="Content" Type="String" />
            <asp:Parameter Name="OrganisationId" Type="String" />
            <asp:Parameter Name="SelectedId" Type="Int32" />
            <asp:ControlParameter ControlID="GridView1" Name="Id" PropertyName="SelectedValue"
                Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="ContentType" Type="String" DefaultValue="FAQ" />
            <asp:Parameter Name="Caption" Type="String" />
            <asp:Parameter Name="Content" Type="String" />
            <asp:CookieParameter CookieName="OrganisationId" Name="OrganisationId" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>
