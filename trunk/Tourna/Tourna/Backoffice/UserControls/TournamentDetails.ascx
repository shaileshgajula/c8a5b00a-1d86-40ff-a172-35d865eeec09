<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TournamentDetails.ascx.cs"
    Inherits="StrongerOrg.Backoffice.UserControls.TournamentDetails" %>
   <script type="text/javascript">
	$(function() {
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
    AutoGenerateRows="False" EnableModelValidation="True" OnItemUpdating="DetailsView1_ItemUpdating" >
    <Fields>
    
        <asp:BoundField DataField="TournamentName" HeaderText="Tournament Name"  />
        <asp:TemplateField>
            <HeaderStyle  />
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
        <asp:BoundField DataField="MatchingAlgo" HeaderText="MatchingAlgo"/>
         <asp:BoundField DataField="GamesPerDay" HeaderText="Games Per Day"/>
        <asp:BoundField DataField="TimeWindowStart" HeaderText="Time Window Start" />
        <asp:BoundField DataField="TimeWindowEnd" HeaderText="Time Window End" />
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
                <asp:TextBox ID="txtLastRegistrationDate" runat="server" CssClass="datepicker"
                    Text='<%# Eval("LastRegistrationDate", "{0:D}") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>
                Start Date</HeaderTemplate>
            <ItemTemplate>
                <%# Eval("StartDate", "{0:D}")%>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtStartDate" runat="server" CssClass="datepicker"
                    Text='<%# Eval("StartDate", "{0:D}") %>'></asp:TextBox>
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
                Tournament Players
            </HeaderTemplate>
            <ItemTemplate>
                <a href="OrganisationPlayers.aspx?TournamentId=<%#Eval("Id") %>&TournamentName=<%#Eval("TournamentName") %>">Players</a>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:BoundField DataField="DateCreated" HeaderText="Date Created" ReadOnly="true" DataFormatString="{0:f}"  />
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
        <asp:Parameter Name="TimeWindowStart" Type="Int32" />
        <asp:Parameter Name="TimeWindowEnd" Type="Int32" />
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
        <asp:Parameter Name="TimeWindowStart" Type="Int32" />
        <asp:Parameter Name="TimeWindowEnd" Type="Int32" />
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
