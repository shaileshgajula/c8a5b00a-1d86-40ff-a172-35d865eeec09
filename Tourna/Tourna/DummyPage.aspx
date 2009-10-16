<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DummyPage.aspx.cs" Inherits="StrongerOrg.DummyPage" %>

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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server" />
    <telerik:RadSplitter ID="RadSplitter1" runat="server" Width="100%" Height="300">
        <telerik:RadPane ID="RadPane1" runat="server" Width="20%">
            Menue
        </telerik:RadPane>
        <telerik:RadSplitBar ID="RadSplitBar1" runat="server" CollapseMode="Forward"></telerik:RadSplitBar>
        <telerik:RadPane ID="MiddlePane1" runat="server" Width="100%">
            content</telerik:RadPane>
    </telerik:RadSplitter>
    
    </form>
</body>
</html>
