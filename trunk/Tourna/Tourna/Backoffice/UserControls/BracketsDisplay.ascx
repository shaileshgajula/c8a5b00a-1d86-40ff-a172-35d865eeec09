<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BracketsDisplay.ascx.cs"
    Inherits="StrongerOrg.Backoffice.UserControls.BracketsDisplay" %>
<%@ Register Assembly="TourneyLogic.Web.UI.BracketControl.v2" Namespace="TourneyLogic.Web.UI.WebControls"
    TagPrefix="tl" %>
<style type="text/css">
    div#bracket_base
    {
        position: relative; /*height: 466px;*/
        width: 675px;
    }
    div#bracket_base div
    {
        margin: 0;
        padding: 0;
        position: absolute;
    }
    div#bracket_head
    {
        left: 0px;
        top: 0px;
        height: 40px;
    }
    div#bracket_head p
    {
        margin: 0;
        padding: 0;
        width: 135px;
        display: inline;
        float: left;
        font: bold 12px verdana,sans-serif;
    }
    div#bracket_body
    {
        left: 0px;
        top: 20px;
    }
    div#bracket_body p
    {
        margin: 0;
        padding: 0;
        position: absolute;
        bottom: 0px;
        left: 5px;
        font: 11px verdana,sans-serif;
    }
    div#bracket_body p a
    {
        text-decoration: none;
        color: #000;
    }
    div#bracket_body p a:hover
    {
        color: #666;
    }
    div#bracket_base div.round
    {
        width: 135px;
    }
    div#r1
    {
        left: 0px;
    }
    div#r2
    {
        left: 135px;
    }
    div#r3
    {
        left: 270px;
    }
    div#r4
    {
        left: 405px;
    }
    div#r5
    {
        left: 540px;
    }
    div#r6
    {
        left: 675px;
    }
     div#r7
    {
        left: 810px;
    }
    div#bracket_base div.round div
    {
        position: relative;
        width: 135px;
        float: left;
    }
    
    
    
    
    div#r1 div
    {
        height: 25px;
    }
    div#r1 div.top
    {
        height: 124px;
    }
    div#r1 div.blank
    {
        height: 26px;
    }
    div#r1 div.header
    {
        height: 25px;
        font: bold 12px verdana,sans-serif;
    }
    
    div#r2 div
    {
        height: 51px;
    }
    div#r2 div.top
    {
        height: 37px;
    }
    div#r2 div.champ
    {
        height: 37px;
        border-bottom: 1px solid black;
    }
    div#r2 div.header
    {
        height: 25px;
        font: bold 12px verdana,sans-serif;
    }
    
    div#r3 div
    {
        height: 103px;
    }
    div#r3 div.top
    {
        height: 63px;
    }
    div#r3 div.champ
    {
        height: 63px;
        border-bottom: 1px solid black;
    }
    div#r3 div.header
    {
        height: 25px;
        font: bold 12px verdana,sans-serif;
    }
    
    div#r4 div
    {
        height: 207px;
    }
    div#r4 div.top
    {
        height: 115px;
    }
    div#r4 div.champ
    {
        height: 115px;
        border-bottom: 1px solid black;
    }
    div#r4 div.header
    {
        height: 25px;
        font: bold 12px verdana,sans-serif;
    }
    
    div#r5 div
    {
        height: 415px;
    }
    div#r5 div.top
    {
        height: 219px;
    }
    div#r5 div.champ
    {
        height: 219px;
        border-bottom: 1px solid black;
    }
    div#r5 div.header
    {
        height: 25px;
        font: bold 12px verdana,sans-serif;
    }
    
    div#r6 div
    {
        height: 831px;
    }
    div#r6 div.top
    {
        height: 427px;
    }
    div#r6 div.champ
    {
        height: 427px;
        border-bottom: 1px solid black;
    }
    div#r6 div.header
    {
        height: 25px;
        font: bold 12px verdana,sans-serif;
    }
    
    div#r7 div
    {
        height: 1663px;
    }
    div#r7 div.top
    {
        height: 843px;
    }
    div#r7 div.champ
    {
        height: 843px;
        border-bottom: 1px solid black;
    }
    div#r7 div.header
    {
        height: 25px;
        font: bold 12px verdana,sans-serif;
    }
    
    div#r8 div
    {
        height: 3327px;
    }
    div#r8 div.top
    {
        height: 1675px;
    }
    div#r8 div.champ
    {
        height: 1675px;
        border-bottom: 1px solid black;
    }
    div#r8 div.header
    {
        height: 25px;
        font: bold 12px verdana,sans-serif;
    }
    
    div#r9 div.champ
    {
        height: 3339px;
        border-bottom: 1px solid black;
    }
    div#r9 div.header
    {
        height: 25px;
        font: bold 12px verdana,sans-serif;
    }
    
    div#bracket_base div.round div.odd
    {
        border-style: solid solid solid none;
        border-width: 1px;
        border-color: black;
    }
</style>
<asp:Panel ID="Div1" ClientIDMode="Static" CssClass="ui-widget" runat="server" Visible="false">
    <div class="ui-state-highlight ui-corner-all" style="margin-top: 20px; padding: 0 .7em;">
        <p>
            <span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span>
            <strong>Alert:</strong> No mathchups yet!!
        </p>
    </div>
</asp:Panel>
<asp:Panel ID="bracket_base" ClientIDMode="Static" runat="server">
    <asp:Panel ID="bracket_body" ClientIDMode="Static" runat="server">
    </asp:Panel>
</asp:Panel>
