<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LeagueStatTracker.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Sample Registration Page</title>
    <style type="text/css">
        .style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    
        <div>
            
            <form id="RegisterForm" runat="server">
            <table class="style1">
                <tr>
                    <td>Username:</td>
                    <td>
                        <asp:TextBox ID="UserField" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator runat="server" ControlToValidate="UserField" ErrorMessage= "*Username must be between 6-14 characters and can only contain letters and digits." ForeColor="Red" ValidationExpression= "[A-Za-z][A-Za-z0-9]{5,14}" ValidationGroup="RegisterGroup"  />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="UserField" ValidationGroup="RegisterGroup" ErrorMessage="*Required field." ForeColor="Red" />
                    </td>

                </tr>
                <tr>
                    <td>Summoner Name:</td>
                    <td>
                        <asp:TextBox ID="SummonerNameField" runat="server" CausesValidation="true"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="SummonerNameField" ErrorMessage="*Required field." ForeColor="Red" Display="Dynamic" ValidationGroup="RegisterGroup" />
                        <asp:CustomValidator ID="SummonerValidator"
                            ControlToValidate="SummonerNameField"
                            ErrorMessage="*Invalid summoner name"
                            ForeColor="red"
                            OnServerValidate="SummonerValidation"
                            ValidationGroup="RegisterGroup"
                            runat="server"
                             />
                    </td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td>

                        <asp:TextBox ID="PasswordField" runat="server"
                            TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="PasswordField" ErrorMessage="*Required field." ForeColor="Red" Display="Dynamic" ValidationGroup="RegisterGroup" />
                        <asp:RegularExpressionValidator runat="server" ControlToValidate="PasswordField" ErrorMessage= "*Password must be between 8-30 characters and have at least one digit." ForeColor="Red" ValidationExpression= "^(?=.*\d)(?=.*[A-Za-z]).{8,30}$" ValidationGroup="RegisterGroup"  />
                    </td>
                </tr>
                <tr>
                    <td>Re Password:</td>
                    <td>
                        <asp:TextBox ID="ConfirmPasswordField" runat="server" CausesValidation="true"
                            TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPasswordField" ErrorMessage="*Required field." ForeColor="Red" Display="Dynamic" ValidationGroup="RegisterGroup" />
                        <asp:CompareValidator ID="CompareValidator" runat="server"
                            ControlToValidate="ConfirmPasswordField"
                            CssClass="ValidationError"
                            ControlToCompare="PasswordField"
                            ValidationGroup="RegisterGroup"
                            ForeColor="Red"
                            ErrorMessage="*Passwords must match"
                            ToolTip="Password must be the same" />
                    </td>
                </tr>
                <tr>
                    <td>Server:</td>
                    <td>
                        <asp:DropDownList ID="ServerSelect" runat="server">
                            <asp:ListItem Value="na" Text="NA" Selected="True" />
                            <asp:ListItem Value="euw" Text="EUW" />
                            <asp:ListItem Value="eune" Text="EUNE" />
                            <asp:ListItem Value="br" Text="BR" />
                            <asp:ListItem Value="lan" Text="LAN" />
                            <asp:ListItem Value="las" Text="LAS" />
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
                <asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="registerClick" CausesValidation="true" ValidationGroup="RegisterGroup" />
</form>
        </div>
        
    
</body>
</html>
