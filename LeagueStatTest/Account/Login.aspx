<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LeagueStatTracker.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://code.jquery.com/jquery-latest.js " type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <div>
        <asp:Login ID="LoginControl" runat="server">
            <LayoutTemplate>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Username" ClientIDMode="Static" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="LoginButton">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Password" ClientIDMode="Static" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="LoginButton">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <input type="button" clientidmode="Static" id="LoginButton" runat="server" validationGroup="LoginButton" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:Login>
            <div id="LoginStatus"/>
            </div>
    </form>
</body>
</html>
<script>
    $(document).ready(function () {
        $("#LoginButton").click(function () {
            $("#LoginStatus").html("Logging in...");
            var data = { "userid": $("#Username").val(), 
                "password": $("#Username").val(), 
                "rememberme": $("#RememberMe").prop("checked")
            };
            alert($("#Username").val());
            alert($("#Password").val());
            $.ajax({
                url: "/Account/ValidateUser",
                type: "POST",
                data: JSON.stringify(data),
                dataType: "json",
                contentType: "application/json",
                success: function (status) {
                    $("#LoginStatus").html(status.Message);
                    if (status.Success)
                    {
                        window.location.href = status.TargetURL;
                    }
                },
                error: function () {
                    $("#LoginStatus").html("Error while authenticating user credentials!");
                }
            });
        });
    });
</script>
