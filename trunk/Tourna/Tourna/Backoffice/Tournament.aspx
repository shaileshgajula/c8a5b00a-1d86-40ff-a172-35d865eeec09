<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="Tournament.aspx.cs" Inherits="StrongerOrg.Backoffice.Tournament" %>

<%@ MasterType VirtualPath="~/Backoffice/BackOffice.Master" %>
<%@ Register Src="UserControls/TournamentDetails.ascx" TagName="TournamentDetails"
    TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="TourneyLogic.Web.UI.BracketControl.v2" Namespace="TourneyLogic.Web.UI.WebControls"
    TagPrefix="tl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                        <asp:MenuItem Text="Standings [Grid view]" Value="1" SeparatorImageUrl="~/Images/Icons/Seperator.gif">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Standings [Calendar view]" Value="2" SeparatorImageUrl="~/Images/Icons/Seperator.gif">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Standings [Brackets view]" Value="3" SeparatorImageUrl="~/Images/Icons/Seperator.gif">
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
                        <%-- <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
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
                        </asp:SqlDataSource>--%>
                        <ajax:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pnlImageDisplay"
                            TargetControlID="hiddenTargetControlForModalPopup" CancelControlID="btnCancel"
                            BackgroundCssClass="modalBackground" BehaviorID="imgAssociatedModal">
                        </ajax:ModalPopupExtender>
                        <asp:Panel ID="pnlImageDisplay" runat="server" CssClass="ModalWindow" Width="250">
                            <table style="width:100%" cellpadding="2" cellspacing="2">
                                <tr>
                                    <td>Start Date:
                                    </td>
                                    <td align="right">
                                        <asp:TextBox ID="tbStartDate" runat="server" Width="82"></asp:TextBox>
                                        <ajax:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="tbStartDate"  
                                         Mask="99/99/9999" MaskType="Date"  MessageValidatorTip="true">
                                        </ajax:MaskedEditExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Start Time:
                                    </td>
                                    <td align="right" >
                                        <asp:DropDownList ID="ddlHours" runat="server">
                                            <asp:ListItem>00</asp:ListItem>
                                            <asp:ListItem>01</asp:ListItem>
                                            <asp:ListItem>02</asp:ListItem>
                                            <asp:ListItem>03</asp:ListItem>
                                            <asp:ListItem>04</asp:ListItem>
                                            <asp:ListItem>05</asp:ListItem>
                                            <asp:ListItem>06</asp:ListItem>
                                            <asp:ListItem>07</asp:ListItem>
                                            <asp:ListItem>08</asp:ListItem>
                                            <asp:ListItem>09</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddlMinutes" runat="server">
                                            <asp:ListItem>00</asp:ListItem>
                                            <asp:ListItem>15</asp:ListItem>
                                            <asp:ListItem>30</asp:ListItem>
                                            <asp:ListItem>45</asp:ListItem>
                                        </asp:DropDownList>
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
                        <asp:GridView ID="gvStandingsPreview" runat="server" AutoGenerateColumns="False"
                            OnRowDataBound="gvStandingsPreview_RowDataBound" EnableModelValidation="True">
                            <Columns>
                                <asp:BoundField DataField="MatchUpId" HeaderText="Id" ReadOnly="True" />
                                <asp:BoundField DataField="Round" HeaderText="Round" ReadOnly="True" />
                                <asp:BoundField DataField="PlayerA" HeaderText="Player A" ReadOnly="True" />
                                <asp:BoundField DataField="PlayerB" HeaderText="Player B" ReadOnly="false" />
                                <asp:BoundField DataField="NextMatchId" HeaderText="NextMatch Id" ReadOnly="True" />
                                
                                <asp:TemplateField HeaderText="Game start">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbStartDate" runat="server" CommandArgument='<%# Eval("Start")+"*"+Eval("MatchUpId") %>'
                                            OnCommand="lbStartDate_Command"><%# Eval("Start") %> </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                               There are no matchup to show. This can happen if the scheduler hasn't run yet or no one register to the tournament.
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
                            <asp:LinkButton ID="lbEditPicksMode" runat="server" OnClick="lbEditPicksMode_Click">Edit</asp:LinkButton>
                            <img src="../Images/Icons/PrinterIcon.gif" />
                            <asp:HyperLink ID="hlPrint" runat="server">Print</asp:HyperLink>
                            <img src="../Images/Icons/PdfIcon.gif" />
                            <asp:HyperLink ID="HyperLink2" runat="server">Export to pdf</asp:HyperLink>
                        </div>
                    </asp:View>
                   
                </asp:MultiView>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
