<%@ Page Title="Invite To Tournament" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master"
    AutoEventWireup="true" CodeBehind="InvitToTournament.aspx.cs" Inherits="StrongerOrg.Backoffice.InvitToTournament" %>

<%@ MasterType VirtualPath="~/Backoffice/BackOffice.Master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <b class="b1h"></b><b class="b2h"></b><b class="b3h"></b><b class="b4h"></b>
    <div class="headh">
        <h3>
            For Your Information</h3>
    </div>
    <div class="contenth">
        <div>
            To send the invitation to anyone you want, you need to copy paste the message here
            (you can change it if you like except for the link) and send it.
            <br>
            Why don't we send it?<br />
            We want the invitaion to come from someone inside of the organisation so the email
            won't end up blocked or in the junk box.</div>
    </div>
    <b class="b4bh"></b><b class="b3bh"></b><b class="b2bh"></b><b class="b1h"></b>
    <br />
    <table border="0" cellpadding="0" cellspacing="0" style="width:800px;" align="center">
        <tr>
            <td class="GrayTextLight">
             Email invitation to the <a href="Tournament.aspx?TournamentId=<%= Request.QueryString["TournamentId"].ToString() %>">tournament</a>
            </td>
        </tr>
        <tr>
            <td style="border: 1px solid black;width:100%">
             <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </td>
        </tr>
         <tr>
            <td align="right" height="50px" >
            <asp:Label ID="lblResult" runat="server" Text="" CssClass="AlertText"></asp:Label><asp:LinkButton ID="lbSend" runat="server" onclick="lbSend_Click" Font-Bold="true">Send To <%=Membership.GetUser().Email%></asp:LinkButton>    
            </td>
        </tr>
    </table>
   <br /><br />
    
</asp:Content>
