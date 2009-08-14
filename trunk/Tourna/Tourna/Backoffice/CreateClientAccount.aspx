<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Backoffice/BackOffice.Master" CodeBehind="CreateClientAccount.aspx.cs"
    Inherits="Tourna.Backoffice.CreateUserWizard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Create user account</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server">
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server" >
                    <ContentTemplate>
                        <table border="0">
                            <tr>
                                <td align="center" colspan="2">
                                    Sign Up for Your New Account</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                        ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                        ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                        ControlToValidate="Password" ErrorMessage="Password is required." 
                                        ToolTip="Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
                                        ControlToValidate="Email" ErrorMessage="E-mail is required." 
                                        ToolTip="E-mail is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question" 
                                        Visible="False">Security Question:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Question" runat="server" Visible="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer" 
                                        Visible="False">Security Answer:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Answer" runat="server" Visible="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color:Red;">
                                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:CreateUserWizardStep>
                <asp:WizardStep ID="CreateUserWizardStep0" runat="server">
                    <table>
                        <tr>
                            <th>
                                Billing Information
                            </th>
                        </tr>
                        <tr>
                            <td>
                                Billing Address:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="BillingAddress" MaxLength="50" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="BillingAddress"
                                    ErrorMessage="Billing Address is required." />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Billing City:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="BillingCity" MaxLength="50" Columns="15" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="BillingCity"
                                    ErrorMessage="Billing City is required." />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Billing State:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="BillingState" MaxLength="25" Columns="10" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="BillingState"
                                    ErrorMessage="Billing State is required." />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Billing Zip:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="BillingZip" MaxLength="10" Columns="10" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="BillingZip"
                                    ErrorMessage="Billing Zip is required." />
                            </td>
                        </tr>
                    </table>
                </asp:WizardStep>

<asp:CompleteWizardStep runat="server"></asp:CompleteWizardStep>

            </WizardSteps>
        </asp:CreateUserWizard>

</asp:Content>
