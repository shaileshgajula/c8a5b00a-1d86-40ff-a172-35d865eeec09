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
        
        .popupControl {
	background-color:#AAD4FF;
	position:absolute;
	visibility:hidden;
	border-style:solid;
	border-color: Black;
	border-width: 2px;
}

.modalBackground {
	background-color:Gray;
	filter:alpha(opacity=70);
	opacity:0.7;
}

.modalPopup {
	background-color:#ffffdd;
	border-width:3px;
	border-style:solid;
	border-color:Gray;
	padding:3px;
	width:250px;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    
    <asp:Label ID="Label1" runat="server" Text="Number of players"></asp:Label><asp:TextBox ID="TextBox1"
        runat="server"></asp:TextBox><asp:Button ID="btnCreatPlayers" 
        runat="server" Text="Creat players" onclick="btnCreatPlayers_Click" />
        <asp:Button
            ID="btnRandomize" runat="server" Text="Randomize" 
        onclick="btnRandomize_Click" /><asp:Button ID="btnSingle" runat="server" 
        Text="Single Elimination bye" onclick="btnSingle_Click" /><asp:Button ID="btnSinglePair"
            runat="server" Text="Single Elimination Pairs" 
        onclick="btnSinglePair_Click" /><br />
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    <asp:GridView ID="gvResults" runat="server" AutoGenerateColumns="true">
    </asp:GridView>
    <asp:GridView ID="gvPairs" runat="server">
    </asp:GridView>
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
    
    </form>
</body>
</html>
