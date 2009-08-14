<%@ Page Title="" Language="C#" MasterPageFile="~/OrganisationSite/OrgSite.Master"
    AutoEventWireup="true" CodeBehind="Standings.aspx.cs" Inherits="Tourna.OrganisationSite.Standings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Standings</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:DataList ID="dlTournaments" runat="server" DataSourceID="Tournaments" DataKeyField="Id"
        OnItemDataBound="dlTournaments_ItemDataBound" GridLines="Vertical" RepeatColumns="2"
        RepeatLayout="Table">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%#Eval("TournamentName") %>'></asp:Label>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                DataSourceID="SqlDataSource1">
                <EmptyDataTemplate>
                    No Schedules yet !!!
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
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
                SelectCommand="StandingsGet" SelectCommandType="StoredProcedure" 
                UpdateCommand="StandingUpdate" UpdateCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter Name="TournamentId" DbType="Guid" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="ScoreA" Type="Int32"  />
                    <asp:Parameter Name="ScoreB" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource ID="Tournaments" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        SelectCommand="TournamentsGet" SelectCommandType="StoredProcedure" CancelSelectOnNullParameter="false">
        <SelectParameters>
            <asp:QueryStringParameter Name="OrganisationId" QueryStringField="OrgId" Type="String" />
            <asp:QueryStringParameter Name="TournamentId" QueryStringField="TournamentId" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
