<%@ Page Title="Tournaments" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master"
    AutoEventWireup="true" CodeBehind="Tournaments.aspx.cs" Inherits="StrongerOrg.Backoffice.Tournaments" %>

<%@ Register Assembly="TourneyLogic.Web.UI.BracketControl.v2" Namespace="TourneyLogic.Web.UI.WebControls"
    TagPrefix="tl" %>
<%@ Register Src="UserControls/TournamentDetails.ascx" TagName="TournamentDetails"
    TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Backoffice/TournamentBuilder.aspx">Compose a new tournament</asp:HyperLink><br />
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
                Tournament Managment
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
                        <asp:MenuItem Text="Standings [Calendar view]" Value="1" SeparatorImageUrl="~/Images/Icons/Seperator.gif">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Standings [Grid view]" Value="2" SeparatorImageUrl="~/Images/Icons/Seperator.gif">
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
                        <asp:Calendar ID="calSchedules" runat="server" Visible="true"></asp:Calendar>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <asp:GridView ID="schedDatesGrid" runat="server">
                        </asp:GridView>
                        <%--<asp:GridView ID="schedDatesGrid" runat="server" AutoGenerateColumns="true" 
                            DataKeyNames="Id" onrowcancelingedit="schedDatesGrid_RowCancelingEdit" 
                            onrowediting="schedDatesGrid_RowEditing">
                            <Columns>
                                <asp:BoundField DataField="StartDate" HeaderText=" Start Date" ReadOnly="true" />
                                <asp:BoundField DataField="GameName" HeaderText=" Game Title" ReadOnly="true" />
                                <asp:TemplateField HeaderText="Score">
                                    <ItemTemplate>
                                        <%# Eval("Score")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images/Icons/Trophy.gif" HeaderText="Set Score" ShowEditButton="True" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  />
                            </Columns>
                        </asp:GridView>--%>
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
