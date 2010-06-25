<%@ Page Title="Team Tournament" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master"
    AutoEventWireup="true" CodeBehind="TeamTournament.aspx.cs" Inherits="StrongerOrg.Backoffice.TeamTournament" %>

<%@ MasterType VirtualPath="~/Backoffice/BackOffice.Master" %>
<%@ Register Src="UserControls/TournamentDetails.ascx" TagName="TournamentDetails"
    TagPrefix="uc1" %>
<%@ Register Src="UserControls/CalendarDisplay.ascx" TagName="CalendarDisplay" TagPrefix="uc3" %>
<%@ Register Src="UserControls/Feedbacks.ascx" TagName="Feedbacks" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;" cellpadding="0" cellspacing="5">
        <tr>
            <td class="GrayTitle">
                <a href="Tournaments.aspx" title="Tournaments list" alt="Tournaments list"><<</a>
                Tournament Managment -
                <asp:Label ID="lblTournamentName" runat="server" Text="" CssClass="ThemeTitle"></asp:Label>
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
                        <asp:MenuItem Text="Standings [Grid view]" Value="1" SeparatorImageUrl="~/Images/Icons/Seperator.gif">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Standings [Calendar view]" Value="2" SeparatorImageUrl="~/Images/Icons/Seperator.gif">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Feedbacks" Value="3" SeparatorImageUrl="~/Images/Icons/Seperator.gif">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Control Panel" Value="4" SeparatorImageUrl="~/Images/Icons/Seperator.gif">
                        </asp:MenuItem>
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
                    <asp:View ID="TournamentDetails" runat="server">
                        <uc1:TournamentDetails ID="TournamentDetails1" runat="server" />
                    </asp:View>
                    <asp:View ID="GridView" runat="server">
                    </asp:View>
                    <asp:View ID="CalendarView" runat="server">
                        <uc3:CalendarDisplay ID="CalendarDisplay1" runat="server" />
                    </asp:View>
                    <asp:View ID="FeedbacksView" runat="server">
                        <uc2:Feedbacks ID="Feedbacks1" runat="server" TextContentName="Feedbacks" IsEditMode="True" />
                    </asp:View>
                    <asp:View ID="ContorlPanelView" runat="server">
                        cp view
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>
