<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.Master" AutoEventWireup="true"
    CodeBehind="FAQ.aspx.cs" Inherits="StrongerOrg.FrontSitePages.FAQ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>F.A.Q</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td style="padding: 15px">
                <img src="../Images/FAQTitle.gif" />
            </td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="LinqDataSource1">
            <ItemTemplate>
                <tr>
                    <td style="padding: 5px;height:15px;vertical-align: top;color:#2e2e2e;font-size:15px;font-weight:bold">
                        <%#Eval("Caption")%>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 15px;vertical-align: top" class="GrayTextNormal">
                        <%#Eval("Content")%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="StrongerOrg.Backoffice.DataLayer.TournaDataContext"
            Select="new (ContentType, Caption, Content)" TableName="TextContents" Where="ContentType == @ContentType">
            <WhereParameters>
                <asp:Parameter DefaultValue="FAQ" Name="ContentType" Type="String" />
            </WhereParameters>
        </asp:LinqDataSource>
</asp:Content>
