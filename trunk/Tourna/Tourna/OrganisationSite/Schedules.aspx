<%@ Page Title="" Language="C#" MasterPageFile="~/OrganisationSite/OrgSite.Master"
    AutoEventWireup="true" CodeBehind="Schedules.aspx.cs" Inherits="StrongerOrg.OrganisationSite.Schedules"
    Theme="OrganisationSite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Schedules</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <telerik:RadScheduler ID="RadScheduler1" runat="server" DataEndField="End" DataKeyField="Id"
        DataSourceID="SqlDataSource1" DataStartField="Start" DataSubjectField="Subject"
        HoursPanelTimeFormat="htt" ValidationGroup="RadScheduler1" SelectedView="MonthView"
        FirstDayOfWeek="Monday" LastDayOfWeek="Friday" ReadOnly="true" Height="800">
        <Localization AdvancedAllDayEvent="All day"></Localization>
        <AdvancedForm DateFormat="M/d/yyyy" TimeFormat="h:mm tt"></AdvancedForm>
    </telerik:RadScheduler>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        SelectCommand="SchedulesGet" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="TournamentId" QueryStringField="TournamentId" Type="String" />
            <asp:QueryStringParameter Name="OrganisationId" QueryStringField="OrgId" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>--%>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
        EnableModelValidation="True">
        <Columns>
            <asp:BoundField DataField="MatchupId" HeaderText="MatchupId" SortExpression="MatchupId" />
            <asp:BoundField DataField="Round" HeaderText="Round" SortExpression="Round" />
            <asp:TemplateField HeaderText="Game">
                <ItemTemplate>
                    <%# string.Format("{0} vs. {1}", Eval("PlayerA") ,Eval("PlayerB"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="NextMatchId" HeaderText="NextMatchId" SortExpression="NextMatchId" />
            <asp:BoundField DataField="Start" HeaderText="Start" SortExpression="Start" />
        </Columns>
        <EmptyDataTemplate>
            No mathchups yet!!
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetTournamentMatchups" TypeName="StrongerOrg.Backoffice.Entities.TournamentMatchupManager">
        <SelectParameters>
            <asp:QueryStringParameter DbType="Guid" Name="tournamentId" QueryStringField="TournamentId" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
