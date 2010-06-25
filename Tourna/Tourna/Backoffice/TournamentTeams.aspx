<%@ Page Title="Tournament teams" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="TournamentTeams.aspx.cs" Inherits="StrongerOrg.Backoffice.TournamentTeams" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Image ID="imgCompetitorMode" runat="server" ImageUrl="~/Images/Icons/group.gif" Style="padding: 5px; vertical-align: middle" />
    <asp:HyperLink ID="hlTournamentTeams" runat="server" CssClass="GrayTitle"></asp:HyperLink>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
        AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="Id" PageSize="20" onrowcreated="GridView1_RowCreated">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <%# (i++).ToString() +"." %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="true" HeaderText="Edit" />
            <asp:BoundField HeaderText="Team Name" DataField="Name" />
            
            <asp:HyperLinkField HeaderText="Players#" DataTextField="Cnt" DataNavigateUrlFormatString="~/Backoffice/TeamPlayers.aspx?TeamId={0}&TournamentId={1}"
                DataNavigateUrlFields="Id, TournamentId" />
            <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center">
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Icons/trash.gif"
                        CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete')" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <div id="Div1" class="ui-widget" runat="server">
                <div class="ui-state-highlight ui-corner-all" style="margin-top: 20px; padding: 0 .7em;">
                    <p>
                        <span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span>
                        <strong>Alert:</strong> No teams found.
                    </p>
                </div>
            </div>
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        SelectCommand="TeamsGet" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="tournamentId" QueryStringField="TournamentId" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
