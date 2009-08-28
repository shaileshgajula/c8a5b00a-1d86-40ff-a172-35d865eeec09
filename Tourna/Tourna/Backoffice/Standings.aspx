<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="Standings.aspx.cs" Inherits="StrongerOrg.Backoffice.Standings" %>

<%@ MasterType VirtualPath="~/Backoffice/BackOffice.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblTitle" runat="server" Text="Standings" CssClass="GrayTitle"></asp:Label>
    <table style="width: 100%">
        <tr>
            <td style="text-align: right">
                <a href="BracketsDisplay.aspx">Grid Display</a>
                |
                <a href="BracketsDisplay.aspx">Brackets Display</a>
            </td>
        </tr>
    </table>
    
    <asp:DataList ID="dlTournaments" runat="server" DataSourceID="Tournaments" DataKeyField="Id"
        OnItemDataBound="dlTournaments_ItemDataBound" RepeatColumns="2" RepeatLayout="Table"
        GridLines="None" Width="100%" CellPadding="5" AlternatingRowStyle-CssClass="AlternatingRow">
        <AlternatingItemStyle BackColor="#f7f7f6" VerticalAlign="Top" />
        <ItemStyle VerticalAlign="Top" Width="50%" />
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%#Eval("TournamentName") %>' CssClass="GrayTitleNormal"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                DataSourceID="SqlDataSource1" ondatabound="GridView1_DataBound">
                <EmptyDataTemplate>
                   
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField DataField="Start" HeaderText="Start" SortExpression="Start" ReadOnly="true" />
                    <asp:TemplateField HeaderText="Game">
                        <ItemTemplate>
                            <%# string.Format("{0} vs. {1}", Eval("PlayerAName").ToString() ,Eval("PlayerBName").ToString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Score</HeaderTemplate>
                        <ItemTemplate>
                            <%# ScoreDisplay(Eval("ScoreA"), Eval("ScoreB")) %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <%#Eval("PlayerAName")%>
                            Score:
                            <asp:TextBox ID="TextBox1" runat="server" Width="30" Text='<%# Bind("ScoreA") %>'></asp:TextBox>
                            <%#Eval("PlayerBName")%>
                            Score:<asp:TextBox ID="TextBox2" runat="server" Width="30" Text='<%# Bind("ScoreB")%>'></asp:TextBox></EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Link" EditText="X" HeaderText="Set Score" ShowEditButton="True" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
                SelectCommand="StandingsGet" SelectCommandType="StoredProcedure" UpdateCommand="StandingUpdate"
                UpdateCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter Name="TournamentId" DbType="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="ScoreA" Type="Int32" />
                    <asp:Parameter Name="ScoreB" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource ID="Tournaments" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        SelectCommand="TournamentsGet" SelectCommandType="StoredProcedure" CancelSelectOnNullParameter="false">
        <SelectParameters>
            <asp:CookieParameter Name="OrganisationId" CookieName="OrganisationId" Type="String" />
            <asp:QueryStringParameter Name="TournamentId" QueryStringField="TournamentId" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
