<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="PlayersChart.aspx.cs" Inherits="StrongerOrg.Backoffice.PlayersChart" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Charting" TagPrefix="telerik" %>
<%--<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" Height="400px" 
        Width="775px" >
        
        <Titles>
            <asp:Title Name="title1" Text="Player per company">
            </asp:Title>
        </Titles>
        <Series>
            <asp:Series Name="Series1" XValueMember="Name" YValueMembers="PlayersCount" IsValueShownAsLabel="true" >
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        SelectCommand="PlayerStats" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>
--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadChart ID="RadChart1" runat="server" Height="500px" Width="600px" 
        DataSourceID="SqlDataSource1">
        <Series>
            <telerik:ChartSeries Name="PlayersCount" DataLabelsColumn="Name" 
                DataYColumn="PlayersCount">
            </telerik:ChartSeries>
        </Series>
        <ChartTitle>
            <TextBlock Text="Players per organisation">
            </TextBlock>
        </ChartTitle>
    </telerik:RadChart>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        SelectCommand="PlayerStats" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>