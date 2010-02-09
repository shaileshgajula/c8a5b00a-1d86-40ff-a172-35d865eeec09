<%@ Page Title="Tournaments" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master"
    AutoEventWireup="true" CodeBehind="Tournaments.aspx.cs" Inherits="StrongerOrg.Backoffice.Tournaments" %>
<%@ MasterType VirtualPath="~/Backoffice/BackOffice.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="TourneyLogic.Web.UI.BracketControl.v2" Namespace="TourneyLogic.Web.UI.WebControls"
    TagPrefix="tl" %>
<%@ Register Src="UserControls/TournamentDetails.ascx" TagName="TournamentDetails"
    TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Backoffice/TournamentBuilder.aspx">Compose a new tournament</asp:HyperLink><br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id, TournamentName"
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
            <asp:CommandField HeaderText="Del" ShowDeleteButton="True" DeleteText="Del" />
        </Columns>
        <EmptyDataTemplate>
            No Data Found
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
    <table style="width: 100%;" cellpadding="0" cellspacing="5">
        <tr>
            <td class="GrayTitle">
                Tournament Managment -
                <asp:Label ID="lblTournamentName" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" OnMenuItemClick="navMenu_MenuItemClick">
                    <StaticMenuItemStyle HorizontalPadding="10" />
                    <StaticSelectedStyle CssClass="SelectedRowStyle" />
                    <StaticHoverStyle CssClass="SelectedRowStyle" />
                    <Items>
                        <asp:MenuItem Text="Tournament details" Value="0" Selected="true" SeparatorImageUrl="~/Images/Icons/Seperator.gif">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Standings [Grid view]" Value="2" SeparatorImageUrl="~/Images/Icons/Seperator.gif">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Standings [Calendar view]" Value="1" SeparatorImageUrl="~/Images/Icons/Seperator.gif">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Standings [Brackets view]" Value="3" SeparatorImageUrl="~/Images/Icons/Seperator.gif">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Actions" Value="4"></asp:MenuItem>
                    </Items>
                </asp:Menu>
            </td>
        </tr>
        <tr>
            <td class="ThemeBorder">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 20px;">
                <asp:MultiView ID="mvTournament" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View5" runat="server">
                        <uc1:TournamentDetails ID="TournamentDetails1" runat="server" />
                    </asp:View>
                    <asp:View ID="View1" runat="server">
                        <div style="width: 100%" align="center">
                            <asp:Label ID="lblCalendarMatchupResult" runat="server" Text="Label" Visible="false"
                                CssClass="GrayTextLight"></asp:Label>
                            <asp:LinkButton ID="lbCreateMatchUps" runat="server" Visible="false" CssClass="GrayTextLight">click here</asp:LinkButton>
                            <asp:Label ID="lblRememberEdit" runat="server" CssClass="GrayTextLight" Text=".Remember, you can always edit the match up manually."
                                Visible="false"></asp:Label>
                            <asp:Calendar ID="calSchedules" runat="server" Visible="true" Width="50%" Height="250px">
                            </asp:Calendar>
                        </div>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                            DataSourceID="standingsSqlDataSource">
                            <EmptyDataTemplate>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:BoundField DataField="Start" HeaderText="Start" SortExpression="Start" ReadOnly="true" />
                                <asp:TemplateField HeaderText="Game">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="hlScoreUpdatePlayerA" runat="server" Target="_blank" NavigateUrl='<%#BuildNavigateUrl(Eval("Id"), Eval("PlayerAId")) %>'><%#Eval("PlayerAName") %></asp:HyperLink>
                                        vs. 
                                        <asp:HyperLink ID="hlScoreUpdatePlayerB" runat="server" Target="_blank" NavigateUrl='<%#BuildNavigateUrl(Eval("Id"), Eval("PlayerBId")) %>'><%# Eval("PlayerBName")%></asp:HyperLink>
                                        
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
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images/Icons/Trophy.gif" HeaderText="Set Score"
                                    ShowEditButton="True" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                    UpdateText="Save">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" CssClass="navigate" />
                                </asp:CommandField>
                                
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="standingsSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
                            SelectCommand="StandingsGet" SelectCommandType="StoredProcedure" UpdateCommand="StandingUpdate"
                            UpdateCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="GridView1" PropertyName="SelectedValue" Name="TournamentId"
                                    ConvertEmptyStringToNull="true" DbType="Object" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="ScoreA" Type="Int32" />
                                <asp:Parameter Name="ScoreB" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                        <div style="text-align: right">
                            <asp:LinkButton ID="lbEditPicksMode" runat="server" OnClick="lbEditPicksMode_Click">Edit</asp:LinkButton>
                            <img src="../Images/Icons/PrinterIcon.gif" />
                            <asp:HyperLink ID="hlPrint" runat="server">Print</asp:HyperLink>
                            <img src="../Images/Icons/PdfIcon.gif" />
                            <asp:HyperLink ID="HyperLink2" runat="server">Export to pdf</asp:HyperLink>
                        </div>
                        <tl:Bracket runat="server" ID="Bracket1" ChampionshipText="Champion" DisplayMode="ViewMode"
                            RoundWidth="100"></tl:Bracket>
                    </asp:View>
                    <asp:View ID="View4" runat="server">
                        Actions:
                        <ul>
                            <li>
                                <asp:LinkButton ID="LinkButton1" runat="server">Schedule registred players</asp:LinkButton></li>
                            <li>
                                <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="lbClearAllScheduledGames"
                                    ConfirmText="By deleting all match up you are deleteing any scores and you will not be able to reproduce it">
                                </ajax:ConfirmButtonExtender>
                                <asp:LinkButton ID="lbClearAllScheduledGames" runat="server" OnClick="lbClearAllScheduledGames_Click">Clear all Scheduled games</asp:LinkButton></li>
                            <asp:Label ID="lblClearAllScheduledGames" runat="server" Text="All scheduled games have been deleted"
                                Visible="false"></asp:Label>
                            <li>
                                <asp:LinkButton ID="lblCloseRegistration" runat="server">Close registration</asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="LinkButton4" runat="server">Build Schedules manually...</asp:LinkButton></li>
                        </ul>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
