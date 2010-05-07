<%@ Page Title="Tournament builder" Language="C#" AutoEventWireup="true" MasterPageFile="~/Backoffice/BackOffice.Master"
    CodeBehind="TournamentBuilder.aspx.cs" Inherits="StrongerOrg.Backoffice._Default" %>

<%@ MasterType VirtualPath="~/Backoffice/BackOffice.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <style type="text/css">
		#demo-frame > div.demo { padding: 10px !important; };
	</style>
    <script type="text/javascript">
        $(function () {
            $("#slider-range-min").slider({
                range: "min",
                value: 3,
                min: 1,
                max: 10,
                slide: function (event, ui) {
                    $("#amount").val(ui.value);
                }
            });
            $("#amount").val($("#slider-range-min").slider("value"));

            $("#slider-range").slider({
                range: true,
                values: [13, 17],
                min: 0,
                max: 44,
                slide: function (event, ui) {
                    $("#timeFrame").val(BuildTime(ui.values[0]) + ' - '+ BuildTime(ui.values[1]));
                }
            });
            $("#timeFrame").val(BuildTime($("#slider-range").slider("values", 0)) + ' - ' + BuildTime($("#slider-range").slider("values", 1)));


        });
        function BuildTime(t) {
            var h;
            var m;
            h = 9 + parseInt(t / 4);
            if ((t * 15) % 60 == 0)
            { m = "00"; }
            else {
                m = (t * 15) % 60;
            }
            return h + ':' + m;
        }
        $(function () {
            $(".datepicker").datepicker({
                showOn: 'button',
                buttonImage: '../images/Icons/calendar.gif',
                buttonImageOnly: true,
                minDate: +1,
                maxDate: '+5M'//,
                //onClose: function (dateText, inst) { $(".datepicker").datepicker('setDate', dateText); }

            });

            $(".datepicker").datepicker('setDate', new Date());
            
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Wizard ID="Wizard1" runat="server" Width="70%" OnFinishButtonClick="Wizard1_FinishButtonClick">
        <%--FinishCompleteButtonType="Link" FinishPreviousButtonType="Link"--%>
        <WizardSteps>
            <asp:WizardStep runat="server" Title="Step 1">
                <table>
                    <tr>
                        <td class="GrayTitleNormal">
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
                        <td class="GrayTitleNormal">
                            Choose game
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
                            <asp:Label ID="lblGames" runat="server" Text="No games have been opened. Contact us to open the games"
                                Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="GrayTitleNormal">
                            Short description
                        </td>
                        <td>
                            <asp:TextBox ID="txtAbstract" runat="server" Width="249px" Height="61px" TextMode="MultiLine"></asp:TextBox>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="www.cnn.com" Enabled="false">[advanced edit]</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td class="GrayTitleNormal">
                            Choose locations
                        </td>
                        <td>
                            <asp:TextBox ID="txtLocations" runat="server" Width="248px"></asp:TextBox>
                            &nbsp;you can seperate by comma
                        </td>
                    </tr>
                    <tr>
                        <td class="GrayTitleNormal">
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
                        <td class="GrayTitleNormal">
                            Choose matching algo
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbMatchingAlog" runat="server">
                                <asp:ListItem Selected="True">Single Elimination</asp:ListItem>
                                <asp:ListItem>Round Robin</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="GrayTitleNormal">
                            Games per day
                        </td>
                        <td>
                            <label for="amount">
                                </label>
                            <input type="text" id="amount" name="amount" style="border: 0; color: #f6931f; font-weight: bold;width:25px" />
                            <div id="slider-range-min" style="width:150px"></div>

                        </td>
                    </tr>
                    <tr>
                        <td class="GrayTitleNormal">
                            Time frame
                        </td>
                        <td>
                            <asp:CheckBox ID="cbIsOpenAllDay" runat="server" Text="Is Open All Day" /> | Open from
                             <input type="text" id="timeFrame" name="timeFrame" style="border: 0; color: #f6931f; font-weight: bold;width:150px" />
                             <div id="slider-range" style="width:450px"></div>
                            <%--<telerik:RadSlider ID="rsTimeWindow" runat="server" ItemType="Tick" IsSelectionRangeEnabled="True"
                                SelectionEnd="14" Height="40px" Width="350px" SelectionStart="12" SmallChange="1"
                                LargeChange="1" MinimumValue="7" MaximumValue="19" AnimationDuration="400" CssClass="TicksSlider"
                                TrackPosition="TopLeft">
                            </telerik:RadSlider>--%>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td rowspan="3" class="GrayTitleNormal">
                            Prizes
                        </td>
                        <td>
                            I
                        </td>
                        <td>
                            <asp:TextBox ID="txtFirstPrize" runat="server" Width="250px" TextMode="MultiLine"
                                Rows="2"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            II
                        </td>
                        <td>
                            <asp:TextBox ID="txtSecondPrize" runat="server" Width="250px" TextMode="MultiLine"
                                Rows="2"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            III
                        </td>
                        <td>
                            <asp:TextBox ID="txtThirdPrize" runat="server" Width="250px" TextMode="MultiLine"
                                Rows="2"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="GrayTitleNormal">
                            Last registration date
                        </td>
                        <td>
                            <asp:TextBox ID="txtLastRegistrationDate" runat="server" CssClass="datepicker" Width="250px"></asp:TextBox>
                            <%-- <telerik:RadDatePicker ID="rdpLastRegistrationDate" runat="server" Culture="English (United States)"
                                SelectedDate="2009-07-28" Width="216px">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DateInput LabelCssClass="">
                                </DateInput>
                                <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                            </telerik:RadDatePicker>--%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="GrayTitleNormal">
                            Start tournament date
                        </td>
                        <td>
                            <asp:TextBox ID="txtStartDate" runat="server" CssClass="datepicker" Width="250px"></asp:TextBox>
                            <%--<telerik:RadDatePicker ID="rdpStartDate" runat="server" Culture="English (United States)"
                                SelectedDate="2009-07-28" Width="216px">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DateInput LabelCssClass="" SelectedDate="2009-07-28">
                                </DateInput>
                                <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                            </telerik:RadDatePicker>--%>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtLastRegistrationDate"
                                ControlToValidate="txtStartDate" ErrorMessage="Start date must be greater than last registration"
                                Operator="GreaterThan" Type="Date"></asp:CompareValidator>
                        </td>
                    </tr>
                </table>
            </asp:WizardStep>
        </WizardSteps>
    </asp:Wizard>
</asp:Content>
