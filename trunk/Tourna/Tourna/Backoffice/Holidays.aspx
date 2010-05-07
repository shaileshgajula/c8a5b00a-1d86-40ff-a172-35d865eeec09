<%@ Page Title="Organisation Holidays" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master"
    AutoEventWireup="true" CodeBehind="Holidays.aspx.cs" Inherits="StrongerOrg.Backoffice.Holidyas" %>

<%@ MasterType VirtualPath="~/Backoffice/BackOffice.Master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                    DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" DataFormatString="{0:d}" />
                        <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Icons/trash.gif"
                                    CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete')" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        No holidays found for this organisation
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
                    DeleteCommand="DELETE FROM [OrganisationHolidays] WHERE [Id] = @Id" InsertCommand="INSERT INTO [OrganisationHolidays] ([Name], [Date], [OrganisationId]) VALUES (@Name, @Date, @OrganisationId)"
                    SelectCommand="SELECT [Name], [Date], [OrganisationId], [Id] FROM [OrganisationHolidays] WHERE ([OrganisationId] = @OrganisationId) order by [Date] desc"
                    UpdateCommand="UPDATE [OrganisationHolidays] SET [Name] = @Name, [Date] = @Date, [OrganisationId] = @OrganisationId WHERE [Id] = @Id"
                    OnDeleted="SqlDataSource1_Deleted">
                    <SelectParameters>
                        <asp:CookieParameter CookieName="OrganisationId" Name="OrganisationId" Type="String" />
                    </SelectParameters>
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="Date" Type="DateTime" />
                        <asp:Parameter Name="OrganisationId" Type="Object" />
                        <asp:Parameter Name="Id" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="Date" Type="DateTime" />
                        <asp:CookieParameter Name="OrganisationId" CookieName="OrganisationId" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="SelectedRowStyle">
            </td>
        </tr>
        <tr>
            <td style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td>
                <asp:FormView ID="FormView1" runat="server" DataKeyNames="Id" DataSourceID="SqlDataSource1"
                    DefaultMode="Insert" OnItemInserted="FormView1_ItemInserted">
                    <InsertItemTemplate>
                        <table>
                            <tr>
                                <td class="GrayTitleNormal">
                                    Add new holiday date
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Name
                                </td>
                                <td style="margin-left: 40px">
                                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>' Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Date
                                </td>
                                <td style="margin-left: 40px">
                                    <telerik:RadDatePicker ID="tdpDate" runat="server" SelectedDate='<%# Bind("Date") %>'
                                        Width="200px">
                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                                        </Calendar>
                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                    </telerik:RadDatePicker>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; height: 50px" colspan="2">
                                    <asp:LinkButton ID="lbAdd" runat="server" CommandName="Insert">Insert</asp:LinkButton>
                                    |
                                    <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Text="Cancel" />
                                </td>
                            </tr>
                        </table>
                    </InsertItemTemplate>
                </asp:FormView>
            </td>
        </tr>
    </table>
</asp:Content>
