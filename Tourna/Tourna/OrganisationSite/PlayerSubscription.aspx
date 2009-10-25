<%@ Page Title="" Language="C#" MasterPageFile="~/OrganisationSite/OrgSite.Master"
    AutoEventWireup="true" CodeBehind="PlayerSubscription.aspx.cs" Inherits="StrongerOrg.PlayerSubscription"
    Theme="OrganisationSite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Join a tournament</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
    <asp:Panel ID="Panel1" runat="server">
        <table border="0" style="width: 550px">
            <tr>
                <td colspan="2" class="H1Title" style="height: 50px">
                    Register to tournament
                </td>
            </tr>
            <tr>
                <td>
                    Your Name:
                </td>
                <td>
                    <telerik:RadTextBox runat="server" Columns="40" EmptyMessage="-- Your Name --" ID="txtName"
                        Width="220px">
                        <EnabledStyle BorderColor="#aaa2fe" BorderStyle="Solid" />
                        <EmptyMessageStyle ForeColor="#aaa2fe" />
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                        ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <%-- <tr>
                <td>
                    Nick Name:
                </td>
                <td>
                    <asp:TextBox ID="txtNickName" runat="server"  />
                </td>
            </tr>--%>
            <tr>
                <td>
                    Email:
                </td>
                <td>
                    <telerik:RadTextBox runat="server" Columns="40" EmptyMessage="-- Your Email --" ID="txtEmail"
                        Width="220px">
                        <EnabledStyle BorderColor="#aaa2fe" BorderStyle="Solid" />
                        <EmptyMessageStyle ForeColor="#aaa2fe" />
                    </telerik:RadTextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Email is not valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <%--<tr>
                <td>
                    Department:
                </td>
                <td>
                    <asp:TextBox ID="txtDepartment" runat="server"  />
                </td>
            </tr>--%>
            <tr>
                <td style="vertical-align: top">
                    Tournament Title:
                </td>
                <td>
                    <%--<asp:RadioButtonList ID="RadioButtonList1" runat="server" DataSourceID="SqlDataSource2"
                        DataTextField="TournamentName" DataValueField="Id" RepeatColumns="2">
                    </asp:RadioButtonList>--%>
                    <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource2">
                        <ItemTemplate>
                            <asp:Label ID="lblTournametTitle" runat="server" Text='<%#Eval("TournamentName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:FormView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
                        SelectCommand="TournamentsGet" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="TournamentId" QueryStringField="TournamentId" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right">
                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                        Text="Insert" OnClick="InsertButton_Click" />&nbsp;
                    <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                        Text="Cancel" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
