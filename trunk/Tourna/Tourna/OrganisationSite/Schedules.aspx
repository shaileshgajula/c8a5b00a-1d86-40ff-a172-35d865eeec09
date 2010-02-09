<%@ Page Title="" Language="C#" MasterPageFile="~/OrganisationSite/OrgSite.Master"
    AutoEventWireup="true" CodeBehind="Schedules.aspx.cs" Inherits="StrongerOrg.OrganisationSite.Schedules"
    Theme="OrganisationSite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Schedules</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadScheduler ID="RadScheduler1" runat="server" DataEndField="End" DataKeyField="Id"
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
    </asp:SqlDataSource>
</asp:Content>
