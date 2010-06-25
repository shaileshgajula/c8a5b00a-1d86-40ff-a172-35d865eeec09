<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CalendarDisplay.ascx.cs"
    Inherits="StrongerOrg.Backoffice.UserControls.CalendarDisplay" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<ajax:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pnlImageDisplay"
    TargetControlID="hiddenTargetControlForModalPopup" CancelControlID="btnCancel"
    BackgroundCssClass="modalBackground" BehaviorID="imgAssociatedModal">
</ajax:ModalPopupExtender>
<asp:Panel ID="pnlImageDisplay" runat="server" CssClass="ModalWindow">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="" class="GrayTitle"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvDayMatchups" runat="server">
                    <EmptyDataTemplate>
                        No match ups on this date
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <br />
                <asp:LinkButton ID="btnUpdateStartDate" runat="server">Update</asp:LinkButton>
                <img src="../Images/Icons/Seperator.gif" />
                <asp:LinkButton ID="btnCancel" runat="server">Close</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
<div align="center">
<br /><br />
    <asp:Calendar ID="calSchedules" runat="server" Visible="true" Width="50%" Height="250px"
        OnSelectionChanged="calSchedules_SelectionChanged" SelectionMode="Day"></asp:Calendar>
</div>
