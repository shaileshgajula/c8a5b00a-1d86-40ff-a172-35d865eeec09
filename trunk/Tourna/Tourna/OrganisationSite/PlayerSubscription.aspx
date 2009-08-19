<%@ Page Title="" Language="C#" MasterPageFile="~/OrganisationSite/OrgSite.Master"
    AutoEventWireup="true" CodeBehind="PlayerSubscription.aspx.cs" Inherits="StrongerOrg.PlayerSubscription"  Theme="OrganisationSite"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Join a tournament</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
    <asp:Panel ID="Panel1" runat="server">
        Subscribe to tournament
        <table>
            <tr>
                <td>
                    Your Name:
                </td>
                <td>
                    <asp:TextBox ID="NameTextBox" runat="server"  />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NameTextBox"
                        ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Nick Name:
                </td>
                <td>
                    <asp:TextBox ID="txtNickName" runat="server"  />
                </td>
            </tr>
            <tr>
                <td>
                    Email:
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"  />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Email is not valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Department:
                </td>
                <td>
                    <asp:TextBox ID="txtDepartment" runat="server"  />
                </td>
            </tr>
            <tr>
                <td>
                    Tournaments:
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" DataSourceID="SqlDataSource2"
                        DataTextField="TournamentName" DataValueField="Id">
                    </asp:RadioButtonList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
                        SelectCommand="TournamentsGet" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="OrganisationId" QueryStringField="OrgId" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                        Text="Cancel" />
                    &nbsp;<asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                        Text="Insert" OnClick="InsertButton_Click" />
                </td>
            </tr>
        </table>
        
    </asp:Panel>
</asp:Content>
