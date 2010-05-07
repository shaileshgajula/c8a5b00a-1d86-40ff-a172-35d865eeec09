<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="Tournament.aspx.cs" Inherits="StrongerOrg.Backoffice.Tournament"
    Theme="Moderator" %>

<%@ Register Src="UserControls/Feedbacks.ascx" TagName="Feedbacks" TagPrefix="uc1" %>
<%@ Register Src="UserControls/FakeUsers.ascx" TagName="FakeUsers" TagPrefix="fu1" %>
<%@ MasterType VirtualPath="~/Backoffice/BackOffice.Master" %>
<%@ Register Src="UserControls/TournamentDetails.ascx" TagName="TournamentDetails"
    TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register src="UserControls/BracketsDisplay.ascx" tagname="BracketsDisplay" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                        <asp:MenuItem Text="Standings [Brackets view]" Value="3" SeparatorImageUrl="~/Images/Icons/Seperator.gif">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Feedbacks" Value="4" SeparatorImageUrl="~/Images/Icons/Seperator.gif">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Control Panel" Value="5" SeparatorImageUrl="~/Images/Icons/Seperator.gif">
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
                    <asp:View ID="View5" runat="server">
                        <uc1:TournamentDetails ID="TournamentDetails1" runat="server" />
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                       
                        <ajax:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pnlImageDisplay"
                            TargetControlID="hiddenTargetControlForModalPopup" CancelControlID="btnCancel"
                            BackgroundCssClass="modalBackground" BehaviorID="imgAssociatedModal">
                        </ajax:ModalPopupExtender>
                        <asp:Panel ID="pnlImageDisplay" runat="server" CssClass="ModalWindow" Width="500">
                            <table style="width: 100%" cellpadding="2" cellspacing="2">
                                <tr>
                                    <td colspan="2" class="GrayTitle">
                                        Update matchup
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="ThemeBorder">
                                        Update matchup
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Start Date:
                                    </td>
                                    <td align="right">
                                        <asp:TextBox ID="tbStartDate" runat="server" Width="82"></asp:TextBox>
                                        <ajax:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="tbStartDate"
                                            Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true">
                                        </ajax:MaskedEditExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Start Time:
                                    </td>
                                    <td align="right">
                                        <asp:DropDownList ID="ddlHours" runat="server">
                                            <asp:ListItem>12</asp:ListItem>
                                            <asp:ListItem>13</asp:ListItem>
                                            <asp:ListItem>14</asp:ListItem>
                                            <asp:ListItem>15</asp:ListItem>
                                            <asp:ListItem>16</asp:ListItem>
                                            <asp:ListItem>17</asp:ListItem>
                                            <asp:ListItem>18</asp:ListItem>
                                            <asp:ListItem>19</asp:ListItem>
                                            <asp:ListItem>20</asp:ListItem>
                                            <asp:ListItem>21</asp:ListItem>
                                            <asp:ListItem>22</asp:ListItem>
                                            <asp:ListItem>23</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddlMinutes" runat="server">
                                            <asp:ListItem Value="0">00</asp:ListItem>
                                            <asp:ListItem>15</asp:ListItem>
                                            <asp:ListItem>30</asp:ListItem>
                                            <asp:ListItem>45</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Player A:
                                    </td>
                                    <td align="right">
                                        <asp:DropDownList ID="ddlPlayerA" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name"
                                            DataValueField="Id" AppendDataBoundItems="true">
                                            <asp:ListItem Text="--" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Player B:
                                    </td>
                                    <td align="right">
                                        <asp:DropDownList ID="ddlPlayerB" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name"
                                            DataValueField="Id" AppendDataBoundItems="true">
                                            <asp:ListItem Text="--" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
                                            SelectCommand="SELECT p.Id, p.Name FROM Players2Tournaments AS p2t INNER JOIN Players AS p ON p2t.PlayerId = p.Id WHERE (p2t.TournamentId = @TournamentId)">
                                            <SelectParameters>
                                                <asp:QueryStringParameter Name="TournamentId" QueryStringField="TournamentId" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Winner
                                    </td>
                                    <td align="right">
                                        <asp:RadioButtonList ID="rblWinner" runat="server" RepeatDirection="Horizontal">
                                        </asp:RadioButtonList>
                                        <asp:HiddenField ID="hfNextMatchupId" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <br />
                                        <asp:LinkButton ID="btnUpdateStartDate" runat="server" OnClick="btnUpdateStartDate_Click">Update</asp:LinkButton>
                                        <img src="../Images/Icons/Seperator.gif" />
                                        <asp:LinkButton ID="btnCancel" runat="server">Close</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
                        <div align="right">
                            <a href="../OrganisationSite/PrintTournament.aspx?TournamentId=<%= Request.QueryString["TournamentId"].ToString() %>"
                                target="_blank">
                                <img src="../Images/Icons/PrinterIcon.gif" alt="Print" title="Print" border="0" style="vertical-align: top;" />
                                Print</a>
                        </div>
                        <asp:GridView ID="gvStandingsPreview" runat="server" AutoGenerateColumns="False"
                            OnRowDataBound="gvStandingsPreview_RowDataBound" EnableModelValidation="True">
                            <Columns>
                                <asp:BoundField DataField="MatchUpId" HeaderText="Id" ReadOnly="True" />
                                <asp:BoundField DataField="Round" HeaderText="Round" ReadOnly="True" />
                                <asp:BoundField DataField="PlayerA" HeaderText="Player A" ReadOnly="True" />
                                <asp:BoundField DataField="PlayerB" HeaderText="Player B" ReadOnly="false" />
                                <asp:BoundField DataField="NextMatchId" HeaderText="Next Match Id" ReadOnly="True" />
                                <asp:BoundField DataField="Start" HeaderText="Start" ReadOnly="True" DataFormatString="{0:f}" />
                                <asp:BoundField DataField="WinnerName" HeaderText="Winner Name" ReadOnly="True" />
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbStartDate" runat="server" CommandArgument='<%# Eval("Start") + "*" + Eval("MatchUpId") + "*" + Eval("PlayerAId") + "*" + Eval("PlayerBId")+ "*" + Eval("WinnerId") + "*" + Eval("NextMatchId") %>'
                                            OnCommand="lbStartDate_Command">Edit</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Score Update" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <a href="../OrganisationSite/StandingUpdate.aspx?OrgId=<%# Master.OrgBasicInfo.Id.ToString() %>&PlayerId=<%# Guid.Empty.ToString() %>&MatchupId=<%# Eval("Id") %>"
                                            target="_blank">...</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div id="Div1" class="ui-widget" runat="server">
                                    <div class="ui-state-highlight ui-corner-all" style="margin-top: 20px; padding: 0 .7em;">
                                        <p>
                                            <span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span>
                                            <strong>Alert:</strong> There are no matchup to show. This can happen if the scheduler
                                            hasn't run yet or no one register to the tournament.
                                        </p>
                                    </div>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
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
                    <asp:View ID="View3" runat="server">
                        <div style="text-align: right">
                            <uc2:BracketsDisplay ID="bdPlayOffs" runat="server" />
                            <asp:LinkButton ID="lbEditPicksMode" runat="server" OnClick="lbEditPicksMode_Click">Edit</asp:LinkButton>
                            <img src="../Images/Icons/PrinterIcon.gif" />
                            <asp:HyperLink ID="hlPrint" runat="server">Print</asp:HyperLink>
                            <img src="../Images/Icons/PdfIcon.gif" />
                            <asp:HyperLink ID="HyperLink2" runat="server">Export to pdf</asp:HyperLink>
                        </div>
                        
                    </asp:View>
                    <asp:View ID="View4" runat="server">
                        <uc1:Feedbacks ID="Feedbacks1" runat="server" TextContentName="Feedbacks" IsEditMode="True" />
                    </asp:View>
                    <asp:View ID="View6" runat="server">
                        <fu1:FakeUsers ID="FakeUsers1" runat="server" />
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
