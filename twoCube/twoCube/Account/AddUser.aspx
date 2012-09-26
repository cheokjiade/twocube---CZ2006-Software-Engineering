<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="twoCube.Account.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
                        Create a New Account
                    </h2>
                    <p>
                        Use the form below to create a new account.
                    </p>
                    <p>
                        Passwords are required to be a minimum of <%= Membership.MinRequiredPasswordLength %> characters in length.
                    </p>
    <div style="width: 600px;">
    <fieldset>
    <legend>&nbsp;[&nbsp;Enter Your User Information&nbsp;]&nbsp;</legend>
        <table>
            <tr>
                <td align="right">User&nbsp;Name&nbsp;:&nbsp;</td>
                <td>&nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="tbUserName" runat="server" Width="200px" />
                    <asp:RequiredFieldValidator ID="rfvUserName" runat="server"
                                                                ControlToValidate="tbUserName"
                                                                CssClass="ValidationError"
                                                                ErrorMessage="(Required)"
                                                                ToolTip="User Name is a REQUIRED Field." />
                    </td>
            </tr>
            <tr>
                <td align="right">Email&nbsp;Address&nbsp;:&nbsp;</td>
                <td>&nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="tbEmailAddress" runat="server" Width="200px" />
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                                                                ControlToValidate="tbEmailAddress"
                                                                CssClass="ValidationError"
                                                                ErrorMessage="(Required)"
                                                                ToolTip="Email address is a REQUIRED Field." />
                    <asp:RegularExpressionValidator ID="revEmail" runat="server"
                                                                   ControlToValidate="tbEmailAddress"
                                                                   CssClass="ValidationError"
                                                                   style="position:relative; left: -70px;"
                                                                   ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                   ErrorMessage="(Invalid)"
                                                                   ToolTip="Email address MUST contain VALID email address" />
                    </td>
            </tr>
            <tr>
                <td align="right">Age&nbsp;:&nbsp;</td>
                <td>&nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="tbAge" runat="server" Width="200px" />
                    <asp:RequiredFieldValidator ID="rfvAge" runat="server"
                                                                ControlToValidate="tbAge"
                                                                CssClass="ValidationError"
                                                                ErrorMessage="(Required)"
                                                                ToolTip="Age is a REQUIRED Field." />
                    <asp:RegularExpressionValidator ID="revAge" runat="server"
                                                                   ControlToValidate="tbAge"
                                                                   CssClass="ValidationError"
                                                                   style="position:relative; left: -70px;"
                                                                   ValidationExpression="^[0-9]+$"
                                                                   ErrorMessage="(Invalid)"
                                                                   ToolTip="Age MUST only contain NUMBERS" />
                    </td>
            </tr>
            <tr>
                <td align="right">Location&nbsp;:&nbsp;</td>
                <td>&nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="tbLocation" runat="server" Width="200px" />
                    <asp:RequiredFieldValidator ID="rfvLocation" runat="server"
                                                                ControlToValidate="tbLocation"
                                                                CssClass="ValidationError"
                                                                ErrorMessage="(Required)"
                                                                ToolTip="Location is a REQUIRED Field." />
                    </td>
            </tr>
            <tr>
                <td align="right">Password&nbsp;:&nbsp;</td>
                <td>&nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="tbPassword" runat="server" Width="200px" TextMode="Password"/>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                                                                ControlToValidate="tbPassword"
                                                                CssClass="ValidationError"
                                                                ErrorMessage="(Required)"
                                                                ToolTip="Password is a REQUIRED Field." />
                    </td>
            </tr>
            <tr>
                <td align="right">Confirm&nbsp;Password&nbsp;:&nbsp;</td>
                <td>&nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="tbConfirmPassword" runat="server" Width="200px" TextMode="Password"/>
                    <asp:CompareValidator ID="cvPassword" runat="server"
                                                          ControlToValidate="tbConfirmPassword"
                                                          ControlToCompare="tbPassword"
                                                          CssClass="ValidationError"
                                                          ErrorMessage="(No Match)"
                                                          ToolTip="Both Password MUST CONTAIN the same Password." />
                    </td>
            </tr>
            <tr>
                <td align="right">Question&nbsp;:&nbsp;</td>
                <td>&nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="tbQuestion" runat="server" Width="300px" />
                    <asp:RequiredFieldValidator ID="rfvQuestion" runat="server"
                                                                ControlToValidate="tbQuestion"
                                                                CssClass="ValidationError"
                                                                ErrorMessage="(Required)"
                                                                ToolTip="Question is a REQUIRED Field." />
                    </td>
            </tr>
            <tr>
                <td align="right">Answer&nbsp;:&nbsp;</td>
                <td>&nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="tbAnswer" runat="server" Width="300px" />
                    <asp:RequiredFieldValidator ID="rfvAnswer" runat="server"
                                                                ControlToValidate="tbAnswer"
                                                                CssClass="ValidationError"
                                                                ErrorMessage="(Required)"
                                                                ToolTip="Answer is a REQUIRED Field." />
                    </td>
            </tr>


        </table>
    </fieldset>
    <br />
    <div id="divResultMessage" runat="server" visible="false">
        <asp:Label ID="lblCreatingResultMessage" runat="server" Text=""></asp:Label>
        <br /><br />
    </div>
    <asp:Button ID="btnAddUser" runat="server" Text="Create User" CssClass="button"
                                                                  onmouseover="this.className='buttonhover'"
                                                                  onmouseout="this.className='button'"
                                                                  onmousedown="this.className='button'"
                                                                  onmouseup="this.className='buttonhover'"
                                                                  onclick="btnAddUser_Click"/>
    </div>
</asp:Content>
