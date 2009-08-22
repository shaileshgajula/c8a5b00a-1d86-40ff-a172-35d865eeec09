<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Backoffice/BackOffice.Master"
    CodeBehind="TournamentBuilder.aspx.cs" Inherits="StrongerOrg._Default" %>

<%@ MasterType VirtualPath="~/Backoffice/BackOffice.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Tournament builder</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0" Width="931px" OnFinishButtonClick="Wizard1_FinishButtonClick">
        <WizardSteps>
            <asp:WizardStep runat="server" Title="Step 1">
                <table>
                    <tr>
                        <td>
                            Tournament name
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtTournamentName" runat="server" LabelCssClass="" Width="250px">
                            </telerik:RadTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTournamentName"
                                ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Choose games
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbGame" runat="server" DataSourceID="SqlDataSource1" DataTextField="Title"
                                DataValueField="Id" OnDataBound="rbGame_DataBound" RepeatColumns="2" RepeatDirection="Horizontal">
                            </asp:RadioButtonList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StrongerOrgString %>"
                                SelectCommand="GetOrganisationOpenGames" SelectCommandType="StoredProcedure"
                                OnSelected="SqlDataSource1_Selected">
                                <SelectParameters>
                                    <asp:CookieParameter Name="OrganisationId" CookieName="OrganisationId" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:Label ID="lblGames" runat="server" Text="No games selected." Visible="False"></asp:Label>
                            <asp:HyperLink ID="hlSetGames" runat="server" NavigateUrl="~/Backoffice/Games2Organisation.aspx"
                                Visible="False">Select Games</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Short description
                        </td>
                        <td>
                            <asp:TextBox ID="txtAbstract" runat="server" Width="249px" Height="61px"></asp:TextBox>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="www.cnn.com">[advanced edit]</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Choose locations
                        </td>
                        <td>
                            <asp:TextBox ID="txtLocations" runat="server" Width="248px"></asp:TextBox>
                            &nbsp;you can seperate by comma
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Limit number of players
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="rntxtLimitPlayers" runat="server" Culture="English (United States)"
                                EmptyMessage="Suggested: 32" LabelCssClass="" Value="32" Width="125px" ShowSpinButtons="true"
                                MaxValue="128" MinValue="8">
                                <NumberFormat DecimalDigits="0" />
                            </telerik:RadNumericTextBox>
                        </td>
                    </tr>
                </table>
            </asp:WizardStep>
            <asp:WizardStep runat="server" Title="Step 2">
                <table class="style1">
                    <tr>
                        <td>
                            Define departments
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox4" runat="server" Width="178px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Choose matching algo
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbMatchingAlog" runat="server">
                                <asp:ListItem Selected="True">Random</asp:ListItem>
                                <asp:ListItem>Department mix</asp:ListItem>
                                <asp:ListItem>Same department</asp:ListItem>
                                <asp:ListItem>alpha betic</asp:ListItem>
                                <asp:ListItem>Levels</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            time frame
                        </td>
                        <td>
                            <asp:CheckBox ID="cbIsOpenAllDay" runat="server" Text="Is Open All Day" />
                            <telerik:RadSlider ID="rsTimeWindow" runat="server" ItemType="Tick" IsSelectionRangeEnabled="True"
                                SelectionEnd="14" Height="40px" Width="350px" SelectionStart="12" SmallChange="1"
                                LargeChange="1" MinimumValue="7" MaximumValue="19" AnimationDuration="400" CssClass="TicksSlider"
                                TrackPosition="TopLeft">
                            </telerik:RadSlider>
                        </td>
                    </tr>
                </table>
            </asp:WizardStep>
            <asp:WizardStep runat="server" Title="Step 3">
                <table>
                    <tr>
                        <td>
                            Prizes
                        </td>
                        <td>
                            I
                            <asp:TextBox ID="txtFirstPrize" runat="server" Width="80px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtFirstPrize"
                                ErrorMessage="Only number" ValidationExpression="^\d+$">*</asp:RegularExpressionValidator>
                            &nbsp;II<asp:TextBox ID="txtSecondPrize" runat="server" Width="80px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtSecondPrize"
                                ErrorMessage="Only number" ValidationExpression="^\d+$">*</asp:RegularExpressionValidator>
                            III<asp:TextBox ID="txtThirdPrize" runat="server" Width="80px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtThirdPrize"
                                ErrorMessage="Only number" ValidationExpression="^\d+$">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Start date
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="rdpStartDate" runat="server" Culture="English (United States)"
                                SelectedDate="2009-07-28" Width="216px">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DateInput LabelCssClass="" SelectedDate="2009-07-28">
                                </DateInput>
                                <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </asp:WizardStep>
        </WizardSteps>
    </asp:Wizard>
</asp:Content>
