<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FeeTrailForm.ascx.cs"
    Inherits="StrongerOrg.FrontSitePages.UserContorls.FeeTrailForm" %>

<table border="1">
    <tr>
        <td colspan="2">
            New User - Request a Free Trial
        </td>
    </tr>
    <tr>
        <td>
            First Name:
        </td>
        <td>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtFirstName" ErrorMessage="Required Field ">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            Last Name:
        </td>
        <td>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtLastName" ErrorMessage="Required Field">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            Phone:
        </td>
        <td>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            E-mail:
        </td>
        <td>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="txtEmail" ErrorMessage="Required Field">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="txtEmail" ErrorMessage="Email is invalid" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td>
            Country:
        </td>
        <td>
            <select style="font-size: 12px; width: 154px; font-family: arial; height: 21px;"
                id="txtCountry" name="txtCountry" >
                <option value="0"></option>
                <option value="99">Afghanistan </option>
                <option value="203">Alabama (US)</option>
                <option value="205">Alaska (US)</option>
                <option value="51">Albania </option>
                <option value="145">Algeria </option>
                <option value="206">American Samoa</option>
                <option value="52">Andorra </option>
                <option value="146">Angola </option>
                <option value="30002">Anguilla</option>
                <option value="201">Antigua and Barbuda</option>
                <option value="39">Argentina </option>
                <option value="207">Arizona (US)</option>
                <option value="208">Arkansas (US)</option>
                <option value="53">Armenia </option>
                <option value="30005">Aruba</option>
                <option value="25">Australia </option>
                <option value="54">Austria </option>
                <option value="55">Azerbaijan</option>
                <option value="2">Bahamas</option>
                <option value="100">Bahrain </option>
                <option value="101">Bangladesh </option>
                <option value="3">Barbados </option>
                <option value="56">Belarus </option>
                <option value="57">Belgium </option>
                <option value="4">Belize </option>
                <option value="147">Benin </option>
                <option value="263">Bermuda</option>
                <option value="102">Bhutan </option>
                <option value="40">Bolivia </option>
                <option value="58">Bosnia and Herzegovina</option>
                <option value="148">Botswana </option>
                <option value="41">Brazil </option>
                <option value="103">Brunei </option>
                <option value="60">Bulgaria </option>
                <option value="149">Burkina Faso</option>
                <option value="104">Burma (Myanmar) </option>
                <option value="150">Burundi </option>
                <option value="209">California (US)</option>
                <option value="105">Cambodia </option>
                <option value="151">Cameroon </option>
                <option value="5">Canada </option>
                <option value="152">Cape Verde </option>
                <option value="264">Cayman Islands</option>
                <option value="153">Central African Republic</option>
                <option value="155">Chad </option>
                <option value="42">Chile </option>
                <option value="106">China </option>
                <option value="43">Colombia </option>
                <option value="210">Colorado (US)</option>
                <option value="156">Comoros </option>
                <option value="157">Congo</option>
                <option value="211">Connecticut (US)</option>
                <option value="30007">Cook Islands</option>
                <option value="30008">Costa Rica</option>
                <option value="61">Croatia </option>
                <option value="7">Cuba </option>
                <option value="62">Cyprus </option>
                <option value="63">Czech Republic </option>
                <option value="212">Delaware (US)</option>
                <option value="64">Denmark </option>
                <option value="213">District of Columbia (US)</option>
                <option value="160">Djibouti </option>
                <option value="8">Dominica </option>
                <option value="9">Dominican Republic</option>
                <option value="107">East Timor </option>
                <option value="44">Ecuador </option>
                <option value="161">Egypt </option>
                <option value="10">El Salvador </option>
                <option value="162">Equatorial Guinea </option>
                <option value="163">Eritrea </option>
                <option value="65">Estonia </option>
                <option value="164">Ethiopia </option>
                <option value="30009">Falkland Islands (Malvinas)</option>
                <option value="131">Faroe Islands</option>
                <option value="26">Fiji </option>
                <option value="66">Finland </option>
                <option value="215">Florida (US)</option>
                <option value="67">France </option>
                <option value="267">French Polynesia</option>
                <option value="165">Gabon </option>
                <option value="166">Gambia </option>
                <option value="68">Georgia </option>
                <option value="30012">Georgia (US)</option>
                <option value="69">Germany </option>
                <option value="167">Ghana </option>
                <option value="30010">Gibraltar</option>
                <option value="70">Greece </option>
                <option value="30011">Greenland</option>
                <option value="11">Grenada </option>
                <option value="30013">Guadeloupe</option>
                <option value="217">Guam</option>
                <option value="12">Guatemala </option>
                <option value="270">Guernsey</option>
                <option value="168">Guinea </option>
                <option value="169">Guinea-Bissau </option>
                <option value="45">Guyana </option>
                <option value="13">Haiti </option>
                <option value="218">Hawaii (US)</option>
                <option value="14">Honduras </option>
                <option value="202">Hong Kong</option>
                <option value="71">Hungary </option>
                <option value="72">Iceland </option>
                <option value="219">Idaho (US)</option>
                <option value="220">Illinois (US)</option>
                <option value="108">India </option>
                <option value="221">Indiana (US)</option>
                <option value="109">Indonesia </option>
                <option value="222">Iowa (US)</option>
                <option value="110">Iran </option>
                <option value="111">Iraq </option>
                <option value="73">Ireland </option>
                <option value="112">Israel </option>
                <option value="74">Italy </option>
                <option value="170">Ivory Coast </option>
                <option value="15">Jamaica </option>
                <option value="113">Japan </option>
                <option value="114">Jordan </option>
                <option value="223">Kansas (US)</option>
                <option value="115">Kazakhstan </option>
                <option value="224">Kentucky (US)</option>
                <option value="171">Kenya </option>
                <option value="27">Kiribati </option>
                <option value="116">Korea (north) </option>
                <option value="117">Korea (south) </option>
                <option value="118">Kuwait </option>
                <option value="119">Kyrgyzstan </option>
                <option value="120">Laos </option>
                <option value="75">Latvia </option>
                <option value="121">Lebanon </option>
                <option value="172">Lesotho </option>
                <option value="173">Liberia </option>
                <option value="174">Libya </option>
                <option value="76">Liechtenstein </option>
                <option value="77">Lithuania </option>
                <option value="225">Louisiana (US)</option>
                <option value="78">Luxembourg </option>
                <option value="269">Macau</option>
                <option value="79">Macedonia </option>
                <option value="175">Madagascar </option>
                <option value="226">Maine (US)</option>
                <option value="176">Malawi </option>
                <option value="122">Malaysia </option>
                <option value="123">Maldives </option>
                <option value="177">Mali </option>
                <option value="80">Malta </option>
                <option value="28">Marshall Islands </option>
                <option value="30014">Martinique</option>
                <option value="228">Maryland (US)</option>
                <option value="229">Massachusetts (US)</option>
                <option value="178">Mauritania </option>
                <option value="179">Mauritius </option>
                <option value="16">Mexico </option>
                <option value="230">Michigan (US)</option>
                <option value="29">Micronesia </option>
                <option value="231">Minnesota (US)</option>
                <option value="232">Mississippi (US)</option>
                <option value="233">Missouri (US)</option>
                <option value="81">Moldova</option>
                <option value="82">Monaco </option>
                <option value="124">Mongolia </option>
                <option value="234">Montana (US)</option>
                <option value="90">Montenegro</option>
                <option value="180">Morocco </option>
                <option value="181">Mozambique </option>
                <option value="182">Namibia </option>
                <option value="30">Nauru </option>
                <option value="235">Nebraska (US)</option>
                <option value="125">Nepal </option>
                <option value="83">Netherlands </option>
                <option value="30004">Netherlands Antilles</option>
                <option value="236">Nevada (US)</option>
                <option value="30015">New Caledonia</option>
                <option value="237">New Hampshire (US)</option>
                <option value="238">New Jersey (US)</option>
                <option value="239">New Mexico (US)</option>
                <option value="240">New York (US)</option>
                <option value="31">New Zealand </option>
                <option value="17">Nicaragua </option>
                <option value="183">Niger </option>
                <option value="184">Nigeria </option>
                <option value="30016">Norfolk Island</option>
                <option value="241">North Carolina (US)</option>
                <option value="242">North Dakota (US)</option>
                <option value="243">Northern Mariana Islands (US)</option>
                <option value="84">Norway </option>
                <option value="244">Ohio (US)</option>
                <option value="245">Oklahoma (US)</option>
                <option value="126">Oman </option>
                <option value="246">Oregon (US)</option>
                <option value="127">Pakistan </option>
                <option value="32">Palau </option>
                <option value="18">Panama </option>
                <option value="33">Papua New Guinea </option>
                <option value="46">Paraguay </option>
                <option value="248">Pennsylvania (US)</option>
                <option value="47">Peru </option>
                <option value="128">Philippines </option>
                <option value="85">Poland </option>
                <option value="30017">Polynesia</option>
                <option value="86">Portugal </option>
                <option value="249">Puerto Rico</option>
                <option value="129">Qatar </option>
                <option value="250">Rhode Island (US)</option>
                <option value="87">Romania </option>
                <option value="130">Russian Federation</option>
                <option value="185">Rwanda </option>
                <option value="19">Saint Kitts and Nevis</option>
                <option value="20">Saint Lucia</option>
                <option value="21">Saint Vincent and Grenadines</option>
                <option value="34">Samoa </option>
                <option value="88">San Marino </option>
                <option value="186">Sao Tome and Principe</option>
                <option value="132">Saudi Arabia </option>
                <option value="188">Senegal </option>
                <option value="89">Serbia</option>
                <option value="189">Seychelles </option>
                <option value="190">Sierra Leone </option>
                <option value="133">Singapore </option>
                <option value="91">Slovakia </option>
                <option value="92">Slovenia </option>
                <option value="35">Solomon Islands </option>
                <option value="191">Somalia </option>
                <option value="192">South Africa </option>
                <option value="251">South Carolina (US)</option>
                <option value="252">South Dakota (US)</option>
                <option value="93">Spain </option>
                <option value="134">Sri Lanka </option>
                <option value="193">Sudan </option>
                <option value="48">Suriname </option>
                <option value="194">Swaziland </option>
                <option value="94">Sweden </option>
                <option value="95">Switzerland </option>
                <option value="135">Syria </option>
                <option value="30018">Taiwan</option>
                <option value="136">Tajikistan </option>
                <option value="195">Tanzania </option>
                <option value="253">Tennessee (US)</option>
                <option value="254">Texas (US)</option>
                <option value="137">Thailand </option>
                <option value="196">Togo </option>
                <option value="36">Tonga </option>
                <option value="23">Trinidad and Tobago</option>
                <option value="197">Tunisia </option>
                <option value="138">Turkey </option>
                <option value="139">Turkmenistan </option>
                <option value="37">Tuvalu </option>
                <option value="198">Uganda </option>
                <option value="96">Ukraine </option>
                <option value="266">United Arab Emirates</option>
                <option value="97">United Kingdom </option>
                <option value="49">Uruguay </option>
                <option value="255">Utah (US)</option>
                <option value="142">Uzbekistan </option>
                <option value="38">Vanuatu </option>
                <option value="98">Vatican City State</option>
                <option value="50">Venezuela </option>
                <option value="256">Vermont (US)</option>
                <option value="143">Vietnam </option>
                <option value="257">Virgin Islands (US)</option>
                <option value="258">Virginia (US)</option>
                <option value="259">Washington (US)</option>
                <option value="260">West Virginia (US)</option>
                <option value="261">Wisconsin (US)</option>
                <option value="262">Wyoming (US)</option>
                <option value="144">Yemen </option>
                <option value="199">Zambia </option>
                <option value="200">Zimbabwe </option>
            </select>
        </td>
    </tr>
    <tr>
        <td>
            State/City:
        </td>
        <td>
            <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            Job Function:
        </td>
        <td>
            <asp:TextBox ID="txtJobFunction" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Company Name:
        </td>
        <td>
            <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="txtFirstName" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            Username:
        </td>
        <td>
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ControlToValidate="txtUserName" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            Password:
        </td>
        <td>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ControlToValidate="txtPassword" ErrorMessage="RequiredField Validator">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                onclick="btnSubmit_Click" />
        </td>
    </tr>
</table>
