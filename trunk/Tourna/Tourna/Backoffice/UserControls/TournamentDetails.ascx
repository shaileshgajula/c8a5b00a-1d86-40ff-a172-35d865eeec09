<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TournamentDetails.ascx.cs"
    Inherits="StrongerOrg.Backoffice.UserControls.TournamentDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<script type="text/javascript">
    $(function () {
        $(".datepicker").datepicker({
            showOn: 'button',
            buttonImage: '../images/Icons/calendar.gif',
            buttonImageOnly: true,
            minDate: -1,
            maxDate: '+5M'
        });
    });
</script>
<asp:DetailsView ID="DetailsView1" runat="server" DataKeyNames="Id" DataSourceID="SqlDataSource1"
    AutoGenerateRows="False" EnableModelValidation="True" OnItemUpdating="DetailsView1_ItemUpdating">
    <Fields>
        <asp:BoundField DataField="TournamentName" HeaderText="Tournament Name" />
        <asp:TemplateField>
            <HeaderStyle />
            <HeaderTemplate>
                Abstract</HeaderTemplate>
            <ItemTemplate>
                <%# Eval("Abstract")%>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtAbstract" runat="server" TextMode="MultiLine" Height="100" Width="250"
                    Text='<%# Eval("Abstract")%>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Locations" HeaderText="Locations" SortExpression="Locations" />
        <asp:BoundField DataField="NumberOfPlayersLimit" HeaderText="Limit Of Players" SortExpression="NumberOfPlayersLimit" />
        <asp:BoundField DataField="MatchingAlgo" HeaderText="MatchingAlgo" />
        <asp:BoundField DataField="GamesPerDay" HeaderText="Games Per Day" />
        <asp:TemplateField>
            <HeaderTemplate>
                Time Window Start</HeaderTemplate>
            <ItemTemplate>
                <%# ((TimeSpan)Eval("TimeWindowStart")).TruncateSeconds()%>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtTimeWindowStart" runat="server" Text='<%# ((TimeSpan)Eval("TimeWindowStart")).TruncateSeconds()%>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>
                Time Window End</HeaderTemplate>
            <ItemTemplate>
                <%# ((TimeSpan)Eval("TimeWindowEnd")).TruncateSeconds()%>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtTimeWindowEnd" runat="server" Text='<%# ((TimeSpan)Eval("TimeWindowEnd")).TruncateSeconds()%>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="FirstPrize" HeaderText="First Prize" />
        <asp:BoundField DataField="SecondPrize" HeaderText="Second Prize" />
        <asp:BoundField DataField="ThirdPrize" HeaderText="Third Prize" />
        <asp:TemplateField>
            <HeaderTemplate>
                Last Registration Date</HeaderTemplate>
            <ItemTemplate>
                <%# Eval("LastRegistrationDate", "{0:D}")%>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtLastRegistrationDate" runat="server" CssClass="datepicker" Text='<%# Eval("LastRegistrationDate", "{0:D}") %>'
                    Width="200"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>
                Start Date</HeaderTemplate>
            <ItemTemplate>
                <%# Eval("StartDate", "{0:D}")%>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtStartDate" runat="server" CssClass="datepicker" Text='<%# Eval("StartDate", "{0:D}") %>'
                    Width="200"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>
                Watch email invitation
            </HeaderTemplate>
            <ItemTemplate>
                <a href="InvitToTournament.aspx?TournamentId=<%#Eval("Id") %>">Email Invitation</a>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>
                Tournament Competitors
            </HeaderTemplate>
            <ItemTemplate>
                <a href='<%# CompetitorsLink(Eval("Id"),Eval("TournamentName").ToString() ,Eval("Mode") ) %>' href="OrganisationPlayers.aspx?TournamentId=<%#Eval("Id") %>&TournamentName=<%#Eval("TournamentName") %>&Mode=<%# Eval("Mode") %>">
                    Competitors</a>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>
                Mode
            </HeaderTemplate>
            <ItemTemplate>
                <%# CompetitorType(Eval("Mode")) %>
                <asp:LinkButton ID="lbEditTeams" Visible="false" runat="server" OnClick="lbEditTeams_Click">Edit teams...</asp:LinkButton>
            </ItemTemplate>
            <EditItemTemplate>
                <%# CompetitorType(Eval("Mode")) %>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="DateCreated" HeaderText="Date Created" ReadOnly="true"
            DataFormatString="{0:f}" />
        <asp:CheckBoxField DataField="IsTournamentOver" HeaderText="Is Tournament Over" />
        <asp:TemplateField ItemStyle-CssClass="ThemeBorder" ShowHeader="false" ItemStyle-HorizontalAlign="Right">
            <ItemTemplate>
                <asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit">Edit Tournament</asp:LinkButton>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:LinkButton ID="lbUpdate" runat="server" CommandName="Update">Update Tournament</asp:LinkButton>
                <img src="../Images/Icons/Seperator.gif" />
                <asp:LinkButton ID="LbCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
            </EditItemTemplate>
        </asp:TemplateField>
    </Fields>
</asp:DetailsView>
<ajax:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="hiddenTargetControlForModalPopup"
    PopupControlID="panEdit" BackgroundCssClass="modalBackground" CancelControlID="btnCancel"
    PopupDragHandleControlID="panEdit">
