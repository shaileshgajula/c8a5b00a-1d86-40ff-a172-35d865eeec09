<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Feedbacks.ascx.cs" Inherits="StrongerOrg.Backoffice.UserControls.Feedbacks" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:LinkButton ID="lbShowAddNew" runat="server" OnClientClick="return false">
    <asp:Image ID="Image1" runat="server" />&nbsp
    <asp:Label ID="lblFeedbackHeader" runat="server" Text="Leave a message"></asp:Label></asp:LinkButton>
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
<ajax:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" Collapsed="true"
    CollapsedSize="0" ExpandedSize="170" ExpandControlID="lbShowAddNew" CollapseControlID="lbShowAddNew"
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
                <%# Eval("Content") %>
            </td>
            <td style="vertical-align:top;text-align:right">
                <asp:LinkButton ID="lbDelete" runat="server" CommandName="Delete">Delete</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td align="right" class="LightGrayTextLight" colspan="2">
                <%# Eval("Caption") %> (<%# Eval("CreateDate") %>)
            </td>
        </tr>
    </ItemTemplate>
</asp:ListView>

<asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvFeedbacks" PageSize="5">
    <Fields>
        <asp:NumericPagerField ButtonCount="10" NextPageText="..." PreviousPageText="..." />
        <asp:NextPreviousPagerField FirstPageText="First" LastPageText="Last" NextPageText="Next"
            PreviousPageText="Previous" />
    </Fields>
</asp:DataPager>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetTextContents"
    TypeName="TextContentManager" OnSelecting="ObjectDataSource1_Selecting" 
    DeleteMethod="DeleteTextContents">
    <DeleteParameters>
        <asp:Parameter Name="Id" Type="Int32" />
    </DeleteParameters>
    <SelectParameters>
        <asp:Parameter Name="orgId" Type="String" />
        <asp:Parameter Name="contentType" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
