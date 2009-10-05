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
    
    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
    
    
    <tl:Bracket ID="Bracket1" runat="server"><Competitors>
<tl:BracketCompetitor ID="BracketCompetitor1" runat="server" CompetitorId="1"></tl:BracketCompetitor>
<tl:BracketCompetitor ID="BracketCompetitor2" runat="server" CompetitorId="2"></tl:BracketCompetitor>
<tl:BracketCompetitor ID="BracketCompetitor3" runat="server" CompetitorId="3"></tl:BracketCompetitor>
<tl:BracketCompetitor ID="BracketCompetitor4" runat="server" CompetitorId="4"></tl:BracketCompetitor>
</Competitors>
</tl:Bracket>

    

    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />

<br /><br />
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">LinkButton</asp:LinkButton>
    <br />
    
    <span id="ctl00_ContentPlaceHolder1_Bracket1" style="color: Blue; font-family: Arial;
        font-size: small; font-weight: normal; font-style: normal;" roundtextappearance-forecolor="Gray"
        correctpickappearance-font-bold="True" correctpickappearance-forecolor="0, 192, 0"
        incorrectpickappearance-font-strikeout="True" incorrectpickappearance-forecolor="Red">
        <table cellspacing="0" cellpadding="0" border="0">
            <tbody>
                <tr>
                    <td>
                        <table cellspacing="0" cellpadding="0" border="0">
                            <tbody>
                                <tr>
                                    <td class="Round" valign="top">
                                        <span>Round 1 </span>
                                        <div id="ctl00_ContentPlaceHolder1_Bracket1_MatchUp1_Upper" class="UpperSlot" style="height: 50px;
                                            width: 130px;">
                                        </div>
                                        <div id="ctl00_ContentPlaceHolder1_Bracket1_MatchUp1_Lower" class="LowerSlot" style="height: 50px;
                                            width: 130px;">
                                        </div>
                                        <div id="ctl00_ContentPlaceHolder1_Bracket1_MatchUp2_Upper" class="UpperSlot" style="height: 50px;
                                            width: 130px;">
                                        </div>
                                        <div id="ctl00_ContentPlaceHolder1_Bracket1_MatchUp2_Lower" class="LowerSlot" style="height: 50px;
                                            width: 130px;">
                                        </div>
                                        <div id="ctl00_ContentPlaceHolder1_Bracket1_MatchUp3_Upper" class="UpperSlot" style="height: 50px;
                                            width: 130px;">
                                        </div>
                                        <div id="ctl00_ContentPlaceHolder1_Bracket1_MatchUp3_Lower" class="LowerSlot" style="height: 50px;
                                            width: 130px;">
                                        </div>
                                        <div id="ctl00_ContentPlaceHolder1_Bracket1_MatchUp4_Upper" class="UpperSlot" style="height: 50px;
                                            width: 130px;">
                                        </div>
                                        <div id="ctl00_ContentPlaceHolder1_Bracket1_MatchUp4_Lower" class="LowerSlot" style="height: 50px;
                                            width: 130px;">
                                        </div>
                                    </td>
                                    <td class="Round" valign="top">
                                        <span>Round 2 </span>
                                        <div id="ctl00_ContentPlaceHolder1_Bracket1_MatchUp5_Upper" class="UpperSlot" style="height: 75px;
                                            width: 130px;">
                                        </div>
                                        <div id="ctl00_ContentPlaceHolder1_Bracket1_MatchUp5_Lower" class="LowerSlot" style="height: 101px;
                                            width: 130px;">
                                            <span class="SpanWrapper"><span class="Text" style="color: Blue; font-family: Arial;
                                                font-size: small; font-weight: normal; font-style: normal;">John</span> </span>
                                        </div>
                                        <div id="ctl00_ContentPlaceHolder1_Bracket1_MatchUp6_Upper" class="UpperSlot" style="height: 101px;
                                            width: 130px;">
                                        </div>
                                        <div id="ctl00_ContentPlaceHolder1_Bracket1_MatchUp6_Lower" class="LowerSlot" style="height: 101px;
                                            width: 130px;">
                                        </div>
                                    </td>
                                    <td class="Round" valign="top">
                                        <span>Round 3 </span>
                                        <div id="ctl00_ContentPlaceHolder1_Bracket1_MatchUp7_Upper" class="UpperSlot" style="height: 126px;
                                            width: 130px;">
                                        </div>
                                        <div id="ctl00_ContentPlaceHolder1_Bracket1_MatchUp7_Lower" class="LowerSlot" style="height: 203px;
                                            width: 130px;">
                                        </div>
                                    </td>
                                    <td class="Round" valign="top">
                                        <span>Champion </span>
                                        <div class="ChampSlot" style="height: 228px; width: 130px;">
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </span>
    <br />
    <table cellspacing="0" cellpadding="0" border="0">
        <tbody>
            <tr>
                <td class="Round" valign="top">
                    <span>Round 1 </span>
                    <div id="Div1" class="UpperSlot" style="height: 50px; width: 130px;">
                    </div>
                    <div id="Div2" class="LowerSlot" style="height: 50px; width: 130px;">
                    </div>
                    <div id="Div3" class="UpperSlot" style="height: 50px; width: 130px;">
                    </div>
                    <div id="Div4" class="LowerSlot" style="height: 50px; width: 130px;">
                    </div>
                    <div id="Div5" class="UpperSlot" style="height: 50px; width: 130px;">
                    </div>
                    <div id="Div6" class="LowerSlot" style="height: 50px; width: 130px;">
                    </div>
                    <div id="Div7" class="UpperSlot" style="height: 50px; width: 130px;">
                    </div>
                    <div id="Div8" class="LowerSlot" style="height: 50px; width: 130px;">
                    </div>
                </td>
                <td class="Round" valign="top">
                    <span>Round 2 </span>
                    <div id="Div13" class="UpperSlot" style="height: 75px; width: 130px;">
                    </div>
                    <div id="Div14" class="LowerSlot" style="height: 100px; width: 130px;">
                    </div>
                    <div id="Div15" class="UpperSlot" style="height: 100px; width: 130px;">
                    </div>
                    <div id="Div16" class="LowerSlot" style="height: 100px; width: 130px;">
                    </div>
                </td>
                <td class="Round" valign="top">
                    <span>Round 3 
                    
                    </span>
                    <div id="Div9" class="UpperSlot" style="height: 126px; width: 130px;">
                    </div>
                    <div id="Div10" class="LowerSlot" style="height: 203px; width: 130px;">
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
</body>
</html>
