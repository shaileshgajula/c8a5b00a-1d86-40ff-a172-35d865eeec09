<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="DefaultHolidays.aspx.cs" Inherits="StrongerOrg.Backoffice.DefaultHolidays" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Default Holidays</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%">
        <tr>
            <td class="GrayTitle" colspan="2">
                Default Holidays
            </td>
        </tr>
        <tr>
            <td>
                Select Culture
            </td>
            <td>
               <asp:DropDownList ID="ddlCountries" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="en-US">English - USA</asp:ListItem>
                        <asp:ListItem Value="he-IL">Hebrew -  Israel</asp:ListItem>
                        <asp:ListItem Value="uk-UA">Ukraine - Ukraine</asp:ListItem>
                    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                    DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="CultureInfoName" HeaderText="Culture info name" SortExpression="CultureInfoName" ReadOnly="true" />
                        <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                    </Columns>
                    <EmptyDataTemplate>
                        No holidays found for this culture
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>" InsertCommandType="Text"
                    SelectCommand="SELECT [Id], [Name], [Date], [CultureInfoName] FROM [DefaultHolidays] WHERE ([CultureInfoName] = @CultureInfoName and [Date]>= getdate())  order by date "
                    InsertCommand="INSERT INTO [DefaultHolidays] values (@Name, @Date, @CultureInfoName)"
                    DeleteCommand="DELETE FROM [DefaultHolidays] WHERE ID=@Id"
                    UpdateCommand="UPDATE [DefaultHolidays] SET Name=@Name, Date=@Date where Id=@Id">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlCountries" Name="CultureInfoName" PropertyName="SelectedValue"
                            Type="String" />
                    </SelectParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="Date" Type="DateTime" />
                        <asp:ControlParameter ControlID="ddlCountries" Name="CultureInfoName" PropertyName="SelectedValue" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="Date" Type="DateTime" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:FormView ID="FormView1" runat="server" DefaultMode="Insert" DataSourceID="SqlDataSource1">
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
                        <asp:LinkButton ID="lbAdd" runat="server" CommandName="Insert">Insert</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
