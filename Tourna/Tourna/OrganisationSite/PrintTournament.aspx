<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintTournament.aspx.cs"
    Inherits="StrongerOrg.OrganisationSite.PrintTournament" Theme="OrganisationSite" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print Tournament</title>
    <link type="text/css" href="../scripts/css/redmond/jquery-ui-1.8.custom.css" rel="stylesheet" />
</head>
<body style="margin-left: 10px; margin-right: 10px">
    <form id="form1" runat="server">
    <br />
    <div>
        <asp:DetailsView ID="dvGameDetails" runat="server" AutoGenerateRows="false" DataSourceID="SqlDataSource1">
            <HeaderTemplate>
                <strong>Tournament details</strong>
            </HeaderTemplate>
            <Fields>
                <asp:BoundField DataField="TournamentName" HeaderText="Tournament Name:" HeaderStyle-Font-Bold="true" />
                <asp:BoundField DataField="ConsoleName" HeaderText="ConsoleName:" HeaderStyle-Font-Bold="true" />
                <asp:BoundField DataField="StartDate" HeaderText="Start:" DataFormatString="{0:f}"
                    HeaderStyle-Font-Bold="true" />
                <asp:BoundField DataField="Title" HeaderText="Title:" HeaderStyle-Font-Bold="true" />
                <asp:BoundField DataField="RegisteredPlayers" HeaderText="Registered Players:" HeaderStyle-Font-Bold="true" />
            </Fields>
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
            SelectCommand="TournamentsGet" SelectCommandType="StoredProcedure" CancelSelectOnNullParameter="False">
            <SelectParameters>
                <asp:QueryStringParameter Name="OrganisationId" QueryStringField="OrgId" Type="String" />
                <asp:QueryStringParameter DbType="String" Name="TournamentId" QueryStringField="TournamentId" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
            EnableModelValidation="True" Style="width: 100%" RowStyle-HorizontalAlign="Center"
            GridLines="None">
            <Columns>
                <asp:BoundField DataField="MatchupId" HeaderText="Id" />
                <asp:BoundField DataField="Round" HeaderText="Round" />
                <asp:TemplateField HeaderText="Player" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="playerText">
                    <ItemTemplate>
                        <%#Eval("PlayerA")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        vs.
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Player" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="playerText">
                    <ItemTemplate>
                        <%# Eval("PlayerB")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Next Match Id">
                    <ItemTemplate>
                        <%# Eval("NextMatchId").ToString() == "0" ? "Final Game" : Eval("NextMatchId") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Start" HeaderText="Start" SortExpression="Start" DataFormatString="{0:f}"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        Winner
                    </HeaderTemplate>
                    <ItemTemplate>
                        <strong>
                            <%# Eval("WinnerName")%></strong>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
            <span>    
                    <div id="Div1" class="ui-widget" runat="server">
                        <div class="ui-state-highlight ui-corner-all" style="margin-top: 20px; padding: 0 .7em;">
                            <p>
                                <span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span>
                                <strong>Alert:</strong>
                                No mathchups yet!! 
                            </p>
                        </div>
                    </div>
                </span>
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetTournamentMatchups" TypeName="StrongerOrg.Backoffice.Entities.TournamentMatchupManager">
            <SelectParameters>
                <asp:QueryStringParameter DbType="Guid" Name="tournamentId" QueryStringField="TournamentId" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    <br />
    <br>
    <div style="border-top: 1px dotted #444444; text-align: center">
        www.strongerorg.com</div>
    </form>
</body>
</html>
