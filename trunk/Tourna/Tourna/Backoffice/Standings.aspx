<%@ Page Title="Standings" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master"
    AutoEventWireup="true" CodeBehind="Standings.aspx.cs" Inherits="StrongerOrg.Backoffice.Standings" %>

<%@ MasterType VirtualPath="~/Backoffice/BackOffice.Master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="dlTournaments" runat="server" DataSourceID="Tournaments" DataKeyField="Id"
        OnItemDataBound="dlTournaments_ItemDataBound" RepeatColumns="2" RepeatLayout="Table"
        GridLines="None" Width="100%" CellPadding="2" CellSpacing="5" AlternatingRowStyle-CssClass="AlternatingRow">
        <AlternatingItemStyle BackColor="#f7f7f6" VerticalAlign="Top" />
        <ItemStyle VerticalAlign="Top" Width="50%" />
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <table cellpadding="0" cellspacing="0" style="width:100%">
                <tr>
                    <td cssclass="GrayTitleNormal">
                        <%#Eval("TournamentName") %>
                    </td>
                    <td style="text-align: right;padding-right:10px">
                        <a href="BracketsDisplay.aspx?TournamentId=<%#Eval("Id") %>" >
                            <img src="../Images/Icons/BracketsIcon.gif" border="0" alt="Brackets display" title="Brackets display" /></a>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                DataSourceID="SqlDataSource1" OnDataBound="GridView1_DataBound">
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
                            <asp:TextBox ID="TextBox1" runat="server" Width="20" Text='<%# Bind("ScoreA") %>'></asp:TextBox>
                            <%#Eval("PlayerBName")%>
                            <asp:TextBox ID="TextBox2" runat="server" Width="20" Text='<%# Bind("ScoreB")%>'></asp:TextBox></EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Image" EditImageUrl="~/Images/Icons/Trophy.gif" HeaderText="Set Score" ShowEditButton="True" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  />
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
