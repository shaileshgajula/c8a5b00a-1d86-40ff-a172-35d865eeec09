<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="PlayersChart.aspx.cs" Inherits="StrongerOrg.Backoffice.PlayersChart" %>


<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" Height="400px" 
        Width="775px" >
        
        <Titles>
            <asp:Title Name="title1" Text="Competitor per organisation">
            </asp:Title>
        </Titles>
        <Series>
            <asp:Series Name="Series1" XValueMember="Name" YValueMembers="PlayersCount" 
                IsValueShownAsLabel="true" LabelAngle="45" LabelToolTip="#VALX" 
                XValueType="String" YValueType="Int32" >
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1" BorderWidth="0">
                <AxisX IntervalAutoMode="VariableCount">
                    <MajorGrid Enabled="False" />
                </AxisX>
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        SelectCommand="PlayerStats" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>
