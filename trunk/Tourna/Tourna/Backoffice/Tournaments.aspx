<%@ Page Title="Tournaments" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master"
    AutoEventWireup="true" CodeBehind="Tournaments.aspx.cs" Inherits="StrongerOrg.Backoffice.Tournaments" %>

<%@ Register Assembly="TourneyLogic.Web.UI.BracketControl.v2" Namespace="TourneyLogic.Web.UI.WebControls"
    TagPrefix="tl" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        OnDataBound="GridView1_DataBound">
        <Columns>
            <asp:CommandField HeaderText="Select" ShowSelectButton="True" />
            <asp:BoundField DataField="TournamentName" HeaderText="Tournament Name" ReadOnly="True"
                SortExpression="TournamentName" />
            <asp:BoundField DataField="StartDate" HeaderText="Start Date" SortExpression="StartDate"
                DataFormatString="{0:d}" />
            <asp:BoundField DataField="Title" HeaderText="Game Title" SortExpression="Title" />
            <asp:BoundField DataField="NumberOfPlayersLimit" HeaderText="Limit" SortExpression="NumberOfPlayersLimit" />
            <asp:HyperLinkField DataNavigateUrlFields="Id,TournamentName" DataNavigateUrlFormatString="OrganisationPlayers.aspx?TournamentId={0}&TournamentName={1}"
                DataTextField="RegisteredPlayers" HeaderText="Registered" />
            <asp:HyperLinkField Text="Edit" />
            <%--<asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Backoffice/ControlPanel.aspx?TournamentId={0}"
                HeaderImageUrl="~/Images/Icons/scheduler.gif" HeaderText="Scheduales" Text="Scheduales" />
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Backoffice/Standings.aspx?TournamentId={0}"
                HeaderText="Standings" Text="Standing" />
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Backoffice/InvitToTournament.aspx?TournamentId={0}"
                HeaderText="Invite" Text="Invite" />--%>
            <asp:CommandField HeaderText="Del" ShowDeleteButton="True" DeleteText="Del" />
        </Columns>
        <EmptyDataTemplate>
            No Data Found
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Backoffice/TournamentBuilder.aspx">Compose a new tournament</asp:HyperLink>
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        DeleteCommand="DELETE FROM [Tournaments] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Tournaments] ([Id], [TournamentName], [Abstract]) VALUES (@Id, @TournamentName, @Abstract)"
        SelectCommand="TournamentsGet" UpdateCommand="UPDATE [Tournaments] SET [TournamentName] = @TournamentName, [Abstract] = @Abstract WHERE [Id] = @Id"
        SelectCommandType="StoredProcedure" CancelSelectOnNullParameter="false">
        <SelectParameters>
            <asp:CookieParameter CookieName="OrganisationId" Name="OrganisationId" Type="String" />
            <asp:Parameter Name="TournamentId" Type="String" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Object" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="TournamentName" Type="String" />
            <asp:Parameter Name="Abstract" Type="String" />
            <asp:Parameter Name="Id" Type="Object" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="Id" Type="Object" />
            <asp:Parameter Name="TournamentName" Type="String" />
            <asp:Parameter Name="Abstract" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
    <br />
    <table style="width: 100%;" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2" style="height: 60px">
                Tournament Managment
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 250px; border-right-color: Black; border-right-width: 1px;
                border-right-style: solid;">
                <asp:Menu ID="navMenu" runat="server" Orientation="Vertical" BorderWidth="0px" Width="100%"
                    OnMenuItemClick="navMenu_MenuItemClick">
                    <StaticSelectedStyle CssClass="SelectedRowStyle" />
                    <Items>
                        <asp:MenuItem Text="Calendar" Value="0" Selected="true"></asp:MenuItem>
                        <asp:MenuItem Text="Standings [Grid view]" Value="1"></asp:MenuItem>
                        <asp:MenuItem Text="Standings [Brackets view]" Value="2"></asp:MenuItem>
                        <asp:MenuItem Text="Actions" Value="3"></asp:MenuItem>
                    </Items>
                </asp:Menu>
            </td>
            <td style="padding-left: 20px; vertical-align: top;">
                <asp:MultiView ID="mvTournament" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <asp:Calendar ID="calSchedules" runat="server" Visible="true"></asp:Calendar>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <asp:GridView ID="schedDatesGrid" runat="server" AutoGenerateColumns="False" 
                            DataKeyNames="Id">
                            <Columns>
                                <asp:BoundField DataField="StartDate" HeaderText=" Start Date" ReadOnly="true" />
                                <asp:BoundField DataField="GameName" HeaderText=" Game Title" ReadOnly="true"/>
                                <asp:TemplateField HeaderText="Score">
                                    <ItemTemplate>
                                        <%# Eval("Score")%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                       222
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:CommandField
                                    ShowEditButton="True" ItemStyle-HorizontalAlign="Center" 
                                    HeaderStyle-HorizontalAlign="Center"  />
                                
                                
                            </Columns>
                        </asp:GridView>
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                        <asp:HyperLink ID="hlPrint" runat="server">Print</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink2" runat="server">Export to pdf</asp:HyperLink>
                        <tl:Bracket runat="server" ID="Bracket1" ChampionshipText="Champion" DisplayMode="ViewMode"
                            RoundWidth="130"></tl:Bracket>
                    </asp:View>
                    <asp:View ID="View4" runat="server">
                        <asp:LinkButton ID="LinkButton1" runat="server">Schedule registred players</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton2" runat="server">Clear all Scheduled games</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton3" runat="server">Close registration</asp:LinkButton><br />
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
