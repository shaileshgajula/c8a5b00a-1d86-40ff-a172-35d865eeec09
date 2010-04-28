<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Feedbacks.ascx.cs" Inherits="StrongerOrg.Backoffice.UserControls.Feedbacks" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:LinkButton ID="lbShowAddNew" runat="server" OnClientClick="return false">
    <asp:Image ID="Image1" runat="server" style="vertical-align: middle;padding-right:5px"/>
    <asp:Label ID="lblFeedbackHeader" runat="server" Text="Leave a message" style="vertical-align: middle;"></asp:Label></asp:LinkButton>
<asp:Panel ID="Panel1" runat="server" Width="450">
    <table border="0" cellpadding="2" cellspacing="2" id="addNewFeedback">
        <tr>
            <td>
                Name:
            </td>
            <td align="right">
                <asp:TextBox ID="txtName" runat="server" Width="350"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Email:
            </td>
            <td align="right">
                <asp:TextBox ID="txtEmail" runat="server" Width="350"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="top">
                Message:
            </td>
            <td align="right">
                <asp:TextBox ID="txtMessage" runat="server" Rows="5" TextMode="MultiLine" Width="350"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">
                <asp:Label ID="lblSendMsg" runat="server" Text=""></asp:Label>
                <asp:LinkButton ID="lbSend" runat="server" OnClick="lbSend_Click">    Send</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Panel>
<ajax:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" Collapsed="false"
    CollapsedSize="0" ExpandedSize="200" ExpandControlID="lbShowAddNew" CollapseControlID="lbShowAddNew"
    AutoCollapse="False" AutoExpand="false" TextLabelID="lblFeedbackHeader" ExpandedImage="~/Images/Icons/expand.jpg"
    CollapsedImage="~/Images/Icons/collapse.jpg" TargetControlID="Panel1" ExpandDirection="Vertical"
    ImageControlID="Image1">
</ajax:CollapsiblePanelExtender>
<br />&nbsp
<asp:ListView ID="lvFeedbacks" runat="server" DataSourceID="ObjectDataSource1" 
    ItemContainerID="itemPlaceholder" onitemcreated="lvFeedbacks_ItemCreated" 
    DataKeyNames="Id">
    <LayoutTemplate>
        <table border="0" style="width:100%">
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </table>
    </LayoutTemplate>
    
    <ItemSeparatorTemplate>
        <tr>
            <td colspan="2" style="border-top:1px solid black">
                
            </td>
        </tr>
    </ItemSeparatorTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <%# Eval("FeedbackContent")%>
            </td>
            <td style="vertical-align:top;text-align:right">
                <asp:ImageButton ID="ibDelete" runat="server" ImageUrl="~/Images/Icons/trash.gif"
                        CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete')"  />
                
            </td>
        </tr>
        <tr>
            <td align="right" class="LightGrayTextLight" colspan="2">
                <%# Eval("FeedbackWriterName")%> (<%# String.Format("{0:ddd, MMM d, yyyy}", Eval("DateStamp")) %>) 
                <asp:Label ID="lblFeedbackWriterEmail" runat="server" Text=""><%# Eval("FeedbackWriterEmail")%></asp:Label>
            </td>
        </tr>
    </ItemTemplate>
</asp:ListView>

<asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvFeedbacks" PageSize="10">
    <Fields>
        <asp:NumericPagerField ButtonCount="10" NextPageText="..." PreviousPageText="..." />
        <asp:NextPreviousPagerField FirstPageText="First" LastPageText="Last" NextPageText="Next"
            PreviousPageText="Previous" />
    </Fields>
</asp:DataPager>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetFeedbacks"
    TypeName="StrongerOrg.Backoffice.Entities.FeedbacksManager" OnSelecting="ObjectDataSource1_Selecting" 
    DeleteMethod="DeleteFeedback">
    <DeleteParameters>
        <asp:Parameter Name="Id" Type="Int32" />
    </DeleteParameters>
    <SelectParameters>
        <asp:Parameter Name="orgId" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
