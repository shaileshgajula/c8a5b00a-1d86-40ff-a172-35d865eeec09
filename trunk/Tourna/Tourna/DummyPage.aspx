<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DummyPage.aspx.cs" Inherits="StrongerOrg.DummyPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="TourneyLogic.Web.UI.BracketControl.v2" Namespace="TourneyLogic.Web.UI.WebControls"
    TagPrefix="tl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .Round
        {
        }
        .BlankSlot
        {
            padding-bottom: 1px;
            position: relative;
            padding-left: 5px;
        }
        .UpperSlot
        {
            border-bottom: solid 1px black;
            position: relative;
            padding-left: 5px;
        }
        .LowerSlot
        {
            border-bottom: solid 1px black;
            border-right: solid 1px black;
            position: relative;
            padding-left: 5px;
        }
        .ChampSlot
        {
            border-bottom: solid 1px black;
            position: relative;
            padding-left: 5px;
        }
        .Hidden
        {
            width: 0px;
            height: 0px;
        }
        .SpanWrapper
        {
            position: absolute;
            bottom: 0;
        }
        .Text
        {
        }
        .Image
        {
            vertical-align: middle;
            cursor: hand;
            padding-left: 5px;
        }
        .FinalLowerSlot
        {
            border-bottom: solid 1px black;
            border-right: solid 1px black;
            margin-left: 5px;
            position: relative;
            padding-left: 5px;
        }
        .OptionalLowerSlot
        {
            border-bottom: dashed 1px black;
            border-right: dashed 1px black;
            margin-left: 5px;
            position: relative;
            padding-left: 5px;
        }
        .OptionalChampSlot
        {
            border-bottom: dashed 1px black;
            position: relative;
            padding-left: 5px;
        }
        .RequiredLowerSlot
        {
            border-bottom: solid 1px black;
            border-right: solid 1px black;
            margin-left: 5px;
            position: relative;
            padding-left: 5px;
        }
        .RequiredChampSlot
        {
            border-bottom: solid 1px black;
            position: relative;
            padding-left: 5px;
        }
        .NoneLowerSlot
        {
            border-bottom: hidden 1px black;
            border-right: hidden 1px black;
            margin-left: 5px;
            position: relative;
            padding-left: 5px;
        }
        .NoneChampSlot
        {
            border-bottom: hidden 1px black;
            position: relative;
            padding-left: 5px;
        }
        
        .popupControl
        {
            background-color: #AAD4FF;
            position: absolute;
            visibility: hidden;
            border-style: solid;
            border-color: Black;
            border-width: 2px;
        }
        
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
        
        .modalPopup
        {
            background-color: #ffffdd;
            border-width: 3px;
            border-style: solid;
            border-color: Gray;
            padding: 3px;
            width: 250px;
        }
        .reorderListDemo
li {  list-style:none; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ajax:ReorderList ID="ReorderList2" runat="server">
    </ajax:ReorderList>
    <asp:Label ID="Label1" runat="server" Text="Number of players"></asp:Label><asp:TextBox
        ID="TextBox1" runat="server"></asp:TextBox><asp:Button ID="btnCreatPlayers" runat="server"
            Text="Creat players" OnClick="btnCreatPlayers_Click" />
    <asp:Button ID="btnRandomize" runat="server" Text="Randomize" OnClick="btnRandomize_Click" /><asp:Button
        ID="btnSingle" runat="server" Text="Single Elimination bye" OnClick="btnSingle_Click" /><asp:Button
            ID="btnSinglePair" runat="server" Text="Single Elimination Pairs" OnClick="btnSinglePair_Click" /><br />
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    <asp:GridView ID="gvResults" runat="server" OnRowDataBound="gvPairs_RowDataBound"
        AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="MatchUpId" HeaderText="Matchup Id" />
            <asp:BoundField DataField="Round" HeaderText="Round" />
            <asp:BoundField DataField="PlayerA" HeaderText="A" />
            <asp:BoundField DataField="PlayerB" HeaderText="B" />
            <asp:BoundField DataField="NextMatchId" HeaderText="Next matchup" />
        </Columns>
    </asp:GridView>
    <asp:GridView ID="gvPairs" runat="server">
    </asp:GridView>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="Button1" runat="server" Text="Button" />
    <tl:Bracket ID="Bracket1" runat="server"></tl:Bracket>
    <%--<asp:ScriptManager ID="ScriptManager" runat="server" />
    <telerik:RadSplitter ID="RadSplitter1" runat="server" Width="100%" Height="300">
        <telerik:RadPane ID="RadPane1" runat="server" Width="20%">
            Menue
        </telerik:RadPane>
        <telerik:RadSplitBar ID="RadSplitBar1" runat="server" CollapseMode="Forward"></telerik:RadSplitBar>
        <telerik:RadPane ID="MiddlePane1" runat="server" Width="100%">
            <ajax:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="LinkButton1" DropShadow="true" PopupControlID="myPanel" BackgroundCssClass="modalBackground">
            </ajax:ModalPopupExtender>
            <asp:Panel runat="server" ID="myPanel" style="display:none" CssClass="modalPopup">
            assss
            </asp:Panel>
        
            <asp:LinkButton ID="LinkButton1" runat="server" >LinkButton</asp:LinkButton>
            </telerik:RadPane>
    </telerik:RadSplitter>--%>
    <%-- <ajax:ReorderList ID="ReorderList1" runat="server" AllowReorder="True" DataSourceID="SqlDataSource1"
        PostBackOnReorder="False" SortOrderField="Name">
        <ItemTemplate>
            <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("GameImage", @"~\Images\GamesImages\{0}") %>' />
            <%# Eval("Title") %>
        </ItemTemplate>
        <DragHandleTemplate>
            <div style="height: 20px; width: 20px; border: solid 1px black; background-color: Red;
                cursor: pointer;">
            </div>
        </DragHandleTemplate>
    </ajax:ReorderList>--%>
   <%-- <ajax:ReorderList ID="ReorderList1" runat="server" AllowReorder="True" PostBackOnReorder="False"
        SortOrderField="name" DataKeyField="Id" DataSourceID="SqlDataSource1" ItemInsertLocation="End" CssClass="reorderListDemo">
        <DragHandleTemplate>
            <div style="height:100%; width: 20px; border: solid 1px black; background-color: Red;
                cursor: pointer;" class="reorderListDemo">
            </div>
        </DragHandleTemplate>
        <ItemTemplate>
            <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("GameImage", @"~\Images\GamesImages\{0}") %>' />
            <%#Eval("title") %>
            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" Text="Edit" />
            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Delete" Text="Delete" />
        </ItemTemplate>
        <ReorderTemplate>
            <div style="width: 300px; height: 20px; border: dotted 2px black;">
            </div>
        </ReorderTemplate>
        <InsertItemTemplate>
            <asp:Label ID="Label3" runat="server" Text="Name"></asp:Label><asp:TextBox ID="txtName"
                runat="server" Text='<%# Bind("strName") %>'></asp:TextBox><br />
            <asp:Label ID="Label4" runat="server" Text="Link"></asp:Label><asp:TextBox ID="txtLink"
                runat="server" Text='<%# Bind("strLink") %>'></asp:TextBox><br />
            <asp:Button ID="btnInsert" runat="server" Text="Add Link" CommandName="Insert" />
        </InsertItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("title") %>' />
            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" Text="Update" />
            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
    </ajax:ReorderList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        SelectCommand="SELECT [GameImage], [Title], [Id] FROM [Games] ORDER BY [Title]">
    </asp:SqlDataSource>--%>
    </form>
</body>
</html>