</ajax:ModalPopupExtender>
<asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
<asp:Panel ID="panEdit" runat="server" Width="550px" CssClass="ModalWindow">
    <table width="100%">
        <tr>
            <td class="GrayTitle" colspan="2">
                Add new team
            </td>
        </tr>
        <tr>
            <td class="formtext" align="left">
                Team name:
            </td>
            <td align="right">
                <asp:TextBox ID="txtTeamName" runat="server" Width="200px">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:LinkButton ID="btnAdd" runat="server" OnClick="btnAddTeam_Click">Add</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="GrayTitle" colspan="2">
                Current teams (check the ones you want to delete)
            </td>
        </tr>
        <tr>
            <td colspan="2" height="10">
                <asp:CheckBoxList ID="cblTeams" runat="server" DataValueField="Id" RepeatColumns="5"
                    RepeatDirection="Horizontal" DataSourceID="SqlDataSource2" 
                    DataTextField="Name">
                </asp:CheckBoxList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>" 
                    SelectCommand="PlayersGet" SelectCommandType="StoredProcedure" EnableCaching="false">
                    <SelectParameters>
                        <asp:CookieParameter CookieName="OrganisationId" Type="String" Name="OrganisationId" 
                             />
                        <asp:QueryStringParameter Type="String" Name="TournamentId" 
                            QueryStringField="TournamentId" />
                            <asp:Parameter Type="Char" DefaultValue="T" Name="CompetitorType" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:Label ID="lblNoAlbumsFound" runat="server" Text="No teams Found" Visible="False">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click">Delete</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right; height: 40px">
                <asp:LinkButton ID="btnCancel" runat="server">Close</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
    SelectCommand="SELECT * FROM [Tournaments] WHERE ([Id] = @Id)" DeleteCommand="DELETE FROM [Tournaments] WHERE [Id] = @Id"
    UpdateCommand="UPDATE [Tournaments] SET [TournamentName] = @TournamentName, [Abstract] = @Abstract, [Locations] = @Locations, [NumberOfPlayersLimit] = @NumberOfPlayersLimit,[GamesPerDay] = @GamesPerDay, [TimeWindowStart] = @TimeWindowStart, [TimeWindowEnd] = @TimeWindowEnd, [IsOpenAllDay] = @IsOpenAllDay, [FirstPrize] = @FirstPrize, [SecondPrize] = @SecondPrize, [ThirdPrize] = @ThirdPrize, [LastRegistrationDate] = @LastRegistrationDate, [StartDate] = @StartDate, [IsTournamentOver] = @IsTournamentOver WHERE [Id] = @Id">
    <DeleteParameters>
        <asp:Parameter Name="Id" Type="Object" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="Id" Type="Object" />
        <asp:Parameter Name="OrganisationId" Type="Object" />
        <asp:Parameter Name="TournamentName" Type="String" />
        <asp:Parameter Name="Abstract" Type="String" />
        <asp:Parameter Name="Locations" Type="String" />
        <asp:Parameter Name="NumberOfPlayersLimit" Type="Int32" />
        <asp:Parameter Name="GameId" Type="Int32" />
        <asp:Parameter Name="MatchingAlgo" Type="String" />
        <asp:Parameter Name="TimeWindowStart" Type="DateTime" />
        <asp:Parameter Name="TimeWindowEnd" Type="DateTime" />
        <asp:Parameter Name="IsOpenAllDay" Type="Boolean" />
        <asp:Parameter Name="FirstPrize" Type="String" />
        <asp:Parameter Name="SecondPrize" Type="String" />
        <asp:Parameter Name="ThirdPrize" Type="String" />
        <asp:Parameter Name="LastRegistrationDate" Type="DateTime" />
        <asp:Parameter Name="StartDate" Type="DateTime" />
        <asp:Parameter Name="EmailTemplate" Type="String" />
        <asp:Parameter Name="IsTournamentOver" Type="Boolean" />
        <asp:Parameter Name="DateCreated" Type="DateTime" />
    </InsertParameters>
    <SelectParameters>
        <asp:QueryStringParameter Name="Id" QueryStringField="TournamentId" Type="String" />
    </SelectParameters>
    <UpdateParameters>
        <asp:Parameter Name="TournamentName" Type="String" />
        <asp:Parameter Name="Abstract" Type="String" />
        <asp:Parameter Name="Locations" Type="String" />
        <asp:Parameter Name="NumberOfPlayersLimit" Type="Int32" />
        <asp:Parameter Name="GameId" Type="Int32" />
        <asp:Parameter Name="MatchingAlgo" Type="String" />
        <asp:Parameter Name="TimeWindowStart" Type="DateTime" />
        <asp:Parameter Name="TimeWindowEnd" Type="DateTime" />
        <asp:Parameter Name="GamesPerDay" Type="Int32" />
        <asp:Parameter Name="IsOpenAllDay" Type="Boolean" />
        <asp:Parameter Name="FirstPrize" Type="String" />
        <asp:Parameter Name="SecondPrize" Type="String" />
        <asp:Parameter Name="ThirdPrize" Type="String" />
        <asp:Parameter Name="LastRegistrationDate" Type="DateTime" />
        <asp:Parameter Name="StartDate" Type="DateTime" />
        <asp:Parameter Name="EmailTemplate" Type="String" />
        <asp:Parameter Name="IsTournamentOver" Type="Boolean" />
        <asp:Parameter Name="DateCreated" Type="DateTime" />
        <asp:Parameter Name="Id" Type="Object" />
    </UpdateParameters>
</asp:SqlDataSource>
