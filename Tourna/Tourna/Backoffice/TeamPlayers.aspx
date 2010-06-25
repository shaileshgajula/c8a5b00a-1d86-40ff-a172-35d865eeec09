<%@ Page Title="Team Players" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master"
    AutoEventWireup="true" CodeBehind="TeamPlayers.aspx.cs" Inherits="StrongerOrg.Backoffice.TeamPlayers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False"
        OnRowCreated="GridView1_RowCreated" OnRowEditing="GridView1_RowEditing">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <%# (i++).ToString() + "." %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="true" HeaderText="Edit" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Email" HeaderText="E-Mail" />
            <asp:TemplateField HeaderText="Team Name">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("TeamName") %>' ></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" 
                        DataSourceID="SqlDataSource2" DataTextField="Name"  DataValueField="Id"
                        SelectedValue='<%# Bind("TeamId") %>'>
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center">

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Icons/trash.gif"
                        CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete')" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField></asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <div id="Div1" class="ui-widget" runat="server">
                <div class="ui-state-highlight ui-corner-all" style="margin-top: 20px; padding: 0 .7em;">
                    <p>
                        <span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span>
                        <strong>Alert:</strong> No players have been registered to this team.
                    </p>
                </div>
            </div>
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        SelectCommand="TeamPlayersGet" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="TeamId" QueryStringField="TeamId" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
        SelectCommand="TeamsGet" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="tournamentId" QueryStringField="tournamentId" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
