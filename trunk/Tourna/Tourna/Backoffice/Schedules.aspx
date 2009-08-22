<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="Schedules.aspx.cs" Inherits="StrongerOrg.Backoffice.Schedules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Schedules</title>

    <script type="text/javascript">
			function Export(sender, e)
			{
				$find("<%= RadAjaxManager1.ClientID %>").__doPostBack(sender.name, "");
			}
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadScheduler1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadScheduler1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <asp:ImageButton runat="server" ID="Button2" ImageUrl="~/Images/Icons/exportButton.gif"
        AlternateText="Export All to iCalendar" OnClientClick="Export(this, event); return false;"
        OnClick="Button2_Click" />
    <telerik:RadScheduler ID="RadScheduler1" runat="server" DataEndField="End" DataKeyField="Id"
        DataSourceID="SqlDataSource1" DataStartField="Start" DataSubjectField="Subject"
        HoursPanelTimeFormat="htt" ValidationGroup="RadScheduler1" SelectedView="MonthView"
        FirstDayOfWeek="Monday" LastDayOfWeek="Friday" StartInsertingInAdvancedForm="True"
        OnFormCreated="RadScheduler1_FormCreated" OnAppointmentCommand="RadScheduler1_AppointmentCommand"
        Height="650px">
        <Localization AdvancedAllDayEvent="All day" ConfirmDeleteText="Are you sure you want to delete the scheduled game?">
        </Localization>
        <AdvancedForm DateFormat="M/d/yyyy" TimeFormat="h:mm tt"></AdvancedForm>
        <ResourceStyles>
            <telerik:ResourceStyleMapping Type="Calendar" Text="Development" ApplyCssClass="rsCategoryGreen" />
        </ResourceStyles>
        <AdvancedInsertTemplate>
            <asp:SqlDataSource ID="SqlDataSourceTournamentPlayers" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
                SelectCommand="PlayersGet" SelectCommandType="StoredProcedure" CancelSelectOnNullParameter="true">
                <SelectParameters>
                <asp:CookieParameter Name="OrganisationId" CookieName="OrganisationId" Type="String" />
                    <%--<asp:ProfileParameter Name="OrganisationId" PropertyName="OrganisationId" Type="String" />--%>
                    <asp:QueryStringParameter Name="TournamentId" QueryStringField="TournamentId" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <table>
                <tr>
                    <td>
                        Insert mode!!
                    </td>
                </tr>
                <tr>
                    <td>
                        Player A
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPlayerA" runat="server" DataSourceID="SqlDataSourceTournamentPlayers"
                            DataTextField="Name" DataValueField="Id">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Player B
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPlayerB" runat="server" DataSourceID="SqlDataSourceTournamentPlayers"
                            DataTextField="Name" DataValueField="Id">
                        </asp:DropDownList>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator"
                            ControlToCompare="ddlPlayerB" ControlToValidate="ddlPlayerA" Operator="NotEqual"
                            Text="Player A can't play itself. please select diffrent player to play against"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Start time:
                    </td>
                    <td>
                        <%#DateTime.Parse(Eval("start").ToString()).ToShortDateString() %>
                        <telerik:RadTimePicker ID="RadTimePicker1" runat="server" ShowPopupOnFocus="true"
                            SelectedDate="12:00:00">
                            <TimeView runat="server" Interval="00:15:00" StartTime="08:00:00" EndTime="18:00:00">
                            </TimeView>
                        </telerik:RadTimePicker>
                    </td>
                </tr>
                <tr>
                    <td>
                        A game is typiclly around 10 minuts;
                    </td>
                    <td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                        Style="margin-right: 8px;" Text="Cancel" />
                    <asp:LinkButton ID="InsertButton" runat="server" CommandName="Insert">Insert</asp:LinkButton>
                    <td>
                </tr>
            </table>
        </AdvancedInsertTemplate>
    </telerik:RadScheduler>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        SelectCommand="SchedulesGet" SelectCommandType="StoredProcedure" DeleteCommand="ScheduleDelete"
        DeleteCommandType="StoredProcedure" UpdateCommand="ScheduleUpdate" UpdateCommandType="StoredProcedure" CancelSelectOnNullParameter="false">
        <SelectParameters>
            <asp:QueryStringParameter Name="TournamentId" QueryStringField="TournamentId" Type="String" />
            <asp:CookieParameter Name="OrganisationId" CookieName="OrganisationId" Type="String" ConvertEmptyStringToNull="true" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Id" Type="Int32" />
            <asp:Parameter Name="Start" Type="DateTime" />
            <asp:Parameter Name="End" Type="DateTime" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Backoffice/UnscheduledPlayers.aspx">Conflicts and Unscheduled players [##]</asp:HyperLink></asp:Content>
