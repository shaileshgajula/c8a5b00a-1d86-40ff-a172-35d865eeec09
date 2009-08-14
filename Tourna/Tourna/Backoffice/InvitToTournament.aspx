<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="InvitToTournament.aspx.cs" Inherits="Tourna.Backoffice.InvitToTournament" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Invit To Tournament</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <b class="b1h"></b><b class="b2h"></b><b class="b3h"></b><b class="b4h"></b>
    <div class="headh">
        <h3>
            For Your Information</h3>
    </div>
    <div class="contenth">
        <div>
            To send the invitation to anyone you want, you need to copy paste the message
            here (you can change it if you like except for the link) and send it. We don't we
            send it? we want the invitaion to come from someone inside of the organisation so
            the email won't end up in the junk box.</div>
    </div>
    <b class="b4bh"></b><b class="b3bh"></b><b class="b2bh"></b><b class="b1h"></b>
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="Id" DataSourceID="SqlDataSource1">
        <EditItemTemplate>
            <telerik:RadEditor ID="reRules" runat="server" Skin="Black" SkinID="" EditModes="All"
                EnableResize="False" ToolsFile="~/App_Data/RadEditor/BasicTools.xml" Content='<%# Bind("EmailTemplate") %>'>
            </telerik:RadEditor>
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <ItemTemplate>
            <table>
                <tr>
                    <td>
                        EmailTemplate:
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <a href="#" onclick="alert('not ready yet')">Copy</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="EmailTemplateLabel" runat="server" Text='<%# Bind("EmailTemplate") %>'
                            CssClass="emailTemplateBox" BorderWidth="1" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="Edit" />
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="SendToModerator"
                            Text="Send to [moderator]" />
                    </td>
                </tr>
            </table>
            <br />
        </ItemTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        SelectCommand="SELECT [EmailTemplate], [Id] FROM [Tournaments] WHERE ([Id] = @Id)"
        UpdateCommand="UPDATE [Tournaments] SET [EmailTemplate] = @EmailTemplate WHERE [Id] = @Id">
        <SelectParameters>
            <asp:QueryStringParameter Name="Id" QueryStringField="TournamentId" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="EmailTemplate" Type="String" />
            <asp:Parameter Name="Id" Type="Object" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
