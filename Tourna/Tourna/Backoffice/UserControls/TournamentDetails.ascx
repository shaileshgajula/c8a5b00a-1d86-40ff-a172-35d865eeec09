<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TournamentDetails.ascx.cs"
    Inherits="StrongerOrg.Backoffice.UserControls.TournamentDetails" %>
<asp:DetailsView ID="DetailsView1" runat="server" DataKeyNames="Id" DataSourceID="SqlDataSource1" >
    <Fields>
        <asp:BoundField DataField="TournamentName" HeaderText="Tournament Name" SortExpression="TournamentName" HeaderStyle-Width="200px"  />
        <asp:BoundField DataField="IsOpen" HeaderText="Is Open"  />
        <asp:BoundField DataField="StartDate" HeaderText="Start Date" SortExpression="Start Date" />
        <asp:BoundField DataField="Abstract" HeaderText="Abstract" SortExpression="Abstract" />
        <asp:BoundField DataField="Locations" HeaderText="Locations" SortExpression="Locations" />
        <asp:BoundField DataField="NumberOfPlayersLimit" HeaderText="Players Limit"
            SortExpression="NumberOfPlayersLimit" />
        <asp:BoundField DataField="TimeWindowStart" HeaderText="Time Window Start" SortExpression="TimeWindowStart" />
        <asp:BoundField DataField="TimeWindowEnd" HeaderText="Time Window End" SortExpression="TimeWindowEnd" />
        <asp:CheckBoxField DataField="IsOpenAllDay" HeaderText="Is OpenAll Day" SortExpression="IsOpenAllDay" />
        <asp:BoundField DataField="FirstPrize" HeaderText="First Prize" SortExpression="FirstPrize" />
        <asp:BoundField DataField="SecondPrize" HeaderText="Second Prize" SortExpression="SecondPrize" />
        <asp:BoundField DataField="ThirdPrize" HeaderText="Third Prize" SortExpression="Third Prize" />
        
        <asp:TemplateField HeaderStyle-VerticalAlign="Top">
            <HeaderTemplate>
                Email Invitation [<asp:HyperLink ID="hlEditEmailInvitation" NavigateUrl='<%# Eval("Id", "~/Backoffice/InvitToTournament.aspx?TournamentId={0}" ) %>' runat="server">Edit</asp:HyperLink>]
                </HeaderTemplate>
            <ItemTemplate>
                <%#Eval("EmailTemplate")%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated" />
    </Fields>
</asp:DetailsView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
    SelectCommand="SELECT * FROM [Tournaments] WHERE ([Id] = @Id)">
    <SelectParameters>
        <asp:ControlParameter ControlID="GridView1" Name="Id" PropertyName="SelectedValue"
            Type="Object" />
    </SelectParameters>
</asp:SqlDataSource>
