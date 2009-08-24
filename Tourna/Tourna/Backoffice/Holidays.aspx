<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="Holidays.aspx.cs" Inherits="StrongerOrg.Backoffice.Holidyas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Organisation Holidays</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%">
        <tr>
            <td class="GrayTitle">
                Organisation Holidays
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="Id" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                    </Columns>
                    <EmptyDataTemplate>
                        No holidays found for this organisation
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>" 
                    DeleteCommand="DELETE FROM [OrganisationHolidays] WHERE [Id] = @Id" 
                    InsertCommand="INSERT INTO [OrganisationHolidays] ([Name], [Date], [OrganisationId]) VALUES (@Name, @Date, @OrganisationId)" 
                    SelectCommand="SELECT [Name], [Date], [OrganisationId], [Id] FROM [OrganisationHolidays] WHERE ([OrganisationId] = @OrganisationId)" 
                    UpdateCommand="UPDATE [OrganisationHolidays] SET [Name] = @Name, [Date] = @Date, [OrganisationId] = @OrganisationId WHERE [Id] = @Id">
                    <SelectParameters>
                        <asp:CookieParameter CookieName="OrganisationId" Name="OrganisationId" 
                            Type="Object" />
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
            <td style="height:1px;background-color:Fuchsia">
                
            </td>
        </tr>
        <tr>
            <td>
                <asp:FormView ID="FormView1" runat="server" DataKeyNames="Id" 
                    DataSourceID="SqlDataSource1" DefaultMode="Insert">
                    <InsertItemTemplate>
                        <table>
                <tr>
                    <td>
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
                        <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Date
                    </td>
                    <td style="margin-left: 40px">
                        <telerik:RadDatePicker ID="tdpDate" runat="server" SelectedDate='<%# Bind("Date") %>' >
                            <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                            </Calendar>
                            <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                        </telerik:RadDatePicker>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td style="margin-left: 40px; text-align: right">
                        <asp:LinkButton ID="InsertCancelButton" runat="server" 
                            CausesValidation="False" CommandName="Cancel" Text="Cancel" /> <asp:LinkButton ID="lbAdd" runat="server" CommandName="Insert">Insert</asp:LinkButton>
                    </td>
                </tr>
            </table>
                        
                    </InsertItemTemplate>
                </asp:FormView>
                
            </td>
        </tr>
    </table>
</asp:Content>
