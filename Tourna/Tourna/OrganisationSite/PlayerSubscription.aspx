<%@ Page Title="" Language="C#" MasterPageFile="~/OrganisationSite/OrgSite.Master"
    AutoEventWireup="true" CodeBehind="PlayerSubscription.aspx.cs" Inherits="StrongerOrg.PlayerSubscription"
    Theme="OrganisationSite" %>

<%@ MasterType VirtualPath="~/OrganisationSite/OrgSite.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Join a tournament</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <ul class="lavaLampBottomStyle" id="M1">
        <li></li>
        <li><a href="ContactModerator.aspx?orgId=<%= Request.QueryString["OrgId"].ToString()%>">
            Contact Moderator</a></li>
        <li><a href="Rules.aspx?orgId=<%= Request.QueryString["OrgId"].ToString() %>">Rules</a></li>
        <li><a href="EventGallery.aspx?orgId=<%= Request.QueryString["OrgId"].ToString() %>">
            Event Gallery</a></li>
        <li><a href="Leagues.aspx?orgId=<%= Request.QueryString["OrgId"].ToString() %>">Tournaments</a></li>
    </ul>
    <script type="text/javascript">
        function ClearForm() {
            return false;
        }
</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:PlaceHolder ID="phRegister" runat="server" Visible="false">
    <table border="0" cellpadding="5" style="-moz-border-radius: 15px; -webkit-border-radius: 10px;
        border-radius: 10px; width: 600px; border: 1px solid #ADA6FF; background-color: White;height:100px"
        align="center">
        <tr>
            <td colspan="2" class="H1Title" style="height: 50px">
                <asp:Label ID="lblMsg" runat="server" CssClass="H1Title"></asp:Label>
            </td>
        </tr>
    </table>
    </asp:PlaceHolder>
    <asp:Panel ID="Panel1" runat="server">
        
        <table border="0" cellpadding="5" style="-moz-border-radius: 15px; -webkit-border-radius: 10px;
            border-radius: 10px; width: 500px; border: 1px solid #ADA6FF; background-color: White;"
            align="center">
            <tr>
                <td colspan="2" class="H1Title" style="height: 50px">
                    Register to tournament
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top">
                    Tournament Title:
                </td>
                <td align="right">
                    <%--<asp:RadioButtonList ID="RadioButtonList1" runat="server" DataSourceID="SqlDataSource2"
                        DataTextField="TournamentName" DataValueField="Id" RepeatColumns="2">
                    </asp:RadioButtonList>--%>
                    <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource2">
                        <ItemTemplate>
                            <asp:Label ID="lblTournametTitle" runat="server" Text='<%#Eval("TournamentName") %>'
                                Font-Bold="true"></asp:Label>
                        </ItemTemplate>
                    </asp:FormView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
                        SelectCommand="TournamentsGet" SelectCommandType="StoredProcedure" CancelSelectOnNullParameter="false">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="OrganisationId" QueryStringField="OrgId" Type="String"
                                ConvertEmptyStringToNull="true" />
                            <asp:QueryStringParameter Name="TournamentId" QueryStringField="TournamentId" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    Your Name:
                </td>
                <td align="right">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                        ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtName" runat="server" Width="220px"></asp:TextBox>
                    
                </td>
            </tr>
             
            <tr>
                <td>
                    Email:
                </td>
                <td align="right">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Email is not valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="txtEmail" runat="server" Width="220px"></asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTeam" runat="server" Text="Team"></asp:Label>
                </td>
                <td align="right">
                    <asp:DropDownList ID="ddlTeams" runat="server" DataSourceID="SqlDataSource1" 
                        DataTextField="Name" DataValueField="Id">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>" 
                        SelectCommand="PlayersGet" SelectCommandType="StoredProcedure" 
                        onselected="SqlDataSource1_Selected">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="OrganisationId" QueryStringField="OrgId" 
                                Type="String" />
                            <asp:QueryStringParameter Name="TournamentId" QueryStringField="TournamentId" 
                                Type="String" />
                            <asp:Parameter DefaultValue="T" Name="CompetitorType" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
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
                <td colspan="2" style="text-align: right">
                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                        Text="Register" OnClick="InsertButton_Click" />&nbsp;
                    <img src="../Images/Icons/Seperator.gif" />&nbsp;
                    <a href="" onclick="ClearForm()">Cancel</a> 
                  
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
